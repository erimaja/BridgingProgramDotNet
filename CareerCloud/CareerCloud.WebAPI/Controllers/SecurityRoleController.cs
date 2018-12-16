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
    public class SecurityRoleController : ApiController
    {
        private SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
        }
        [HttpGet]
        [Route("role/{SecurityRoleId}")]
        [ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid SecurityRoleId)
        {
            SecurityRolePoco securityRole = _logic.Get(SecurityRoleId);
            if (securityRole == null)
            {
                return NotFound();
            }

            return Ok(securityRole);
        }

        [HttpGet]
        [Route("role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetAllSecurityRole()
        {
            List<SecurityRolePoco> securityRole = _logic.GetAll();
            return Ok(securityRole);
        }

        [HttpPost]
        [Route("role")]
        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("role")]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("role")]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
