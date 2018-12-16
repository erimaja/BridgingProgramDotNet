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
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
        }
        [HttpGet]
        [Route("language/{systemLanguageCodePocoId}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]
        public IHttpActionResult GetSystemLanguageCode(string systemLanguageCodeId)
        {
            SystemLanguageCodePoco sysLan = _logic.Get(systemLanguageCodeId);
            if (sysLan == null)
            {
                return NotFound();
            }

            return Ok(sysLan);
        }

        [HttpGet]
        [Route("language")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult GetAllSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> sysLan = _logic.GetAll();
            return Ok(sysLan);
        }

        [HttpPost]
        [Route("language")]
        public IHttpActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("language")]
        public IHttpActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("language")]
        public IHttpActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
