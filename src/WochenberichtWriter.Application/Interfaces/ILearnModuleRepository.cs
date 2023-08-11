using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WochenberichtWriter.Data.Entities;

namespace WochenberichtWriter.Application.Interfaces
{
    public interface ILearnModuleRepository
    {
        public List<LearnModule> GetAllLearnModules();
        public LearnModule GetLearnModuleByFieldId(string ID);
        public void AddLearnModule(string learnField, string moduleName, decimal soll);
        public void DeleteModule(LearnModule module);
    }
}
