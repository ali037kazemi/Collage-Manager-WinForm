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

namespace CollageManager {
    public partial class Form1 : Form {

        public SqlConnection Connection { get; }

        IHeadTeachsRepo headTeachsRepo;
        IStudentsRepo studentsRepo;
        ITeachersRepo teachersRepo;
        ICoursesRepo coursesRepo;
        IExistingCoursesRepo existingCoursesRepo;
        IStudentCoursesRepo studentCoursesRepo;
        IStudentTeacherRepo studentTeacherRepo;
        IPreCoursesRepo preCoursesRepo;

        public Form1()
        {
            // Default connection
            Connection =
                    new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

            InitializeComponent();
            headTeachsRepo = new HeadTeachsRepo(Connection);
            studentsRepo = new StudentsRepo(Connection);
            teachersRepo = new TeachersRepo(Connection);
            coursesRepo = new CoursesRepo(Connection);
            existingCoursesRepo = new ExistingCoursesRepo(Connection);
            studentCoursesRepo = new StudentCoursesRepo(Connection);
            studentTeacherRepo = new StudentTeacherRepo(Connection);
            preCoursesRepo = new PreCoursesRepo(Connection);
        }

        public Form1(SqlConnection connection)
        {
            Connection = connection;

            InitializeComponent();
            headTeachsRepo = new HeadTeachsRepo(Connection);
            studentsRepo = new StudentsRepo(Connection);
            teachersRepo = new TeachersRepo(Connection);
            coursesRepo = new CoursesRepo(Connection);
            existingCoursesRepo = new ExistingCoursesRepo(Connection);
            studentCoursesRepo = new StudentCoursesRepo(Connection);
            studentTeacherRepo = new StudentTeacherRepo(Connection);
            preCoursesRepo = new PreCoursesRepo(Connection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CreatDatabase())
            {
                if (CreateTables())
                {
                    BindGrid();
                }
                else
                {
                    MessageBox.Show("مشکلی بوجود آمده است");
                }
            }
            else
            {
                MessageBox.Show("مشکلی بوجود آمده است");
            }
        }

        private bool CreatDatabase()
        {
            string queryString =
                    "use master \n" +
                    "IF DB_ID('Collage') <= 0 " +
                        "CREATE DATABASE Collage ";

            SqlConnection connection =
                    new SqlConnection("data source=.; database=master; integrated security=SSPI");
            try
            {
                connection.Open();
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Executing the SQL query
                cm.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// رفرش کردن اطلاعات
        /// </summary>
        private void BindGrid()
        {
            // خودش ستون ها رو نمیسازه و ما باید بهش بگیم بره از کجا بگیره بسازیم
            gridView.AutoGenerateColumns = false;

            //gridViewRelation.DataSource = existingCoursesRepo.SelectByTeacherId(1);

            if (rBtnHeadTeachs.Checked)
            {
                gridView.DataSource = headTeachsRepo.SelectAll();
                SetHeadTeachs();
                SetRelationListData();
            }
            if (rBtnStudents.Checked)
            {
                gridView.DataSource = studentsRepo.SelectAll();
                SetStudents();
            }
            if (rBtnTeachers.Checked)
            {
                gridView.DataSource = teachersRepo.SelectAll();
                SetTeachers();
            }
            if (rBtnCourses.Checked)
            {
                gridView.DataSource = coursesRepo.SelectAll();
                SetCourses();
            }
        }

        #region Set Grid Culomn Values
        private void SetHeadTeachs()
        {
            #region
            DataGridViewTextBoxColumn HeadTeachId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn FirstName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Family = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn NationalCode = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn FatherName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PhoneNumber = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Address = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn StudyField = new DataGridViewTextBoxColumn();
            #endregion

            gridView.Columns.Clear();
            gridView.Columns.AddRange(new DataGridViewColumn[] {
                HeadTeachId,
                FirstName,
                Family,
                NationalCode,
                FatherName,
                PhoneNumber,
                Address,
                StudyField
            });

            #region
            // 
            // HeadTeachsId
            // 
            HeadTeachId.DataPropertyName = "HeadTeachId";
            HeadTeachId.HeaderText = "کد مسول آموزش";
            HeadTeachId.Name = "HeadTeachsId";
            HeadTeachId.ReadOnly = true;
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
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "آدرس";
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // StudyField
            // 
            StudyField.DataPropertyName = "StudyField";
            StudyField.HeaderText = "رشته";
            StudyField.Name = "StudyField";
            StudyField.ReadOnly = true;
            #endregion
        }

        private void SetStudents()
        {
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

            gridView.Columns.Clear();
            gridView.Columns.AddRange(new DataGridViewColumn[] {
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
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "آدرس";
            Address.Name = "Address";
            Address.ReadOnly = true;
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
        }

        private void SetTeachers()
        {
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

            gridView.Columns.Clear();
            gridView.Columns.AddRange(new DataGridViewColumn[] {
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
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "آدرس";
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // Degree
            // 
            Degree.DataPropertyName = "Degree";
            Degree.HeaderText = "مدرک تحصیلی";
            Degree.Name = "Degree";
            Degree.ReadOnly = true;
            #endregion
        }

        private void SetCourses()
        {
            #region
            DataGridViewTextBoxColumn CourseId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Title = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn CreditType = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn HeadTeachId = new DataGridViewTextBoxColumn();
            #endregion

            gridView.Columns.Clear();
            gridView.Columns.AddRange(new DataGridViewColumn[] {
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
        #endregion

        private bool CreateTables()
        {
            if (!headTeachsRepo.CreateTable())
            {
                return false;
            }
            if (!studentsRepo.CreateTable())
            {
                return false;
            }
            if (!teachersRepo.CreateTable())
            {
                return false;
            }
            if (!coursesRepo.CreateTable())
            {
                return false;
            }
            if (!existingCoursesRepo.CreateTable())
            {
                return false;
            }
            if (!studentCoursesRepo.CreateTable())
            {
                return false;
            }
            if (!studentTeacherRepo.CreateTable())
            {
                return false;
            }
            if (!preCoursesRepo.CreateTable())
            {
                return false;
            }

            return true;
        }





        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void radioBtnMouseClick(object sender, MouseEventArgs e)
        {
            cmbRelationList.Items.Clear();

            cmbRelationList.Items.Add("دانشجویان");
            cmbRelationList.Items.Add("دروس");

            BindGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchStr = txtSearch.Text.Trim();

            if (rBtnHeadTeachs.Checked)
            {
                if (searchStr != "")
                {
                    gridView.DataSource = headTeachsRepo.Search(searchStr);
                }
                else
                {
                    gridView.DataSource = headTeachsRepo.SelectAll();
                }
                //SetHeadTeachs();
            }
            else if (rBtnStudents.Checked)
            {
                if (searchStr != "")
                {
                    gridView.DataSource = studentsRepo.Search(searchStr);
                }
                else
                {
                    gridView.DataSource = studentsRepo.SelectAll();
                }
                //SetStudents();
            }
            else if (rBtnTeachers.Checked)
            {
                if (searchStr != "")
                {
                    gridView.DataSource = teachersRepo.Search(searchStr);
                }
                else
                {
                    gridView.DataSource = teachersRepo.SelectAll();
                }
                //SetTeachers();
            }
            else if (rBtnCourses.Checked)
            {
                if (searchStr != "")
                {
                    gridView.DataSource = coursesRepo.Search(searchStr);
                }
                else
                {
                    gridView.DataSource = coursesRepo.SelectAll();
                }
                //SetCourses();
            }
            else
            {
                MessageBox.Show("ابتدا یک لیست را برای جستجو انتخاب کنید", "اخطار");
            }
        }




        
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (rBtnHeadTeachs.Checked)
            {
                FormHeadTeach form = new FormHeadTeach(Connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else if (rBtnStudents.Checked)
            {
                FormStudent form = new FormStudent(Connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else if (rBtnTeachers.Checked)
            {
                FormTeacher form = new FormTeacher(Connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else if (rBtnCourses.Checked)
            {
                FormCourse form = new FormCourse(Connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک گزینه را برای حذف از لیست انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow != null)
            {
                if (rBtnHeadTeachs.Checked)
                {
                    string fullName = gridView.CurrentRow.Cells[1].Value.ToString() + " " +
                        gridView.CurrentRow.Cells[2].Value.ToString();
                    if (MessageBox.Show($"آیا از حذف {fullName} مطمین هستید؟", "توجه",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        int id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                        if (!headTeachsRepo.Delete(id))
                        {
                            MessageBox.Show("مشکلی در حذف رکورد پیش آمده است. درخواست اجرا نشد.\n(ممکن است تداخلی با اطلاعات دیگر بوجود آمده باشد)", "خطا",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (rBtnStudents.Checked)
                {
                    string fullName = gridView.CurrentRow.Cells[1].Value.ToString() + " " +
                        gridView.CurrentRow.Cells[2].Value.ToString();
                    if (MessageBox.Show($"آیا از حذف {fullName} مطمین هستید؟", "توجه",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        int id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                        if (!studentsRepo.Delete(id))
                        {
                            MessageBox.Show("مشکلی در حذف رکورد پیش آمده است. درخواست اجرا نشد.\n(ممکن است تداخلی با اطلاعات دیگر بوجود آمده باشد)", "خطا",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (rBtnTeachers.Checked)
                {
                    string fullName = gridView.CurrentRow.Cells[1].Value.ToString() + " " +
                        gridView.CurrentRow.Cells[2].Value.ToString();
                    if (MessageBox.Show($"آیا از حذف {fullName} مطمین هستید؟", "توجه",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        int id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                        if (!teachersRepo.Delete(id))
                        {
                            MessageBox.Show("مشکلی در حذف رکورد پیش آمده است. درخواست اجرا نشد.\n(ممکن است تداخلی با اطلاعات دیگر بوجود آمده باشد)", "خطا",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (rBtnCourses.Checked)
                {
                    string title = gridView.CurrentRow.Cells[1].Value.ToString();
                    if (MessageBox.Show($"آیا از حذف {title} مطمین هستید؟", "توجه",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        int id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                        if (!coursesRepo.Delete(id))
                        {
                            MessageBox.Show("مشکلی در حذف رکورد پیش آمده است. درخواست اجرا نشد.\n(ممکن است تداخلی با اطلاعات دیگر بوجود آمده باشد)", "خطا",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                BindGrid();
            }
            else
            {
                MessageBox.Show("لطفا یک گزینه را برای حذف از لیست انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow != null)
            {
                int id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());

                if (rBtnHeadTeachs.Checked)
                {
                    FormHeadTeach form = new FormHeadTeach(Connection);
                    form.HeadTeachId = id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        BindGrid();
                    }
                }
                else if (rBtnStudents.Checked)
                {
                    FormStudent form = new FormStudent(Connection);
                    form.StudentId = id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        BindGrid();
                    }
                }
                else if (rBtnTeachers.Checked)
                {
                    FormTeacher form = new FormTeacher(Connection);
                    form.TeacherId = id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        BindGrid();
                    }
                }
                else if (rBtnCourses.Checked)
                {
                    FormCourse form = new FormCourse(Connection);
                    form.CourseId = id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        BindGrid();
                    }
                }
                else
                {
                    MessageBox.Show("لطفا یک گزینه را برای ویرایش از لیست انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }





        private void SetRelationListData()
        {
            if (rBtnHeadTeachs.Checked)
            {
                SetHeadTeachsRelationList();
            }
            if (rBtnStudents.Checked)
            {
                gridView.DataSource = studentsRepo.SelectAll();
                SetStudents();
            }
            if (rBtnTeachers.Checked)
            {
                gridView.DataSource = teachersRepo.SelectAll();
                SetTeachers();
            }
            if (rBtnCourses.Checked)
            {
                gridView.DataSource = coursesRepo.SelectAll();
                SetCourses();
            }
        }

        #region Set Relation Lists
        private void SetHeadTeachsRelationList()
        {
            if (gridView.CurrentRow != null)
            {
                int id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());

                switch (cmbRelationList.SelectedIndex)
                {
                    case 0:
                    gridViewRelation.DataSource = headTeachsRepo.SelectAllStudents(id);
                    break;

                    case 1:
                    gridViewRelation.DataSource = headTeachsRepo.SelectAllCourses(id);
                    break;

                    default:
                    break;
                }
            }
        }
        #endregion

        private void cmbRelationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHeadTeachsRelationList();
        }
    }
}
