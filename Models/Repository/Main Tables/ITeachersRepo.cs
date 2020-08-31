using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models {
    public interface ITeachersRepo : ITableRepo {
        bool Insert(Teacher teacher);
        bool Insert(string name, string family, string fatherName, string nationalCode,
                    string phoneNumber, string address, string degree);
        bool Update(int teacherId, Teacher teacher);
        bool Update(int teacherId, string name, string family, string fatherName,
                    string nationalCode, string phoneNumber, string address,
                    string degree);
        bool Delete(Teacher teacher);
    }
}
