using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormCollage {
    public class StudentTeacherVM {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentFamily { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherFamily { get; set; }

        public override string ToString()
        {
            return $"StudentId({StudentId})" +
                   $"StudentName({StudentName})" +
                   $"StudentFamily({StudentFamily})" +
                   $"TeacherId({TeacherId})" +
                   $"TeacherName({TeacherName})" +
                   $"TeacherFamily({TeacherFamily})";
        }
    }
}
