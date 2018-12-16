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
    public class ApplicantWorkHistoryController : ApiController
    {
        private ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistoryController()
        {
            _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
        }
        [HttpGet]
        [Route("work/{applicantWorkHistoryId}")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public IHttpActionResult GetApplicantWorkHistory(Guid applicantWorkHistoryId)
        {
            ApplicantWorkHistoryPoco appWork = _logic.Get(applicantWorkHistoryId);
            if (appWork == null)
            {
                return NotFound();
            }

            return Ok(appWork);
        }

        [HttpGet]
        [Route("work")]
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult GetAllApplicantWorkHistory()
        {
            List<ApplicantWorkHistoryPoco> appJobApp = _logic.GetAll();
            return Ok(appJobApp);
        }

        [HttpPost]
        [Route("work")]
        public IHttpActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("work")]
        public IHttpActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("work")]
        public IHttpActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
