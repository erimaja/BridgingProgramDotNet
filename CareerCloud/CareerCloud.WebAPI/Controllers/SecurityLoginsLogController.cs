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
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
        }
        [HttpGet]
        [Route("log/{securityLoginsLogId}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]
        public IHttpActionResult GetSecurityLoginLog(Guid securityLoginsLogId)
        {
            SecurityLoginsLogPoco loginsLog = _logic.Get(securityLoginsLogId);
            if (loginsLog == null)
            {
                return NotFound();
            }

            return Ok(loginsLog);
        }

        [HttpGet]
        [Route("log")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]
        public IHttpActionResult GetAllSecurityLoginsLog()
        {
            List<SecurityLoginsLogPoco> loginsLog = _logic.GetAll();
            return Ok(loginsLog);
        }

        [HttpPost]
        [Route("log")]
        public IHttpActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("log")]
        public IHttpActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("log/{companyProfieId}")]
        public IHttpActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
