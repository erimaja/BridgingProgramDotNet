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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantEducationController : ApiController
    {
        private ApplicantEducationLogic _logic;

        public ApplicantEducationController()
        {
            _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
        }

        [HttpGet]
        [Route("education/{applicantEducationId}")]
        [ResponseType(typeof(ApplicantEducationPoco))]
        public IHttpActionResult GetApplicantEducation(Guid applicantEducationId)
        {
            ApplicantEducationPoco appEdu = _logic.Get(applicantEducationId);
            if (appEdu == null)
            {
                return NotFound();
            }

            return Ok(appEdu);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))]
        public IHttpActionResult GetAllCompanyProfile()
        {
            List<ApplicantEducationPoco> appEdu = _logic.GetAll();
            return Ok(appEdu);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
