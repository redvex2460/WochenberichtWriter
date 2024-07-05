using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WochenberichtWriter.Application.Interfaces;
using WochenberichtWriter.Data.Entities;

namespace WochenberichtWriter.Application.Database
{
    public class ReportRepository : IReportRepository
    {
        DatabaseContext _databaseContext;
        public ReportRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }
        public void AddReport(Report report)
        {
            if (report.ID == 0)
                _databaseContext.Reports.Add(report);
            else
                _databaseContext.Reports.Update(report);
            _databaseContext.SaveChanges();
        }

        public Report GetReport(int id)
        {
            return GetReports().FirstOrDefault(x => x.ID == id);
        }

        public List<Report> GetReports()
        {
            return _databaseContext.Reports
                .Include(x => x.MondayLessons)
                .ThenInclude(x => x.Module)
                .Include(x => x.TuesdayLessons)
                .ThenInclude(x => x.Module)
                .Include(x => x.WednesdayLessons)
                .ThenInclude(x => x.Module)
                .Include(x => x.ThursdayLessons)
                .ThenInclude(x => x.Module)
                .Include(x => x.FridayLessons)
                .ThenInclude(x => x.Module)
                .ToList();
        }

        public void RemoveReport(int id)
        {
            var report = GetReport(id);
            if (report == null)
                return;
            _databaseContext.Reports.Remove(report);
            _databaseContext.SaveChanges();
        }
    }
}
