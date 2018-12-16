using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository)
            : base(repository)
        {
        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (CompanyJobEducationPoco poco in pocos)
            {
                if (poco.Major != null && poco.Major.Length < 2)
                {
                    vError = new ValidationException(200, "Major must be at least 2 characters");
                    errors.Add(vError);
                }
                if (poco.Importance < 0)
                {
                    vError = new ValidationException(201, "Importance cannot be less than 0");
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
