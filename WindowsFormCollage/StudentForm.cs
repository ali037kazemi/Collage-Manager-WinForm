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
    public partial class StudentForm : Form {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        public StudentForm(SqlConnection connection)
        {
            Connection = connection;
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Student s = new Student(
                nationalCodeTxt.Text, nameTxt.Text, familyTxt.Text,
                fatherNameTxt.Text, Convert.ToInt16(entryYearTxt.Text),
                phoneTxt.Text, addressTxt.Text,
                postalCodeTxt.Text, fieldTxt.Text,
                gradeTxt.Text, Convert.ToInt32(headTeachId.Text));

            InsertStudent(s);
            this.Close();
        }

        /// <summary>
        /// افزودن یک دانشجو جدید در دیتابیس
        /// </summary>
        /// <param name="st">دانشجویی که در دیتابیس اضافه میشود</param>
        public void InsertStudent(Student st)
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

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                SqlCommand cm = new SqlCommand(queryString, Connection, transaction);

                // Executing the SQL query  
                int rowsEffected = cm.ExecuteNonQuery();

                if (rowsEffected == 1)
                {
                    transaction.Commit();

                    // Displaying a message  
                    Console.WriteLine("Insert into Students table Successfully");
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
