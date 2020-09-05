using Models2;
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

namespace CollageManager {
    public partial class FormCourse : Form {

        public SqlConnection Connection { get; }
        private ICoursesRepo coursesRepo;
        private IHeadTeachsRepo headTeachsRepo;
        public int? CourseId { get; set; }

        public FormCourse(SqlConnection connection)
        {
            CourseId = null;
            Connection = connection;
            coursesRepo = new CoursesRepo(Connection);
            headTeachsRepo = new HeadTeachsRepo(connection);
            InitializeComponent();
        }

        /// <summary>
        /// چک کردن ورودی های کابر
        /// </summary>
        /// <returns>در صورت وجود ایرادی در ورودی های بعد از نمایش خطا مقدار غلط را برمیگرداند</returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("لطفا عنوان درس را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCredit.Text))
            {
                MessageBox.Show("لطفا تعداد واحد را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //string headTeach = boxHeadTeachId.SelectedItem.ToString();
            //int headTeachId = int.Parse(headTeach.Substring(headTeach.Length - 1));
            if (string.IsNullOrWhiteSpace(boxHeadTeachId.GetItemText(boxHeadTeachId.SelectedItem)) ||
                !boxHeadTeachId.Items.Contains(boxHeadTeachId.SelectedItem))
            {
                MessageBox.Show("لطفا مسول آموزش را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                int headTeachId = (int)boxHeadTeachId.SelectedValue;

                Course c = new Course(txtTitle.Text, (byte)txtCredit.Value, creditType.Checked, headTeachId);

                bool isSuccess;

                if (CourseId == null)
                {
                    isSuccess = coursesRepo.Insert(c);
                }
                else
                {
                    isSuccess = coursesRepo.Update((int)CourseId, c);
                }

                if (isSuccess)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("مشکلی در افزودن یا ویرایش اطلاعات بوجود آمده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormCourse_Load(object sender, EventArgs e)
        {
            #region بارگذاری اطلاعات مسولین آموزش
            boxHeadTeachId.DisplayMember = "FullName";
            boxHeadTeachId.ValueMember = "Id";

            DataTable headTeachsTable = headTeachsRepo.SelectAll();
            ArrayList fullHeadTeachs = new ArrayList();

            foreach (DataRow item in headTeachsTable.Rows)
            {
                var fullHeadTeach = new
                {
                    FullName = item.ItemArray[2].ToString() + " " + item.ItemArray[3].ToString(),
                    Id = (int)item.ItemArray[0]
                };
                fullHeadTeachs.Add(fullHeadTeach);
            }

            boxHeadTeachId.DataSource = fullHeadTeachs;
            #endregion

            if (CourseId == null)
            {
                this.Text = "افزودن درس";
            }
            else
            {
                this.Text = "ویرایش درس";

                DataTable courseTable = coursesRepo.SelectById((int)CourseId);
                txtTitle.Text = courseTable.Rows[0][1].ToString();
                txtCredit.Value = (byte)courseTable.Rows[0][2];
                creditType.Checked = (bool)courseTable.Rows[0][3];

                try
                {
                    boxHeadTeachId.SelectedValue = (int)courseTable.Rows[0][4];
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                btnConfirm.Text = "ویرایش";
            }
        }
    }
}
