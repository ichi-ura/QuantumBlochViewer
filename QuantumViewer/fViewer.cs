using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuantumViewer
{
    public partial class fViewer : Form
    {
        public fViewer()
        {
            InitializeComponent();

            this.Load += fViewer_Load;

            //---

            glMain.MouseWheel += glMain_MouseWheel;

            //---

            ReadXml();

            numericUpDownA00Re.Value = (decimal)InfXml.a00Re;
            numericUpDownA00Im.Value = (decimal)InfXml.a00Im;
            numericUpDownA01Re.Value = (decimal)InfXml.a01Re;
            numericUpDownA01Im.Value = (decimal)InfXml.a01Im;

            //---

            timer.Interval = 20;
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private void fViewer_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            glMain.MakeCurrent();
            glMain.MouseWheel += glMain_MouseWheel;
        }

        private void fViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteXml();
        }

        bool isAnimating = false;

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (!isAnimating) return;

            if (checkBoxSU2.Checked)
            {
                RotateSU2(0.02, new Vector3(0, 0, 1)); // SU(2)
            }
            else
            {
                RotateBloch();  // SO(3)
            }

            // 表示更新
            UodateDisp(checkBoxSU2.Checked);

            glMain.Invalidate();
        }

        /// <summary>
        /// ロドリゲス回転 ... SO(3)
        /// </summary>
        private void RotateBloch()
        {
            // 回転軸（例：Z軸）
            Vector3d axis = new Vector3d(0, 0, 1);   // 必要なら変更

            // 回転角度（度 → ラジアン）
            double angleDeg = 1.0;                  // 1°ずつ回す例
            double angle = angleDeg * Math.PI / 180.0;

            // ロドリゲスの回転公式
            Vector3d v = bloch;                     // 現在の向き
            Vector3d k = axis.Normalized();         // 回転軸の単位ベクトル

            Vector3d term1 = v * Math.Cos(angle);
            Vector3d term2 = Vector3d.Cross(k, v) * Math.Sin(angle);
            Vector3d term3 = k * (Vector3d.Dot(k, v)) * (1 - Math.Cos(angle));

            bloch = term1 + term2 + term3;          // 新しい向き
        }

        /// <summary>
        /// パウリ回転 ... SU(2)
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="axis"></param>
        private void RotateSU2(double theta, Vector3 axis)
        {
            axis = Vector3.Normalize(axis);

            double nx = axis.X;
            double ny = axis.Y;
            double nz = axis.Z;

            double ct = Math.Cos(theta / 2.0);
            double st = Math.Sin(theta / 2.0);

            // SU(2) 行列要素（実部・虚部）
            double u00_re = ct;
            double u00_im = -nz * st;

            double u01_re = -ny * st;
            double u01_im = -nx * st;

            double u10_re = ny * st;
            double u10_im = -nx * st;

            double u11_re = ct;
            double u11_im = nz * st;

            // α = a + bi
            double a = InfXml.a00Re;
            double b = InfXml.a00Im;

            // β = c + di
            double c = InfXml.a01Re;
            double d = InfXml.a01Im;

            // α' = U00*α + U01*β
            double alpha_re = u00_re * a - u00_im * b + u01_re * c - u01_im * d;
            double alpha_im = u00_re * b + u00_im * a + u01_re * d + u01_im * c;

            // β' = U10*α + U11*β
            double beta_re = u10_re * a - u10_im * b + u11_re * c - u11_im * d;
            double beta_im = u10_re * b + u10_im * a + u11_re * d + u11_im * c;

            // 内部状態に戻す
            InfXml.a00Re = alpha_re;
            InfXml.a00Im = alpha_im;
            InfXml.a01Re = beta_re;
            InfXml.a01Im = beta_im;

            // 正規化
            NormalizeState();

            UpdateBlochVector();
        }

        private void UodateDisp(bool bSU2)
        {
            // Bloch
            labelV3.Text = bloch.X.ToString("F4") + ", " +
                           bloch.Y.ToString("F4") + ", " +
                           bloch.Z.ToString("F4");

            // Argを計算（正規化後の状態）
            if (bSU2)
            {   // SU(2)
                double aArg = Math.Atan2(InfXml.a00Im, InfXml.a00Re) * 180.0 / Math.PI;
                double bArg = Math.Atan2(InfXml.a01Im, InfXml.a01Re) * 180.0 / Math.PI;

                this.aArg.Text = aArg.ToString("F2");
                this.bArg.Text = bArg.ToString("F2");
            }

            // 量子状態
            labelA00Re.Text = InfXml.a00Re.ToString("F4");
            labelA00Im.Text = InfXml.a00Im.ToString("F4");
            labelA01Re.Text = InfXml.a01Re.ToString("F4");
            labelA01Im.Text = InfXml.a01Im.ToString("F4");
        }

        private void UpdateBlochVector()
        {
            // α = a + bi
            double a = InfXml.a00Re;
            double b = InfXml.a00Im;

            // β = c + di
            double c = InfXml.a01Re;
            double d = InfXml.a01Im;

            // Bloch ベクトルの計算
            // x = 2 Re(α* β)
            // y = 2 Im(α* β)
            // z = |α|^2 - |β|^2

            // α*β の実部：a*c + b*d
            double x = 2.0 * (a * c + b * d);

            // α*β の虚部：a*d - b*c
            double y = 2.0 * (a * d - b * c);

            // z 成分
            double z = (a * a + b * b) - (c * c + d * d);

            // Bloch ベクトルに反映
            bloch.X = x;
            bloch.Y = y;
            bloch.Z = z;
        }

        Vector3d bloch = new Vector3d(0, 0, 0);

        private void glMain_Paint(object sender, PaintEventArgs e)
        {
            glMain.MakeCurrent();

            GL.Viewport(0, 0, glMain.Width, glMain.Height);

            GL.ClearColor(0.35f, 0.35f, 0.35f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // --- Projection ---
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            float fovy = (float)MathHelper.DegreesToRadians(45.0f);
            float aspect = glMain.Width / (float)glMain.Height;
            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView(fovy, aspect, 0.1f, 100f);
            InfXml.projection = proj;
            GL.LoadMatrix(ref proj);

            // --- ModelView ---
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(0.0f, 0.0f, -5.0f);
            GL.Rotate(InfXml.rot_v, 1.0f, 0.0f, 0.0f);
            GL.Rotate(InfXml.rot_h, 0.0f, 1.0f, 0.0f);
            GL.Scale(InfXml.mag, InfXml.mag, InfXml.mag);

            GL.GetFloat(GetPName.ModelviewMatrix, out InfXml.model);

            float radius = 1.0f;

            // --- 球本体 ---
            int slices = 40;
            int stacks = 40;

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Color4(0.9216f, 0.9686, 1, 0.6f);            // ← α=0.6 の半透明球

            for (int i = 0; i < stacks; i++)
            {
                float lat0 = (float)(Math.PI * (-0.5 + (double)i / stacks));
                float z0 = (float)Math.Sin(lat0);
                float zr0 = (float)Math.Cos(lat0);

                float lat1 = (float)(Math.PI * (-0.5 + (double)(i + 1) / stacks));
                float z1 = (float)Math.Sin(lat1);
                float zr1 = (float)Math.Cos(lat1);

                GL.Begin(PrimitiveType.QuadStrip);

                for (int j = 0; j <= slices; j++)
                {
                    float lng = (float)(2.0 * Math.PI * j / slices);
                    float x = (float)Math.Cos(lng);
                    float y = (float)Math.Sin(lng);

                    GL.Vertex3(x * zr0 * radius, y * zr0 * radius, z0 * radius);
                    GL.Vertex3(x * zr1 * radius, y * zr1 * radius, z1 * radius);
                }

                GL.End();
            }

            GL.LineWidth(0.00001f); // 細くもならない
            drawLatitude();     // 緯度線
            drawLongitude();    // 経度線
            GL.LineWidth(1.0f);

            // --- XYZ 軸（細め・球貫通） ---
            float axisLen = radius * 1.2f;

            GL.LineWidth(2.0f);

            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-axisLen, 0, 0);
            GL.Vertex3(axisLen, 0, 0);
            GL.End();

            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, -axisLen, 0);
            GL.Vertex3(0, axisLen, 0);
            GL.End();

            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, -axisLen);
            GL.Vertex3(0, 0, axisLen);
            GL.End();

            //---
            // Blochベクトル（棒）の描画
            DrawBlochVector();

            //---

            glMain.SwapBuffers();

            // --- ここから GDI 描画 ---
            Graphics g = e.Graphics;

            DrawText(g, "+X", Project(pX), Color.OrangeRed, 14f);
            DrawText(g, "+Y", Project(pY), Color.LightGreen, 14f);
            DrawText(g, "+Z", Project(pZ), Color.Blue, 14f);

            DrawText(g, "-X", Project(nX), Color.OrangeRed, 12f);
            DrawText(g, "-Y", Project(nY), Color.LightGreen, 12f);
            DrawText(g, "-Z", Project(nZ), Color.Blue, 12f);
        }

        //--- Paint sub

        private void DrawBlochVector()
        {
            GL.Color3(Color.DarkGreen);

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);                    // 原点
            GL.Vertex3(bloch.X, bloch.Y, bloch.Z);  // 向き
            GL.End();

            GL.Color3(Color.Red);

            // 先端の団子（小球）
            GL.PointSize(6f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(bloch.X, bloch.Y, bloch.Z);
            GL.End();
        }

        /// <summary>
        /// 緯度線の描画
        /// </summary>
        void drawLatitude()
        {
            // ---- 状態を保存 ----
            GL.PushAttrib(AttribMask.AllAttribBits);
            GL.PushMatrix();

            GL.Disable(EnableCap.Lighting);
            GL.Color3(1, 1, 1); // なぜか黒にしかならない

            int slices = 24;
            double r = 1.001;

            for (int i = 1; i < slices - 1; i++)
            {
                double phi = Math.PI * i / slices;
                double z = r * Math.Cos(phi);
                double rr = r * Math.Sin(phi);

                GL.Begin(PrimitiveType.LineLoop);
                for (int j = 0; j < slices; j++)
                {
                    double theta = 2.0 * Math.PI * j / slices;
                    double x = rr * Math.Cos(theta);
                    double y = rr * Math.Sin(theta);
                    GL.Vertex3(x, y, z);
                }
                GL.End();
            }

            // ---- 状態を元に戻す ----
            GL.PopMatrix();
            GL.PopAttrib();
        }

        /// <summary>
        /// 経度線の描画
        /// </summary>
        void drawLongitude()
        {
            // ---- 状態を保存 ----
            GL.PushAttrib(AttribMask.AllAttribBits);
            GL.PushMatrix();

            GL.Disable(EnableCap.Lighting);
            GL.Color3(1, 1, 1);  // なぜか黒にしかならない

            int slices = 24;
            double r = 1.001;

            for (int i = 0; i < slices; i++)
            {
                double theta = 2.0 * Math.PI * i / slices;

                GL.Begin(PrimitiveType.LineLoop);
                for (int j = 0; j < slices; j++)
                {
                    double phi = Math.PI * j / (slices - 1);

                    double x = r * Math.Sin(phi) * Math.Cos(theta);
                    double y = r * Math.Sin(phi) * Math.Sin(theta);
                    double z = r * Math.Cos(phi);

                    GL.Vertex3(x, y, z);
                }
                GL.End();
            }

            // ---- 状態を元に戻す ----
            GL.PopMatrix();
            GL.PopAttrib();
        }

        public void DrawText(Graphics g, string text, PointF pt, Color color, float size = 12f)
        {
            using (Font font = new Font("Consolas", size, FontStyle.Regular))
            using (SolidBrush br = new SolidBrush(color))
            {
                g.DrawString(text, font, br, pt);
            }
        }

        //---

        private void glMain_Resize(object sender, EventArgs e)
        {

        }

        private Point _last;

        private void glMain_MouseDown(object sender, MouseEventArgs e)
        {
            _last = e.Location;
        }

        private void glMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.X - _last.X;
                int dy = e.Y - _last.Y;

                // ★ 回転量を累積
                InfXml.rot_h += dx;
                InfXml.rot_v += dy;

                _last = e.Location;

                glMain.Invalidate();
            }
        }

        private void glMain_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void glMain_MouseWheel(object sender, MouseEventArgs e)
        {
            InfXml.mag += e.Delta * 0.001f; // 拡大率の更新

            glMain.Invalidate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            // UI の値を取得
            double a00ReTmp = (double)numericUpDownA00Re.Value;
            double a00ImTmp = (double)numericUpDownA00Im.Value;
            double a01ReTmp = (double)numericUpDownA01Re.Value;
            double a01ImTmp = (double)numericUpDownA01Im.Value;

            // 妥当性チェック（例：ノルムが0でないか）
            double normTmp = Math.Sqrt(
                a00ReTmp * a00ReTmp + a00ImTmp * a00ImTmp +
                a01ReTmp * a01ReTmp + a01ImTmp * a01ImTmp);

            if (normTmp == 0)
            {
                MessageBox.Show("量子状態のノルムが 0 です。入力を確認してください。");
                return;
            }

            // 内部状態にコピー
            InfXml.a00Re = a00ReTmp;
            InfXml.a00Im = a00ImTmp;
            InfXml.a01Re = a01ReTmp;
            InfXml.a01Im = a01ImTmp;

            // 正規化
            NormalizeState();

            // 正規化後の内部状態を UI に戻す）
            numericUpDownA00Re.Value = (decimal)InfXml.a00Re;
            numericUpDownA00Im.Value = (decimal)InfXml.a00Im;
            numericUpDownA01Re.Value = (decimal)InfXml.a01Re;
            numericUpDownA01Im.Value = (decimal)InfXml.a01Im;

            //---

            // Blochベクトル計算
            double ar = InfXml.a00Re;
            double ai = InfXml.a00Im;
            double br = InfXml.a01Re;
            double bi = InfXml.a01Im;

            // α*β の実部・虚部
            double real_ab = ar * br + ai * bi;     // Re(α*β)
            double imag_ab = ar * bi - ai * br;     // Im(α*β)

            // Bloch球XYZ
            double X = 2.0 * real_ab;
            double Y = 2.0 * imag_ab;
            double Z = (ar * ar + ai * ai) - (br * br + bi * bi);

            // 正規化（安全）
            double r = Math.Sqrt(X * X + Y * Y + Z * Z);
            if (r > 0)
            {
                X /= r;
                Y /= r;
                Z /= r;
            }

            // 描画用ベクトルに流す
            bloch.X = X;
            bloch.Y = Y;
            bloch.Z = Z;

            // 表示更新（Bloch, Arg, 量子状態）
            UodateDisp(checkBoxSU2.Checked);

            glMain.Invalidate();
        }

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            isAnimating = !isAnimating;

            btnAnimate.Text = isAnimating ? "アニメ停止" : "アニメ開始";
            btnUpdate.Visible = !isAnimating;

            numericUpDownA00Re.ReadOnly = isAnimating;
            numericUpDownA00Im.ReadOnly = isAnimating;
            numericUpDownA01Re.ReadOnly = isAnimating;
            numericUpDownA01Im.ReadOnly = isAnimating;

            if (isAnimating)
            {   // アニメ開始 → 内部状態を正規化してから動かす
                NormalizeState();
            }
            else
            {   // アニメ停止 → 内部状態を UI に戻す
                numericUpDownA00Re.Value = (decimal)InfXml.a00Re;
                numericUpDownA00Im.Value = (decimal)InfXml.a00Im;
                numericUpDownA01Re.Value = (decimal)InfXml.a01Re;
                numericUpDownA01Im.Value = (decimal)InfXml.a01Im;
            }
        }

        private void NormalizeState()
        {
            double norm = Math.Sqrt(
                InfXml.a00Re * InfXml.a00Re + InfXml.a00Im * InfXml.a00Im +
                InfXml.a01Re * InfXml.a01Re + InfXml.a01Im * InfXml.a01Im);

            if (norm == 0) return;

            InfXml.a00Re /= norm;
            InfXml.a00Im /= norm;
            InfXml.a01Re /= norm;
            InfXml.a01Im /= norm;
        }

        private void checkBoxSU2_CheckedChanged(object sender, EventArgs e)
        {
            aArgG.Visible = aArg.Visible = checkBoxSU2.Checked;
            bArgG.Visible = bArg.Visible = checkBoxSU2.Checked;
        }

        #region Sphere Axis Name =======================================================================================

        Vector3 pX = new Vector3(1.2f, 0f, 0f);     // +X
        Vector3 pY = new Vector3(0f, 1.2f, 0f);     // +Y
        Vector3 pZ = new Vector3(0f, 0f, 1.2f);     // +Z

        Vector3 nX = new Vector3(-1.2f, 0f, 0f);    // -X
        Vector3 nY = new Vector3(0f, -1.2f, 0f);    // -Y
        Vector3 nZ = new Vector3(0f, 0f, -1.2f);    // -Z

        public PointF Project(Vector3 obj)
        {
            Matrix4 mv = InfXml.model;
            Matrix4 pr = InfXml.projection;

            int w = glMain.Width;
            int h = glMain.Height;

            Vector4 v = new Vector4(obj, 1f);

            v = Vector4.Transform(v, mv);
            v = Vector4.Transform(v, pr);

            v /= v.W;

            float x = (1 + v.X) * w / 2;
            float y = (1 - v.Y) * h / 2;

            return new PointF(x, y);
        }

        #endregion Sphere Axis Name ====================================================================================

        #region InfXml ==================================================================================================

        /// <summary>
        /// class "AP .xml contents"
        /// </summary>
        public infXml InfXml = new infXml();

        /// <summary>
        /// Write ?.Xml
        /// </summary>
        public void WriteXml()
        {
            string exeName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            string pathFname = Directory.GetCurrentDirectory() + @"\" + exeName + ".xml";

            File.Delete(pathFname);

            XmlSerializer serializer = new XmlSerializer(typeof(infXml));

            using (FileStream fs = new FileStream(pathFname, FileMode.Create))
            {
                serializer.Serialize(fs, (object)InfXml);
            }
        }

        /// <summary>
        /// Read ?.Xml
        /// </summary>
        /// <returns></returns>
        public bool ReadXml()
        {
            string exeName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            string pathFname = Directory.GetCurrentDirectory() + @"\" + exeName + ".xml";

            if (!File.Exists(pathFname)) return false;

            XmlSerializer serializer = new XmlSerializer(typeof(infXml));

            using (FileStream fs = new FileStream(pathFname, FileMode.Open))
            {
                InfXml = (infXml)serializer.Deserialize(fs);
            }

            return true;
        }

        /// <summary>
        /// AP .xml contents
        /// </summary>
        public class infXml
        {
            /// <summary>
            /// Sphere 拡大・回転
            /// </summary>
            public float mag = 2.0f;
            public int rot_h = 0;
            public int rot_v = 0;

            /// <summary>
            /// MODELVIEW 行列 ... for Sphere GLControl
            /// </summary>
            public Matrix4 model = new Matrix4();

            /// <summary>
            /// PROJECTION 行列 ... for Sphere GLControl
            /// </summary>
            public Matrix4 projection = new Matrix4();

            public double a00Re = 1.0;
            public double a00Im = 0.0;
            public double a01Re = 0.0;
            public double a01Im = 0.0;
        }

        #endregion InfXml ===============================================================================================
    }
}
