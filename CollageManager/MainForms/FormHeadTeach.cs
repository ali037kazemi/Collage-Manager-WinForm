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
    public partial class FormHeadTeach : Form {

        public SqlConnection Connection { get; }
        private IHeadTeachsRepo headTeachsRepo;
        public int? HeadTeachId { get; set; }

        public FormHeadTeach(SqlConnection connection)
        {
            HeadTeachId = null;
            Connection = connection;
            headTeachsRepo = new HeadTeachsRepo(connection);
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
            if (txtNationalCode.Text.Length != 10)
            {
                MessageBox.Show("کد ملی 10 رقم باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("لطفا شماره تلفن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPhone.Text.Length != 11)
            {
                MessageBox.Show("شماره تلفن 11 رقم باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtField.Text))
            {
                MessageBox.Show("لطفا رشته را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                HeadTeach ht = new HeadTeach(txtNationalCode.Text, txtName.Text, txtFamily.Text,
                            txtFatherName.Text, txtPhone.Text, txtAddress.Text, txtField.Text);

                bool isSuccess;

                if (HeadTeachId == null)
                {
                    isSuccess = headTeachsRepo.Insert(ht);
                }
                else
                {
                    isSuccess = headTeachsRepo.Update((int)HeadTeachId, ht);
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

        private void FormHeadTeach_Load(object sender, EventArgs e)
        {
            if (HeadTeachId == null)
            {
                this.Text = "افزودن مسول آموزش";
            }
            else
            {
                this.Text = "ویرایش مسول آموزش";

                DataTable table = headTeachsRepo.SelectById((int)HeadTeachId);
                txtName.Text = table.Rows[0][2].ToString();
                txtFamily.Text = table.Rows[0][3].ToString();
                txtFatherName.Text = table.Rows[0][4].ToString();
                txtNationalCode.Text = table.Rows[0][1].ToString();
                txtPhone.Text = table.Rows[0][5].ToString();
                txtAddress.Text = table.Rows[0][6].ToString();
                txtField.Text = table.Rows[0][7].ToString();
                btnConfirm.Text = "ویرایش";
            }
        }
    }
}
