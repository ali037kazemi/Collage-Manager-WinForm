using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface IExistingCoursesRepo : ITableRepo {
        bool Insert(ExistingCourse existingCourse);
        bool Insert(int teacherId, int courseId);
        bool Update(int id, Course course);
        bool Update(int id, int teacherId, int courseId);
        bool Delete(ExistingCourse existingCourse);
        DataTable SelectByTeacherId(int teacherId);
        DataTable SelectByCourseId(int courseId);
    }
}
