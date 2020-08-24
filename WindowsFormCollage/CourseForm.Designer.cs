namespace WindowsFormCollage {
    partial class CourseForm {
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.headTeachIdTxt = new System.Windows.Forms.TextBox();
            this.creditTypeTxt = new System.Windows.Forms.TextBox();
            this.creditTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(411, 145);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 42;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Head of Teach(ID) :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "CreditType(نوع واحد) :";
            // 
            // headTeachIdTxt
            // 
            this.headTeachIdTxt.Location = new System.Drawing.Point(207, 147);
            this.headTeachIdTxt.Name = "headTeachIdTxt";
            this.headTeachIdTxt.Size = new System.Drawing.Size(162, 20);
            this.headTeachIdTxt.TabIndex = 39;
            // 
            // creditTypeTxt
            // 
            this.creditTypeTxt.Location = new System.Drawing.Point(207, 121);
            this.creditTypeTxt.Name = "creditTypeTxt";
            this.creditTypeTxt.Size = new System.Drawing.Size(162, 20);
            this.creditTypeTxt.TabIndex = 38;
            // 
            // creditTxt
            // 
            this.creditTxt.Location = new System.Drawing.Point(207, 95);
            this.creditTxt.Name = "creditTxt";
            this.creditTxt.Size = new System.Drawing.Size(162, 20);
            this.creditTxt.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Credit(تعداد واحد) :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Title :";
            // 
            // titleTxt
            // 
            this.titleTxt.Location = new System.Drawing.Point(207, 69);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(162, 20);
            this.titleTxt.TabIndex = 34;
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.headTeachIdTxt);
            this.Controls.Add(this.creditTypeTxt);
            this.Controls.Add(this.creditTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.titleTxt);
            this.Name = "CourseForm";
            this.Text = "CourseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox headTeachIdTxt;
        private System.Windows.Forms.TextBox creditTypeTxt;
        private System.Windows.Forms.TextBox creditTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox titleTxt;
    }
}