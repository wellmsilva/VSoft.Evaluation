using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;
using VSoft.Evaluation.Application.UseCases.Lessons.GetLessonByStudentUseCase;
using VSoft.Evaluation.Application.UseCases.Lessons.ScheduleLessonUseCase;
using VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;
using VSoft.Evaluation.Application.UseCases.Students.DeleteStudentUseCase;
using VSoft.Evaluation.Application.UseCases.Students.GetStudentDetailsUseCase;
using VSoft.Evaluation.Application.UseCases.Students.GetStudentsUseCase;
using VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;
using VSoft.Evaluation.Application.UseCases.Users.LoginUserUseCase;
using VSoft.Evaluation.Application.UseCases.Users.Providers;

namespace VSoft.Evaluation.Application.Extensions.DependencyInjection;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // MassTransit
        services.AddMassTransit(busConfigurator =>
        {
            var entryAssembly = Assembly.GetExecutingAssembly();
            busConfigurator.AddConsumers(entryAssembly);
            busConfigurator.AddConsumer<CreatedStudentConsumer>();
            busConfigurator.AddConsumer<ConcludedLessonConsumer>();


            busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
            {
                var host = configuration.GetValue("RabbitMQ:Host", "localhost");
                busFactoryConfigurator.Host(host, "/", h =>
                {
                    h.Username(configuration.GetValue("RabbitMQ:Username", string.Empty));
                    h.Password(configuration.GetValue("RabbitMQ:Password", string.Empty));

                    h.ConfigureBatchPublish(x => { x.Enabled = true; });
                });

                busFactoryConfigurator.UseMessageRetry(r => r.Intervals(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15)));
                busFactoryConfigurator.AutoStart = true;


                busFactoryConfigurator.ReceiveEndpoint("CreatedStudent", e =>
                {
                    e.ConfigureConsumer<CreatedStudentConsumer>(context);
                });

                busFactoryConfigurator.ReceiveEndpoint("ConcludedLesson", e =>
                {
                    e.ConfigureConsumer<ConcludedLessonConsumer>(context);
                }); 
            });
        });
        
        // User
        services.AddSingleton<TokenProvider>();
        services.AddScoped<ILoginUserCommandHandler, LoginUserCommandHandler>();

        // Student
        services.AddScoped<ICreateStudentCommandHandler, CreateStudentCommandHandler>();
        services.AddScoped<IGetStudentsCommandHandler, GetStudentsCommandHandler>();
        services.AddScoped<IGetStudentCommandHandler, GetStudentCommandHandler>();
        services.AddScoped<IDeleteStudentCommandHandler, DeleteStudentCommandHandler>();
        services.AddScoped<IGetStudentDetailsCommandHandler, GetStudentDetailsCommandHandler>();

        // Lesson
        services.AddScoped<IScheduleLessonCommandHandler, ScheduleLessonCommandHandler>();
        services.AddScoped<IConcludeLessonCommandHandler, ConcludeLessonCommandHandler>();
        services.AddScoped<IGetLessonByStudentCommandHandler, GetLessonByStudentCommandHandler>();


        return services;
    }
}
