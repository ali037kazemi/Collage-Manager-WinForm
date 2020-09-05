using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface IHeadTeachsRepo : ITableRepo {
        bool Insert(HeadTeach headTeach);
        bool Insert(string name, string family, string fatherName,string nationalCode,
                    string phoneNumber, string address, string studyField);
        bool Update(int headTeachId, HeadTeach headTeach);
        bool Update(int headTeachId, string name, string family, string fatherName,
                    string nationalCode, string phoneNumber, string address,
                    string studyField);
        bool Delete(HeadTeach headTeach);

        /// <summary>
        /// انتخاب تمام دانشجویانی که زیر نظر این مسول آموزش هستند
        /// </summary>
        /// <param name="headTeachId">آیدی مسول آموزش مورد نظر</param>
        /// <returns>تمام دانشجویانی که زیر نظر این مسول آموزش هستند</returns>
        DataTable SelectAllStudents(int headTeachId);

        /// <summary>
        /// انتخاب تمام دروسی که زیر نظر این مسول آموزش هستند
        /// </summary>
        /// <param name="headTeachId">آیدی مسول آموزش مورد نظر</param>
        /// <returns>تمام دروسی که زیر نظر این مسول آموزش هستند</returns>
        DataTable SelectAllCourses(int headTeachId);
    }
}
