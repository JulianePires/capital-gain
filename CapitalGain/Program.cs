using CapitalGain.Data.Services;
using CapitalGain.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace CapitalGain
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IProcessOperationUseCase, OperationsService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IProcessOperationUseCase>();

            Console.WriteLine("STDIN");
            Console.WriteLine("Enter the values:");

            var input = Console.ReadLine();

            Console.WriteLine("STDOUT");
            try
            {
                Console.WriteLine(service.CalculateTaxesFromUserInput(input));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}