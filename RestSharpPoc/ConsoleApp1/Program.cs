using ConsoleApp1.Scenarios;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await InlineRestClientWithOptions.GetByIdModel1();
            await InlineRestClientWithOptions.GetManyModel1();
            await InlineRestClientWithOptions.GetByIdModel2();
            await InlineRestClientWithOptions.GetManyModel2();
            await InlineRestClientWithOptions.GetWithDetection();
        }
    }
}