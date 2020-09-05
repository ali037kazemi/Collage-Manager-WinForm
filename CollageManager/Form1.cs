using CollageManager.JoiningForms;
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

        private IHeadTeachsRepo headTeachsRepo;
        private IStudentsRepo studentsRepo;
        private ITeachersRepo teachersRepo;
        private ICoursesRepo coursesRepo;
        private IExistingCoursesRepo existingCoursesRepo;
        private IStudentCoursesRepo studentCoursesRepo;
        private IStudentTeacherRepo studentTeacherRepo;
        private IPreCoursesRepo preCoursesRepo;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">Connection for connecting to Database</param>
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
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

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

        /// <summary>
        /// بارگذاری و تعیین اطلاعات مربوط به هر جدول با توجه به آیتم انتخابی
        /// </summary>
        private void SetRelationListsData()
        {
            if (rBtnHeadTeachs.Checked)
            {
                SetHeadTeachsRelationList();
            }
            else if (rBtnStudents.Checked)
            {
                SetStudentsRelationList();
            }
            else if (rBtnTeachers.Checked)
            {
                SetTeachersRelationList();
            }
            else if (rBtnCourses.Checked)
            {
                SetCoursesRelationList();
            }
        }

        /// <summary>
        /// باگذاری دوباره اطلاعات
        /// </summary>
        private void BindGrid()
        {
            if (rBtnHeadTeachs.Checked)
            {
                gridView.DataSource = headTeachsRepo.SelectAll();
                SetHeadTeachs(this.gridView);
                SetHeadTeachsRelationList();
            }
            if (rBtnStudents.Checked)
            {
                gridView.DataSource = studentsRepo.SelectAll();
                SetStudents(this.gridView);
                SetStudentsRelationList();
            }
            if (rBtnTeachers.Checked)
            {
                gridView.DataSource = teachersRepo.SelectAll();
                SetTeachers(this.gridView);
                SetTeachersRelationList();
            }
            if (rBtnCourses.Checked)
            {
                gridView.DataSource = coursesRepo.SelectAll();
                SetCourses(this.gridView);
                SetCoursesRelationList();
            }
        }

        #region Set Relation Lists Data

        // دو دکمه حذف و درج برای یک سری از جداول تنها وجود دارد و در بقیه موارد دکمه ها نمایان نیستند
        // به علت آنکه به عنوان مثال ما نمیتوانیم از قسمت ارتباط دانشجوها با اساتید تغییری بوجود بیاوریم
        // زیرا این تغییرات با توجه به تغییرات دروس اخذ شده به طور خودکار انجام میشوند

        private void SetHeadTeachsRelationList()
        {
            btnAddRelation.Visible = false;
            btnDeleteRelation.Visible = false;
            if (gridView.CurrentRow != null)
            {
                int id = 0;
                if (gridView.CurrentRow.Cells[0].Value != null)
                {
                    id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                }

                switch (cmbRelationList.SelectedIndex)
                {
                    case 0:// نمایش دانشجویانی که زیر نظر این مسول آموزش هستند
                    gridViewRelation.DataSource = headTeachsRepo.SelectAllStudents(id);
                    SetStudents(gridViewRelation);
                    break;

                    case 1:// نمایش دروسی که زیر نظر این مسول آموزش هستند
                    gridViewRelation.DataSource = headTeachsRepo.SelectAllCourses(id);
                    SetCourses(gridViewRelation);
                    break;

                    default:
                    cmbRelationList.SelectedIndex = 0;
                    break;
                }
            }
        }

        private void SetStudentsRelationList()
        {
            if (gridView.CurrentRow != null)
            {
                int id = 0;
                if (gridView.CurrentRow.Cells[0].Value != null)
                {
                    id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                }

                switch (cmbRelationList.SelectedIndex)
                {
                    case 0:// نمایش اساتیدی که در ارتباط با این دانشجو هستند
                    btnAddRelation.Visible = false;
                    btnDeleteRelation.Visible = false;
                    gridViewRelation.DataSource = studentsRepo.SelectAllTeachers(id);
                    SetTeachers(gridViewRelation);
                    break;

                    case 1:// نمایش دروسی که توسط دانشجو اخذ شده اند
                    btnAddRelation.Visible = true;
                    btnDeleteRelation.Visible = true;
                    gridViewRelation.DataSource = studentsRepo.SelectAllCourses(id);
                    SetCourses(gridViewRelation);
                    break;

                    default:
                    btnAddRelation.Visible = false;
                    btnDeleteRelation.Visible = false;
                    cmbRelationList.SelectedIndex = 0;
                    break;
                }
            }
        }

        private void SetTeachersRelationList()
        {
            if (gridView.CurrentRow != null)
            {
                int id = 0;
                if (gridView.CurrentRow.Cells[0].Value != null)
                {
                    id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                }

                switch (cmbRelationList.SelectedIndex)
                {
                    case 0:// نمایش دانشجویانی که با استاد در ارتباط هستند
                    btnAddRelation.Visible = false;
                    btnDeleteRelation.Visible = false;
                    gridViewRelation.DataSource = teachersRepo.SelectAllStudents(id);
                    SetStudents(gridViewRelation);
                    break;

                    case 1:// نمایش دروسی که این استاد ارایه داده است
                    btnAddRelation.Visible = true;
                    btnDeleteRelation.Visible = true;
                    gridViewRelation.DataSource = teachersRepo.SelectAllCourses(id);
                    SetCourses(gridViewRelation);
                    break;

                    default:
                    btnAddRelation.Visible = false;
                    btnDeleteRelation.Visible = false;
                    cmbRelationList.SelectedIndex = 0;
                    break;
                }
            }
        }

        private void SetCoursesRelationList()
        {
            if (gridView.CurrentRow != null)
            {
                btnAddRelation.Visible = true;
                btnDeleteRelation.Visible = true;
                int id = 0;
                if (gridView.CurrentRow.Cells[0].Value != null)
                {
                    id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
                }

                switch (cmbRelationList.SelectedIndex)
                {
                    case 0:// نمایش تمام دانشجویانی که این درس را اخذ کرده اند
                    gridViewRelation.DataSource = coursesRepo.SelectAllStudents(id);
                    SetStudents(gridViewRelation);
                    break;

                    case 1:// نمایش اساتیدی که این درس را ارایه داده اند
                    gridViewRelation.DataSource = coursesRepo.SelectAllTeachers(id);
                    SetTeachers(gridViewRelation);
                    break;

                    case 2:// نمایش دروسی پیشنیاز این دروس
                    gridViewRelation.DataSource = coursesRepo.SelectAllRequiredCourses(id);
                    SetCourses(gridViewRelation);
                    break;

                    default:
                    btnAddRelation.Visible = false;
                    btnDeleteRelation.Visible = false;
                    cmbRelationList.SelectedIndex = 0;
                    break;
                }
            }
        }
        #endregion

        #region Set GridView Culomn Values

        /// <summary>
        /// اطلاعات ستون های dataGridView که در ورودی می آید را با توجه با نوع جدول(مسول آموزش) تنظیم میکند
        /// </summary>
        /// <param name="gridView">محل ذخیره و نمایش اطلاعات خوانده شده از دیتابیس</param>
        private void SetHeadTeachs(DataGridView gridView)
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

        /// <summary>
        /// اطلاعات ستون های dataGridView که در ورودی می آید را با توجه با نوع جدول(دانشجویان) تنظیم میکند
        /// </summary>
        /// <param name="gridView">محل ذخیره و نمایش اطلاعات خوانده شده از دیتابیس</param>
        private void SetStudents(DataGridView gridView)
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

        /// <summary>
        /// اطلاعات ستون های dataGridView که در ورودی می آید را با توجه با نوع جدول(اساتید) تنظیم میکند
        /// </summary>
        /// <param name="gridView">محل ذخیره و نمایش اطلاعات خوانده شده از دیتابیس</param>
        private void SetTeachers(DataGridView gridView)
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

        /// <summary>
        /// اطلاعات ستون های dataGridView که در ورودی می آید را با توجه با نوع جدول(دروس) تنظیم میکند
        /// </summary>
        /// <param name="gridView">محل ذخیره و نمایش اطلاعات خوانده شده از دیتابیس</param>
        private void SetCourses(DataGridView gridView)
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

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            if (CreatDatabase())
            {
                if (CreateTables())
                {
                    // بارگیری اطلاعات
                    BindGrid();
                }
                else
                {
                    MessageBox.Show("مشکلی در ساخت جداول بوجود آمده است بوجود آمده است");
                }
            }
            else
            {
                MessageBox.Show("مشکلی بوجود آمده است");
            }
        }

        /// <summary>
        /// رویداد اضافه کردن اطلاعات به جداول اصلی
        /// </summary>
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

        /// <summary>
        /// رویداد ویرایش کردن اطلاعات جداول اصلی
        /// </summary>
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

        /// <summary>
        /// رویداد حذف کردن از اطلاعات جداول اصلی
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // اگر رکوردی برای حذف انتخاب شده بود
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
            }
            else
            {
                MessageBox.Show("ابتدا یک لیست را برای جستجو انتخاب کنید", "اخطار");
            }
        }

        /// <summary>
        /// رویداد به روز رسانی اطلاعات
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// رویداد اضافه کردن اطلاعات به جداول فرعی(رابطه چند به چند)
        /// </summary>
        private void btnAddRelation_Click(object sender, EventArgs e)
        {
            // ابتدا برای اطلاعات جدول پایین که امکان تغییر جداول هست چک میکند
            // سپس بعد از انجام عملیات افزودن اطلاعات دوباره اطلاعات بارگذاری میشود
            if ((rBtnCourses.Checked && cmbRelationList.SelectedIndex == 1) ||
                (rBtnTeachers.Checked && cmbRelationList.SelectedIndex == 1))
            {
                FormExistingCourse form = new FormExistingCourse(Connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            if ((rBtnCourses.Checked && cmbRelationList.SelectedIndex == 2))
            {
                FormRequiredCourse form = new FormRequiredCourse(Connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            if ((rBtnCourses.Checked && cmbRelationList.SelectedIndex == 0) ||
                (rBtnStudents.Checked && cmbRelationList.SelectedIndex == 1))
            {
                FormStudentCourse form = new FormStudentCourse(Connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void cmbRelationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRelationListsData();
        }

        private void gridView_SelectionChanged(object sender, EventArgs e)
        {
            SetRelationListsData();
        }

        private void radioBtnMouseClick(object sender, MouseEventArgs e)
        {
            cmbRelationList.Items.Clear();// با تغییر لیست اطلاعات ستونها پاک میشوند و از نو دوباره تنظیم میشوند

            // تنظیم لیست انتخاب اطلاعات جداول فرعی(رابطه چند به چند)
            if (rBtnHeadTeachs.Checked)
            {
                cmbRelationList.Items.Add("دانشجویان");
                cmbRelationList.Items.Add("دروس");
            }
            else if (rBtnStudents.Checked)
            {
                cmbRelationList.Items.Add("اساتید");
                cmbRelationList.Items.Add("دروس");
            }
            else if (rBtnTeachers.Checked)
            {
                cmbRelationList.Items.Add("دانشجویان");
                cmbRelationList.Items.Add("دروس");
            }
            else if (rBtnCourses.Checked)
            {
                cmbRelationList.Items.Add("دانشجویان");
                cmbRelationList.Items.Add("اساتید");
                cmbRelationList.Items.Add("دروس پیشنیاز");
            }
            
            // سپس اطلاعات دوباره باگذاری میشود
            BindGrid();
        }

        /// <summary>
        /// رویداد حذف اطلاعات از جداول فرعی(رابطه چند به چند)
        /// </summary>
        private void btnDeleteRelation_Click(object sender, EventArgs e)
        {
            //if ((rBtnCourses.Checked && cmbRelationList.SelectedIndex == 1) ||
            //    (rBtnTeachers.Checked && cmbRelationList.SelectedIndex == 1))
            //{
            //    string fullName = gridView.CurrentRow.Cells[1].Value.ToString() + " " +
            //            gridView.CurrentRow.Cells[2].Value.ToString();
            //    if (MessageBox.Show($"آیا از حذف {fullName} مطمین هستید؟", "توجه",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //    {
            //        int id = int.Parse(gridView.CurrentRow.Cells[0].Value.ToString());
            //        if (!headTeachsRepo.Delete(id))
            //        {
            //            MessageBox.Show("مشکلی در حذف رکورد پیش آمده است. درخواست اجرا نشد.\n(ممکن است تداخلی با اطلاعات دیگر بوجود آمده باشد)", "خطا",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //if ((rBtnCourses.Checked && cmbRelationList.SelectedIndex == 2))
            //{
            //    FormRequiredCourse form = new FormRequiredCourse(Connection);
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        BindGrid();
            //    }
            //}
            //if ((rBtnCourses.Checked && cmbRelationList.SelectedIndex == 0) ||
            //    (rBtnStudents.Checked && cmbRelationList.SelectedIndex == 1))
            //{
            //    FormStudentCourse form = new FormStudentCourse(Connection);
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        BindGrid();
            //    }
            //}
        }
        #endregion Events
    }
}
