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
        DataTable SelectAllStudents(int courseId);
        DataTable SelectAllTeachers(int courseId);
        DataTable SelectAllRequiredCourses(int courseId);
    }
}
