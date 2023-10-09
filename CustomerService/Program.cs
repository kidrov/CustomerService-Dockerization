using DAL;
using Microsoft.EntityFrameworkCore;
using Service;

namespace CustomerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Register Repositories
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

            // Register Services
            builder.Services.AddScoped<ICustomerService, CustomerService>();


            builder.Services.AddDbContext<KeepDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration["ConnectionStrings:MyConnectionString"]);
            });




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddConsulConfig(builder.Configuration); 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

               var context = services.GetRequiredService<KeepDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            app.UseConsul(builder.Configuration);
            app.Run();
        }
    }
}
