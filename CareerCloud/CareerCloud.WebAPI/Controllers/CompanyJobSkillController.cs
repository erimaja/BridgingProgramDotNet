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
    public class CompanyJobSkillController : ApiController
    {
        private CompanyJobSkillLogic _logic;

        public CompanyJobSkillController()
        {
            _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
        }
        [HttpGet]
        [Route("jobskill/{companyJobSkillId}")]
        [ResponseType(typeof(CompanyJobSkillPoco))]
        public IHttpActionResult GetCompanyJobSkill(Guid companyJobSkillId)
        {
            CompanyJobSkillPoco compJobSkill = _logic.Get(companyJobSkillId);
            if (compJobSkill == null)
            {
                return NotFound();
            }

            return Ok(compJobSkill);
        }

        [HttpGet]
        [Route("jobskill")]
        [ResponseType(typeof(List<CompanyJobSkillPoco>))]
        public IHttpActionResult GetAllCompanyJobSkill()
        {
            List<CompanyJobSkillPoco> appJobApp = _logic.GetAll();
            return Ok(appJobApp);
        }

        [HttpPost]
        [Route("jobskill")]
        public IHttpActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobskill")]
        public IHttpActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("jobskill")]
        public IHttpActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
