using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.BusinessLogicLayer;

namespace CareerCloud.WCF//WcfServiceLibrary1
{
    class System : ISystem
    {
        public void AddSystemCountryCode(SystemCountryCodePoco[] items)
        {
            var logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            logic.Add(items);
        }

        public void AddSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            logic.Add(items);
        }

        public List<SystemCountryCodePoco> GetAllSystemCountryCode()
        {
           var logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            return logic.GetAll();
        }

        public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            return logic.GetAll();
        }

        public SystemCountryCodePoco GetSingleSystemCountryCode(string Id)
        {
            var logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            return logic.Get(Id);
        }

        public SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            return logic.Get(Id);
        }

        public void RemoveSystemCountryCode(SystemCountryCodePoco[] items)
        {
           var logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            logic.Delete(items);
        }

        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            logic.Delete(items);
        }

        public void UpdateSystemCountryCode(SystemCountryCodePoco[] items)
        {
            var logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            logic.Update(items);
        }

        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            logic.Update(items);
        }
    }
}
