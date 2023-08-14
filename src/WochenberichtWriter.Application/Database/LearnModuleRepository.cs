using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WochenberichtWriter.Application.Interfaces;
using WochenberichtWriter.Data.Entities;

namespace WochenberichtWriter.Application.Database
{
    public class LearnModuleRepository : ILearnModuleRepository
    {
        private DatabaseContext _context;
        public LearnModuleRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public void AddLearnModule(string learnField, string moduleName, decimal soll)
        {
            var module = new LearnModule()
            {
                LearnField = learnField,
                MaxHours = soll,
                UsedHours = 0,
                Name = moduleName
            };
            _context.Modules.Add(module);
            _context.SaveChanges();
        }

        public void DeleteModule(LearnModule module)
        {
            _context.Modules.Remove(module);
            _context.SaveChanges();
        }

        public List<LearnModule> GetAllLearnModules()
        {
            return _context.Modules.ToList();
        }

        public LearnModule GetLearnModuleByFieldId(string ID)
        {
            return _context.Modules.FirstOrDefault(mod => mod.LearnField == ID);
        }

        public decimal GetModuleHours(LearnModule module)
        {
            decimal value = 0.0M;
            foreach(var repo in _context.Reports)
            {
                foreach(var mod in repo.GetLessons())
                {
                    if (mod.Module == module)
                        value += mod.Hour;
                }

            }
            return value;
        }
    }
}
