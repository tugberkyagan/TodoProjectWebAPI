using FinalTodoProject.Api.Controllers;
using FinalTodoProject.Data.SubTodoData;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Data.UserData;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Service;
using FinalTodoProject.Service.TodoServices;
using FinalTodoProject.Service.UserServices;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Cors;



namespace FinalTodoProject.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddCors();

            var todoConnectionString = "Server= localhost; Database= DbTodo; Integrated Security=True";

            services.AddSingleton<ITodoProjectDbConnection>(s => new TodoProjectDbConnection(todoConnectionString));

            // Services for Todo
            services.AddSingleton<IGetTodoByIdServiceRequest, GetTodoByIdServiceRequest>();
            services.AddSingleton<IGetAllTodosServiceRequest, GetAllTodosServiceRequest>();
            services.AddSingleton<IInsertTodoServiceRequest, InsertTodoServiceRequest>();
            services.AddSingleton<IDeleteTodoByIdServiceRequest, DeleteTodoByIdServiceRequest>();
            services.AddSingleton<IGetAllTodoTitlesServiceRequest, GetAllTodoTitlesServiceRequest>();
            services.AddSingleton<IUpdateTodoByIdServiceRequest, UpdateTodoByIdServiceRequest>();
            services.AddSingleton<ISwitchTodoDoneServiceRequest, SwitchTodoDoneServiceRequest>();
            services.AddSingleton<IGetProgressAndIdFromTodoBySubTodoIdServiceRequest, GetProgressAndIdFromTodoBySubTodoIdServiceRequest>();
            services.AddSingleton<ISwitchTodoUndoneServiceRequest, SwitchTodoUndoneServiceRequest>();

            // Services for User
            services.AddSingleton<IGetAllUsersServiceRequest, GetAllUsersServiceRequest>();
            services.AddSingleton<IGetUserByIdServiceRequest, GetUserByIdServiceRequest>();
            services.AddSingleton<IDeleteUserByIdServiceRequest, DeleteUserByIdServiceRequest>();
            services.AddSingleton<IInsertUserServiceRequest, InsertUserServiceRequest>();
            services.AddSingleton<IUpdateUserByIdServiceRequest, UpdateUserByIdServiceRequest>();
            services.AddSingleton<IGetUserNameByTodoIsDoneServiceRequest, GetUserNameByTodoIsDoneServiceRequest>();

            // Services for SubTodo
            services.AddSingleton<IInsertSubTodoServiceRequest, InsertSubTodoServiceRequest>();
            services.AddSingleton<ISwitchSubTodoDoneServiceRequest, SwitchSubTodoDoneServiceRequest>();
            services.AddSingleton<IDeleteSubTodoByIdServiceRequest, DeleteSubTodoByIdServiceRequest>();


            // Data for Todo
            services.AddSingleton<IGetTodoByIdDataRequest, GetTodoByIdDataRequest>();
            services.AddSingleton<IGetAllTodosDataRequest, GetAllTodosDataRequest>();
            services.AddSingleton<IInsertTodoDataRequest, InsertTodoDataRequest>();
            services.AddSingleton<IDeleteTodoByIdDataRequest, DeleteTodoByIdDataRequest>();
            services.AddSingleton<IUpdateTodoByIdDataRequest, UpdateTodoByIdDataRequest>();
            services.AddSingleton<IGetProgressAndIdFromTodoBySubTodoIdDataRequest, GetProgressAndIdFromTodoBySubTodoIdDataRequest>();
            services.AddSingleton<ISwitchTodoDoneDataRequest, SwitchTodoDoneDataRequest>();
            services.AddSingleton<IChangeProgressOfTodoDataRequest, ChangeProgressOfTodoDataRequest>();
            services.AddSingleton<ISwitchTodoUndoneDataRequest, SwitchTodoUndoneDataRequest>();

            // Data for User
            services.AddSingleton<IGetAllUsersDataRequest, GetAllUsersDataRequest>();
            services.AddSingleton<IGetUserByIdDataRequest, GetUserByIdDataRequest>();
            services.AddSingleton<IDeleteUserByIdDataRequest, DeleteUserByIdDataRequest>();
            services.AddSingleton<IInsertUserDataRequest, InsertUserDataRequest>();
            services.AddSingleton<IUpdateUserByIdDataRequest, UpdateUserByIdDataRequest>();
            services.AddSingleton<IGetUserNameByTodoIsDoneDataRequest, GetUserNameByTodoIsDoneDataRequest>();

            // Data for SubTodo
            services.AddSingleton<IGetEffectPercentageFromSubTodoDataRequest, GetEffectPercentageFromSubTodoDataRequest>();
            services.AddSingleton<IInsertSubTodoDataRequest, InsertSubTodoDataRequest>();
            services.AddSingleton<ISwitchSubTodoDoneDataRequest, SwitchSubTodoDoneDataRequest>();
            services.AddSingleton<IDeleteSubTodoByIdDataRequest, DeleteSubTodoByIdDataRequest>();
            services.AddSingleton<ISwitchSubTodosUndoneByTodoIdDataRequest, SwitchSubTodosUndoneByTodoIdDataRequest>();
            services.AddSingleton<IGetEffectPercentageOfSubTodosByTodoIdDataRequest, GetEffectPercentageOfSubTodosByTodoIdDataRequest>();

            // Controllers
            services.AddSingleton<TodoController>();
            services.AddSingleton<UserController>();
            services.AddSingleton<SubTodoController>();


            // Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Todo Api",
                    Description = "Todo Api"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo Api Swagger");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var corsUrl = "http://127.0.0.1:5500";

            app.UseCors(builder => builder.WithOrigins(corsUrl).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); }); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}