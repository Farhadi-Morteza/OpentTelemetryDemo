
namespace WebApiA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ////Open Telemetry
            //// Logging
            //builder.Logging.AddOpenTelemetry(logging =>
            //{
            //    logging.IncludeScopes = true;
            //    logging.ParseStateValues = true;
            //    logging.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName));

            //});

            //// Tracing & Metrics
            //builder.Services.AddOpenTelemetry()
            //    .WithTracing(tracer =>
            //    {
            //        tracer
            //            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName))
            //            .AddAspNetCoreInstrumentation()
            //            .AddHttpClientInstrumentation();

            //        tracer.AddOtlpExporter();
            //        tracer.AddJaegerExporter();
            //    })
            //    .WithMetrics(metrics =>
            //    {
            //        metrics
            //            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName))
            //            .AddAspNetCoreInstrumentation()
            //            .AddHttpClientInstrumentation();

            //        metrics.AddOtlpExporter();
            //    });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient("WebApiB", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7279"); // WebApiB address
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
