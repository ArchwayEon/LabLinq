using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabLinq.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LabLinq
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			SeedData(host);
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		public static void SeedData(IHost host)
		{
			using var scope = host.Services.CreateScope();
			var services = scope.ServiceProvider;
			try
			{
				var initializer = services.GetRequiredService<Initializer>();
				initializer.SeedDatabase();
			}
			catch (Exception)
			{
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError("An error occurred while seeding the database.");
			}
		}
	}
}
