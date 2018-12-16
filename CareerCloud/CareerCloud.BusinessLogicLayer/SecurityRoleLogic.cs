using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityRoleLogic : BaseLogic<SecurityRolePoco>
    {
        public SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository)
            : base(repository)
        {

        }

        protected override void Verify(SecurityRolePoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";

            foreach (SecurityRolePoco poco in pocos)
            {
                if (String.IsNullOrEmpty(poco.Role))
                {
                    vError = new ValidationException(800, $"{poco.Role} Cannot be empty");
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
