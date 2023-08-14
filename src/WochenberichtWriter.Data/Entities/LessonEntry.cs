using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WochenberichtWriter.Data.Entities
{
    public class LessonEntry
    {
        public int ID { get; set; }
        public LearnModule Module { get; set; }
        public decimal Hour { get; set; }
        public string Text { get; set; }
    }
}
