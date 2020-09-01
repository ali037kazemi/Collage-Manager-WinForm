using System;
using System.Collections.Generic;
using System.Text;

namespace Models2 {
    public class StudentCourse {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public StudentCourse(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
