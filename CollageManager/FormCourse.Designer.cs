namespace CollageManager {
    partial class FormCourse {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxHeadTeachId = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCredit = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.creditType = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.creditType);
            this.groupBox1.Controls.Add(this.txtCredit);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.boxHeadTeachId);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 171);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات";
            // 
            // boxHeadTeachId
            // 
            this.boxHeadTeachId.FormattingEnabled = true;
            this.boxHeadTeachId.Location = new System.Drawing.Point(132, 74);
            this.boxHeadTeachId.Name = "boxHeadTeachId";
            this.boxHeadTeachId.Size = new System.Drawing.Size(205, 21);
            this.boxHeadTeachId.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(343, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "مسول آموزش :";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(346, 142);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "افزودن";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(237, 35);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(138, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(381, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "عنوان :";
            // 
            // txtCredit
            // 
            this.txtCredit.Location = new System.Drawing.Point(6, 35);
            this.txtCredit.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtCredit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(130, 21);
            this.txtCredit.TabIndex = 26;
            this.txtCredit.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(142, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "واحد :";
            // 
            // creditType
            // 
            this.creditType.AutoSize = true;
            this.creditType.Checked = true;
            this.creditType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.creditType.Location = new System.Drawing.Point(6, 76);
            this.creditType.Name = "creditType";
            this.creditType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.creditType.Size = new System.Drawing.Size(65, 17);
            this.creditType.TabIndex = 27;
            this.creditType.Text = "تخصصی";
            this.creditType.UseVisualStyleBackColor = true;
            // 
            // FormCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 195);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCourse";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "FormCourse";
            this.Load += new System.EventHandler(this.FormCourse_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox boxHeadTeachId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtCredit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox creditType;
    }
}