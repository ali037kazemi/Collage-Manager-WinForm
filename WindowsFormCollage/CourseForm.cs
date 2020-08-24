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
    /// A class for quering on Courses table
    /// </summary>
    public partial class CourseForm : Form {

        #region Properties
        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }
        public int? ItemId { get; set; }
        public Course C { get; set; }
        #endregion

        #region Constructors
        public CourseForm(SqlConnection connection, int? id)
        {
            ItemId = id;
            Connection = connection;
            InitializeComponent();
        }

        /// <summary>
        /// برای اپدیت کردن اطلاعات
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="course"></param>
        public CourseForm(SqlConnection connection, Course course, int? id)
            : this(connection, course.CourseId)
        {
            C = course;
            SetValueForEdit();
        }
        #endregion

        private void SetValueForEdit()
        {
            titleTxt.Text = C.Title;
            creditTxt.Text = C.Credit.ToString();
            creditTypeTxt.Text = C.CreditType.ToString();
            headTeachIdTxt.Text = C.HeadTeachId.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Course c = new Course(
                titleTxt.Text, Convert.ToByte(creditTxt.Text),
                Convert.ToBoolean(creditTypeTxt.Text), Convert.ToInt32(headTeachIdTxt.Text));

            if (ItemId == null) // Insert into table
            {
                InsertCourse(c);
            }
            else                // Update the table
            {
                UpdateCourse((int)ItemId, c);
            }

            this.Close();
        }

        /// <summary>
        /// افزودن یک درس جدید در دیتابیس
        /// </summary>
        /// <param name="c">درسی که در دیتابیس اضافه میشود</param>
        public void InsertCourse(Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =

                    "insert into Courses " +
                    "(" +
                            "Title," +
                            "Credit," +
                            "CreditType," +
                            "HeadTeachId" +
                    ") " +
                    "values" +
                    "(" +
                            $"N'{c.Title}', " +
                            $"{c.Credit}, " +
                            $"{type}," +
                            $"{c.HeadTeachId}" +
                    ")";

            ExecuteCommand(queryString, "Insert into Courses table Successfully");
        }

        /// <summary>
        /// تغییر اطلاعات یک درس با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی درس مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="c">درس جدید که به جای درس قبلی قرار خواهد گرفت</param>
        public void UpdateCourse(int id, Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =
                     $"update Courses set " +
                        $"Title = N'{c.Title}', " +
                        $"Credit = {c.Credit}, " +
                        $"CreditType = {type}," +
                        $"HeadTeachId = {c.HeadTeachId}" +
                     $"where CourseId = {id}";

            ExecuteCommand(queryString, "Courses update Successfully");
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
