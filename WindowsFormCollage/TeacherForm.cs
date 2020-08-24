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

namespace WindowsFormCollage {
    /// <Author>Ali Kazemi</Author>
    /// <summary>
    /// A class for quering on Teachers table
    /// </summary>
    public partial class TeacherForm : Form {

        #region Properties
        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }
        public int? ItemId { get; set; }
        public Teacher T { get; set; }
        #endregion

        #region Constructors
        public TeacherForm(SqlConnection connection, int? id)
        {
            ItemId = id;
            Connection = connection;
            InitializeComponent();
        }

        /// <summary>
        /// برای اپدیت کردن اطلاعات
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="teacher"></param>
        public TeacherForm(SqlConnection connection, Teacher teacher, int? id)
            : this(connection, teacher.TeacherId)
        {
            T = teacher;
            SetValueForEdit();
        }
        #endregion

        private void SetValueForEdit()
        {
            nationalCodeTxt.Text = T.NationalCode;
            nameTxt.Text = T.Name;
            familyTxt.Text = T.Family;
            fatherNameTxt.Text = T.FatherName;
            phoneTxt.Text = T.PhoneNumber;
            addressTxt.Text = T.Address;
            degreeTxt.Text = T.Degree;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher(
                nationalCodeTxt.Text, nameTxt.Text, familyTxt.Text,
                fatherNameTxt.Text, phoneTxt.Text, addressTxt.Text,
                degreeTxt.Text);

            if (ItemId == null) // Insert into table
            {
                InsertTeacher(t);
            }
            else                // Update the table
            {
                UpdateTeacher((int)ItemId, t);
            }

            this.Close();
        }

        /// <summary>
        /// افزودن یک استاد جدید در دیتابیس
        /// </summary>
        /// <param name="st">استادی که در دیتابیس اضافه میشود</param>
        public void InsertTeacher(Teacher st)
        {
            string queryString =

                    "insert into Teachers " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "PhoneNumber," +
                            "Address," +
                            "Degree" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{st.NationalCode}', " +
                            $"N'{st.Name}', " +
                            $"N'{st.Family}', " +
                            $"N'{st.FatherName}', " +
                            $"'{st.PhoneNumber}', " +
                            $"N'{st.Address}', " +
                            $"N'{st.Degree}'" +
                    ")";

            ExecuteCommand(queryString, "Insert into Teachers table Successfully");
        }

        /// <summary>
        /// تغییر اطلاعات یک استاد با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی استاد مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="t">استاد جدید که به جای استاد قبلی قرار خواهد گرفت</param>
        public void UpdateTeacher(int id, Teacher t)
        {
            string queryString =
                    $"update Teachers set " +
                        $"NationalCode = '{t.NationalCode}', " +
                        $"Name = N'{t.Name}', " +
                        $"Family = N'{t.Family}', " +
                        $"FatherName = N'{t.FatherName}', " +
                        $"PhoneNumber = '{t.PhoneNumber}', " +
                        $"Address = N'{t.Address}', " +
                        $"Degree = N'{t.Degree}'" +
                    $"where TeacherId = {id}";

            ExecuteCommand(queryString, "Teachers update Successfully");
        }



        #region Other Methods
        /// <summary>
        /// تابعی برای اجرای دستورات Sql و مدیریت خطاها
        /// </summary>
        /// <param name="queryString">رشته دستورات SQL</param>
        /// <param name="message">پیغام مناسب در صورت اجرا شدن بدون خطای دستور</param>
        private void ExecuteCommand(string queryString, string message)
        {
            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                SqlCommand cm = new SqlCommand(queryString, Connection, transaction);

                // Executing the SQL query
                cm.ExecuteNonQuery();

                transaction.Commit();

                // Displaying a message
                MessageBox.Show(message);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion
    }
}
