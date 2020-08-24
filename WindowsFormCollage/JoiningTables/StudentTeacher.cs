using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormCollage {
    /// <summary>
    /// A class for representing multi-to-multi relation between student and teacher
    /// </summary>
    public class StudentTeacher {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public StudentTeacher(int studentId, int teacherId)
        {
            StudentId = studentId;
            TeacherId = teacherId;
        }
    }
}
