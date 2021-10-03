using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

const string basePath = "/api";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(config =>
{
	config.SwaggerDoc("pictr", new() { Title = "Pictr" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger(c =>
	{
		c.PreSerializeFilters.Add((doc, req) => doc.Servers =
			new List<OpenApiServer>
			{
				new OpenApiServer { Url = $"{req.Scheme}://{req.Host.Value}{basePath}" }
			});
	});
	app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/pictr/swagger.json", "Pictr"));
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		// serve compiled SPA files on same host as API
		Path.Combine(app.Environment.ContentRootPath, "wwwroot/dist")),
	RequestPath = ""
});

app.UseAuthorization();

app.Map(basePath, config =>
{
	config.UseRouting();
	config.UseEndpoints(endpoints => endpoints.MapControllers());
});

app.Run();
