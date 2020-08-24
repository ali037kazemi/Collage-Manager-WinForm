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
    /// A class for quering on Students table
    /// </summary>
    public partial class StudentForm : Form {

        #region Properties
        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }
        public int? ItemId { get; set; }
        public Student St { get; set; }
        #endregion

        #region Constructors
        public StudentForm(SqlConnection connection, int? id)
        {
            ItemId = id;
            Connection = connection;
            InitializeComponent();
        }

        /// <summary>
        /// برای اپدیت کردن اطلاعات
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="student"></param>
        public StudentForm(SqlConnection connection, Student student, int? id)
            : this(connection, student.StudentId)
        {
            St = student;
            SetValueForEdit();
        }
        #endregion

        private void SetValueForEdit()
        {
            nationalCodeTxt.Text = St.NationalCode;
            nameTxt.Text = St.Name;
            familyTxt.Text = St.Family;
            fatherNameTxt.Text = St.FatherName;
            phoneTxt.Text = St.PhoneNumber;
            addressTxt.Text = St.Address;
            entryYearTxt.Text = St.EntryYear.ToString();
            postalCodeTxt.Text = St.PostalCode;
            fieldTxt.Text = St.Field;
            gradeTxt.Text = St.Grade;
            headTeachId.Text = St.HeadTeachId.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Student s = new Student(
                nationalCodeTxt.Text, nameTxt.Text, familyTxt.Text,
                fatherNameTxt.Text, Convert.ToInt16(entryYearTxt.Text),
                phoneTxt.Text, addressTxt.Text,
                postalCodeTxt.Text, fieldTxt.Text,
                gradeTxt.Text, Convert.ToInt32(headTeachId.Text));

            if (ItemId == null) // Insert into table
            {
                InsertStudent(s);
            }
            else                // Update the table
            {
                UpdateStudent((int)ItemId, s);
            }

            this.Close();
        }

        /// <summary>
        /// افزودن یک دانشجو جدید در دیتابیس
        /// </summary>
        /// <param name="st">دانشجویی که در دیتابیس اضافه میشود</param>
        private void InsertStudent(Student st)
        {
            string queryString =

                    "insert into Students " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "EntryYear," +
                            "PhoneNumber," +
                            "Address," +
                            "PostalCode," +
                            "Field," +
                            "Grade," +
                            "HeadTeachId" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{st.NationalCode}', " +
                            $"N'{st.Name}', " +
                            $"N'{st.Family}', " +
                            $"N'{st.FatherName}', " +
                            $"{st.EntryYear}, " +
                            $"'{st.PhoneNumber}', " +
                            $"N'{st.Address}', " +
                            $"'{st.PostalCode}'," +
                            $"N'{st.Field}'," +
                            $"N'{st.Grade}'," +
                            $"{st.HeadTeachId}" +
                    ")";

            ExecuteCommand(queryString, "Insert into Students table Successfully");
        }

        /// <summary>
        /// تغییر اطلاعات یک داشنجو با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی داشنجوی مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="st">داشنجوی جدید که به جای داشنجو قبلی قرار خواهد گرفت</param>
        private void UpdateStudent(int id, Student st)
        {
            string queryString =
                    $"update Students set " +
                        $"NationalCode = '{st.NationalCode}', " +
                        $"[Name] = N'{st.Name}', " +
                        $"Family = N'{st.Family}', " +
                        $"FatherName = N'{st.FatherName}', " +
                        $"EntryYear = {st.EntryYear}, " +
                        $"PhoneNumber = '{st.PhoneNumber}', " +
                        $"[Address]= N'{st.Address}', " +
                        $"PostalCode = '{st.PostalCode}'," +
                        $"Field = N'{st.Field}'," +
                        $"Grade = N'{st.Grade}'," +
                        $"HeadTeachId = {st.HeadTeachId}" +
                    $" where StudentId = {id}";

            ExecuteCommand(queryString, "Students updated Successfully");
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
