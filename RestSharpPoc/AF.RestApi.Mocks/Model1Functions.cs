using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AutoFixture;
using RestSharpPoc.Models;
using System.Linq;

namespace AF.RestApi.Mocks
{
    public static class Model1Functions
    {
        [FunctionName("Model1_GetById")]
        public static IActionResult GetById(
         [HttpTrigger(AuthorizationLevel.Function, "get", Route = "model1/{id}")] HttpRequest req,
         string id,
         ILogger log)
        {
            string authorizationHeader = req.Headers["Authorization"];
            log.LogInformation($"Authorization header: {authorizationHeader}");

            Fixture fixture = new Fixture();
            Model1 model = fixture.Create<Model1>();
            model.Echo = authorizationHeader;
            model.Id = id;

            return new OkObjectResult(model);
        }
        [FunctionName("Model1_GetAll")]
        public static IActionResult GetAll(
         [HttpTrigger(AuthorizationLevel.Function, "get", Route = "model1")] HttpRequest req,
         ILogger log)
        {
            string authorizationHeader = req.Headers["Authorization"];
            log.LogInformation($"Authorization header: {authorizationHeader}");

            Fixture fixture = new Fixture();
            Model1[] model = fixture.Create<Model1[]>();
            model.ToList().ForEach(m=> m.Echo = authorizationHeader);
            return new OkObjectResult(model);
        }
    }
}
