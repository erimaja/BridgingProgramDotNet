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
    class Security : ISecurity
    {
        public void AddSecurityLogin(SecurityLoginPoco[] items)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            logic.Add(items);
        }

        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            logic.Add(items);
        }

        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            logic.Add(items);
        }

        public void AddSecurityRole(SecurityRolePoco[] items)
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            logic.Add(items);
        }

        public List<SecurityLoginPoco> GetAllSecurityLogin()
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return logic.GetAll();
        }

        public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            return logic.GetAll();
        }

        public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            return logic.GetAll();
        }

        public List<SecurityRolePoco> GetAllSecurityRole()
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            return logic.GetAll();
        }

        public SecurityLoginPoco GetSingleSecurityLogin(string Id)
        {
            Guid id = new Guid(Id);
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return logic.Get(id);
        }

        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id)
        {
            Guid id = new Guid(Id);
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            return logic.Get(id);
        }

        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id)
        {
            Guid id = new Guid(Id);
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            return logic.Get(id);
        }

        public SecurityRolePoco GetSingleSecurityRole(string Id)
        {
            Guid id = new Guid(Id);
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            return logic.Get(id);
        }

        public void RemoveSecurityLogin(SecurityLoginPoco[] items)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            logic.Delete(items);
        }

        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            logic.Delete(items);
        }

        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            logic.Delete(items);
        }

        public void RemoveSecurityRole(SecurityRolePoco[] items)
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            logic.Delete(items);
        }

        public void UpdateSecurityLogin(SecurityLoginPoco[] items)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            logic.Update(items);
        }

        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            logic.Update(items);
        }

        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            logic.Update(items);
        }

        public void UpdateSecurityRole(SecurityRolePoco[] items)
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            logic.Update(items);
        }
    }
}
