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
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
        }
        [HttpGet]
        [Route("jobapplication/{applicantJobApplicationId}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]
        public IHttpActionResult GetCompanyDescription(Guid companyDescriptionId)
        {
            CompanyDescriptionPoco compDesc = _logic.Get(companyDescriptionId);
            if (compDesc == null)
            {
                return NotFound();
            }

            return Ok(compDesc);
        }

        [HttpGet]
        [Route("description")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyDescription()
        {
            List<CompanyDescriptionPoco> appJobApp = _logic.GetAll();
            return Ok(appJobApp);
        }

        [HttpPost]
        [Route("desciption")]
        public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("description")]
        public IHttpActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("description")]
        public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
