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
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
        }
        [HttpGet]
        [Route("profile/{companyProfieId}")]
        [ResponseType(typeof(CompanyProfilePoco))]
        public IHttpActionResult GetCompanyProfile(Guid companyProfileId)
        {
            CompanyProfilePoco companyProf = _logic.Get(companyProfileId);
            if (companyProf == null)
            {
                return NotFound();
            }

            return Ok(companyProf);
        }

        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]
        public IHttpActionResult GetAllCompanyProfile()
        {
            List<CompanyProfilePoco> companyProf = _logic.GetAll();
            return Ok(companyProf);
        }

        [HttpPost]
        [Route("profile")]
        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]
        public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("profile")]
        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
    }
}
}
