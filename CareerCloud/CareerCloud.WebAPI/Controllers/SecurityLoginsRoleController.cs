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
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
        }
        [HttpGet]
        [Route("loginsrole/{securityLoginsRoleId}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]
        public IHttpActionResult GetSecurityLoginsRole(Guid securityLoginsRoleId)
        {
            SecurityLoginsRolePoco loginsRole = _logic.Get(securityLoginsRoleId);
            if (loginsRole == null)
            {
                return NotFound();
            }

            return Ok(loginsRole);
        }

        [HttpGet]
        [Route("loginsrole")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public IHttpActionResult GetAllSecurityLoginsRole()
        {
            List<SecurityLoginsRolePoco> loginsRole = _logic.GetAll();
            return Ok(loginsRole);
        }

        [HttpPost]
        [Route("loginsrole")]
        public IHttpActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginsrole")]
        public IHttpActionResult PutSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("loginsrole")]
        public IHttpActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
