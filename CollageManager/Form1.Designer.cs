namespace CollageManager {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridViewRelation = new System.Windows.Forms.DataGridView();
            this.comboRelationList = new System.Windows.Forms.ComboBox();
            this.btnFullSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rBtnCourses = new System.Windows.Forms.RadioButton();
            this.rBtnHeadTeachs = new System.Windows.Forms.RadioButton();
            this.rBtnTeachers = new System.Windows.Forms.RadioButton();
            this.rBtnStudents = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRelation)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridViewRelation);
            this.groupBox1.Controls.Add(this.comboRelationList);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(927, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // gridViewRelation
            // 
            this.gridViewRelation.AllowUserToAddRows = false;
            this.gridViewRelation.AllowUserToDeleteRows = false;
            this.gridViewRelation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewRelation.Location = new System.Drawing.Point(228, 20);
            this.gridViewRelation.Name = "gridViewRelation";
            this.gridViewRelation.ReadOnly = true;
            this.gridViewRelation.Size = new System.Drawing.Size(693, 120);
            this.gridViewRelation.TabIndex = 6;
            // 
            // comboRelationList
            // 
            this.comboRelationList.FormattingEnabled = true;
            this.comboRelationList.Location = new System.Drawing.Point(6, 20);
            this.comboRelationList.Name = "comboRelationList";
            this.comboRelationList.Size = new System.Drawing.Size(216, 21);
            this.comboRelationList.TabIndex = 5;
            // 
            // btnFullSearch
            // 
            this.btnFullSearch.Location = new System.Drawing.Point(517, 59);
            this.btnFullSearch.Name = "btnFullSearch";
            this.btnFullSearch.Size = new System.Drawing.Size(118, 23);
            this.btnFullSearch.TabIndex = 1;
            this.btnFullSearch.Text = "جستجوی پیشرفته";
            this.btnFullSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(535, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.gridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(927, 245);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "بیشتر";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(765, 216);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(846, 216);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Location = new System.Drawing.Point(6, 20);
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.Size = new System.Drawing.Size(915, 190);
            this.gridView.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rBtnCourses);
            this.groupBox3.Controls.Add(this.rBtnHeadTeachs);
            this.groupBox3.Controls.Add(this.rBtnTeachers);
            this.groupBox3.Controls.Add(this.rBtnStudents);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 66);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "انتخاب لیست";
            // 
            // rBtnCourses
            // 
            this.rBtnCourses.AutoSize = true;
            this.rBtnCourses.Location = new System.Drawing.Point(164, 43);
            this.rBtnCourses.Name = "rBtnCourses";
            this.rBtnCourses.Size = new System.Drawing.Size(52, 17);
            this.rBtnCourses.TabIndex = 3;
            this.rBtnCourses.Text = "دروس";
            this.rBtnCourses.UseVisualStyleBackColor = true;
            this.rBtnCourses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtnMouseClick);
            // 
            // rBtnHeadTeachs
            // 
            this.rBtnHeadTeachs.AutoSize = true;
            this.rBtnHeadTeachs.Location = new System.Drawing.Point(119, 20);
            this.rBtnHeadTeachs.Name = "rBtnHeadTeachs";
            this.rBtnHeadTeachs.Size = new System.Drawing.Size(97, 17);
            this.rBtnHeadTeachs.TabIndex = 2;
            this.rBtnHeadTeachs.Text = "مسولین آموزش";
            this.rBtnHeadTeachs.UseVisualStyleBackColor = true;
            this.rBtnHeadTeachs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtnMouseClick);
            // 
            // rBtnTeachers
            // 
            this.rBtnTeachers.AutoSize = true;
            this.rBtnTeachers.Location = new System.Drawing.Point(42, 43);
            this.rBtnTeachers.Name = "rBtnTeachers";
            this.rBtnTeachers.Size = new System.Drawing.Size(55, 17);
            this.rBtnTeachers.TabIndex = 1;
            this.rBtnTeachers.Text = "اساتید";
            this.rBtnTeachers.UseVisualStyleBackColor = true;
            this.rBtnTeachers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtnMouseClick);
            // 
            // rBtnStudents
            // 
            this.rBtnStudents.AutoSize = true;
            this.rBtnStudents.Location = new System.Drawing.Point(24, 20);
            this.rBtnStudents.Name = "rBtnStudents";
            this.rBtnStudents.Size = new System.Drawing.Size(73, 17);
            this.rBtnStudents.TabIndex = 0;
            this.rBtnStudents.Text = "دانشجویان";
            this.rBtnStudents.UseVisualStyleBackColor = true;
            this.rBtnStudents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtnMouseClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(858, 29);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "به روز رسانی";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "جستجو کردن :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(684, 216);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "افزودن";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 493);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFullSearch);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت مدرسه";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRelation)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rBtnCourses;
        private System.Windows.Forms.RadioButton rBtnHeadTeachs;
        private System.Windows.Forms.RadioButton rBtnTeachers;
        private System.Windows.Forms.RadioButton rBtnStudents;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFullSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox comboRelationList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridViewRelation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdd;
    }
}

