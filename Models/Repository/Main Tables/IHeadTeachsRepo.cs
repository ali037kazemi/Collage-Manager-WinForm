using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models {
    public interface IHeadTeachsRepo : ITableRepo {
        bool Insert(HeadTeach headTeach);
        bool Insert(string name, string family, string fatherName,string nationalCode,
                    string phoneNumber, string address, string studyField);
        bool Update(int headTeachId, HeadTeach headTeach);
        bool Update(int headTeachId, string name, string family, string fatherName,
                    string nationalCode, string phoneNumber, string address,
                    string studyField);
        bool Delete(HeadTeach headTeach);
    }
}
