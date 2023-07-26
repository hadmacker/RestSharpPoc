using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AutoFixture;
using RestSharpPoc.Models;
using System.Linq;

namespace AF.RestApi.Mocks
{
    public static class Model2Functions
    {
        [FunctionName("Model2_GetById")]
        public static IActionResult GetById(
         [HttpTrigger(AuthorizationLevel.Function, "get", Route = "model2/{status}")] HttpRequest req,
         string status,
         ILogger log)
        {
            string authorizationHeader = req.Headers["Authorization"];
            log.LogInformation($"Authorization header: {authorizationHeader}");

            Fixture fixture = new Fixture();
            Model2 model = fixture.Create<Model2>();
            model.Echo = authorizationHeader;
            model.Status = status;

            return new OkObjectResult(model);
        }
        [FunctionName("Model2_GetAll")]
        public static IActionResult GetAll(
         [HttpTrigger(AuthorizationLevel.Function, "get", Route = "model2")] HttpRequest req,
         ILogger log)
        {
            string authorizationHeader = req.Headers["Authorization"];
            log.LogInformation($"Authorization header: {authorizationHeader}");

            Fixture fixture = new Fixture();
            Model2[] model = fixture.Create<Model2[]>();
            model.ToList().ForEach(m => m.Echo = authorizationHeader);
            return new OkObjectResult(model);
        }
    }
}
