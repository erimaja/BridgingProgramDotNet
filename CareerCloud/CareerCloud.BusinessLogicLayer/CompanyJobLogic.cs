using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
    {
        public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository)
            : base(repository)
        {

        }
    }
}
