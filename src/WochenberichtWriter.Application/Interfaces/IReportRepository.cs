using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WochenberichtWriter.Data.Entities;

namespace WochenberichtWriter.Application.Interfaces
{
    public interface IReportRepository
    {
        public List<Report> GetReports();
        public Report GetReport(int id);
        public void AddReport(Report report);
        public void RemoveReport(int id);
    }
}
