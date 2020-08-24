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
            this.editStudentBtn = new System.Windows.Forms.Button();
            this.deleteStudentBtn = new System.Windows.Forms.Button();
            this.createStudentsBtn = new System.Windows.Forms.Button();
            this.dropStudentsBtn = new System.Windows.Forms.Button();
            this.selectStudentBtn = new System.Windows.Forms.Button();
            this.dropHeadTeachsBtn = new System.Windows.Forms.Button();
            this.createHeadTeachsBtn = new System.Windows.Forms.Button();
            this.editHeadTeachBtn = new System.Windows.Forms.Button();
            this.deleteHeadTeachBtn = new System.Windows.Forms.Button();
            this.selectHeadTeach = new System.Windows.Forms.Button();
            this.dropTeachersBtn = new System.Windows.Forms.Button();
            this.createTeachersBtn = new System.Windows.Forms.Button();
            this.editTeacherBtn = new System.Windows.Forms.Button();
            this.deleteTeacherBtn = new System.Windows.Forms.Button();
            this.selectTeacherBtn = new System.Windows.Forms.Button();
            this.createCoursesBtn = new System.Windows.Forms.Button();
            this.dropCoursesBtn = new System.Windows.Forms.Button();
            this.addCourseBtn = new System.Windows.Forms.Button();
            this.editCourseBtn = new System.Windows.Forms.Button();
            this.deleteCourseBtn = new System.Windows.Forms.Button();
            this.selectCourseBtn = new System.Windows.Forms.Button();
            this.noteLbl = new System.Windows.Forms.Label();
            this.studentIdTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headTeachIdTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.teacherIdTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.courseIdTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.exist_courseIdTxt = new System.Windows.Forms.TextBox();
            this.selectExistBtn = new System.Windows.Forms.Button();
            this.dropExistBtn = new System.Windows.Forms.Button();
            this.createExistBtn = new System.Windows.Forms.Button();
            this.deleteExistBtn = new System.Windows.Forms.Button();
            this.addExistBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.exist_teacherIdTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.preCourseIdTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mainCourseIdTxt = new System.Windows.Forms.TextBox();
            this.selectPreBtn = new System.Windows.Forms.Button();
            this.dropPreBtn = new System.Windows.Forms.Button();
            this.createPreBtn = new System.Windows.Forms.Button();
            this.deletePreBtn = new System.Windows.Forms.Button();
            this.addPreBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.classCourseIdTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.classStudentIdTxt = new System.Windows.Forms.TextBox();
            this.selectClassBtn = new System.Windows.Forms.Button();
            this.dropClassBtn = new System.Windows.Forms.Button();
            this.createClassBtn = new System.Windows.Forms.Button();
            this.deleteClassBtn = new System.Windows.Forms.Button();
            this.addClassBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.takeTeacherIdTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.takeStudentIdTxt = new System.Windows.Forms.TextBox();
            this.selectTakeBtn = new System.Windows.Forms.Button();
            this.dropTakeBtn = new System.Windows.Forms.Button();
            this.createTakeBtn = new System.Windows.Forms.Button();
            this.deleteTakeBtn = new System.Windows.Forms.Button();
            this.addTakeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.Location = new System.Drawing.Point(45, 94);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(130, 23);
            this.addStudentBtn.TabIndex = 0;
            this.addStudentBtn.Text = "Add Student";
            this.addStudentBtn.UseVisualStyleBackColor = true;
            this.addStudentBtn.Click += new System.EventHandler(this.addStudentBtn_Click);
            // 
            // addTeacherBtn
            // 
            this.addTeacherBtn.Location = new System.Drawing.Point(445, 94);
            this.addTeacherBtn.Name = "addTeacherBtn";
            this.addTeacherBtn.Size = new System.Drawing.Size(130, 23);
            this.addTeacherBtn.TabIndex = 2;
            this.addTeacherBtn.Text = "Add Teacher";
            this.addTeacherBtn.UseVisualStyleBackColor = true;
            this.addTeacherBtn.Click += new System.EventHandler(this.addTeacherBtn_Click);
            // 
            // addHeadTeachBtn
            // 
            this.addHeadTeachBtn.Location = new System.Drawing.Point(245, 94);
            this.addHeadTeachBtn.Name = "addHeadTeachBtn";
            this.addHeadTeachBtn.Size = new System.Drawing.Size(147, 23);
            this.addHeadTeachBtn.TabIndex = 4;
            this.addHeadTeachBtn.Text = "Add Head of Teach";
            this.addHeadTeachBtn.UseVisualStyleBackColor = true;
            this.addHeadTeachBtn.Click += new System.EventHandler(this.addHeadTeachBtn_Click);
            // 
            // editStudentBtn
            // 
            this.editStudentBtn.BackColor = System.Drawing.Color.Red;
            this.editStudentBtn.Location = new System.Drawing.Point(45, 123);
            this.editStudentBtn.Name = "editStudentBtn";
            this.editStudentBtn.Size = new System.Drawing.Size(130, 23);
            this.editStudentBtn.TabIndex = 5;
            this.editStudentBtn.Text = "Edit Student";
            this.editStudentBtn.UseVisualStyleBackColor = false;
            this.editStudentBtn.Click += new System.EventHandler(this.editStudentBtn_Click);
            // 
            // deleteStudentBtn
            // 
            this.deleteStudentBtn.BackColor = System.Drawing.Color.Red;
            this.deleteStudentBtn.Location = new System.Drawing.Point(45, 152);
            this.deleteStudentBtn.Name = "deleteStudentBtn";
            this.deleteStudentBtn.Size = new System.Drawing.Size(130, 23);
            this.deleteStudentBtn.TabIndex = 6;
            this.deleteStudentBtn.Text = "Delete Student";
            this.deleteStudentBtn.UseVisualStyleBackColor = false;
            this.deleteStudentBtn.Click += new System.EventHandler(this.deleteStudentBtn_Click);
            // 
            // createStudentsBtn
            // 
            this.createStudentsBtn.Location = new System.Drawing.Point(45, 36);
            this.createStudentsBtn.Name = "createStudentsBtn";
            this.createStudentsBtn.Size = new System.Drawing.Size(130, 23);
            this.createStudentsBtn.TabIndex = 7;
            this.createStudentsBtn.Text = "Create Table Studnts";
            this.createStudentsBtn.UseVisualStyleBackColor = true;
            this.createStudentsBtn.Click += new System.EventHandler(this.createStudentsBtn_Click);
            // 
            // dropStudentsBtn
            // 
            this.dropStudentsBtn.Location = new System.Drawing.Point(45, 65);
            this.dropStudentsBtn.Name = "dropStudentsBtn";
            this.dropStudentsBtn.Size = new System.Drawing.Size(130, 23);
            this.dropStudentsBtn.TabIndex = 8;
            this.dropStudentsBtn.Text = "Delete Table Students";
            this.dropStudentsBtn.UseVisualStyleBackColor = true;
            this.dropStudentsBtn.Click += new System.EventHandler(this.dropStudentsBtn_Click);
            // 
            // selectStudentBtn
            // 
            this.selectStudentBtn.BackColor = System.Drawing.Color.Red;
            this.selectStudentBtn.Location = new System.Drawing.Point(45, 181);
            this.selectStudentBtn.Name = "selectStudentBtn";
            this.selectStudentBtn.Size = new System.Drawing.Size(130, 23);
            this.selectStudentBtn.TabIndex = 9;
            this.selectStudentBtn.Text = "Select Student";
            this.selectStudentBtn.UseVisualStyleBackColor = false;
            this.selectStudentBtn.Click += new System.EventHandler(this.selectStudentBtn_Click);
            // 
            // dropHeadTeachsBtn
            // 
            this.dropHeadTeachsBtn.Location = new System.Drawing.Point(245, 65);
            this.dropHeadTeachsBtn.Name = "dropHeadTeachsBtn";
            this.dropHeadTeachsBtn.Size = new System.Drawing.Size(147, 23);
            this.dropHeadTeachsBtn.TabIndex = 10;
            this.dropHeadTeachsBtn.Text = "Delete Table HeadTeachs";
            this.dropHeadTeachsBtn.UseVisualStyleBackColor = true;
            this.dropHeadTeachsBtn.Click += new System.EventHandler(this.dropHeadTeachsBtn_Click);
            // 
            // createHeadTeachsBtn
            // 
            this.createHeadTeachsBtn.Location = new System.Drawing.Point(245, 36);
            this.createHeadTeachsBtn.Name = "createHeadTeachsBtn";
            this.createHeadTeachsBtn.Size = new System.Drawing.Size(147, 23);
            this.createHeadTeachsBtn.TabIndex = 11;
            this.createHeadTeachsBtn.Text = "Create Table HeadTeachs";
            this.createHeadTeachsBtn.UseVisualStyleBackColor = true;
            this.createHeadTeachsBtn.Click += new System.EventHandler(this.createHeadTeachsBtn_Click);
            // 
            // editHeadTeachBtn
            // 
            this.editHeadTeachBtn.BackColor = System.Drawing.Color.Red;
            this.editHeadTeachBtn.Location = new System.Drawing.Point(245, 123);
            this.editHeadTeachBtn.Name = "editHeadTeachBtn";
            this.editHeadTeachBtn.Size = new System.Drawing.Size(147, 23);
            this.editHeadTeachBtn.TabIndex = 12;
            this.editHeadTeachBtn.Text = "Edit Head of Teach";
            this.editHeadTeachBtn.UseVisualStyleBackColor = false;
            this.editHeadTeachBtn.Click += new System.EventHandler(this.editHeadTeachBtn_Click);
            // 
            // deleteHeadTeachBtn
            // 
            this.deleteHeadTeachBtn.BackColor = System.Drawing.Color.Red;
            this.deleteHeadTeachBtn.Location = new System.Drawing.Point(245, 152);
            this.deleteHeadTeachBtn.Name = "deleteHeadTeachBtn";
            this.deleteHeadTeachBtn.Size = new System.Drawing.Size(147, 23);
            this.deleteHeadTeachBtn.TabIndex = 13;
            this.deleteHeadTeachBtn.Text = "Delete Head of Teach";
            this.deleteHeadTeachBtn.UseVisualStyleBackColor = false;
            this.deleteHeadTeachBtn.Click += new System.EventHandler(this.deleteHeadTeachBtn_Click);
            // 
            // selectHeadTeach
            // 
            this.selectHeadTeach.BackColor = System.Drawing.Color.Red;
            this.selectHeadTeach.Location = new System.Drawing.Point(245, 181);
            this.selectHeadTeach.Name = "selectHeadTeach";
            this.selectHeadTeach.Size = new System.Drawing.Size(147, 23);
            this.selectHeadTeach.TabIndex = 14;
            this.selectHeadTeach.Text = "Select Head of Teach";
            this.selectHeadTeach.UseVisualStyleBackColor = false;
            this.selectHeadTeach.Click += new System.EventHandler(this.selectHeadTeach_Click);
            // 
            // dropTeachersBtn
            // 
            this.dropTeachersBtn.Location = new System.Drawing.Point(445, 65);
            this.dropTeachersBtn.Name = "dropTeachersBtn";
            this.dropTeachersBtn.Size = new System.Drawing.Size(130, 23);
            this.dropTeachersBtn.TabIndex = 15;
            this.dropTeachersBtn.Text = "Delete Table Teachers";
            this.dropTeachersBtn.UseVisualStyleBackColor = true;
            this.dropTeachersBtn.Click += new System.EventHandler(this.dropTeachersBtn_Click);
            // 
            // createTeachersBtn
            // 
            this.createTeachersBtn.Location = new System.Drawing.Point(445, 36);
            this.createTeachersBtn.Name = "createTeachersBtn";
            this.createTeachersBtn.Size = new System.Drawing.Size(130, 23);
            this.createTeachersBtn.TabIndex = 16;
            this.createTeachersBtn.Text = "Create Table Teachers";
            this.createTeachersBtn.UseVisualStyleBackColor = true;
            this.createTeachersBtn.Click += new System.EventHandler(this.createTeachersBtn_Click);
            // 
            // editTeacherBtn
            // 
            this.editTeacherBtn.BackColor = System.Drawing.Color.Red;
            this.editTeacherBtn.Location = new System.Drawing.Point(445, 123);
            this.editTeacherBtn.Name = "editTeacherBtn";
            this.editTeacherBtn.Size = new System.Drawing.Size(130, 23);
            this.editTeacherBtn.TabIndex = 17;
            this.editTeacherBtn.Text = "Edit Teacher";
            this.editTeacherBtn.UseVisualStyleBackColor = false;
            this.editTeacherBtn.Click += new System.EventHandler(this.editTeacherBtn_Click);
            // 
            // deleteTeacherBtn
            // 
            this.deleteTeacherBtn.BackColor = System.Drawing.Color.Red;
            this.deleteTeacherBtn.Location = new System.Drawing.Point(445, 152);
            this.deleteTeacherBtn.Name = "deleteTeacherBtn";
            this.deleteTeacherBtn.Size = new System.Drawing.Size(130, 23);
            this.deleteTeacherBtn.TabIndex = 18;
            this.deleteTeacherBtn.Text = "Delete Teacher";
            this.deleteTeacherBtn.UseVisualStyleBackColor = false;
            this.deleteTeacherBtn.Click += new System.EventHandler(this.deleteTeacherBtn_Click);
            // 
            // selectTeacherBtn
            // 
            this.selectTeacherBtn.BackColor = System.Drawing.Color.Red;
            this.selectTeacherBtn.Location = new System.Drawing.Point(445, 181);
            this.selectTeacherBtn.Name = "selectTeacherBtn";
            this.selectTeacherBtn.Size = new System.Drawing.Size(130, 23);
            this.selectTeacherBtn.TabIndex = 19;
            this.selectTeacherBtn.Text = "Select Teacher";
            this.selectTeacherBtn.UseVisualStyleBackColor = false;
            this.selectTeacherBtn.Click += new System.EventHandler(this.selectTeacherBtn_Click);
            // 
            // createCoursesBtn
            // 
            this.createCoursesBtn.Location = new System.Drawing.Point(645, 36);
            this.createCoursesBtn.Name = "createCoursesBtn";
            this.createCoursesBtn.Size = new System.Drawing.Size(130, 23);
            this.createCoursesBtn.TabIndex = 20;
            this.createCoursesBtn.Text = "Create Table Courses";
            this.createCoursesBtn.UseVisualStyleBackColor = true;
            this.createCoursesBtn.Click += new System.EventHandler(this.createCoursesBtn_Click);
            // 
            // dropCoursesBtn
            // 
            this.dropCoursesBtn.Location = new System.Drawing.Point(645, 65);
            this.dropCoursesBtn.Name = "dropCoursesBtn";
            this.dropCoursesBtn.Size = new System.Drawing.Size(130, 23);
            this.dropCoursesBtn.TabIndex = 21;
            this.dropCoursesBtn.Text = "Delete Table Courses";
            this.dropCoursesBtn.UseVisualStyleBackColor = true;
            this.dropCoursesBtn.Click += new System.EventHandler(this.dropCoursesBtn_Click);
            // 
            // addCourseBtn
            // 
            this.addCourseBtn.Location = new System.Drawing.Point(645, 94);
            this.addCourseBtn.Name = "addCourseBtn";
            this.addCourseBtn.Size = new System.Drawing.Size(130, 23);
            this.addCourseBtn.TabIndex = 22;
            this.addCourseBtn.Text = "Add Course";
            this.addCourseBtn.UseVisualStyleBackColor = true;
            this.addCourseBtn.Click += new System.EventHandler(this.addCourseBtn_Click);
            // 
            // editCourseBtn
            // 
            this.editCourseBtn.BackColor = System.Drawing.Color.Red;
            this.editCourseBtn.Location = new System.Drawing.Point(645, 123);
            this.editCourseBtn.Name = "editCourseBtn";
            this.editCourseBtn.Size = new System.Drawing.Size(130, 23);
            this.editCourseBtn.TabIndex = 23;
            this.editCourseBtn.Text = "Edit Course";
            this.editCourseBtn.UseVisualStyleBackColor = false;
            this.editCourseBtn.Click += new System.EventHandler(this.editCourseBtn_Click);
            // 
            // deleteCourseBtn
            // 
            this.deleteCourseBtn.BackColor = System.Drawing.Color.Red;
            this.deleteCourseBtn.Location = new System.Drawing.Point(645, 152);
            this.deleteCourseBtn.Name = "deleteCourseBtn";
            this.deleteCourseBtn.Size = new System.Drawing.Size(130, 23);
            this.deleteCourseBtn.TabIndex = 24;
            this.deleteCourseBtn.Text = "Delete Course";
            this.deleteCourseBtn.UseVisualStyleBackColor = false;
            this.deleteCourseBtn.Click += new System.EventHandler(this.deleteCourseBtn_Click);
            // 
            // selectCourseBtn
            // 
            this.selectCourseBtn.BackColor = System.Drawing.Color.Red;
            this.selectCourseBtn.Location = new System.Drawing.Point(645, 181);
            this.selectCourseBtn.Name = "selectCourseBtn";
            this.selectCourseBtn.Size = new System.Drawing.Size(130, 23);
            this.selectCourseBtn.TabIndex = 25;
            this.selectCourseBtn.Text = "Select Course";
            this.selectCourseBtn.UseVisualStyleBackColor = false;
            this.selectCourseBtn.Click += new System.EventHandler(this.selectCourseBtn_Click);
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.BackColor = System.Drawing.Color.Red;
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.noteLbl.Location = new System.Drawing.Point(284, 9);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(292, 17);
            this.noteLbl.TabIndex = 26;
            this.noteLbl.Text = "Note : id is only for Edit, Delete, Select";
            // 
            // studentIdTxt
            // 
            this.studentIdTxt.Location = new System.Drawing.Point(75, 221);
            this.studentIdTxt.Name = "studentIdTxt";
            this.studentIdTxt.Size = new System.Drawing.Size(100, 20);
            this.studentIdTxt.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "ID :";
            // 
            // headTeachIdTxt
            // 
            this.headTeachIdTxt.Location = new System.Drawing.Point(275, 221);
            this.headTeachIdTxt.Name = "headTeachIdTxt";
            this.headTeachIdTxt.Size = new System.Drawing.Size(100, 20);
            this.headTeachIdTxt.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "ID :";
            // 
            // teacherIdTxt
            // 
            this.teacherIdTxt.Location = new System.Drawing.Point(475, 221);
            this.teacherIdTxt.Name = "teacherIdTxt";
            this.teacherIdTxt.Size = new System.Drawing.Size(100, 20);
            this.teacherIdTxt.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(645, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "ID :";
            // 
            // courseIdTxt
            // 
            this.courseIdTxt.Location = new System.Drawing.Point(675, 221);
            this.courseIdTxt.Name = "courseIdTxt";
            this.courseIdTxt.Size = new System.Drawing.Size(100, 20);
            this.courseIdTxt.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 454);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "CourseID :";
            // 
            // exist_courseIdTxt
            // 
            this.exist_courseIdTxt.Location = new System.Drawing.Point(109, 451);
            this.exist_courseIdTxt.Name = "exist_courseIdTxt";
            this.exist_courseIdTxt.Size = new System.Drawing.Size(35, 20);
            this.exist_courseIdTxt.TabIndex = 41;
            // 
            // selectExistBtn
            // 
            this.selectExistBtn.Location = new System.Drawing.Point(45, 422);
            this.selectExistBtn.Name = "selectExistBtn";
            this.selectExistBtn.Size = new System.Drawing.Size(155, 23);
            this.selectExistBtn.TabIndex = 40;
            this.selectExistBtn.Text = "Select All ExistingCourse";
            this.selectExistBtn.UseVisualStyleBackColor = true;
            this.selectExistBtn.Click += new System.EventHandler(this.selectExistBtn_Click);
            // 
            // dropExistBtn
            // 
            this.dropExistBtn.Location = new System.Drawing.Point(45, 306);
            this.dropExistBtn.Name = "dropExistBtn";
            this.dropExistBtn.Size = new System.Drawing.Size(155, 23);
            this.dropExistBtn.TabIndex = 39;
            this.dropExistBtn.Text = "Delete Table ExistingCourses";
            this.dropExistBtn.UseVisualStyleBackColor = true;
            this.dropExistBtn.Click += new System.EventHandler(this.dropExistBtn_Click);
            // 
            // createExistBtn
            // 
            this.createExistBtn.Location = new System.Drawing.Point(45, 277);
            this.createExistBtn.Name = "createExistBtn";
            this.createExistBtn.Size = new System.Drawing.Size(155, 23);
            this.createExistBtn.TabIndex = 38;
            this.createExistBtn.Text = "Create Table ExistingCourses";
            this.createExistBtn.UseVisualStyleBackColor = true;
            this.createExistBtn.Click += new System.EventHandler(this.createExistBtn_Click);
            // 
            // deleteExistBtn
            // 
            this.deleteExistBtn.BackColor = System.Drawing.Color.Red;
            this.deleteExistBtn.Location = new System.Drawing.Point(45, 393);
            this.deleteExistBtn.Name = "deleteExistBtn";
            this.deleteExistBtn.Size = new System.Drawing.Size(155, 23);
            this.deleteExistBtn.TabIndex = 37;
            this.deleteExistBtn.Text = "Delete ExistingCourse";
            this.deleteExistBtn.UseVisualStyleBackColor = false;
            this.deleteExistBtn.Click += new System.EventHandler(this.deleteExistBtn_Click);
            // 
            // addExistBtn
            // 
            this.addExistBtn.BackColor = System.Drawing.Color.Red;
            this.addExistBtn.Location = new System.Drawing.Point(45, 364);
            this.addExistBtn.Name = "addExistBtn";
            this.addExistBtn.Size = new System.Drawing.Size(155, 23);
            this.addExistBtn.TabIndex = 35;
            this.addExistBtn.Text = "Add ExistingCourse";
            this.addExistBtn.UseVisualStyleBackColor = false;
            this.addExistBtn.Click += new System.EventHandler(this.addExistBtn_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(75, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(700, 3);
            this.label6.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "TeacherID :";
            // 
            // exist_teacherIdTxt
            // 
            this.exist_teacherIdTxt.Location = new System.Drawing.Point(109, 470);
            this.exist_teacherIdTxt.Name = "exist_teacherIdTxt";
            this.exist_teacherIdTxt.Size = new System.Drawing.Size(35, 20);
            this.exist_teacherIdTxt.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 473);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Pre Course ID :";
            // 
            // preCourseIdTxt
            // 
            this.preCourseIdTxt.Location = new System.Drawing.Point(309, 470);
            this.preCourseIdTxt.Name = "preCourseIdTxt";
            this.preCourseIdTxt.Size = new System.Drawing.Size(35, 20);
            this.preCourseIdTxt.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 454);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Main Course ID :";
            // 
            // mainCourseIdTxt
            // 
            this.mainCourseIdTxt.Location = new System.Drawing.Point(309, 451);
            this.mainCourseIdTxt.Name = "mainCourseIdTxt";
            this.mainCourseIdTxt.Size = new System.Drawing.Size(35, 20);
            this.mainCourseIdTxt.TabIndex = 52;
            // 
            // selectPreBtn
            // 
            this.selectPreBtn.Location = new System.Drawing.Point(220, 422);
            this.selectPreBtn.Name = "selectPreBtn";
            this.selectPreBtn.Size = new System.Drawing.Size(180, 23);
            this.selectPreBtn.TabIndex = 51;
            this.selectPreBtn.Text = "Select All PrerequisitesCourse";
            this.selectPreBtn.UseVisualStyleBackColor = true;
            this.selectPreBtn.Click += new System.EventHandler(this.selectPreBtn_Click);
            // 
            // dropPreBtn
            // 
            this.dropPreBtn.Location = new System.Drawing.Point(220, 306);
            this.dropPreBtn.Name = "dropPreBtn";
            this.dropPreBtn.Size = new System.Drawing.Size(180, 23);
            this.dropPreBtn.TabIndex = 50;
            this.dropPreBtn.Text = "Delete Table PrerequisitesCourses";
            this.dropPreBtn.UseVisualStyleBackColor = true;
            this.dropPreBtn.Click += new System.EventHandler(this.dropPreBtn_Click);
            // 
            // createPreBtn
            // 
            this.createPreBtn.Location = new System.Drawing.Point(220, 277);
            this.createPreBtn.Name = "createPreBtn";
            this.createPreBtn.Size = new System.Drawing.Size(180, 23);
            this.createPreBtn.TabIndex = 49;
            this.createPreBtn.Text = "Create Table PrerequisitesCourses";
            this.createPreBtn.UseVisualStyleBackColor = true;
            this.createPreBtn.Click += new System.EventHandler(this.createPreBtn_Click);
            // 
            // deletePreBtn
            // 
            this.deletePreBtn.BackColor = System.Drawing.Color.Red;
            this.deletePreBtn.Location = new System.Drawing.Point(220, 393);
            this.deletePreBtn.Name = "deletePreBtn";
            this.deletePreBtn.Size = new System.Drawing.Size(180, 23);
            this.deletePreBtn.TabIndex = 48;
            this.deletePreBtn.Text = "Delete PrerequisitesCourse";
            this.deletePreBtn.UseVisualStyleBackColor = false;
            this.deletePreBtn.Click += new System.EventHandler(this.deletePreBtn_Click);
            // 
            // addPreBtn
            // 
            this.addPreBtn.BackColor = System.Drawing.Color.Red;
            this.addPreBtn.Location = new System.Drawing.Point(220, 364);
            this.addPreBtn.Name = "addPreBtn";
            this.addPreBtn.Size = new System.Drawing.Size(180, 23);
            this.addPreBtn.TabIndex = 46;
            this.addPreBtn.Text = "Add PrerequisitesCourse";
            this.addPreBtn.UseVisualStyleBackColor = false;
            this.addPreBtn.Click += new System.EventHandler(this.addPreBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(443, 473);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Course ID :";
            // 
            // classCourseIdTxt
            // 
            this.classCourseIdTxt.Location = new System.Drawing.Point(509, 470);
            this.classCourseIdTxt.Name = "classCourseIdTxt";
            this.classCourseIdTxt.Size = new System.Drawing.Size(35, 20);
            this.classCourseIdTxt.TabIndex = 64;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(439, 454);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Student ID :";
            // 
            // classStudentIdTxt
            // 
            this.classStudentIdTxt.Location = new System.Drawing.Point(509, 451);
            this.classStudentIdTxt.Name = "classStudentIdTxt";
            this.classStudentIdTxt.Size = new System.Drawing.Size(35, 20);
            this.classStudentIdTxt.TabIndex = 62;
            // 
            // selectClassBtn
            // 
            this.selectClassBtn.Location = new System.Drawing.Point(445, 422);
            this.selectClassBtn.Name = "selectClassBtn";
            this.selectClassBtn.Size = new System.Drawing.Size(155, 23);
            this.selectClassBtn.TabIndex = 61;
            this.selectClassBtn.Text = "Select All StudentCourse";
            this.selectClassBtn.UseVisualStyleBackColor = true;
            this.selectClassBtn.Click += new System.EventHandler(this.selectClassBtn_Click);
            // 
            // dropClassBtn
            // 
            this.dropClassBtn.Location = new System.Drawing.Point(445, 306);
            this.dropClassBtn.Name = "dropClassBtn";
            this.dropClassBtn.Size = new System.Drawing.Size(155, 23);
            this.dropClassBtn.TabIndex = 60;
            this.dropClassBtn.Text = "Delete Table StudentCourses";
            this.dropClassBtn.UseVisualStyleBackColor = true;
            this.dropClassBtn.Click += new System.EventHandler(this.dropClassBtn_Click);
            // 
            // createClassBtn
            // 
            this.createClassBtn.Location = new System.Drawing.Point(445, 277);
            this.createClassBtn.Name = "createClassBtn";
            this.createClassBtn.Size = new System.Drawing.Size(155, 23);
            this.createClassBtn.TabIndex = 59;
            this.createClassBtn.Text = "Create Table StudentCourses";
            this.createClassBtn.UseVisualStyleBackColor = true;
            this.createClassBtn.Click += new System.EventHandler(this.createClassBtn_Click);
            // 
            // deleteClassBtn
            // 
            this.deleteClassBtn.BackColor = System.Drawing.Color.Red;
            this.deleteClassBtn.Location = new System.Drawing.Point(445, 393);
            this.deleteClassBtn.Name = "deleteClassBtn";
            this.deleteClassBtn.Size = new System.Drawing.Size(155, 23);
            this.deleteClassBtn.TabIndex = 58;
            this.deleteClassBtn.Text = "Delete StudentCourse";
            this.deleteClassBtn.UseVisualStyleBackColor = false;
            this.deleteClassBtn.Click += new System.EventHandler(this.deleteClassBtn_Click);
            // 
            // addClassBtn
            // 
            this.addClassBtn.BackColor = System.Drawing.Color.Red;
            this.addClassBtn.Location = new System.Drawing.Point(445, 364);
            this.addClassBtn.Name = "addClassBtn";
            this.addClassBtn.Size = new System.Drawing.Size(155, 23);
            this.addClassBtn.TabIndex = 56;
            this.addClassBtn.Text = "Add StudentCourse";
            this.addClassBtn.UseVisualStyleBackColor = false;
            this.addClassBtn.Click += new System.EventHandler(this.addClassBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(636, 473);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "Teacher ID :";
            // 
            // takeTeacherIdTxt
            // 
            this.takeTeacherIdTxt.Location = new System.Drawing.Point(709, 470);
            this.takeTeacherIdTxt.Name = "takeTeacherIdTxt";
            this.takeTeacherIdTxt.Size = new System.Drawing.Size(35, 20);
            this.takeTeacherIdTxt.TabIndex = 74;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(639, 454);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 73;
            this.label13.Text = "Student ID :";
            // 
            // takeStudentIdTxt
            // 
            this.takeStudentIdTxt.Location = new System.Drawing.Point(709, 451);
            this.takeStudentIdTxt.Name = "takeStudentIdTxt";
            this.takeStudentIdTxt.Size = new System.Drawing.Size(35, 20);
            this.takeStudentIdTxt.TabIndex = 72;
            // 
            // selectTakeBtn
            // 
            this.selectTakeBtn.Location = new System.Drawing.Point(639, 422);
            this.selectTakeBtn.Name = "selectTakeBtn";
            this.selectTakeBtn.Size = new System.Drawing.Size(161, 23);
            this.selectTakeBtn.TabIndex = 71;
            this.selectTakeBtn.Text = "Select All StudenTeacher";
            this.selectTakeBtn.UseVisualStyleBackColor = true;
            this.selectTakeBtn.Click += new System.EventHandler(this.selectTakeBtn_Click);
            // 
            // dropTakeBtn
            // 
            this.dropTakeBtn.Location = new System.Drawing.Point(639, 306);
            this.dropTakeBtn.Name = "dropTakeBtn";
            this.dropTakeBtn.Size = new System.Drawing.Size(161, 23);
            this.dropTakeBtn.TabIndex = 70;
            this.dropTakeBtn.Text = "Delete Table StudenTeachers";
            this.dropTakeBtn.UseVisualStyleBackColor = true;
            this.dropTakeBtn.Click += new System.EventHandler(this.dropTakeBtn_Click);
            // 
            // createTakeBtn
            // 
            this.createTakeBtn.Location = new System.Drawing.Point(639, 277);
            this.createTakeBtn.Name = "createTakeBtn";
            this.createTakeBtn.Size = new System.Drawing.Size(161, 23);
            this.createTakeBtn.TabIndex = 69;
            this.createTakeBtn.Text = "Create Table StudenTeachers";
            this.createTakeBtn.UseVisualStyleBackColor = true;
            this.createTakeBtn.Click += new System.EventHandler(this.createTakeBtn_Click);
            // 
            // deleteTakeBtn
            // 
            this.deleteTakeBtn.BackColor = System.Drawing.Color.Red;
            this.deleteTakeBtn.Location = new System.Drawing.Point(639, 393);
            this.deleteTakeBtn.Name = "deleteTakeBtn";
            this.deleteTakeBtn.Size = new System.Drawing.Size(161, 23);
            this.deleteTakeBtn.TabIndex = 68;
            this.deleteTakeBtn.Text = "Delete StudenTeacher";
            this.deleteTakeBtn.UseVisualStyleBackColor = false;
            this.deleteTakeBtn.Click += new System.EventHandler(this.deleteTakeBtn_Click);
            // 
            // addTakeBtn
            // 
            this.addTakeBtn.BackColor = System.Drawing.Color.Red;
            this.addTakeBtn.Location = new System.Drawing.Point(639, 364);
            this.addTakeBtn.Name = "addTakeBtn";
            this.addTakeBtn.Size = new System.Drawing.Size(161, 23);
            this.addTakeBtn.TabIndex = 66;
            this.addTakeBtn.Text = "Add StudenTeacher";
            this.addTakeBtn.UseVisualStyleBackColor = false;
            this.addTakeBtn.Click += new System.EventHandler(this.addTakeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 530);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.takeTeacherIdTxt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.takeStudentIdTxt);
            this.Controls.Add(this.selectTakeBtn);
            this.Controls.Add(this.dropTakeBtn);
            this.Controls.Add(this.createTakeBtn);
            this.Controls.Add(this.deleteTakeBtn);
            this.Controls.Add(this.addTakeBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.classCourseIdTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.classStudentIdTxt);
            this.Controls.Add(this.selectClassBtn);
            this.Controls.Add(this.dropClassBtn);
            this.Controls.Add(this.createClassBtn);
            this.Controls.Add(this.deleteClassBtn);
            this.Controls.Add(this.addClassBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.preCourseIdTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mainCourseIdTxt);
            this.Controls.Add(this.selectPreBtn);
            this.Controls.Add(this.dropPreBtn);
            this.Controls.Add(this.createPreBtn);
            this.Controls.Add(this.deletePreBtn);
            this.Controls.Add(this.addPreBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.exist_teacherIdTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.exist_courseIdTxt);
            this.Controls.Add(this.selectExistBtn);
            this.Controls.Add(this.dropExistBtn);
            this.Controls.Add(this.createExistBtn);
            this.Controls.Add(this.deleteExistBtn);
            this.Controls.Add(this.addExistBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.courseIdTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.teacherIdTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.headTeachIdTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentIdTxt);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.selectCourseBtn);
            this.Controls.Add(this.deleteCourseBtn);
            this.Controls.Add(this.editCourseBtn);
            this.Controls.Add(this.addCourseBtn);
            this.Controls.Add(this.dropCoursesBtn);
            this.Controls.Add(this.createCoursesBtn);
            this.Controls.Add(this.selectTeacherBtn);
            this.Controls.Add(this.deleteTeacherBtn);
            this.Controls.Add(this.editTeacherBtn);
            this.Controls.Add(this.createTeachersBtn);
            this.Controls.Add(this.dropTeachersBtn);
            this.Controls.Add(this.selectHeadTeach);
            this.Controls.Add(this.deleteHeadTeachBtn);
            this.Controls.Add(this.editHeadTeachBtn);
            this.Controls.Add(this.createHeadTeachsBtn);
            this.Controls.Add(this.dropHeadTeachsBtn);
            this.Controls.Add(this.selectStudentBtn);
            this.Controls.Add(this.dropStudentsBtn);
            this.Controls.Add(this.createStudentsBtn);
            this.Controls.Add(this.deleteStudentBtn);
            this.Controls.Add(this.editStudentBtn);
            this.Controls.Add(this.addHeadTeachBtn);
            this.Controls.Add(this.addTeacherBtn);
            this.Controls.Add(this.addStudentBtn);
            this.Name = "Form1";
            this.Text = "Picture Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStudentBtn;
        private System.Windows.Forms.Button addTeacherBtn;
        private System.Windows.Forms.Button addHeadTeachBtn;
        private System.Windows.Forms.Button editStudentBtn;
        private System.Windows.Forms.Button deleteStudentBtn;
        private System.Windows.Forms.Button createStudentsBtn;
        private System.Windows.Forms.Button dropStudentsBtn;
        private System.Windows.Forms.Button selectStudentBtn;
        private System.Windows.Forms.Button dropHeadTeachsBtn;
        private System.Windows.Forms.Button createHeadTeachsBtn;
        private System.Windows.Forms.Button editHeadTeachBtn;
        private System.Windows.Forms.Button deleteHeadTeachBtn;
        private System.Windows.Forms.Button selectHeadTeach;
        private System.Windows.Forms.Button dropTeachersBtn;
        private System.Windows.Forms.Button createTeachersBtn;
        private System.Windows.Forms.Button editTeacherBtn;
        private System.Windows.Forms.Button deleteTeacherBtn;
        private System.Windows.Forms.Button selectTeacherBtn;
        private System.Windows.Forms.Button createCoursesBtn;
        private System.Windows.Forms.Button dropCoursesBtn;
        private System.Windows.Forms.Button addCourseBtn;
        private System.Windows.Forms.Button editCourseBtn;
        private System.Windows.Forms.Button deleteCourseBtn;
        private System.Windows.Forms.Button selectCourseBtn;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.TextBox studentIdTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox headTeachIdTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox teacherIdTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox courseIdTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox exist_courseIdTxt;
        private System.Windows.Forms.Button selectExistBtn;
        private System.Windows.Forms.Button dropExistBtn;
        private System.Windows.Forms.Button createExistBtn;
        private System.Windows.Forms.Button deleteExistBtn;
        private System.Windows.Forms.Button addExistBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox exist_teacherIdTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox preCourseIdTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mainCourseIdTxt;
        private System.Windows.Forms.Button selectPreBtn;
        private System.Windows.Forms.Button dropPreBtn;
        private System.Windows.Forms.Button createPreBtn;
        private System.Windows.Forms.Button deletePreBtn;
        private System.Windows.Forms.Button addPreBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox classCourseIdTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox classStudentIdTxt;
        private System.Windows.Forms.Button selectClassBtn;
        private System.Windows.Forms.Button dropClassBtn;
        private System.Windows.Forms.Button createClassBtn;
        private System.Windows.Forms.Button deleteClassBtn;
        private System.Windows.Forms.Button addClassBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox takeTeacherIdTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox takeStudentIdTxt;
        private System.Windows.Forms.Button selectTakeBtn;
        private System.Windows.Forms.Button dropTakeBtn;
        private System.Windows.Forms.Button createTakeBtn;
        private System.Windows.Forms.Button deleteTakeBtn;
        private System.Windows.Forms.Button addTakeBtn;
    }
}

