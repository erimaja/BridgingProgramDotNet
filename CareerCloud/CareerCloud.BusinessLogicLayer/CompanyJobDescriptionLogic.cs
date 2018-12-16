using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository)
            : base(repository)
        {
        }
        protected override void Verify(CompanyJobDescriptionPoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (CompanyJobDescriptionPoco poco in pocos)
            {
                if (String.IsNullOrEmpty(poco.JobName))
                {
                    vError = new ValidationException(300, "JobName cannot be empty");
                    errors.Add(vError);
                }
                if (String.IsNullOrEmpty(poco.JobDescriptions))
                {
                    vError = new ValidationException(301, "JobDescriptions cannot be empty");
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
