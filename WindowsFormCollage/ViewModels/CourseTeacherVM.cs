﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormCollage {
    public class CourseTeacherVM {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"TeacherId({TeacherId}), " +
                   $"Name({Name}), " +
                   $"Family({Family}), " +
                   $"CourseId({CourseId}), " +
                   $"Title({Title})";
        }
    }
}
