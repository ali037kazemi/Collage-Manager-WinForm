using System;
using System.Collections.Generic;
using System.Text;

namespace Models {
    public class PreCourse {
        public int Id { get; set; }
        public int MainCourseId { get; set; }
        public int RequiredCourseId { get; set; }

        public PreCourse(int mainCourseId, int requiredCourseId)
        {
            MainCourseId = mainCourseId;
            RequiredCourseId = requiredCourseId;
        }
    }
}
