using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyJobController : ApiController
    {
        private CompanyJobLogic _logic;

        public CompanyJobController()
        {
            _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
        }
        [HttpGet]
        [Route("job/{companyJobId}")]
        [ResponseType(typeof(CompanyJobPoco))]
        public IHttpActionResult GetCompanyJob(Guid companyJobId)
        {
            CompanyJobPoco compJob = _logic.Get(companyJobId);
            if (compJob == null)
            {
                return NotFound();
            }

            return Ok(compJob);
        }

        [HttpGet]
        [Route("job")]
        [ResponseType(typeof(List<CompanyJobPoco>))]
        public IHttpActionResult GetAllApplicantJobApplication()
        {
            List<CompanyJobPoco> appJobApp = _logic.GetAll();
            return Ok(appJobApp);
        }

        [HttpPost]
        [Route("job")]
        public IHttpActionResult PostCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("job")]
        public IHttpActionResult PutCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("job")]
        public IHttpActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
