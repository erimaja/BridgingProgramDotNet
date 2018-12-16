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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
        }
        [HttpGet]
        [Route("location/{companyLocationId}")]
        [ResponseType(typeof(CompanyLocationPoco))]
        public IHttpActionResult GetCompanyLocation(Guid companyLocationId)
        {
            CompanyLocationPoco compLocation = _logic.Get(companyLocationId);
            if (compLocation == null)
            {
                return NotFound();
            }

            return Ok(compLocation);
        }

        [HttpGet]
        [Route("location")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]
        public IHttpActionResult GetAllCompanyLocation()
        {
            List<CompanyLocationPoco> compLocation = _logic.GetAll();
            return Ok(compLocation);
        }

        [HttpPost]
        [Route("location")]
        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("location")]
        public IHttpActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("location")]
        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

    }
}
