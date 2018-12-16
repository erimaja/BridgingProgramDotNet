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
    public class ApplicantJobApplicationController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
        }

        [HttpGet]
        [Route("jobapplication/{applicantJobApplicationId}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]
        public IHttpActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
        {
            ApplicantJobApplicationPoco appJobApp = _logic.Get(applicantJobApplicationId);
            if (appJobApp == null)
            {
                return NotFound();
            }

            return Ok(appJobApp);
        }

        [HttpGet]
        [Route("jobapplication")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public IHttpActionResult GetAllApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> appJobApp = _logic.GetAll();
            return Ok(appJobApp);
        }

        [HttpPost]
        [Route("jobapplication")]
        public IHttpActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobapplication")]
        public IHttpActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("jobapplication")]
        public IHttpActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
