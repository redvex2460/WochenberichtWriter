using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WochenberichtWriter.Data.Entities;

namespace WochenberichtWriter.Application
{
    public class ReportWriter
    {
        Microsoft.Office.Interop.Excel.Application _excel;
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public ReportWriter(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void Write(Report report)
        {
            _excel = new();
            File.Delete(Path.Combine(_environment.WebRootPath, "output.xlsx"));
            _excel.Workbooks.Open(Path.Combine(_environment.WebRootPath, "vorlage.xlsx"));
            var sheet = _excel.ActiveSheet as Worksheet;
            var monday = report.MondayLessons;
            var tuesday = report.TuesdayLessons;
            var wednesday = report.WednesdayLessons;
            var thursday = report.ThursdayLessons;
            var friday = report.FridayLessons;

            sheet.Cells[3, "B"] = report.Surname;
            sheet.Cells[3, "E"] = report.Name;
            sheet.Cells[4, "B"] = report.Course;
            sheet.Cells[5, "B"] = report.CalenderWeek.ToString();
            sheet.Cells[5, "D"] = report.StartDate;
            sheet.Cells[5, "F"] = report.EndDate;



            for (var i = 0; i < monday.Count; i++)
            {
                monday[i].Module.UsedHours += monday[i].Hour;
                sheet.Cells[i + 9, "C"] = monday[i].Text;
                sheet.Cells[i + 9, "E"] = monday[i].Module.LearnField;
                sheet.Cells[i + 9, "F"] = monday[i].Hour;
                sheet.Cells[i + 9, "G"] = $"{monday[i].Module.MaxHours - monday[i].Module.UsedHours}/{monday[i].Module.MaxHours}";
                sheet.Cells[17, "I"] = monday.Sum(x => x.Hour);
            }
            for (var i = 0; i < tuesday.Count; i++)
            {
                tuesday[i].Module.UsedHours += tuesday[i].Hour;
                sheet.Cells[i + 18, "C"] = tuesday[i].Text;
                sheet.Cells[i + 18, "E"] = tuesday[i].Module.LearnField;
                sheet.Cells[i + 18, "F"] = tuesday[i].Hour;
                sheet.Cells[i + 18, "G"] = $"{tuesday[i].Module.MaxHours - tuesday[i].Module.UsedHours}/{tuesday[i].Module.MaxHours}";
                sheet.Cells[26, "I"] = tuesday.Sum(x => x.Hour);
            }
            for (var i = 0; i < wednesday.Count; i++)
            {
                wednesday[i].Module.UsedHours += wednesday[i].Hour;
                sheet.Cells[i + 27, "C"] = wednesday[i].Text;
                sheet.Cells[i + 27, "E"] = wednesday[i].Module.LearnField;
                sheet.Cells[i + 27, "F"] = wednesday[i].Hour;
                sheet.Cells[i + 27, "G"] = $"{wednesday[i].Module.MaxHours - wednesday[i].Module.UsedHours}/{wednesday[i].Module.MaxHours}";
                sheet.Cells[35, "I"] = wednesday.Sum(x => x.Hour);
            }
            for (var i = 0; i < thursday.Count; i++)
            {
                thursday[i].Module.UsedHours += thursday[i].Hour;
                sheet.Cells[i + 36, "C"] = thursday[i].Text;
                sheet.Cells[i + 36, "E"] = thursday[i].Module.LearnField;
                sheet.Cells[i + 36, "F"] = thursday[i].Hour;
                sheet.Cells[i + 36, "G"] = $"{thursday[i].Module.MaxHours - thursday[i].Module.UsedHours}/{thursday[i].Module.MaxHours}";
                sheet.Cells[44, "I"] = thursday.Sum(x => x.Hour);
            }
            for (var i = 0; i < friday.Count; i++)
            {
                friday[i].Module.UsedHours += friday[i].Hour;
                sheet.Cells[i + 45, "C"] = friday[i].Text;
                sheet.Cells[i + 45, "E"] = friday[i].Module.LearnField;
                sheet.Cells[i + 45, "F"] = friday[i].Hour;
                sheet.Cells[i + 45, "G"] = $"{friday[i].Module.MaxHours - friday[i].Module.UsedHours}/{friday[i].Module.MaxHours}";
                sheet.Cells[53, "I"] = friday.Sum(x => x.Hour);
            }

            sheet.SaveAs(Path.Combine(_environment.WebRootPath, "output.xlsx"));
            _excel.Workbooks.Close();
            _excel.Quit();
        }
        public Microsoft.Office.Interop.Excel.Application Excel => _excel;
    }
}
