using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobSkillLogic : BaseLogic<CompanyJobSkillPoco>
    {
        public CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository)
            : base(repository)
        {
        }

        protected override void Verify(CompanyJobSkillPoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (CompanyJobSkillPoco poco in pocos)
            {
                if (poco.Importance < 0)
                {
                    vError = new ValidationException(400, "Importance cannot be less than 0");
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
