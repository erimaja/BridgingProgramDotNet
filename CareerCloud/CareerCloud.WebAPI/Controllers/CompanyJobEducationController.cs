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
    public class CompanyJobEducationController : ApiController
    {
        private CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
        }
        [HttpGet]
        [Route("jobeducation/{companyJobEducationId}")]
        [ResponseType(typeof(CompanyJobEducationPoco))]
        public IHttpActionResult GetCompanyJobEducation(Guid companyJobEducationId)
        {
            CompanyJobEducationPoco appJobApp = _logic.Get(companyJobEducationId);
            if (appJobApp == null)
            {
                return NotFound();
            }

            return Ok(appJobApp);
        }

        [HttpGet]
        [Route("jobeducation")]
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public IHttpActionResult GetAllCompanyJobEducation()
        {
            List<CompanyJobEducationPoco> appJobApp = _logic.GetAll();
            return Ok(appJobApp);
        }

        [HttpPost]
        [Route("jobeducation")]
        public IHttpActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobeducation")]
        public IHttpActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("jobeducation")]
        public IHttpActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
