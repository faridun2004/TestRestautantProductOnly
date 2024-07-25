using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestRestautantProductOnly.CommandsQueries.Mappings;
using TestRestautantProductOnly.Infractruct;
using TestRestautantProductOnly.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestaurantContext>(con => con.UseSqlServer(builder.Configuration["ConnectionString"])
                      .LogTo(Console.Write, LogLevel.Error)
          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMyServices();
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetService<RestaurantContext>();
        context.Database.Migrate();
    }
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1"));
}
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
