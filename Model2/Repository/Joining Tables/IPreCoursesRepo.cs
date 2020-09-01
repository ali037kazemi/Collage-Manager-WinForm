using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface IPreCoursesRepo : ITableRepo {
        bool Insert(PreCourse preCourse);
        bool Insert(int mainCourseId, int requiredCourseId);
        bool Update(int id, Course course);
        bool Update(int id, int mainCourseId, int requiredCourseId);
        bool Delete(PreCourse preCourse);
        DataTable SelectByMainCourseId(int mainCourseId);
    }
}
