using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Models {
    public class HeadTeachsRepo : IHeadTeachsRepo {
        public SqlConnection Connection { get; }

        public HeadTeachsRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('HeadTeachs') is null " +
                    "begin " +
                    "create table HeadTeachs(" +
                        "HeadTeachId int identity(1, 1)  PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "StudyField nvarchar(150)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool DropTable()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string queryString = "Select * From HeadTeachs";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectById(int headTeachId)
        {
            string queryString = "Select * From HeadTeachs Where HeadTeachId = " + headTeachId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public bool Insert(HeadTeach ht)
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

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Insert(string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, string studyField)
        {
            throw new NotImplementedException();
        }

        public bool Update(int headTeachId, HeadTeach ht)
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
                     $"where HeadTeachId = " + headTeachId;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Update(int headTeachId, string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, string studyField)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int headTeachId)
        {
            string queryString = $"delete from HeadTeachs where HeadTeachId = {headTeachId}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(HeadTeach headTeach)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string searchStr)
        {
            string[] searchProp = searchStr.Split(' ');
            string queryString = "Select * From HeadTeachs where ";

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
    }
}
