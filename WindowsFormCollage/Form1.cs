using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.ValueTuple;

namespace WindowsFormCollage {
    public partial class Form1 : Form {

        #region Properties
        public SqlConnection Connection { get; }
        public SqlDataAdapter Adapter { get; set; }
        #endregion

        #region Constructors
        public Form1(SqlConnection connection, SqlDataAdapter adapter)
        {
            Adapter = adapter;
            Connection = connection;
            InitializeComponent();
        }
        #endregion



        #region Create Table // توابع ایجاد جداول

        #region Main Tables
        /// <summary>
        /// ساختن جدول مسولین آموزش
        /// </summary>
        private void createHeadTeachsBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('HeadTeachs') is null " +
                    "begin " +
                    "create table HeadTeachs(" +
                        "HeadTeachId int identity(1, 1)  PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "StudyField nvarchar(150)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "HeadTeachs table created Successfully");
        }

        /// <summary>
        /// ساختن جدول دانشجویان
        /// </summary>
        private void createStudentsBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('Students') is null " +
                    "begin " +
                    "create table Students(" +
                        "StudentId int identity(1, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "EntryYear smallInt not null check(EntryYear > 1394)," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11 and PhoneNumber like '0%')," +
                        "Address nvarchar(150)," +
                        "PostalCode varchar(10) check(LEN(PostalCode) = 10)," +
                        "Field nvarchar(50) not null," +
                        "Grade nvarchar(50) not null," +
                        "HeadTeachId int not null," +

                        "CONSTRAINT FK_Student FOREIGN KEY (HeadTeachId) REFERENCES HeadTeachs(HeadTeachId)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "Students table created Successfully");
        }

        /// <summary>
        /// ساختن جدول اساتید
        /// </summary>
        private void createTeachersBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('Teachers') is null " +
                    "begin " +
                    "create table Teachers(" +
                        "TeacherId int identity(1, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "Degree nvarchar(150)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "Teachers table created Successfully");
        }

        /// <summary>
        /// ساختن جدول دروس
        /// </summary>
        private void createCoursesBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('Courses') is null " +
                    "begin " +
                    "create table Courses(" +
                        "CourseId int identity(1, 1) PRIMARY KEY," +
                        "Title nvarchar(50) not null, " +
                        "Credit tinyInt not null," +
                        "CreditType bit not null," + // True for takhasosi, False for omumi
                        "HeadTeachId int not null FOREIGN KEY (HeadTeachId) REFERENCES HeadTeachs(HeadTeachId)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "Courses table created Successfully");
        }
        #endregion Main Tables

        #region Joining Tables
        /// <summary>
        /// ساخت جدول دروس ارایه شده توسط مسول آموزش
        /// </summary>
        private void createExistBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('ExistingCourses') is null " +
                    "begin " +
                    "create table ExistingCourses(" +
                        "TeacherId int not null," +
                        "CourseId int not null," +

                        "CONSTRAINT FK_Exsting_Teacher FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)," +
                        "CONSTRAINT FK_Exsting_Course FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "ExistingCourses table created Successfully");
        }

        /// <summary>
        /// ساخت جدول پیشنیاز دروس
        /// </summary>
        private void createPreBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('PrerequisitesCourses') is null " +
                    "begin " +
                    "create table PrerequisitesCourses(" +
                        "MainCourseId int not null," +
                        "PrerequisitesCourseId int not null," +

                        "CONSTRAINT FK_Main_Course FOREIGN KEY (MainCourseId) REFERENCES Courses(CourseId)," +
                        "CONSTRAINT FK_Pre_Course FOREIGN KEY (PrerequisitesCourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "PrerequisitesCourses table created Successfully");
        }

        /// <summary>
        /// ساخت جدول دروس اخذ شده توسط دانشجویان
        /// </summary>
        private void createClassBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('StudentCourses') is null " +
                    "begin " +
                    "create table StudentCourses(" +
                        "StudentId int not null," +
                        "CourseId int not null," +

                        "CONSTRAINT FK_Student_SC FOREIGN KEY (StudentId) REFERENCES Students(StudentId)," +
                        "CONSTRAINT FK_Course_SC FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "StudentCourses table created Successfully");
        }

        /// <summary>
        /// ساخت جدول ارتباط دانشجو و استاد
        /// </summary>
        private void createTakeBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "if object_id('StudentTeachers') is null " +
                    "begin " +
                    "create table StudentTeachers(" +
                        "StudentId int not null," +
                        "TeacherId int not null," +

                        "FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)," +
                        "FOREIGN KEY (StudentId) REFERENCES Students(StudentId)" +
                    ")" +
                    "end";

            ExecuteCommand(queryString, "StudentTeachers table created Successfully");
        }
        #endregion Joining Tables

        #endregion Create Table

        #region Drop Table // توابع حذف جداول

        #region Main Tables
        /// <summary>
        /// حذف جدول مسولین آموزش
        /// </summary>
        private void dropHeadTeachsBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists HeadTeachs";

            ExecuteCommand(queryString, "HeadTeachs table deleted Successfully");
        }

        /// <summary>
        /// حذف جدول دانشجویان
        /// </summary>
        private void dropStudentsBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists Students";

            ExecuteCommand(queryString, "Students table deleted Successfully");
        }

        /// <summary>
        /// حذف جدول اساتید
        /// </summary>
        private void dropTeachersBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists Teachers";

            ExecuteCommand(queryString, "Teachers table deleted Successfully");
        }

        /// <summary>
        /// حذف جدول دروس
        /// </summary>
        private void dropCoursesBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists Courses";

            ExecuteCommand(queryString, "Courses table deleted Successfully");
        }
        #endregion Main Tables

        #region Joining Tables
        /// <summary>
        /// حذف جدول دروس ارایه شده توسط مسول آموزش
        /// </summary>
        private void dropExistBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists ExistingCourses";

            ExecuteCommand(queryString, "ExistingCourses table deleted Successfully");
        }

        /// <summary>
        /// حذف جدول پیشنیاز دروس
        /// </summary>
        private void dropPreBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists PrerequisitesCourses";

            ExecuteCommand(queryString, "PrerequisitesCourses table deleted Successfully");
        }

        /// <summary>
        /// حذف جدول دروس اخذ شده توسط دانشجویان
        /// </summary>
        private void dropClassBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists StudentCourses";

            ExecuteCommand(queryString, "StudentCoursess table deleted Successfully");
        }

        /// <summary>
        /// حذف جدول ارتباط دانشجو و استاد
        /// </summary>
        private void dropTakeBtn_Click(object sender, EventArgs e)
        {
            string queryString =
                    "drop table if exists StudentTeachers";

            ExecuteCommand(queryString, "StudentTeachers table deleted Successfully");
        }
        #endregion Joining Tables

        #endregion

        #region Delete // توابع حذف اطلاعات از جدول ها

        #region Main Tables
        /// <summary>
        /// حذف اطلاعات یک مسول آموزش با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی مسول آموزش مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        private void deleteHeadTeachBtn_Click(object sender, EventArgs e)
        {
            int? id = GetId(headTeachIdTxt);
            if (id != null)
            {
                string queryString =
                    $"delete from HeadTeachs where HeadTeachId = " +
                    $"{id}";
                if (TableExists("HeadTeachs"))
                {
                    ExecuteCommand(queryString, "One HeadTeach deleted Successfully");
                }
            }
        }

        /// <summary>
        /// حذف اطلاعات یک دانشجو با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی دانشجوی مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        private void deleteStudentBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("Students"))
            {
                int? id = GetId(studentIdTxt);
                if (id != null)
                {
                    string queryString =
                        $"delete from Students where StudentId = " +
                        $"{id}";

                    ExecuteCommand(queryString, "One Student deleted Successfully");
                }
            }
        }

        /// <summary>
        /// حذف اطلاعات یک استاد با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی استاد مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        private void deleteTeacherBtn_Click(object sender, EventArgs e)
        {
            int? id = GetId(teacherIdTxt);
            if (id != null)
            {
                string queryString =
                    $"delete from Teachers where TeacherId = " +
                    $"{id}";

                ExecuteCommand(queryString, "One Teacher deleted Successfully");
            }
        }

        /// <summary>
        /// حذف اطلاعات یک درس با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی درس مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        private void deleteCourseBtn_Click(object sender, EventArgs e)
        {
            int? id = GetId(courseIdTxt);
            if (id != null)
            {
                string queryString =
                    $"delete from Courses where CourseId = " +
                    $"{id}";
                if (TableExists("Courses"))
                {
                    ExecuteCommand(queryString, "One Course deleted Successfully");
                }
            }
        }
        #endregion Main Tables

        #region Joining Tables
        private void deleteExistBtn_Click(object sender, EventArgs e)
        {
            int? courseId = GetId(exist_courseIdTxt);
            int? teacherId = GetId(exist_teacherIdTxt);
            if (courseId != null && teacherId != null)
            {
                string queryString =
                    $"delete from ExistingCourses where (TeacherId = " + $"{teacherId} AND " +
                                                        "CourseId = " + $"{courseId})";
                if (TableExists("ExistingCourses"))
                {
                    ExecuteCommand(queryString, "One ExistingCourse deleted Successfully");
                }
            }
        }

        private void deletePreBtn_Click(object sender, EventArgs e)
        {
            int? preId = GetId(preCourseIdTxt);
            int? mainId = GetId(mainCourseIdTxt);
            if (preId != null && mainId != null)
            {
                string queryString =
                    $"delete from PrerequisitesCourses where (MainCourseId = " + $"{mainId} AND " +
                                                        "PrerequisitesCourseId = " + $"{preId})";
                if (TableExists("PrerequisitesCourses"))
                {
                    ExecuteCommand(queryString, "One PrerequisitesCourse deleted Successfully");
                }
            }
        }

        private void deleteClassBtn_Click(object sender, EventArgs e)
        {
            int? courseId = GetId(classCourseIdTxt);
            int? studentId = GetId(classStudentIdTxt);
            if (courseId != null && studentId != null)
            {
                string queryString =
                    $"delete from StudentCourses where (StudentId = " + $"{studentId} AND " +
                                                        "CourseId = " + $"{courseId})";
                if (TableExists("StudentCourses"))
                {
                    ExecuteCommand(queryString, "One StudentCourse deleted Successfully");
                }
            }
        }

        private void deleteTakeBtn_Click(object sender, EventArgs e)
        {
            int? teacherId = GetId(takeTeacherIdTxt);
            int? studentId = GetId(takeStudentIdTxt);
            if (teacherId != null && studentId != null)
            {
                string queryString =
                    $"delete from StudentTeachers where (StudentId = " + $"{studentId} AND " +
                                                        "TeacherId = " + $"{teacherId})";
                if (TableExists("StudentTeachers"))
                {
                    ExecuteCommand(queryString, "One StudentTeacher deleted Successfully");
                }
            }
        }
        #endregion Joining Tables

        #endregion

        #region Select // توابع انتخاب و نمایش اطلاعات جداول

        #region Main Tables
        // HeadTeach
        /// <summary>
        /// نمایش اطلاعات یک مسول آموزش با استفاده از آیدی درس
        /// </summary>
        private void selectHeadTeach_Click(object sender, EventArgs e)
        {
            int? id = GetId(headTeachIdTxt);
            if (id != null)
            {
                string headTeachs = "";
                foreach (var item in SelectHeadTeach((int)id))
                {
                    headTeachs += item.ToString();
                    headTeachs += "\n";
                }
                MessageBox.Show(headTeachs);
            }
        }

        /// <param name="id">آیدی مسول آموزش مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از مسول آموزش هایی که آیدی مورد نظر را دارند</returns>
        private List<HeadTeach> SelectHeadTeach(int id)
        {
            string queryString =
                    $"select * from HeadTeachs where HeadTeachId = {id}";

            List<HeadTeach> headTeachs = new List<HeadTeach>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection,
                                                       transaction);

                DataTable table = new DataTable("Students");
                Adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    headTeachs.Add(new HeadTeach(
                        (int)row.ItemArray[0], row.ItemArray[1].ToString(),
                        row.ItemArray[2].ToString(), row.ItemArray[3].ToString(),
                        row.ItemArray[4].ToString(), row.ItemArray[5].ToString(),
                        row.ItemArray[6].ToString(), row.ItemArray[7].ToString()));
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return headTeachs;
        }
        ///// ///// ///// /////

        // Student
        /// <summary>
        /// نمایش اطلاعات یک دانشجو با استفاده از آیدی درس
        /// </summary>
        /// <param name="id">آیدی دانشجوی مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از دانشجویانی که آیدی مورد نظر را دارند</returns>
        private void selectStudentBtn_Click(object sender, EventArgs e)
        {
            int? id = GetId(studentIdTxt);
            if (id != null)
            {
                string students = "";
                foreach (var item in SelectStudent((int)id))
                {
                    students += item.ToString();
                    students += "\n";
                }
                MessageBox.Show(students);
            }
        }

        /// <param name="id">آیدی دانشجوی مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از دانشجویانی که آیدی مورد نظر را دارند</returns>
        public List<Student> SelectStudent(int id)
        {
            string queryString =
                    $"select * from Students where StudentId = {id}";

            List<Student> students = new List<Student>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    students.Add(new Student(
                        (int)row.ItemArray[0], row.ItemArray[1].ToString(),
                        row.ItemArray[2].ToString(), row.ItemArray[3].ToString(),
                        row.ItemArray[4].ToString(), (Int16)row.ItemArray[5],
                        row.ItemArray[6].ToString(), row.ItemArray[7].ToString(),
                        row.ItemArray[8].ToString(), row.ItemArray[9].ToString(),
                        row.ItemArray[10].ToString(), (int)row.ItemArray[11]));
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return students;

            #region DataReader
            //string queryString =
            //        $"select * from Students where StudentId = {id}";

            //List<Student> students = new List<Student>();
            //try
            //{
            //    SqlCommand cm = new SqlCommand(queryString, connection);

            //    // Opening Connection  
            //    connection.Open();

            //    // Executing the SQL query 
            //    SqlDataReader sdr = cm.ExecuteReader();
            //    if (sdr.HasRows)
            //    {
            //        while (sdr.Read())
            //        {
            //            //students.Add(new Student(
            //            //                         (int)sdr["StudentId"], sdr["NationalCode"].ToString(),
            //            //                         sdr["Name"].ToString(), sdr["Family"].ToString(),
            //            //                         sdr["FatherName"].ToString(), (Int16)sdr["EntryYear"],
            //            //                         sdr.GetInt32(6), sdr["PhoneNumber"].ToString(),
            //            //                         sdr["Address"].ToString(), sdr["PostalCode"].ToString()));

            //            students.Add(new Student(sdr.GetInt32(0), sdr.GetString(1),
            //                                     sdr.GetString(2), sdr.GetString(3),
            //                                     sdr.GetString(4), sdr.GetInt16(5),
            //                                     sdr.GetInt32(6), sdr.GetString(7),
            //                                     sdr.GetString(8), sdr.GetString(9)));
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No rows found.");
            //    }

            //    // Displaying a message
            //    Console.WriteLine("Students selected Successfully");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("OOPs, something went wrong.\n" + e);
            //}
            //// Closing the connection  
            //finally
            //{
            //    connection.Close();
            //}

            //return students;
            #endregion
        }
        ///// ///// ///// /////

        // Teacher
        /// <summary>
        /// نمایش اطلاعات یک استاد با استفاده از آیدی استاد
        /// </summary>
        private void selectTeacherBtn_Click(object sender, EventArgs e)
        {
            int? id = GetId(teacherIdTxt);
            if (id != null)
            {
                string teachers = "";
                foreach (var item in SelectTeacher((int)id))
                {
                    teachers += item.ToString();
                    teachers += "\n";
                }
                MessageBox.Show(teachers);
            }
        }

        /// <param name="id">آیدی استاد مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از اساتیدی که آیدی مورد نظر را دارند</returns>
        public List<Teacher> SelectTeacher(int id)
        {
            string queryString =
                    $"select * from Teachers where TeacherId = {id}";

            List<Teacher> teachers = new List<Teacher>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    Teacher teacher = new Teacher(
                            row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                            row.ItemArray[3].ToString(), row.ItemArray[4].ToString(),
                            row.ItemArray[5].ToString(), row.ItemArray[6].ToString(),
                            row.ItemArray[7].ToString());
                    teacher.TeacherId = (int)row.ItemArray[0];
                    teachers.Add(teacher);
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return teachers;
        }
        ///// ///// ///// /////

        // Course
        /// <summary>
        /// نمایش اطلاعات یک درس با استفاده از آیدی درس
        /// </summary>
        private void selectCourseBtn_Click(object sender, EventArgs e)
        {
            int? id = GetId(courseIdTxt);
            if (id != null)
            {
                string courses = "";
                foreach (var item in SelectCourse((int)id))
                {
                    courses += item.ToString();
                    courses += "\n";
                }
                MessageBox.Show(courses);
            }
        }

        /// <param name="id">آیدی درس مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از دروسی که آیدی مورد نظر را دارند</returns>
        public List<Course> SelectCourse(int id)
        {
            string queryString =
                    $"select * from Courses where CourseId = {id}";

            List<Course> courses = new List<Course>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    courses.Add(new Course(
                        (int)row.ItemArray[0], row.ItemArray[1].ToString(),
                        (byte)row.ItemArray[2], (bool)row.ItemArray[3], (int)row.ItemArray[4]));
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return courses;
        }

        public List<Course> SelectAllCourse()
        {
            string queryString =
                    $"select * from Courses";

            List<Course> courses = new List<Course>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    courses.Add(new Course(
                        (int)row.ItemArray[0], row.ItemArray[1].ToString(),
                        (byte)row.ItemArray[2], (bool)row.ItemArray[3], (int)row.ItemArray[4]));
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return courses;
        }
        ///// ///// ///// /////
        #endregion Main Tables

        #region Joining Tables
        /// <summary>
        /// نمایش اطلاعات کل دروس ارایه شده
        /// </summary>
        private void selectExistBtn_Click(object sender, EventArgs e)
        {
            string print = "";
            foreach (var item in SelectAllExistingCourse())
            {
                print += $"{item}\n";
            }
            MessageBox.Show(print);
        }

        private List<CourseTeacherVM> SelectAllExistingCourse()
        {
            string queryString =
                    $"select e.TeacherId , t.Name , t.Family , e.CourseId , c.Title " +
                    $"from ExistingCourses e " +
                    $"Join Teachers t " +
                    $"On t.TeacherId = e.TeacherId " +
                    $"Join Courses c " +
                    $"On c.CourseId = e.CourseId";

            List<CourseTeacherVM> queryList = new List<CourseTeacherVM>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    queryList.Add(new CourseTeacherVM()
                    {
                        TeacherId = (int)row.ItemArray[0],
                        Name = row.ItemArray[1].ToString(),
                        Family = row.ItemArray[2].ToString(),
                        CourseId = (int)row.ItemArray[3],
                        Title = row.ItemArray[4].ToString()
                    });
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return queryList;
        }

        /// <summary>
        /// نمایش اطلاعات کل دروس پیش نیاز
        /// </summary>
        private void selectPreBtn_Click(object sender, EventArgs e)
        {
            string print = "";
            foreach (PreCourseVM item in SelectAllPreCourse())
            {
                print += $"{item}\n";
            }
            MessageBox.Show(print);
        }

        private List<PreCourseVM> SelectAllPreCourse()
        {
            string queryString =
                    $"select c.MainCourseId , m.Title , c.PrerequisitesCourseId , p.Title " +
                    $"from PrerequisitesCourses c " +
                    $"Join Courses m " +
                    $"On m.CourseId = c.MainCourseId " +
                    $"Join Courses p " +
                    $"On p.CourseId = c.PrerequisitesCourseId";

            List<PreCourseVM> queryList = new List<PreCourseVM>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    queryList.Add(new PreCourseVM()
                    {
                        MainId = (int)row.ItemArray[0],
                        MainTitle = row.ItemArray[1].ToString(),
                        PreId = (int)row.ItemArray[2],
                        PreTitle = row.ItemArray[3].ToString()
                    });
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return queryList;
        }

        /// <summary>
        /// نمایش اطلاعات کل دروس اخذ شده توسط دانشجو
        /// </summary>
        private void selectClassBtn_Click(object sender, EventArgs e)
        {
            string print = "";
            foreach (StudentCourseVM item in SelectAllStudentCourse())
            {
                print += $"{item}\n";
            }
            MessageBox.Show(print);
        }

        private List<StudentCourseVM> SelectAllStudentCourse()
        {
            string queryString =
                    $"select sc.StudentId , s.Name, s.Family , sc.CourseId , c.Title " +
                    $"from StudentCourses sc " +
                    $"Join Courses c " +
                    $"On c.CourseId = sc.CourseId " +
                    $"Join Students s " +
                    $"On s.StudentId = sc.StudentId";

            List<StudentCourseVM> queryList = new List<StudentCourseVM>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    queryList.Add(new StudentCourseVM()
                    {
                        StudentId = (int)row.ItemArray[0],
                        Name = row.ItemArray[1].ToString(),
                        Family = row.ItemArray[2].ToString(),
                        CourseId = (int)row.ItemArray[3],
                        Title = row.ItemArray[4].ToString()
                    });
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return queryList;
        }

        /// <summary>
        /// نمایش اطلاعات اساتید یک دانشجو
        /// </summary>
        private void selectTakeBtn_Click(object sender, EventArgs e)
        {
            string print = "";
            foreach (StudentTeacherVM item in SelectAllStudentTeacher())
            {
                print += $"{item}\n";
            }
            MessageBox.Show(print);
        }

        private List<StudentTeacherVM> SelectAllStudentTeacher()
        {
            string queryString =
                    $"select st.StudentId , s.Name, s.Family, st.TeacherId , t.Name, t.Family " +
                    $"from StudentTeachers st " +
                    $"Join Students s " +
                    $"On s.StudentId = st.StudentId " +
                    $"Join Teachers t " +
                    $"On t.TeacherId = st.TeacherId";

            List<StudentTeacherVM> queryList = new List<StudentTeacherVM>();

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);

                DataTable table = new DataTable();
                Adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    queryList.Add(new StudentTeacherVM()
                    {
                        StudentId = (int)row.ItemArray[0],
                        StudentName = row.ItemArray[1].ToString(),
                        StudentFamily = row.ItemArray[2].ToString(),
                        TeacherId = (int)row.ItemArray[3],
                        TeacherName = row.ItemArray[4].ToString(),
                        TeacherFamily = row.ItemArray[5].ToString()
                    });
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return queryList;
        }
        #endregion Joining Tables

        #endregion

        #region Insert // توابع درج اطلاعات جداول

        #region Main Tables
        /// <summary>
        /// افزودن یک مسول آموزش جدید در دیتابیس
        /// </summary>
        private void addHeadTeachBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("HeadTeachs"))
            {
                // هنگامی که مقدار آیدی فرستاده شده به صفحه بعد null باشد یعنی میخواهیم عمل درج را انجام دهیم
                HeadTeachForm htForm = new HeadTeachForm(Connection, null);
                htForm.Show();
            }
        }

        /// <summary>
        /// افزودن یک دانشجوی جدید در دیتابیس
        /// </summary>
        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("Students"))
            {
                // هنگامی که مقدار آیدی فرستاده شده به صفحه بعد null باشد یعنی میخواهیم عمل درج را انجام دهیم
                StudentForm sForm = new StudentForm(Connection, null);
                sForm.Show();
            }
        }

        /// <summary>
        /// افزودن یک استاد جدید در دیتابیس
        /// </summary>
        private void addTeacherBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("Teachers"))
            {
                // هنگامی که مقدار آیدی فرستاده شده به صفحه بعد null باشد یعنی میخواهیم عمل درج را انجام دهیم
                TeacherForm tForm = new TeacherForm(Connection, null);
                tForm.Show();
            }
        }

        /// <summary>
        /// افزودن یک درس جدید در دیتابیس
        /// </summary>
        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("Courses"))
            {
                // هنگامی که مقدار آیدی فرستاده شده به صفحه بعد null باشد یعنی میخواهیم عمل درج را انجام دهیم
                CourseForm cForm = new CourseForm(Connection, null);
                cForm.Show();
            }
        }
        #endregion Main Tables

        #region Joining Tables
        /// <summary>
        /// افزودن یک درس ارایه شده در دیتابیس
        /// </summary>
        private void addExistBtn_Click(object sender, EventArgs e)
        {
            int? teacherId = GetId(exist_teacherIdTxt);
            int? courseId = GetId(exist_courseIdTxt);

            if (teacherId != null && courseId != null && TableExists("ExistingCourses"))
            {
                string queryString =

                    "insert into ExistingCourses " +
                    "(" +
                            "TeacherId," +
                            "CourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{teacherId}, " +
                            $"{courseId} " +
                    ")";

                ExecuteCommand(queryString, "Insert into ExistingCourses table Successfully");
            }
        }

        /// <summary>
        /// افزودن یک پیشنیاز درس در دیتابیس
        /// </summary>
        private void addPreBtn_Click(object sender, EventArgs e)
        {
            int? mainId = GetId(mainCourseIdTxt);
            int? preId = GetId(preCourseIdTxt);

            if (mainId != null && preId != null && TableExists("PrerequisitesCourses"))
            {
                string queryString =

                    "insert into PrerequisitesCourses " +
                    "(" +
                            "MainCourseId," +
                            "PrerequisitesCourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{mainId}, " +
                            $"{preId} " +
                    ")";

                ExecuteCommand(queryString, "Insert into PrerequisitesCourses table Successfully");
            }
        }

        /// <summary>
        /// افزودن یک درس اخذ شده توسط دانشجو در دیتابیس
        /// </summary>
        private void addClassBtn_Click(object sender, EventArgs e)
        {
            int? courseId = GetId(classCourseIdTxt);
            int? studentId = GetId(classStudentIdTxt);

            if (courseId != null && studentId != null && TableExists("StudentCourses"))
            {
                string queryString =

                    "insert into StudentCourses " +
                    "(" +
                            "StudentId," +
                            "CourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{studentId}, " +
                            $"{courseId} " +
                    ")";

                ExecuteCommand(queryString, "Insert into StudentCourses table Successfully");
            }
        }

        /// <summary>
        /// افزودن رابطه استاد با دانشجو در دیتابیس
        /// </summary>
        private void addTakeBtn_Click(object sender, EventArgs e)
        {
            int? teacherId = GetId(takeTeacherIdTxt);
            int? studentId = GetId(takeStudentIdTxt);

            if (teacherId != null && studentId != null && TableExists("StudentTeachers"))
            {
                string queryString =

                    "insert into StudentTeachers " +
                    "(" +
                            "StudentId," +
                            "TeacherId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{studentId}, " +
                            $"{teacherId} " +
                    ")";

                ExecuteCommand(queryString, "Insert into StudentTeachers table Successfully");
            }
        }
        #endregion Joining Tables

        #endregion Insert

        #region Update // توابع تغییر اطلاعات جداول

        #region Main Tables
        /// <summary>
        /// تغییر اطلاعات مسول آموزش
        /// </summary>
        private void editHeadTeachBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("HeadTeachs"))
            {
                int? id = GetId(headTeachIdTxt);
                if (id != null)
                {
                    List<HeadTeach> headTeachs = SelectHeadTeach((int)id);
                    if (headTeachs != null && headTeachs.Count > 0)
                    {
                        // اطلاعات گرفته شده بر اساس آیدی را به صفحه بعدی میفرستد تا بتوان آنها را تصحیح کرد
                        HeadTeachForm htForm = new HeadTeachForm(Connection, headTeachs[0],
                                                             headTeachs[0].HeadTeachId);
                        htForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Head of Teach not found");
                    }
                }
            }
        }

        /// <summary>
        /// تغییر اطلاعات دانشجو
        /// </summary>
        private void editStudentBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("Students"))
            {
                int? id = GetId(studentIdTxt);
                if (id != null)
                {
                    List<Student> students = SelectStudent((int)id);
                    if (students != null && students.Count > 0)
                    {
                        // اطلاعات گرفته شده بر اساس آیدی را به صفحه بعدی میفرستد تا بتوان آنها را تصحیح کرد
                        StudentForm sForm = new StudentForm(Connection, students[0],
                                                             students[0].StudentId);
                        sForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Student not found");
                    }
                }
            }
        }

        /// <summary>
        /// تغییر اطلاعات استاد
        /// </summary>
        private void editTeacherBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("Teachers"))
            {
                int? id = GetId(teacherIdTxt);
                if (id != null)
                {
                    List<Teacher> teachers = SelectTeacher((int)id);
                    if (teachers != null && teachers.Count > 0)
                    {
                        // اطلاعات گرفته شده بر اساس آیدی را به صفحه بعدی میفرستد تا بتوان آنها را تصحیح کرد
                        TeacherForm tForm = new TeacherForm(Connection, teachers[0],
                                                             teachers[0].TeacherId);
                        tForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Teacher not found");
                    }
                }
            }
        }

        /// <summary>
        /// تغییر اطلاعات درس
        /// </summary>
        private void editCourseBtn_Click(object sender, EventArgs e)
        {
            if (TableExists("Courses"))
            {
                int? id = GetId(courseIdTxt);
                if (id != null)
                {
                    List<Course> courses = SelectCourse((int)id);
                    if (courses != null && courses.Count > 0)
                    {
                        // اطلاعات گرفته شده بر اساس آیدی را به صفحه بعدی میفرستد تا بتوان آنها را تصحیح کرد
                        CourseForm cForm = new CourseForm(Connection, courses[0],
                                                             courses[0].CourseId);
                        cForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Course not found");
                    }
                }
            }
        }
        #endregion Main Tables

        #endregion



        #region Other Methods
        /// <summary>
        /// تابعی برای چک کردن وجود داشتن جدول در دیتابیس
        /// </summary>
        /// <param name="tableName">نام جدول مورد نظر</param>
        /// <returns>در صورت وجود داشتن جدول مقدار صحیح و در صورت وجود نداشتن مقدار غلط را بر میگرداند</returns>
        private bool TableExists(string tableName)
        {
            string queryString =
                    $"select 1 from {tableName}";

            try
            {
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query
                cm.ExecuteScalar();

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Table does not exists in database");
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// تابعی برای اجرای دستورات Sql و مدیریت خطاها
        /// </summary>
        /// <param name="queryString">رشته دستورات SQL</param>
        /// <param name="message">پیغام مناسب در صورت اجرا شدن بدون خطای دستور</param>
        private void ExecuteCommand(string queryString, string message)
        {
            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                SqlCommand cm = new SqlCommand(queryString, Connection, transaction);

                // Executing the SQL query
                cm.ExecuteNonQuery();

                transaction.Commit();

                // Displaying a message
                MessageBox.Show(message);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// تابعی برای مدیریت خطاهای پاس دادن آیدی به صفحه دوم
        /// در صورت بروز خطا ابتدا پیغام چاپ میشود و سپس مقدار null بازگردانده میشود
        /// </summary>
        /// <param name="idTxt">باکسی که مقدار آیدی در آن قرار دارد</param>
        /// <returns></returns>
        private int? GetId(TextBox idTxt)
        {
            int? id = null;

            if (idTxt == null || string.IsNullOrEmpty(idTxt.Text))
            {
                MessageBox.Show("Id is empty");
                return null;
            }

            try
            {
                id = Convert.ToInt32(idTxt.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter integer positive number");
                return null;
            }

            if (id < 1)
            {
                MessageBox.Show("Please enter integer positive number");
                return null;
            }

            return id;
        }
        #endregion

        /// <summary>
        /// پیغام نمایش داده شده هنگام لود صفحه اصلی
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("برای استفاده از آیتم های قرمز رن(حذف و اضافه و انتخاب) میبایست آیدی مورد نظر را وارد کنید" +
                "دو آیتم اول هر جدول برای حذف و اضافه جدول در دیتابیس هستند" +
                "مکان نوشتن آیدی برای هر جدول زیر آن قرار دارد");
        }
    }
}
