using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface IStudentCoursesRepo : ITableRepo {
        bool Insert(StudentCourse studentCourse);
        bool Insert(int studentId, int courseId);
        bool Update(int id, StudentCourse studentCourse);
        bool Update(int id, int studentId, int courseId);
        bool Delete(StudentCourse studentCourse);
        DataTable SelectByStudentId(int studentId);
        DataTable SelectByCourseId(int courseId);
    }
}
