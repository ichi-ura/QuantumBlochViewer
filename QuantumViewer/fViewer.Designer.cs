namespace QuantumViewer
{
    partial class fViewer
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glMain = new OpenTK.GLControl();
            this.numericUpDownA00Re = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA00Im = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA01Re = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA01Im = new System.Windows.Forms.NumericUpDown();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnAnimate = new System.Windows.Forms.Button();
            this.checkBoxSU2 = new System.Windows.Forms.CheckBox();
            this.aArgG = new System.Windows.Forms.Label();
            this.aArg = new System.Windows.Forms.Label();
            this.bArg = new System.Windows.Forms.Label();
            this.bArgG = new System.Windows.Forms.Label();
            this.labelV3 = new System.Windows.Forms.Label();
            this.panelOp = new System.Windows.Forms.Panel();
            this.labelβim = new System.Windows.Forms.Label();
            this.labelβre = new System.Windows.Forms.Label();
            this.labelAim = new System.Windows.Forms.Label();
            this.labelAre = new System.Windows.Forms.Label();
            this.panelDsp = new System.Windows.Forms.Panel();
            this.labelA01Im = new System.Windows.Forms.Label();
            this.labelA01Re = new System.Windows.Forms.Label();
            this.labelA00Im = new System.Windows.Forms.Label();
            this.labelA00Re = new System.Windows.Forms.Label();
            this.labelβim2 = new System.Windows.Forms.Label();
            this.labelβre2 = new System.Windows.Forms.Label();
            this.labelAim2 = new System.Windows.Forms.Label();
            this.labelAre2 = new System.Windows.Forms.Label();
            this.labelVector = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA00Re)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA00Im)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA01Re)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA01Im)).BeginInit();
            this.panelOp.SuspendLayout();
            this.panelDsp.SuspendLayout();
            this.SuspendLayout();
            // 
            // glMain
            // 
            this.glMain.BackColor = System.Drawing.Color.Black;
            this.glMain.Location = new System.Drawing.Point(183, 12);
            this.glMain.Name = "glMain";
            this.glMain.Size = new System.Drawing.Size(600, 600);
            this.glMain.TabIndex = 0;
            this.glMain.VSync = false;
            this.glMain.Paint += new System.Windows.Forms.PaintEventHandler(this.glMain_Paint);
            this.glMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glMain_MouseDown);
            this.glMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glMain_MouseMove);
            this.glMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glMain_MouseUp);
            this.glMain.Resize += new System.EventHandler(this.glMain_Resize);
            // 
            // numericUpDownA00Re
            // 
            this.numericUpDownA00Re.DecimalPlaces = 2;
            this.numericUpDownA00Re.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownA00Re.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownA00Re.InterceptArrowKeys = false;
            this.numericUpDownA00Re.Location = new System.Drawing.Point(55, 24);
            this.numericUpDownA00Re.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownA00Re.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.numericUpDownA00Re.Name = "numericUpDownA00Re";
            this.numericUpDownA00Re.Size = new System.Drawing.Size(93, 26);
            this.numericUpDownA00Re.TabIndex = 1;
            this.numericUpDownA00Re.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownA00Im
            // 
            this.numericUpDownA00Im.DecimalPlaces = 2;
            this.numericUpDownA00Im.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownA00Im.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownA00Im.InterceptArrowKeys = false;
            this.numericUpDownA00Im.Location = new System.Drawing.Point(55, 56);
            this.numericUpDownA00Im.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownA00Im.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.numericUpDownA00Im.Name = "numericUpDownA00Im";
            this.numericUpDownA00Im.Size = new System.Drawing.Size(93, 26);
            this.numericUpDownA00Im.TabIndex = 2;
            this.numericUpDownA00Im.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownA01Re
            // 
            this.numericUpDownA01Re.DecimalPlaces = 2;
            this.numericUpDownA01Re.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownA01Re.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownA01Re.InterceptArrowKeys = false;
            this.numericUpDownA01Re.Location = new System.Drawing.Point(55, 103);
            this.numericUpDownA01Re.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownA01Re.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.numericUpDownA01Re.Name = "numericUpDownA01Re";
            this.numericUpDownA01Re.Size = new System.Drawing.Size(93, 26);
            this.numericUpDownA01Re.TabIndex = 3;
            this.numericUpDownA01Re.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownA01Im
            // 
            this.numericUpDownA01Im.DecimalPlaces = 2;
            this.numericUpDownA01Im.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownA01Im.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownA01Im.InterceptArrowKeys = false;
            this.numericUpDownA01Im.Location = new System.Drawing.Point(54, 135);
            this.numericUpDownA01Im.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownA01Im.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.numericUpDownA01Im.Name = "numericUpDownA01Im";
            this.numericUpDownA01Im.Size = new System.Drawing.Size(93, 26);
            this.numericUpDownA01Im.TabIndex = 4;
            this.numericUpDownA01Im.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(10, 176);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 39);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // timer
            // 
            this.timer.Interval = 20;
            // 
            // btnAnimate
            // 
            this.btnAnimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimate.Location = new System.Drawing.Point(10, 512);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(137, 38);
            this.btnAnimate.TabIndex = 6;
            this.btnAnimate.Text = "アニメ開始";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // checkBoxSU2
            // 
            this.checkBoxSU2.AutoSize = true;
            this.checkBoxSU2.Checked = true;
            this.checkBoxSU2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSU2.Location = new System.Drawing.Point(10, 568);
            this.checkBoxSU2.Name = "checkBoxSU2";
            this.checkBoxSU2.Size = new System.Drawing.Size(137, 17);
            this.checkBoxSU2.TabIndex = 7;
            this.checkBoxSU2.Text = "On : SU(2) / Off : SO(3)";
            this.checkBoxSU2.UseVisualStyleBackColor = true;
            this.checkBoxSU2.CheckedChanged += new System.EventHandler(this.checkBoxSU2_CheckedChanged);
            // 
            // aArgG
            // 
            this.aArgG.AutoSize = true;
            this.aArgG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aArgG.Location = new System.Drawing.Point(232, 5);
            this.aArgG.Name = "aArgG";
            this.aArgG.Size = new System.Drawing.Size(51, 20);
            this.aArgG.TabIndex = 9;
            this.aArgG.Text = "α Arg.";
            // 
            // aArg
            // 
            this.aArg.AutoSize = true;
            this.aArg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aArg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aArg.Location = new System.Drawing.Point(289, 5);
            this.aArg.Name = "aArg";
            this.aArg.Size = new System.Drawing.Size(60, 22);
            this.aArg.TabIndex = 10;
            this.aArg.Text = "999.99";
            // 
            // bArg
            // 
            this.bArg.AutoSize = true;
            this.bArg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bArg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bArg.Location = new System.Drawing.Point(289, 29);
            this.bArg.Name = "bArg";
            this.bArg.Size = new System.Drawing.Size(60, 22);
            this.bArg.TabIndex = 12;
            this.bArg.Text = "999.99";
            // 
            // bArgG
            // 
            this.bArgG.AutoSize = true;
            this.bArgG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bArgG.Location = new System.Drawing.Point(232, 29);
            this.bArgG.Name = "bArgG";
            this.bArgG.Size = new System.Drawing.Size(51, 20);
            this.bArgG.TabIndex = 11;
            this.bArgG.Text = "β Arg.";
            // 
            // labelV3
            // 
            this.labelV3.AutoSize = true;
            this.labelV3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelV3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelV3.Location = new System.Drawing.Point(40, 20);
            this.labelV3.Name = "labelV3";
            this.labelV3.Size = new System.Drawing.Size(174, 22);
            this.labelV3.TabIndex = 13;
            this.labelV3.Text = "1.0000, 1.0000, 1.0000";
            // 
            // panelOp
            // 
            this.panelOp.Controls.Add(this.labelβim);
            this.panelOp.Controls.Add(this.labelβre);
            this.panelOp.Controls.Add(this.labelAim);
            this.panelOp.Controls.Add(this.labelAre);
            this.panelOp.Controls.Add(this.btnUpdate);
            this.panelOp.Controls.Add(this.numericUpDownA00Re);
            this.panelOp.Controls.Add(this.numericUpDownA00Im);
            this.panelOp.Controls.Add(this.numericUpDownA01Re);
            this.panelOp.Controls.Add(this.numericUpDownA01Im);
            this.panelOp.Controls.Add(this.btnAnimate);
            this.panelOp.Controls.Add(this.checkBoxSU2);
            this.panelOp.Location = new System.Drawing.Point(12, 12);
            this.panelOp.Name = "panelOp";
            this.panelOp.Size = new System.Drawing.Size(154, 600);
            this.panelOp.TabIndex = 15;
            // 
            // labelβim
            // 
            this.labelβim.AutoSize = true;
            this.labelβim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelβim.Location = new System.Drawing.Point(6, 137);
            this.labelβim.Name = "labelβim";
            this.labelβim.Size = new System.Drawing.Size(40, 20);
            this.labelβim.TabIndex = 11;
            this.labelβim.Text = "β Im";
            // 
            // labelβre
            // 
            this.labelβre.AutoSize = true;
            this.labelβre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelβre.Location = new System.Drawing.Point(6, 105);
            this.labelβre.Name = "labelβre";
            this.labelβre.Size = new System.Drawing.Size(43, 20);
            this.labelβre.TabIndex = 10;
            this.labelβre.Text = "β Re";
            // 
            // labelAim
            // 
            this.labelAim.AutoSize = true;
            this.labelAim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAim.Location = new System.Drawing.Point(6, 58);
            this.labelAim.Name = "labelAim";
            this.labelAim.Size = new System.Drawing.Size(40, 20);
            this.labelAim.TabIndex = 9;
            this.labelAim.Text = "α Im";
            // 
            // labelAre
            // 
            this.labelAre.AutoSize = true;
            this.labelAre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAre.Location = new System.Drawing.Point(6, 26);
            this.labelAre.Name = "labelAre";
            this.labelAre.Size = new System.Drawing.Size(43, 20);
            this.labelAre.TabIndex = 8;
            this.labelAre.Text = "α Re";
            // 
            // panelDsp
            // 
            this.panelDsp.Controls.Add(this.labelA01Im);
            this.panelDsp.Controls.Add(this.labelA01Re);
            this.panelDsp.Controls.Add(this.labelA00Im);
            this.panelDsp.Controls.Add(this.labelA00Re);
            this.panelDsp.Controls.Add(this.labelβim2);
            this.panelDsp.Controls.Add(this.labelβre2);
            this.panelDsp.Controls.Add(this.labelAim2);
            this.panelDsp.Controls.Add(this.labelAre2);
            this.panelDsp.Controls.Add(this.labelVector);
            this.panelDsp.Controls.Add(this.labelV3);
            this.panelDsp.Controls.Add(this.aArg);
            this.panelDsp.Controls.Add(this.bArg);
            this.panelDsp.Controls.Add(this.aArgG);
            this.panelDsp.Controls.Add(this.bArgG);
            this.panelDsp.Location = new System.Drawing.Point(13, 623);
            this.panelDsp.Name = "panelDsp";
            this.panelDsp.Size = new System.Drawing.Size(770, 56);
            this.panelDsp.TabIndex = 16;
            // 
            // labelA01Im
            // 
            this.labelA01Im.AutoSize = true;
            this.labelA01Im.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA01Im.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA01Im.Location = new System.Drawing.Point(613, 29);
            this.labelA01Im.Name = "labelA01Im";
            this.labelA01Im.Size = new System.Drawing.Size(42, 22);
            this.labelA01Im.TabIndex = 22;
            this.labelA01Im.Text = "9.99";
            // 
            // labelA01Re
            // 
            this.labelA01Re.AutoSize = true;
            this.labelA01Re.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA01Re.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA01Re.Location = new System.Drawing.Point(613, 5);
            this.labelA01Re.Name = "labelA01Re";
            this.labelA01Re.Size = new System.Drawing.Size(42, 22);
            this.labelA01Re.TabIndex = 21;
            this.labelA01Re.Text = "9.99";
            // 
            // labelA00Im
            // 
            this.labelA00Im.AutoSize = true;
            this.labelA00Im.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA00Im.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA00Im.Location = new System.Drawing.Point(474, 29);
            this.labelA00Im.Name = "labelA00Im";
            this.labelA00Im.Size = new System.Drawing.Size(42, 22);
            this.labelA00Im.TabIndex = 20;
            this.labelA00Im.Text = "9.99";
            // 
            // labelA00Re
            // 
            this.labelA00Re.AutoSize = true;
            this.labelA00Re.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA00Re.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA00Re.Location = new System.Drawing.Point(474, 5);
            this.labelA00Re.Name = "labelA00Re";
            this.labelA00Re.Size = new System.Drawing.Size(42, 22);
            this.labelA00Re.TabIndex = 19;
            this.labelA00Re.Text = "9.99";
            // 
            // labelβim2
            // 
            this.labelβim2.AutoSize = true;
            this.labelβim2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelβim2.Location = new System.Drawing.Point(564, 29);
            this.labelβim2.Name = "labelβim2";
            this.labelβim2.Size = new System.Drawing.Size(40, 20);
            this.labelβim2.TabIndex = 18;
            this.labelβim2.Text = "β Im";
            // 
            // labelβre2
            // 
            this.labelβre2.AutoSize = true;
            this.labelβre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelβre2.Location = new System.Drawing.Point(564, 5);
            this.labelβre2.Name = "labelβre2";
            this.labelβre2.Size = new System.Drawing.Size(43, 20);
            this.labelβre2.TabIndex = 17;
            this.labelβre2.Text = "β Re";
            // 
            // labelAim2
            // 
            this.labelAim2.AutoSize = true;
            this.labelAim2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAim2.Location = new System.Drawing.Point(428, 29);
            this.labelAim2.Name = "labelAim2";
            this.labelAim2.Size = new System.Drawing.Size(40, 20);
            this.labelAim2.TabIndex = 16;
            this.labelAim2.Text = "α Im";
            // 
            // labelAre2
            // 
            this.labelAre2.AutoSize = true;
            this.labelAre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAre2.Location = new System.Drawing.Point(425, 5);
            this.labelAre2.Name = "labelAre2";
            this.labelAre2.Size = new System.Drawing.Size(43, 20);
            this.labelAre2.TabIndex = 15;
            this.labelAre2.Text = "α Re";
            // 
            // labelVector
            // 
            this.labelVector.AutoSize = true;
            this.labelVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVector.Location = new System.Drawing.Point(5, 15);
            this.labelVector.Name = "labelVector";
            this.labelVector.Size = new System.Drawing.Size(29, 20);
            this.labelVector.TabIndex = 14;
            this.labelVector.Text = "V3";
            // 
            // fViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 689);
            this.Controls.Add(this.panelDsp);
            this.Controls.Add(this.panelOp);
            this.Controls.Add(this.glMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantum viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fViewer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA00Re)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA00Im)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA01Re)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA01Im)).EndInit();
            this.panelOp.ResumeLayout(false);
            this.panelOp.PerformLayout();
            this.panelDsp.ResumeLayout(false);
            this.panelDsp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glMain;
        private System.Windows.Forms.NumericUpDown numericUpDownA00Re;
        private System.Windows.Forms.NumericUpDown numericUpDownA00Im;
        private System.Windows.Forms.NumericUpDown numericUpDownA01Re;
        private System.Windows.Forms.NumericUpDown numericUpDownA01Im;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.CheckBox checkBoxSU2;
        private System.Windows.Forms.Label aArgG;
        private System.Windows.Forms.Label aArg;
        private System.Windows.Forms.Label bArg;
        private System.Windows.Forms.Label bArgG;
        private System.Windows.Forms.Label labelV3;
        private System.Windows.Forms.Panel panelOp;
        private System.Windows.Forms.Panel panelDsp;
        private System.Windows.Forms.Label labelAim;
        private System.Windows.Forms.Label labelAre;
        private System.Windows.Forms.Label labelβim;
        private System.Windows.Forms.Label labelβre;
        private System.Windows.Forms.Label labelVector;
        private System.Windows.Forms.Label labelA00Re;
        private System.Windows.Forms.Label labelβim2;
        private System.Windows.Forms.Label labelβre2;
        private System.Windows.Forms.Label labelAim2;
        private System.Windows.Forms.Label labelAre2;
        private System.Windows.Forms.Label labelA00Im;
        private System.Windows.Forms.Label labelA01Im;
        private System.Windows.Forms.Label labelA01Re;
    }
}

