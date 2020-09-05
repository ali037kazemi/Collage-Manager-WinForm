using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface ITeachersRepo : ITableRepo {
        bool Insert(Teacher teacher);
        bool Insert(string name, string family, string fatherName, string nationalCode,
                    string phoneNumber, string address, string degree);
        bool Update(int teacherId, Teacher teacher);
        bool Update(int teacherId, string name, string family, string fatherName,
                    string nationalCode, string phoneNumber, string address,
                    string degree);
        bool Delete(Teacher teacher);

        /// <summary>
        /// انتخاب تمام دانشجویان این استاد
        /// </summary>
        /// <param name="teacherId">آیدی استاد مورد نظر</param>
        /// <returns>تمام دانشجویان این استاد</returns>
        DataTable SelectAllStudents(int teacherId);

        /// <summary>
        /// انتخاب تمام دروس ارایه شده این استاد
        /// </summary>
        /// <param name="teacherId">آیدی استاد مورد نظر</param>
        /// <returns>تمام دروس ارایه شده این استاد</returns>
        DataTable SelectAllCourses(int teacherId);
    }
}
