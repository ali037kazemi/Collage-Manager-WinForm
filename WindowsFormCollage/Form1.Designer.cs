namespace WindowsFormCollage {
    partial class Form1 {
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
            this.addStudentBtn = new System.Windows.Forms.Button();
            this.addTeacherBtn = new System.Windows.Forms.Button();
            this.addHeadTeachBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.Location = new System.Drawing.Point(166, 122);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(75, 23);
            this.addStudentBtn.TabIndex = 0;
            this.addStudentBtn.Text = "Add Student";
            this.addStudentBtn.UseVisualStyleBackColor = true;
            this.addStudentBtn.Click += new System.EventHandler(this.addStudentBtn_Click);
            // 
            // addTeacherBtn
            // 
            this.addTeacherBtn.Location = new System.Drawing.Point(436, 122);
            this.addTeacherBtn.Name = "addTeacherBtn";
            this.addTeacherBtn.Size = new System.Drawing.Size(107, 23);
            this.addTeacherBtn.TabIndex = 2;
            this.addTeacherBtn.Text = "Add Teacher";
            this.addTeacherBtn.UseVisualStyleBackColor = true;
            this.addTeacherBtn.Click += new System.EventHandler(this.addTeacherBtn_Click);
            // 
            // addHeadTeachBtn
            // 
            this.addHeadTeachBtn.Location = new System.Drawing.Point(298, 122);
            this.addHeadTeachBtn.Name = "addHeadTeachBtn";
            this.addHeadTeachBtn.Size = new System.Drawing.Size(120, 23);
            this.addHeadTeachBtn.TabIndex = 4;
            this.addHeadTeachBtn.Text = "Add Head of Teach";
            this.addHeadTeachBtn.UseVisualStyleBackColor = true;
            this.addHeadTeachBtn.Click += new System.EventHandler(this.addHeadTeachBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addHeadTeachBtn);
            this.Controls.Add(this.addTeacherBtn);
            this.Controls.Add(this.addStudentBtn);
            this.Name = "Form1";
            this.Text = "Picture Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addStudentBtn;
        private System.Windows.Forms.Button addTeacherBtn;
        private System.Windows.Forms.Button addHeadTeachBtn;
    }
}

