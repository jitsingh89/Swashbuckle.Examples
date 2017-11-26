using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json.Converters;
using WebApi.Models;
using WebApi.Models.Examples;
using System.Net.Http;

namespace WebApi.Controllers
{
    public class PersonController : ApiController
    {

        [HttpPost]
        [Route("api/Person/save")]
        //[SwaggerResponseExample(HttpStatusCode.OK, typeof(StringResponseExample))]
        [SwaggerResponse(HttpStatusCode.OK, "Saves the person", typeof(string))]
        public HttpResponseMessage PostenericPerson(PersonRequest personRequest)
        {
            string result = "Created";
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }



        [HttpPost]
        [Route("api/Person/saveok")]
        [SwaggerResponse(HttpStatusCode.OK, "Ok", typeof(PersonResponseExample))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(PersonResponseExample))]
        public HttpResponseMessage SavePersonOk(PersonRequest personRequest)
        {
            var result = new PersonResponse
            {
                Id = 123,
                Title = Title.Dr,
                FirstName = "John",
                LastName = "Doe",
                Age = 27,
                Income = null
            };
            return Request.CreateResponse(HttpStatusCode.Created, result);
        }

        
        [HttpPost]
        [Route("api/Person/savecreted")]
       
        [SwaggerResponse(HttpStatusCode.Created, "Created", typeof(PersonResponse))]

        public HttpResponseMessage SavePersonCreated(PersonRequest personRequest)
        {
            var result = new PersonResponse
            {
                Id = 123,
                Title = Title.Dr,
                FirstName = "John",
                LastName = "Doe",
                Age = 27,
                Income = null
            };
            return Request.CreateResponse(HttpStatusCode.Created, result);
        }



    }
}