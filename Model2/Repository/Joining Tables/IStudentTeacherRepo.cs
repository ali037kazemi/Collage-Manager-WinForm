using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface IStudentTeacherRepo : ITableRepo {
        bool Insert(StudentTeacher studentTeacher);
        bool Insert(int studentId, int teacherId);
        bool Update(int id, StudentTeacher studentTeacher);
        bool Update(int id, int studentId, int teacherId);
        bool Delete(StudentTeacher studentTeacher);
        DataTable SelectByStudentId(int studentId);
        DataTable SelectByTeacherId(int teacherId);
    }
}
