using Models;
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
                //string headTeach = boxHeadTeachId.SelectedItem.ToString();
                //int headTeachId = int.Parse(headTeach.Substring(headTeach.Length - 1));
                int headTeachId = (int)boxHeadTeachId.SelectedItem;

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
                    MessageBox.Show("مشکلی در افزودن اطلاعات بوجود آمده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormCourse_Load(object sender, EventArgs e)
        {
            if (CourseId == null)
            {
                this.Text = "افزودن دانشجو";

                // اضافه کردن مسولین آموزش
                DataTable headTeachsTable = headTeachsRepo.SelectAll();
                foreach (DataRow item in headTeachsTable.Rows)
                {
                    //boxHeadTeachId.Items.Add($"{item.ItemArray[1]} {item.ItemArray[2]} - id({item.ItemArray[0]})");
                    boxHeadTeachId.Items.Add(item.ItemArray[0]);
                }
                //
            }
            else
            {
                this.Text = "ویرایش درس";

                DataTable courseTable = coursesRepo.SelectById((int)CourseId);
                txtTitle.Text = courseTable.Rows[0][1].ToString();
                txtCredit.Value = (byte)courseTable.Rows[0][2];
                creditType.Checked = (bool)courseTable.Rows[0][3];

                // اضافه کردن مسولین آموزش
                DataTable headTeachsTable = headTeachsRepo.SelectAll();
                foreach (DataRow item in headTeachsTable.Rows)
                {
                    //boxHeadTeachId.Items.Add($"{item.ItemArray[1]} {item.ItemArray[2]} - id({item.ItemArray[0]})");
                    boxHeadTeachId.Items.Add(item.ItemArray[0]);
                }

                DataRow headTeach = headTeachsRepo.SelectById((int)courseTable.Rows[0][4]).Rows[0];

                //boxHeadTeachId.SelectedItem = $"{headTeach.ItemArray[1]} {headTeach.ItemArray[2]} - id({headTeach.ItemArray[0]})";
                boxHeadTeachId.SelectedItem = headTeach.ItemArray[0];
                //

                btnConfirm.Text = "ویرایش";
            }
        }
    }
}
