using System;
using System.Collections.Generic;
using System.Text;

namespace Models2 {
    public class ExistingCourse {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public ExistingCourse(int teacherId, int courseId)
        {
            TeacherId = teacherId;
            CourseId = courseId;
        }
    }
}
