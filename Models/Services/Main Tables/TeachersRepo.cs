using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Models {
    public class TeachersRepo : ITeachersRepo {
        public SqlConnection Connection { get; }

        public TeachersRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('Teachers') is null " +
                    "begin " +
                    "create table Teachers(" +
                        "TeacherId int identity(1, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "Degree nvarchar(150)" +
                    ")" +
                    "end";

            return ExecuteCommand(queryString);
        }

        public bool DropTable()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int teacherId)
        {
            string queryString =
                    $"delete from Teachers where TeacherId = " +
                    $"{teacherId}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Teacher t)
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
                            $"'{t.NationalCode}', " +
                            $"N'{t.Name}', " +
                            $"N'{t.Family}', " +
                            $"N'{t.FatherName}', " +
                            $"'{t.PhoneNumber}', " +
                            $"N'{t.Address}', " +
                            $"N'{t.Degree}'" +
                    ")";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Insert(string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, string degree)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string queryString = "Select * From Teachers";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectById(int teacherId)
        {
            string queryString = "Select * From Teachers Where TeacherId = " + teacherId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public bool Update(int teacherId, Teacher t)
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
                    $"where TeacherId = " + teacherId;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Update(int teacherId, string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, string degree)
        {
            throw new NotImplementedException();
        }

        #region Other Methods
        /// <summary>
        /// تابعی برای اجرای دستورات Sql و مدیریت خطاها
        /// </summary>
        /// <param name="queryString">رشته دستورات SQL</param>
        public bool ExecuteCommand(string queryString)
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

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show("مشکلی بوجود آمده است\n" + e.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable Search(string searchStr)
        {
            string[] searchProp = searchStr.Split(' ');
            string queryString = "Select * From Teachers where ";

            for (int i = 0; i < searchProp.Length; i++)
            {
                string str = searchProp[i];
                queryString += $" Name like '%{str}%' or Family like '%{str}%' " + " or ";
            }
            if (searchProp.Length > 0)
            {
                queryString = queryString.Substring(0, queryString.Length - 4);
            }

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                transaction = Connection.BeginTransaction();
                adapter.SelectCommand = new SqlCommand(queryString, Connection, transaction);
                DataTable table = new DataTable();
                adapter.Fill(table);
                transaction.Commit();
                return table;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion
    }
}
