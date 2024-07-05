using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WochenberichtWriter.Data.Entities
{
    public class Report
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Course { get; set; }
        public int CalenderWeek { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<LessonEntry> MondayLessons { get; set; } = new();
        public List<LessonEntry> TuesdayLessons { get; set; } = new();
        public List<LessonEntry> WednesdayLessons { get; set; } = new();
        public List<LessonEntry> ThursdayLessons { get; set; } = new();
        public List<LessonEntry> FridayLessons { get; set; } = new();
        
        public List<LessonEntry> GetLessons()
        {
            var result = new List<LessonEntry>();
            result.AddRange(MondayLessons);
            result.AddRange(TuesdayLessons);
            result.AddRange(WednesdayLessons);
            result.AddRange(ThursdayLessons);
            result.AddRange(FridayLessons);
            return result;
        }

        public Report()
        {
            Name = "";
            Surname = "";
            Course = "";
            CalenderWeek = 99;
            StartDate = new DateTime().ToString();
            EndDate = new DateTime().ToString();
            MondayLessons = new List<LessonEntry>();
            TuesdayLessons = new List<LessonEntry>();
            WednesdayLessons = new List<LessonEntry>();
            ThursdayLessons = new List<LessonEntry>();
            FridayLessons = new List<LessonEntry>();
        }
    }
}
