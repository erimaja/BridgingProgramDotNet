using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository)
            : base(repository)
        {

        }

        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (ApplicantSkillPoco poco in pocos)
            {
                if (poco.StartMonth > 12)
                {
                    vError = new ValidationException(101, "Cannot be greater than 12");
                    errors.Add(vError);
                }

                if (poco.EndMonth > 12)
                {
                    vError = new ValidationException(102, "Cannot be greater than 12");
                    errors.Add(vError);
                }

                if (poco.StartYear < 1900)
                {
                    vError = new ValidationException(103, "Cannot be less then 1900");
                    errors.Add(vError);
                }

                if (poco.EndYear < poco.StartYear)
                {
                    vError = new ValidationException(104, "Cannot be less then StartYear");
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
