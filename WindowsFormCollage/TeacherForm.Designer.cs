namespace WindowsFormCollage {
    partial class TeacherForm {
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
            this.label6 = new System.Windows.Forms.Label();
            this.degreeTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.phoneTxt = new System.Windows.Forms.TextBox();
            this.nationalCodeTxt = new System.Windows.Forms.TextBox();
            this.fatherNameTxt = new System.Windows.Forms.TextBox();
            this.familyTxt = new System.Windows.Forms.TextBox();
            this.familyLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(519, 214);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 61;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Degree :";
            // 
            // degreeTxt
            // 
            this.degreeTxt.Location = new System.Drawing.Point(519, 63);
            this.degreeTxt.Name = "degreeTxt";
            this.degreeTxt.Size = new System.Drawing.Size(162, 20);
            this.degreeTxt.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Address :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Phone Number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "National Code :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Father Name :";
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(156, 195);
            this.addressTxt.Multiline = true;
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(162, 42);
            this.addressTxt.TabIndex = 46;
            // 
            // phoneTxt
            // 
            this.phoneTxt.Location = new System.Drawing.Point(156, 168);
            this.phoneTxt.Name = "phoneTxt";
            this.phoneTxt.Size = new System.Drawing.Size(162, 20);
            this.phoneTxt.TabIndex = 45;
            // 
            // nationalCodeTxt
            // 
            this.nationalCodeTxt.Location = new System.Drawing.Point(156, 141);
            this.nationalCodeTxt.Name = "nationalCodeTxt";
            this.nationalCodeTxt.Size = new System.Drawing.Size(162, 20);
            this.nationalCodeTxt.TabIndex = 44;
            // 
            // fatherNameTxt
            // 
            this.fatherNameTxt.Location = new System.Drawing.Point(156, 115);
            this.fatherNameTxt.Name = "fatherNameTxt";
            this.fatherNameTxt.Size = new System.Drawing.Size(162, 20);
            this.fatherNameTxt.TabIndex = 43;
            // 
            // familyTxt
            // 
            this.familyTxt.Location = new System.Drawing.Point(156, 89);
            this.familyTxt.Name = "familyTxt";
            this.familyTxt.Size = new System.Drawing.Size(162, 20);
            this.familyTxt.TabIndex = 42;
            // 
            // familyLbl
            // 
            this.familyLbl.AutoSize = true;
            this.familyLbl.Location = new System.Drawing.Point(108, 92);
            this.familyLbl.Name = "familyLbl";
            this.familyLbl.Size = new System.Drawing.Size(42, 13);
            this.familyLbl.TabIndex = 41;
            this.familyLbl.Text = "Family :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Name :";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(156, 63);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(162, 20);
            this.nameTxt.TabIndex = 39;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.degreeTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.phoneTxt);
            this.Controls.Add(this.nationalCodeTxt);
            this.Controls.Add(this.fatherNameTxt);
            this.Controls.Add(this.familyTxt);
            this.Controls.Add(this.familyLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTxt);
            this.Name = "TeacherForm";
            this.Text = "TeacherForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox degreeTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.TextBox phoneTxt;
        private System.Windows.Forms.TextBox nationalCodeTxt;
        private System.Windows.Forms.TextBox fatherNameTxt;
        private System.Windows.Forms.TextBox familyTxt;
        private System.Windows.Forms.Label familyLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTxt;
    }
}