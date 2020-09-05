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
    public partial class FormRequiredCourse : Form {

        public SqlConnection Connection { get; }
        private ICoursesRepo coursesRepo;
        private IPreCoursesRepo preCoursesRepo;

        public FormRequiredCourse(SqlConnection connection)
        {
            coursesRepo = new CoursesRepo(connection);
            preCoursesRepo = new PreCoursesRepo(connection);
            InitializeComponent();
        }

        private void FormRequiredCourse_Load(object sender, EventArgs e)
        {
            // Set Main Course Data
            dgvMainCourses.AutoGenerateColumns = false;

            dgvMainCourses.DataSource = coursesRepo.SelectAll();

            #region
            DataGridViewTextBoxColumn CourseId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Title = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn CreditType = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn HeadTeachId = new DataGridViewTextBoxColumn();
            #endregion

            dgvMainCourses.Columns.Clear();
            dgvMainCourses.Columns.AddRange(new DataGridViewColumn[] {
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

            // Set Required Course Data
            dgvRequiredCourses.AutoGenerateColumns = false;

            dgvRequiredCourses.DataSource = coursesRepo.SelectAll();

            #region
            DataGridViewTextBoxColumn PreCourseId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PreTitle = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PreCredit = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PreCreditType = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn PreHeadTeachId = new DataGridViewTextBoxColumn();
            #endregion

            dgvRequiredCourses.Columns.Clear();
            dgvRequiredCourses.Columns.AddRange(new DataGridViewColumn[] {
                PreCourseId,
                PreTitle,
                PreCredit,
                PreCreditType,
                PreHeadTeachId
            });

            #region
            // 
            // PreCourseId
            // 
            PreCourseId.DataPropertyName = "CourseId";
            PreCourseId.HeaderText = "کد درس";
            PreCourseId.Name = "CourseId";
            PreCourseId.ReadOnly = true;
            PreCourseId.Visible = false;
            // 
            // PreTitle
            // 
            PreTitle.DataPropertyName = "Title";
            PreTitle.HeaderText = "عنوان";
            PreTitle.Name = "Title";
            PreTitle.ReadOnly = true;
            // 
            // PreCredit
            // 
            PreCredit.DataPropertyName = "Credit";
            PreCredit.HeaderText = "واحد";
            PreCredit.Name = "Credit";
            PreCredit.ReadOnly = true;
            // 
            // PreCreditType
            // 
            PreCreditType.DataPropertyName = "CreditType";
            PreCreditType.HeaderText = "نوع";
            PreCreditType.Name = "CreditType";
            PreCreditType.ReadOnly = true;
            // 
            // PreHeadTeachId
            // 
            PreHeadTeachId.DataPropertyName = "HeadTeachId";
            PreHeadTeachId.HeaderText = "کد مسول آموزش";
            PreHeadTeachId.Name = "HeadTeachId";
            PreHeadTeachId.ReadOnly = true;
            #endregion
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int mainCourseId;
            if (dgvMainCourses.CurrentRow != null)
            {
                mainCourseId = (int)dgvMainCourses.CurrentRow.Cells[0].Value;
            }
            else
            {
                MessageBox.Show("لطفا ابتدا یک درس را انتخاب کنید");
                return;
            }

            int preCourseId;
            if (dgvRequiredCourses.CurrentRow != null)
            {
                preCourseId = (int)dgvRequiredCourses.CurrentRow.Cells[0].Value;
            }
            else
            {
                MessageBox.Show("لطفا ابتدا یک درس را برای پیشنیاز شدن انتخاب کنید");
                return;
            }

            preCoursesRepo.Insert(mainCourseId, preCourseId);
            DialogResult = DialogResult.OK;
        }
    }
}
