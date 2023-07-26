using RestSharp;
using RestSharp.Authenticators;
using RestSharpPoc.Models;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Scenarios
{
    internal class InlineRestClientWithOptions : BaseScenario
    {
        public static async Task GetByIdModel1()
        {
            Console.WriteLine($"{nameof(InlineRestClientWithOptions)}.{nameof(GetByIdModel1)}()");

            var id = nameof(InlineRestClientWithOptions);

            var options = new RestClientOptions("http://localhost:7001/api")
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };
            var client = new RestClient(options);

            var request = new RestRequest($"model1/{id}");

            var response = await client.GetAsync<Model1>(request);

            Display(response);

            Console.WriteLine();
        }
        public static async Task GetManyModel1()
        {
            Console.WriteLine($"{nameof(InlineRestClientWithOptions)}.{nameof(GetManyModel1)}()");

            var id = nameof(InlineRestClientWithOptions);

            var options = new RestClientOptions("http://localhost:7001/api")
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };
            var client = new RestClient(options);

            var request = new RestRequest($"model1");

            var response = await client.GetAsync<Model1[]>(request);

            response?.ToList().ForEach(r => Display(r));

            Console.WriteLine();
        }

        public static async Task GetByIdModel2()
        {
            Console.WriteLine($"{nameof(InlineRestClientWithOptions)}.{nameof(GetByIdModel2)}()");

            var id = nameof(InlineRestClientWithOptions);

            var options = new RestClientOptions("http://localhost:7001/api")
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };
            var client = new RestClient(options);

            var request = new RestRequest($"model2/{id}");

            var response = await client.GetAsync<Model2>(request);

            Display(response);

            Console.WriteLine();
        }
        public static async Task GetManyModel2()
        {
            Console.WriteLine($"{nameof(InlineRestClientWithOptions)}.{nameof(GetManyModel2)}()");

            var id = nameof(InlineRestClientWithOptions);

            var options = new RestClientOptions("http://localhost:7001/api")
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };
            var client = new RestClient(options);

            var request = new RestRequest($"model2");

            var response = await client.GetAsync<Model2[]>(request);

            response?.ToList().ForEach(r => Display(r));

            Console.WriteLine();
        }

        public static async Task GetWithDetection()
        {
            Console.WriteLine($"{nameof(InlineRestClientWithOptions)}.{nameof(GetManyModel2)}()");

            var id = nameof(InlineRestClientWithOptions);

            var options = new RestClientOptions("http://localhost:7001/api")
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };
            var client = new RestClient(options);

            var request = new RestRequest($"model2/status1");

            var response = await client.ExecuteAsync(request);

            // Can control deserialization of the model manually.
            var model1Response = client.Deserialize<Model1>(response);
            var model2Response = client.Deserialize<Model2>(response);

            if (model1Response.IsSuccessful) Display(model1Response.Data);
            if (model2Response.IsSuccessful) Display(model2Response.Data);


            Console.WriteLine();
        }
    }
}
