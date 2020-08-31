using System;
using System.Collections.Generic;
using System.Text;

namespace Models {
   public class StudentTeacher {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public StudentTeacher(int studentId, int teacherId)
        {
            StudentId = studentId;
            TeacherId = teacherId;
        }
    }
}
