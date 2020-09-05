using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface ICoursesRepo : ITableRepo {
        bool Insert(Course course);
        bool Insert(string title, byte credit, bool creditType, int headTeachId);
        bool Update(int courseId, Course course);
        bool Update(int courseId, string title, byte credit, bool creditType, int headTeachId);
        bool Delete(Course course);

        /// <summary>
        /// انتخاب تمام دانشجویانی که این درس را اخذ کرده اند
        /// </summary>
        /// <param name="courseId">آیدی درس مورد نظر</param>
        /// <returns>دانشجویانی که درس را اخذ کرده اند</returns>
        DataTable SelectAllStudents(int courseId);

        /// <summary>
        /// انتخاب تمام اساتیدی که این درس را ارایه کرده اند
        /// </summary>
        /// <param name="courseId">آیدی درس مورد نظر</param>
        /// <returns>اساتید که درس را ارایه کرده اند</returns>
        DataTable SelectAllTeachers(int courseId);

        /// <summary>
        /// انتخاب دروس پیشنیاز این درس
        /// </summary>
        /// <param name="courseId">آیدی درس مورد نظر</param>
        /// <returns>دروس پیشنیاز این درس</returns>
        DataTable SelectAllRequiredCourses(int courseId);
    }
}
