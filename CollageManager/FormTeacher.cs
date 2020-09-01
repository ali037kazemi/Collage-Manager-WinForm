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
    public partial class FormTeacher : Form {

        public SqlConnection Connection { get; }
        private ITeachersRepo teachersRepo;
        public int? TeacherId { get; set; }

        public FormTeacher(SqlConnection connection)
        {
            TeacherId = null;
            Connection = connection;
            teachersRepo = new TeachersRepo(connection);
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFamily.Text))
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFatherName.Text))
            {
                MessageBox.Show("لطفا نام پدر را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                MessageBox.Show("لطفا کد ملی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("لطفا شماره تلفن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDegree.Text))
            {
                MessageBox.Show("لطفا مدرک تحصیلی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("لطفا آدرس را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                Teacher t = new Teacher(txtNationalCode.Text, txtName.Text, txtFamily.Text,
                            txtFatherName.Text, txtPhone.Text, txtAddress.Text, txtDegree.Text);

                bool isSuccess;

                if (TeacherId == null)
                {
                    isSuccess = teachersRepo.Insert(t);
                }
                else
                {
                    isSuccess = teachersRepo.Update((int)TeacherId, t);
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

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            if (TeacherId == null)
            {
                this.Text = "افزودن استاد";
            }
            else
            {
                this.Text = "ویرایش استاد";

                DataTable table = teachersRepo.SelectById((int)TeacherId);
                txtName.Text = table.Rows[0][2].ToString();
                txtFamily.Text = table.Rows[0][3].ToString();
                txtFatherName.Text = table.Rows[0][4].ToString();
                txtNationalCode.Text = table.Rows[0][1].ToString();
                txtPhone.Text = table.Rows[0][5].ToString();
                txtAddress.Text = table.Rows[0][6].ToString();
                txtDegree.Text = table.Rows[0][7].ToString();
                btnConfirm.Text = "ویرایش";
            }
        }
    }
}
