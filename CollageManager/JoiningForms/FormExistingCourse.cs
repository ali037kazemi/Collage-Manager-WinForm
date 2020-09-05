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
    public partial class FormExistingCourse : Form {

        public SqlConnection Connection { get; }
        private ITeachersRepo teachersRepo;
        private ICoursesRepo coursesRepo;
        private IExistingCoursesRepo existingCoursesRepo;

        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }

        public FormExistingCourse(SqlConnection connection)
        {
            Connection = connection;
            teachersRepo = new TeachersRepo(connection);
            coursesRepo = new CoursesRepo(connection);
            existingCoursesRepo = new ExistingCoursesRepo(connection);
            InitializeComponent();
        }

        private void FormExistingCourse_Load(object sender, EventArgs e)
        {
            // Set Teachers Data
            dgvTeachers.AutoGenerateColumns = false;

            dgvTeachers.DataSource = teachersRepo.SelectAll();

            #region
            DataGridViewTextBoxColumn TeacherId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn FirstName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Family = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn NationalCode = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn FatherName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PhoneNumber = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Address = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Degree = new DataGridViewTextBoxColumn();
            #endregion

            dgvTeachers.Columns.Clear();
            dgvTeachers.Columns.AddRange(new DataGridViewColumn[] {
                TeacherId,
                FirstName,
                Family,
                NationalCode,
                FatherName,
                PhoneNumber,
                Address,
                Degree
            });

            #region
            // 
            // TeacherId
            // 
            TeacherId.DataPropertyName = "TeacherId";
            TeacherId.HeaderText = "کد استاد";
            TeacherId.Name = "TeacherId";
            TeacherId.ReadOnly = true;
            TeacherId.Visible = false;
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
            NationalCode.Visible = false;
            // 
            // FatherName
            // 
            FatherName.DataPropertyName = "FatherName";
            FatherName.HeaderText = "نام پدر";
            FatherName.Name = "FatherName";
            FatherName.ReadOnly = true;
            FatherName.Visible = false;
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
            // Degree
            // 
            Degree.DataPropertyName = "Degree";
            Degree.HeaderText = "مدرک تحصیلی";
            Degree.Name = "Degree";
            Degree.ReadOnly = true;
            #endregion

            // Set Courses Data
            dgvCourses.AutoGenerateColumns = false;

            dgvCourses.DataSource = coursesRepo.SelectAll();

            #region
            DataGridViewTextBoxColumn CourseId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Title = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn CreditType = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn HeadTeachId = new DataGridViewTextBoxColumn();
            #endregion

            dgvCourses.Columns.Clear();
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] {
                CourseId,
                Title,
                Credit,
                CreditType,
                HeadTeachId
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
            // HeadTeachId
            // 
            HeadTeachId.DataPropertyName = "HeadTeachId";
            HeadTeachId.HeaderText = "کد مسول آموزش";
            HeadTeachId.Name = "HeadTeachId";
            HeadTeachId.ReadOnly = true;
            #endregion
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int teacherId;
            if (dgvTeachers.CurrentRow != null)
            {
                teacherId = (int)dgvTeachers.CurrentRow.Cells[0].Value;
            }
            else
            {
                MessageBox.Show("لطفا ابتدا یک استاد را انتخاب کنید");
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

            existingCoursesRepo.Insert(teacherId, courseId);
            DialogResult = DialogResult.OK;
        }
    }
}
