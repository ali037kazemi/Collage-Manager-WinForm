using Models2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollageManager.JoiningForms {
    public partial class FormStudentCourse : Form {

        public SqlConnection Connection { get; }
        private ICoursesRepo coursesRepo;
        private IStudentsRepo studentsRepo;
        private IStudentCoursesRepo studentCoursesRepo;

        public FormStudentCourse(SqlConnection connection)
        {
            Connection = connection;
            coursesRepo = new CoursesRepo(connection);
            studentsRepo = new StudentsRepo(connection);
            studentCoursesRepo = new StudentCoursesRepo(connection);
            InitializeComponent();
        }

        private void FormStudentCourse_Load(object sender, EventArgs e)
        {
            // Set Students Data
            dgvStudents.AutoGenerateColumns = false;

            dgvStudents.DataSource = studentsRepo.SelectAll();

            #region
            DataGridViewTextBoxColumn StudentId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn FirstName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Family = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn NationalCode = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn FatherName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PhoneNumber = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Address = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn EntryYear = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PostalCode = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Field = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Grade = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn HeadTeachId = new DataGridViewTextBoxColumn();
            #endregion

            dgvStudents.Columns.Clear();
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] {
                StudentId,
                FirstName,
                Family,
                NationalCode,
                FatherName,
                PhoneNumber,
                Address,
                EntryYear,
                PostalCode,
                Field,
                Grade,
                HeadTeachId
            });

            #region
            // 
            // StudentId
            // 
            StudentId.DataPropertyName = "StudentId";
            StudentId.HeaderText = "کد دانشجو";
            StudentId.Name = "StudentId";
            StudentId.ReadOnly = true;
            StudentId.Visible = false;
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "Name";
            FirstName.HeaderText = "نام";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            // 
            // Family
            // 
            Family.DataPropertyName = "Family";
            Family.HeaderText = "نام خانوادگی";
            Family.Name = "Family";
            Family.ReadOnly = true;
            // 
            // NationalCode
            // 
            NationalCode.DataPropertyName = "NationalCode";
            NationalCode.HeaderText = "کد ملی";
            NationalCode.Name = "NationalCode";
            NationalCode.ReadOnly = true;
            //NationalCode.Visible = false;
            // 
            // FatherName
            // 
            FatherName.DataPropertyName = "FatherName";
            FatherName.HeaderText = "نام پدر";
            FatherName.Name = "FatherName";
            FatherName.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.HeaderText = "شماره تلفن";
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            PhoneNumber.Visible = false;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "آدرس";
            Address.Name = "Address";
            Address.ReadOnly = true;
            Address.Visible = false;
            // 
            // EntryYear
            // 
            EntryYear.DataPropertyName = "EntryYear";
            EntryYear.HeaderText = "سال ورود";
            EntryYear.Name = "EntryYear";
            EntryYear.ReadOnly = true;
            // 
            // PostalCode
            // 
            PostalCode.DataPropertyName = "PostalCode";
            PostalCode.HeaderText = "کد پستی";
            PostalCode.Name = "PostalCode";
            PostalCode.ReadOnly = true;
            PostalCode.Visible = false;
            // 
            // Field
            // 
            Field.DataPropertyName = "Field";
            Field.HeaderText = "رشته تحصیلی";
            Field.Name = "Field";
            Field.ReadOnly = true;
            // 
            // Grade
            // 
            Grade.DataPropertyName = "Grade";
            Grade.HeaderText = "مقطع تحصیلی";
            Grade.Name = "Grade";
            Grade.ReadOnly = true;
            // 
            // HeadTeachId
            // 
            HeadTeachId.DataPropertyName = "HeadTeachId";
            HeadTeachId.HeaderText = "کد مسول آموزش";
            HeadTeachId.Name = "HeadTeachId";
            HeadTeachId.ReadOnly = true;
            #endregion

            // Set Teachers Data
            dgvCourses.AutoGenerateColumns = false;

            dgvCourses.DataSource = coursesRepo.SelectAll();

            #region
            DataGridViewTextBoxColumn CourseId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Title = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn CreditType = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn CourseHeadTeachId = new DataGridViewTextBoxColumn();
            #endregion

            dgvCourses.Columns.Clear();
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] {
                CourseId,
                Title,
                Credit,
                CreditType,
                CourseHeadTeachId
            });

            #region
            // 
            // CourseId
            // 
            CourseId.DataPropertyName = "CourseId";
            CourseId.HeaderText = "کد درس";
            CourseId.Name = "CourseId";
            CourseId.ReadOnly = true;
            CourseId.Visible = false;
            // 
            // Title
            // 
            Title.DataPropertyName = "Title";
            Title.HeaderText = "عنوان";
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Credit
            // 
            Credit.DataPropertyName = "Credit";
            Credit.HeaderText = "واحد";
            Credit.Name = "Credit";
            Credit.ReadOnly = true;
            // 
            // CreditType
            // 
            CreditType.DataPropertyName = "CreditType";
            CreditType.HeaderText = "نوع";
            CreditType.Name = "CreditType";
            CreditType.ReadOnly = true;
            // 
            // CourseHeadTeachId
            // 
            CourseHeadTeachId.DataPropertyName = "HeadTeachId";
            CourseHeadTeachId.HeaderText = "کد مسول آموزش";
            CourseHeadTeachId.Name = "HeadTeachId";
            CourseHeadTeachId.ReadOnly = true;
            #endregion
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int studentId;
            if (dgvStudents.CurrentRow != null)
            {
                studentId = (int)dgvStudents.CurrentRow.Cells[0].Value;
            }
            else
            {
                MessageBox.Show("لطفا ابتدا یک دانشجو را انتخاب کنید");
                return;
            }
            int courseId;
            if (dgvCourses.CurrentRow != null)
            {
                courseId = (int)dgvCourses.CurrentRow.Cells[0].Value;
            }
            else
            {
                MessageBox.Show("لطفا ابتدا یک درس را انتخاب کنید");
                return;
            }

            studentCoursesRepo.Insert(studentId, courseId);
            DialogResult = DialogResult.OK;
        }
    }
}
