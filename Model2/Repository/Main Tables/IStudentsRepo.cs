using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface IStudentsRepo : ITableRepo {
        bool Insert(Student student);
        bool Insert(string name, string family, string fatherName, string nationalCode,
                    string phoneNumber, string address, short entryYear,
                    string postalCode, string field, string grade, int headTeachId);
        bool Update(int studentId, Student student);
        bool Update(int studentId, string name, string family, string fatherName,
                    string nationalCode, string phoneNumber, string address,
                    short entryYear, string postalCode, string field,
                    string grade, int headTeachId);
        bool Delete(Student student);

        /// <summary>
        /// انتخاب تمام اساتیدی که با این دانشجو در ارتباط هستند
        /// </summary>
        /// <param name="studentId">آیدی دانشجو مورد نظر</param>
        /// <returns>تمام اساتیدی که با این دانشجو در ارتباط هستند</returns>
        DataTable SelectAllTeachers(int studentId);

        /// <summary>
        /// انتخاب تمام دروسی که این دانشجو اخذ کرده است
        /// </summary>
        /// <param name="studentId">آیدی دانشجو مورد نظر</param>
        /// <returns>تمام دروسی که این دانشجو اخذ کرده است</returns>
        DataTable SelectAllCourses(int studentId);
    }
}
