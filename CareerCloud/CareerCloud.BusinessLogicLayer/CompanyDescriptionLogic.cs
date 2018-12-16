using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository)
            : base(repository)
        {
        }
        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (CompanyDescriptionPoco poco in pocos)
            {
                if (poco.CompanyDescription != null && poco.CompanyDescription.Length < 3)
                {
                    vError = new ValidationException(107, "CompanyDescription must be greater than 2 characters");
                    errors.Add(vError);
                }
                if (poco.CompanyName !=null && poco.CompanyName.Length < 3)
                {
                    vError = new ValidationException(106, "CompanyName must be greater than 2 characters");
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
