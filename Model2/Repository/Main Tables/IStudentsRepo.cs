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
        DataTable SelectAllTeachers(int studentId);
        DataTable SelectAllCourses(int studentId);
    }
}
