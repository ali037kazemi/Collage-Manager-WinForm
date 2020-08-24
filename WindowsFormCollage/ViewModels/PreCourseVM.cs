using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormCollage {
    public class PreCourseVM {
        public int MainId { get; set; }
        public string MainTitle { get; set; }
        public int PreId { get; set; }
        public string PreTitle { get; set; }

        public override string ToString()
        {
            return $"MainId({MainId}), " +
                   $"MainTitle({MainTitle}), " +
                   $"PreId({PreId}), " +
                   $"PreTitle({PreTitle})";
        }
    }
}
