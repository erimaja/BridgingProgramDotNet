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
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
        }
        [HttpGet]
        [Route("country/{systemCountryCodeId}")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string systemCountryCode)
        {
            SystemCountryCodePoco country = _logic.Get(systemCountryCode);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpGet]
        [Route("country")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetAllSystemCountryCode()
        {
            List<SystemCountryCodePoco> country = _logic.GetAll();
            return Ok(country);
        }

        [HttpPost]
        [Route("country")]
        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("country")]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("country")]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
