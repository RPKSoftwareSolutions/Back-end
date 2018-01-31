using AuthServer.Generic;
using AuthServer.Uow;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SeedMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IUnitOfWork, UnitOfWork>()
            .BuildServiceProvider();

            var U = serviceProvider.GetService<IUnitOfWork>();
            
            /*U.Clients.Add(new DomainModel.Client()
            {
                ClientId = "resourceOwner",
                AccessTokenLifeTime = 3600,
                AllowedCorsOrigins = 
            })*/

            Console.WriteLine("Hello World!");
            
        }
    }
}
