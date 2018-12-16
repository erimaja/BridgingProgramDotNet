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
    public class ApplicantProfileController : ApiController
    {
        private ApplicantProfileLogic _logic;

        public ApplicantProfileController()
        {
            _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
        }
        [HttpGet]
        [Route("profile/{applicantProfileId}")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public IHttpActionResult GetApplicantProfile(Guid applicantProfileId)
        {
            ApplicantProfilePoco appJobApp = _logic.Get(applicantProfileId);
            if (appJobApp == null)
            {
                return NotFound();
            }

            return Ok(appJobApp);
        }

        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(List<ApplicantProfilePoco>))]
        public IHttpActionResult GetAllApplicantProfile()
        {
            List<ApplicantProfilePoco> appProf = _logic.GetAll();
            return Ok(appProf);
        }

        [HttpPost]
        [Route("profile")]
        public IHttpActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]
        public IHttpActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("profile/{companyProfieId}")]
        public IHttpActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
