using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) 
            : base(repository)
        {
        }
        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (ApplicantEducationPoco poco in pocos)
            {
                if (String.IsNullOrEmpty(poco.Major) || poco.Major.Length < 3)
                {
                    vError = new ValidationException(107, "Cannot be empty or less than 3 characters");
                    errors.Add(vError);
                }

                if(poco.StartDate >  DateTime.Now)
                {
                    vError = new ValidationException(108, "Cannot be greater than today");
                    errors.Add(vError);
                }

                if (poco.CompletionDate < poco.StartDate)
                {
                    vError = new ValidationException(109, "CompletionDate cannot be earlier than StartDate");
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
