using rardk.web.BusinessLayer;
using rardk.web.ServiceLayer;

namespace rardk.web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ILetterboxdBusinessLayer, LetterboxdBusinessLayer>();
            builder.Services.AddScoped<ILetterboxdServiceLayer, LetterboxdServiceLayer>();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}