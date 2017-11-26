﻿using Swashbuckle.Examples;
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
    public class ValuesController : ApiController
    {
        [HttpPost]
        [Route("api/values/person")]

        [SwaggerResponse(HttpStatusCode.OK, "Successfully found the person", typeof(PersonResponse))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(PersonResponseExample), jsonConverter: typeof(StringEnumConverter))]
        // [SwaggerResponseExample(HttpStatusCode.OK, typeof(PersonResponseExample), typeof(DefaultContractResolver))]

        [SwaggerResponse(HttpStatusCode.NotFound, "Could not find the person", typeof(ErrorResponse))]
        [SwaggerResponseExample(HttpStatusCode.NotFound, typeof(NotFoundResponseExample))]

        [SwaggerResponse(HttpStatusCode.InternalServerError, "There was an unexpected error")]
        [SwaggerResponseExample(HttpStatusCode.InternalServerError, typeof(InternalServerResponseExample))]

        [SwaggerRequestExample(typeof(PersonRequest), typeof(PersonRequestExample), jsonConverter: typeof(StringEnumConverter))]
        public IHttpActionResult GetPerson(PersonRequest personRequest)
        {
            var personResponse = new PersonResponse { Id = 1, Title = Title.Mr, FirstName = "Dave", Age = 32 };
            return Ok(personResponse);
        }

        [HttpPost]
        [Route("api/values/genericperson")]
        [SwaggerResponse(HttpStatusCode.OK, "Successfully found the person", typeof(ResponseWrapper<PersonResponse>))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(WrappedPersonResponseExample), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerRequestExample(typeof(RequestWrapper<PersonRequest>), typeof(WrappedPersonRequestExample), jsonConverter: typeof(StringEnumConverter))]
        public IHttpActionResult GetGenericPerson(RequestWrapper<PersonRequest> personRequest)
        {
            var personResponse = new ResponseWrapper<PersonResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Body = new PersonResponse { Id = 1, FirstName = "Dave" }
            };

            return Ok(personResponse);
        }

        [HttpPost]
        [Route("api/value/saveperson")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(PersonResponseExample), jsonConverter: typeof(StringEnumConverter))]
        public HttpResponseMessage PostenericPerson(RequestWrapper<PersonRequest> personRequest)
        {
            int result = 10;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
