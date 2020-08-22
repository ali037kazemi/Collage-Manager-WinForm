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
    /// A class for quering on HeadTeachs table
    /// </summary>
    public partial class HeadTeachForm : Form {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        public HeadTeachForm(SqlConnection connection)
        {
            Connection = connection;
            InitializeComponent();
        }

        private void saveHeadTeachBtn_Click(object sender, EventArgs e)
        {
            HeadTeach ht = new HeadTeach(
                nationalCodeTxt.Text, nameTxt.Text, familyTxt.Text,
                fatherNameTxt.Text, phoneTxt.Text, addressTxt.Text, studyFieldTxt.Text);

            InsertHeadTeach(ht);
            this.Close();
        }

        /// <summary>
        /// افزودن یک مسول آموزش جدید در دیتابیس
        /// </summary>
        /// <param name="ht">مسول آموزشی که در دیتابیس اضافه میشود</param>
        private void InsertHeadTeach(HeadTeach ht)
        {
            string queryString =

                    "insert into HeadTeachs " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "PhoneNumber," +
                            "Address," +
                            "StudyField" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{ht.NationalCode}', " +
                            $"N'{ht.Name}', " +
                            $"N'{ht.Family}', " +
                            $"N'{ht.FatherName}', " +
                            $"'{ht.PhoneNumber}', " +
                            $"N'{ht.Address}', " +
                            $"N'{ht.StudyField}'" +
                    ")";

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
                Console.WriteLine("Insert into HeadTeachs table Successfully");
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

        //private void editBtn_Click(object sender, EventArgs e)
        //{
        //    HeadTeach ht = new HeadTeach(
        //        nationalCodeTxt.Text, nameTxt.Text, familyTxt.Text,
        //        fatherNameTxt.Text, phoneTxt.Text, addressTxt.Text, studyFieldTxt.Text);

        //    UpdateHeadTeach(, ht);
        //    this.Close();
        //}

        /// <summary>
        /// تغییر اطلاعات یک مسول آموزش با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی مسول آموزش مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="ht">مسول آموزش جدید که به جای درس قبلی قرار خواهد گرفت</param>
        private void UpdateHeadTeach(int id, HeadTeach ht)
        {
            string queryString =
                     $"update HeadTeachs set " +
                        $"NationalCode = '{ht.NationalCode}', " +
                        $"Name = N'{ht.Name}', " +
                        $"Family = N'{ht.Family}', " +
                        $"FatherName = N'{ht.FatherName}', " +
                        $"PhoneNumber = '{ht.PhoneNumber}', " +
                        $"Address = N'{ht.Address}', " +
                        $"StudyField = N'{ht.StudyField}'" +
                     $"where HeadTeachId = {id}";

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                transaction.Commit();

                // Displaying a message  
                Console.WriteLine("HeadTeachs update Successfully");
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
    }
}
