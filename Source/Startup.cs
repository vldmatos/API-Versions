using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddApiVersioning(options => 
			{
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
				options.DefaultApiVersion = ApiVersion.Default;
				options.ApiVersionReader = ApiVersionReader.Combine
				(
					new HeaderApiVersionReader("version"),
					new HeaderApiVersionReader("api-version"),
					new HeaderApiVersionReader("x-version"),

					new MediaTypeApiVersionReader("version"),
					new MediaTypeApiVersionReader("api-version"),
					new MediaTypeApiVersionReader("x-version")
				);
			});
		}
		
		public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
		{
			if (webHostEnvironment.IsDevelopment())
			{
				applicationBuilder.UseDeveloperExceptionPage();
			}

			applicationBuilder.UseRouting();
			applicationBuilder.UseAuthorization();
			applicationBuilder.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
