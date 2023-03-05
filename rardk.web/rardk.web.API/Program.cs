using rardk.web.BusinessLayer;
using rardk.web.Models;
using rardk.web.ServiceLayer;

namespace rardk.web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var rardkAllowOrigins = "_rardkAllowOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: rardkAllowOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200",
                            "http://localhost:52340",
                            "https://rardk.com",
                            "https://www.rardk.com");
                    });
            });

            // Add services to the container.
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var letterboxdSettings = new LetterboxdSettings(configuration["Letterboxd:ProfileUrl"]);
            var backloggdSettings = new BackloggdSettings(configuration["Backloggd:ProfileUrl"]);

            builder.Services.AddSingleton(letterboxdSettings);
            builder.Services.AddSingleton(backloggdSettings);

            builder.Services.AddScoped<ILetterboxdBusinessLayer, LetterboxdBusinessLayer>();
            builder.Services.AddScoped<ILetterboxdServiceLayer, LetterboxdServiceLayer>();

            builder.Services.AddScoped<IBackloggdBusinessLayer, BackloggdBusinessLayer>();
            builder.Services.AddScoped<IBackloggdServiceLayer, BackloggdServiceLayer>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();
            }

            app.UseCors(rardkAllowOrigins); //this must be between UseRouting and UseEndpoints if those exist (i.e. with endpoint routing)

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}