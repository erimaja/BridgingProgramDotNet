using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic 
    {

        protected IDataRepository<SystemLanguageCodePoco> _repository;
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
        {
            _repository = repository;
        }

        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public virtual List<SystemLanguageCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual SystemLanguageCodePoco Get(string id)
        {
            return _repository.GetSingle(c => c.LanguageID == id);
        }

        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }
        public void Update(SystemLanguageCodePoco[] pocos)
        {
            this.Verify(pocos);
            _repository.Update(pocos);
        }

        public void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (SystemLanguageCodePoco poco in pocos)
            {
                if (String.IsNullOrEmpty(poco.LanguageID))
                {
                    vError = new ValidationException(1000, $" {poco.LanguageID} Cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.Name))
                {
                    vError = new ValidationException(1001, $"{poco.Name} Cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.NativeName))
                {
                    vError = new ValidationException(1002, $"{poco.NativeName} Cannot be empty");
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
