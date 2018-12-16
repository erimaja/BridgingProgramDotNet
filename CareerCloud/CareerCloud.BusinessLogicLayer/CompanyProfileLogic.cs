using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository)
            : base(repository)
        {
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            ValidationException vError;
            //String message = "";
            string[] split ;
            string endWord = "";
            foreach (CompanyProfilePoco poco in pocos)
            {
                if (poco.CompanyWebsite != null)
                {
                    split = poco.CompanyWebsite.Split(new Char[] { '.' }, StringSplitOptions.None);
                    if (split.Length > 0)
                        endWord = split[split.Length - 1];

                    if (!endWord.Equals("ca") && !endWord.Equals("com") && !endWord.Equals("biz"))
                    {
                        vError = new ValidationException(600, $"{poco.CompanyWebsite} Valid websites must end with the following extensions – '.ca', '.com', '.biz'");
                        errors.Add(vError);
                    }

                }
                string[] phoneComponents =null;
                if (poco.ContactPhone != null)
                {
                    phoneComponents = poco.ContactPhone.Split('-');
                }

                if (phoneComponents==null ||  phoneComponents.Length < 3)
                {
                    vError = new ValidationException(601, $"{poco.ContactPhone} Must correspond to a valid phone number ");
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
