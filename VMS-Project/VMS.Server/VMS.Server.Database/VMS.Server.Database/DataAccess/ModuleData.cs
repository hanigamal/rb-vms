using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.Server.Models;

namespace VMS.Server.Database.DataAccess
{
    public class ModuleData
    {
        public ModuleModel GetModule(string moduleNumber)
        {
            vmsServerLinqDataContext datacontext = new vmsServerLinqDataContext();
            ModuleModel model = new ModuleModel();
            Module query = (from m in datacontext.Modules
                            where m.ModuleNumber == moduleNumber
                            select m).SingleOrDefault<Module>();
            model.ModuleNumber = query.ModuleNumber;
            model.ModuleType = query.ModuleType;
            model.IsActive = Convert.ToBoolean(query.IsActive);
            return model;
        }

        public void Save(ModuleModel model)
        {
            vmsServerLinqDataContext datacontext = new vmsServerLinqDataContext();
            Module objModule = new Module();
            try
            {
                objModule = datacontext.Modules.Single(m => m.ModuleNumber == model.ModuleNumber);

                objModule.ModuleNumber = model.ModuleNumber;
                objModule.ModuleType = model.ModuleType;
                objModule.IsActive = model.IsActive;
                datacontext.SubmitChanges();
            }
            catch
            {
                objModule.ModuleNumber = model.ModuleNumber;
                objModule.ModuleType = model.ModuleType;
                objModule.IsActive = model.IsActive;
                datacontext.Modules.InsertOnSubmit(objModule);
                datacontext.SubmitChanges();
            }
        }
    }
}
