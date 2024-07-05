using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WochenberichtWriter.Data.Entities
{
    public class LearnModule
    {
        public string Name { get; set; }
        public decimal MaxHours { get; set; }
        public decimal UsedHours { get; set; }
        public long ID { get; set; }
        public string LearnField { get; set; }
    }
}
