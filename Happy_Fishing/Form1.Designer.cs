namespace Happy_Fishing
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_start_fishing = new System.Windows.Forms.Button();
            this.lbl_repeats = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ckbx_giant_float = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start_fishing
            // 
            this.btn_start_fishing.Font = new System.Drawing.Font("Chiller", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start_fishing.Location = new System.Drawing.Point(303, 212);
            this.btn_start_fishing.Name = "btn_start_fishing";
            this.btn_start_fishing.Size = new System.Drawing.Size(100, 30);
            this.btn_start_fishing.TabIndex = 0;
            this.btn_start_fishing.Text = "START";
            this.btn_start_fishing.UseVisualStyleBackColor = true;
            this.btn_start_fishing.Click += new System.EventHandler(this.btn_start_fishing_Click);
            // 
            // lbl_repeats
            // 
            this.lbl_repeats.Font = new System.Drawing.Font("Chiller", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_repeats.Location = new System.Drawing.Point(12, 9);
            this.lbl_repeats.Name = "lbl_repeats";
            this.lbl_repeats.Size = new System.Drawing.Size(100, 30);
            this.lbl_repeats.TabIndex = 1;
            this.lbl_repeats.Text = "REPEATS";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Chiller", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(12, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 32);
            this.numericUpDown1.TabIndex = 2;
            // 
            // ckbx_giant_float
            // 
            this.ckbx_giant_float.Font = new System.Drawing.Font("Chiller", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbx_giant_float.Location = new System.Drawing.Point(12, 212);
            this.ckbx_giant_float.Name = "ckbx_giant_float";
            this.ckbx_giant_float.Size = new System.Drawing.Size(150, 30);
            this.ckbx_giant_float.TabIndex = 3;
            this.ckbx_giant_float.Text = "GIANT FLOAT";
            this.ckbx_giant_float.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(415, 254);
            this.Controls.Add(this.ckbx_giant_float);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lbl_repeats);
            this.Controls.Add(this.btn_start_fishing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(431, 292);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(431, 292);
            this.Name = "Form1";
            this.Text = "Happy Fishing";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start_fishing;
        private System.Windows.Forms.Label lbl_repeats;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox ckbx_giant_float;
    }
}

