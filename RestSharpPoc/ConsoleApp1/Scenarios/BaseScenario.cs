using RestSharpPoc.Models;

namespace ConsoleApp1.Scenarios
{
    internal abstract class BaseScenario
    {
        protected static void Display(Model1? response)
        {
            if(response == null)
            {
                Console.WriteLine("Response is null");
                return;
            }
            Console.WriteLine($"Response.Id: {response.Id}");
            Console.WriteLine($"Response.Echo: {response.Echo}");
            Console.WriteLine($"Response.Message: {response.Message}");
            Console.WriteLine($"Response.ActivationDate: {response.ActivationDate}");
        }
        protected static void Display(Model2? response)
        {
            if (response == null)
            {
                Console.WriteLine("Response is null");
                return;
            }
            Console.WriteLine($"Response.Status: {response.Status}");
            Console.WriteLine($"Response.Echo: {response.Echo}");
            Console.WriteLine($"Response.Message: {response.Message}");
            Console.WriteLine($"Response.CurrentDateTime: {response.CurrentDateTime}");
        }
    }
}