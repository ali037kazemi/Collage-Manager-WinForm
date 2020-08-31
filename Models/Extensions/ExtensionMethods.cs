using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Models {
    public static class ExtensionMethods {

        /// <summary>
        /// تابعی برای اجرای دستورات Sql و مدیریت خطاها
        /// </summary>
        /// <param name="queryString">رشته دستورات SQL</param>
        /// <param name="connection">رشته اتصال به دیتابیس</param>
        public static bool ExecuteCommand(string queryString,
                                          SqlConnection connection)
        {
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand cm = new SqlCommand(queryString, connection, transaction);

                // Executing the SQL query
                cm.ExecuteNonQuery();

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataTable ExecuteReadCommand(string queryString,
                                              SqlConnection connection)
        {
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                transaction = connection.BeginTransaction();
                adapter.SelectCommand = new SqlCommand(queryString, connection, transaction);
                DataTable table = new DataTable();
                adapter.Fill(table);
                transaction.Commit();
                return table;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// تابعی برای چک کردن وجود داشتن جدول در دیتابیس
        /// </summary>
        /// <param name="tableName">نام جدول مورد نظر</param>
        /// <returns>در صورت وجود داشتن جدول مقدار صحیح و در صورت وجود نداشتن مقدار غلط را بر میگرداند</returns>
        public static bool TableExists(string tableName, SqlConnection connection)
        {
            string queryString =
                    $"select 1 from {tableName}";

            try
            {
                connection.Open();
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Executing the SQL query
                cm.ExecuteScalar();

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Table does not exists in database");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
