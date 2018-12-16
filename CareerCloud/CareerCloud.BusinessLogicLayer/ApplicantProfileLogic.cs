using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository)
            : base(repository)
        {

        }

        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (ApplicantProfilePoco poco in pocos)
            {
                if (poco.CurrentSalary < 0)
                {
                    vError = new ValidationException(111, "CurrentSalary cannot be negative");
                    errors.Add(vError);
                }

                if (poco.CurrentRate < 0 )
                {
                    vError = new ValidationException(112, "CurrentRate cannot be negative");
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
