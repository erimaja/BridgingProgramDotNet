using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic 
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        {
            _repository = repository;
        }

        public void Add(SystemCountryCodePoco[] pocos)
        {
            this.Verify(pocos);
            _repository.Add(pocos);
        }

        public virtual List<SystemCountryCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual SystemCountryCodePoco Get(string id)
        {
            return _repository.GetSingle(c => c.Code == id);
        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            this.Verify(pocos);
            _repository.Update(pocos);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (String.IsNullOrEmpty(poco.Code))
                {
                    vError = new ValidationException(900, $" {poco.Code} Code cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.Name))
                {
                    vError = new ValidationException(901, $"{poco.Name} Name cannot be empty");
                    errors.Add(vError);
                }

            }

            if (errors.Any())
            {
                throw new AggregateException("Multiple errors. See InnerExceptions for more details", errors);
            }
            return;
        }
    }
}
