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
    public partial class FormStudent : Form {

        public SqlConnection Connection { get; }
        private IStudentsRepo studentsRepo;
        private IHeadTeachsRepo headTeachsRepo;
        public int? StudentId { get; set; }

        public FormStudent(SqlConnection connection)
        {
            StudentId = null;
            Connection = connection;
            studentsRepo = new StudentsRepo(Connection);
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
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("لطفا شماره تلفن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEntryYear.Text))
            {
                MessageBox.Show("لطفا سال ورود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtField.Text))
            {
                MessageBox.Show("لطفا رشته تحصیلی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGrade.Text))
            {
                MessageBox.Show("لطفا مقطع تحصیلی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                MessageBox.Show("لطفا کد پستی 10 رقمی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //string headTeach = boxHeadTeachId.SelectedItem.ToString();
                //int headTeachId = int.Parse(headTeach.Substring(headTeach.Length - 1));
                int headTeachId = (int)boxHeadTeachId.SelectedItem;

                Student s = new Student(txtNationalCode.Text, txtName.Text, txtFamily.Text,
                            txtFatherName.Text, (short)txtEntryYear.Value, txtPhone.Text, txtAddress.Text,
                            txtPostalCode.Text, txtField.Text, txtGrade.Text, headTeachId);

                bool isSuccess;

                if (StudentId == null)
                {
                    isSuccess = studentsRepo.Insert(s);
                }
                else
                {
                    isSuccess = studentsRepo.Update((int)StudentId, s);
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

        private void FormStudet_Load(object sender, EventArgs e)
        {
            if (StudentId == null)
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
                this.Text = "ویرایش دانشجو";

                DataTable studentTable = studentsRepo.SelectById((int)StudentId);
                txtNationalCode.Text = studentTable.Rows[0][1].ToString();
                txtName.Text = studentTable.Rows[0][2].ToString();
                txtFamily.Text = studentTable.Rows[0][3].ToString();
                txtFatherName.Text = studentTable.Rows[0][4].ToString();
                txtEntryYear.Value = (short)studentTable.Rows[0][5];
                txtPhone.Text = studentTable.Rows[0][6].ToString();
                txtAddress.Text = studentTable.Rows[0][7].ToString();
                txtPostalCode.Text = studentTable.Rows[0][8].ToString();
                txtField.Text = studentTable.Rows[0][9].ToString();
                txtGrade.Text = studentTable.Rows[0][10].ToString();

                // اضافه کردن مسولین آموزش
                DataTable headTeachsTable = headTeachsRepo.SelectAll();
                foreach (DataRow item in headTeachsTable.Rows)
                {
                    //boxHeadTeachId.Items.Add($"{item.ItemArray[1]} {item.ItemArray[2]} - id({item.ItemArray[0]})");
                    boxHeadTeachId.Items.Add(item.ItemArray[0]);
                }

                DataRow headTeach = headTeachsRepo.SelectById((int)studentTable.Rows[0][11]).Rows[0];

                //boxHeadTeachId.SelectedItem = $"{headTeach.ItemArray[1]} {headTeach.ItemArray[2]} - id({headTeach.ItemArray[0]})";
                boxHeadTeachId.SelectedItem = headTeach.ItemArray[0];
                //

                btnConfirm.Text = "ویرایش";
            }
        }

        //private bool ValidateInputs()
        //{
        //    if (string.IsNullOrWhiteSpace(txtName.Text))
        //    {
        //        MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtFamily.Text))
        //    {
        //        MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtFatherName.Text))
        //    {
        //        MessageBox.Show("لطفا نام پدر را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
        //    {
        //        MessageBox.Show("لطفا کد ملی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtPhone.Text))
        //    {
        //        MessageBox.Show("لطفا شماره تلفن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtEntryYear.Text))
        //    {
        //        MessageBox.Show("لطفا سال ورود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtField.Text))
        //    {
        //        MessageBox.Show("لطفا رشته تحصیلی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtGrade.Text))
        //    {
        //        MessageBox.Show("لطفا مقطع تحصیلی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
        //    {
        //        MessageBox.Show("لطفا کد پستی 10 رقمی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    //string headTeach = boxHeadTeachId.SelectedItem.ToString();
        //    //int headTeachId = int.Parse(headTeach.Substring(headTeach.Length - 1));
        //    if (!boxHeadTeachId.Items.Contains(boxHeadTeachId.SelectedItem))
        //    {
        //        MessageBox.Show("لطفا مسول آموزش را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtAddress.Text))
        //    {
        //        MessageBox.Show("لطفا آدرس را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return true;
        //}

        //private void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    if (ValidateInputs())
        //    {
        //        //string headTeach = boxHeadTeachId.SelectedItem.ToString();
        //        //int headTeachId = int.Parse(headTeach.Substring(headTeach.Length - 1));
        //        int headTeachId = ((HeadTeach)boxHeadTeachId.SelectedItem).HeadTeachId;

        //        Student s = new Student(txtNationalCode.Text, txtName.Text, txtFamily.Text,
        //                    txtFatherName.Text, (short)txtEntryYear.Value, txtPhone.Text, txtAddress.Text,
        //                    txtPostalCode.Text, txtField.Text, txtGrade.Text, headTeachId);

        //        bool isSuccess;

        //        if (StudentId == null)
        //        {
        //            isSuccess = studentsRepo.Insert(s);
        //        }
        //        else
        //        {
        //            isSuccess = studentsRepo.Update((int)StudentId, s);
        //        }

        //        if (isSuccess)
        //        {
        //            MessageBox.Show("عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            DialogResult = DialogResult.OK;
        //        }
        //        else
        //        {
        //            MessageBox.Show("مشکلی در افزودن اطلاعات بوجود آمده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //private void FormStudet_Load(object sender, EventArgs e)
        //{
        //    if (StudentId == null)
        //    {
        //        this.Text = "افزودن دانشجو";

        //        // اضافه کردن مسولین آموزش
        //        DataTable headTeachsTable = headTeachsRepo.SelectAll();
        //        foreach (DataRow item in headTeachsTable.Rows)
        //        {
        //            HeadTeach ht = new HeadTeach(
        //                        (int)item.ItemArray[0], item.ItemArray[1].ToString(),
        //                        item.ItemArray[2].ToString(), item.ItemArray[3].ToString(),
        //                        item.ItemArray[4].ToString(), item.ItemArray[5].ToString(),
        //                        item.ItemArray[6].ToString(), item.ItemArray[7].ToString());
        //            boxHeadTeachId.Items.Add(ht);
        //        }
        //        //
        //    }
        //    else
        //    {
        //        this.Text = "ویرایش دانشجو";

        //        DataTable studentTable = studentsRepo.SelectById((int)StudentId);
        //        txtNationalCode.Text = studentTable.Rows[0][1].ToString();
        //        txtName.Text = studentTable.Rows[0][2].ToString();
        //        txtFamily.Text = studentTable.Rows[0][3].ToString();
        //        txtFatherName.Text = studentTable.Rows[0][4].ToString();
        //        txtEntryYear.Value = (short)studentTable.Rows[0][5];
        //        txtPhone.Text = studentTable.Rows[0][6].ToString();
        //        txtAddress.Text = studentTable.Rows[0][7].ToString();
        //        txtPostalCode.Text = studentTable.Rows[0][8].ToString();
        //        txtField.Text = studentTable.Rows[0][9].ToString();
        //        txtGrade.Text = studentTable.Rows[0][10].ToString();

        //        // اضافه کردن مسولین آموزش
        //        DataTable headTeachsTable = headTeachsRepo.SelectAll();
        //        boxHeadTeachId.DataSource = headTeachsTable;
        //        boxHeadTeachId.DisplayMember = "Text";
        //        boxHeadTeachId.ValueMember = "Value";
        //        foreach (DataRow item in headTeachsTable.Rows)
        //        {
        //            HeadTeach ht = new HeadTeach(
        //                        (int)item.ItemArray[0], item.ItemArray[1].ToString(),
        //                        item.ItemArray[2].ToString(), item.ItemArray[3].ToString(),
        //                        item.ItemArray[4].ToString(), item.ItemArray[5].ToString(),
        //                        item.ItemArray[6].ToString(), item.ItemArray[7].ToString());
        //            boxHeadTeachId.Items.Add(ht);
        //        }

        //        DataRow htRow = headTeachsRepo.SelectById((int)studentTable.Rows[0][11]).Rows[0];
        //        HeadTeach headTeach = new HeadTeach(
        //                        (int)htRow.ItemArray[0], htRow.ItemArray[1].ToString(),
        //                        htRow.ItemArray[2].ToString(), htRow.ItemArray[3].ToString(),
        //                        htRow.ItemArray[4].ToString(), htRow.ItemArray[5].ToString(),
        //                        htRow.ItemArray[6].ToString(), htRow.ItemArray[7].ToString());

        //        boxHeadTeachId.SelectedItem = headTeach;
        //        //

        //        btnConfirm.Text = "ویرایش";
        //    }
        //}
    }
}
