using efApp.Data;
using efApp.Models;
using efApp.Repository;
using efApp.Repository.Implementations;
using efApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        //needed to configure appsettings
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
        // dependency injection
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MyDbContext>();

    try
    {
        context.Database.Migrate();

        // getting the repository and doing the CRUD operations
        var studentRepository = services.GetRequiredService<IRepository<Student>>();

        var newStudent = new Student
        {
            FirstName = "Anas",
            LastName = "Hamzaoui",
            StudentNumber = 165284
        };

        await studentRepository.AddAsync(newStudent);

        Console.WriteLine("Nouvelle entité ajoutée avec succès !");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
    }
}

await host.RunAsync();