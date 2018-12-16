using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository)
            : base(repository)
        {
        }

        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (CompanyLocationPoco poco in pocos)
            {
                //if (poco.CountryCode != null)
                if (String.IsNullOrEmpty(poco.CountryCode))
                {
                    vError = new ValidationException(500, "CountryCode cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.Province))
                {
                    vError = new ValidationException(501, "Province cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.Street))
                {
                    vError = new ValidationException(502, "Street cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.City))
                {
                    vError = new ValidationException(503, "City cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.PostalCode))
                {
                    vError = new ValidationException(504, "PostalCode cannot be empty");
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
