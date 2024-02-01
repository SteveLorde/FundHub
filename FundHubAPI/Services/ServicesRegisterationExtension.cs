﻿using FundHubAPI.Data;
using FundHubAPI.Services.Authentication;
using FundHubAPI.Services.AutoMapper;
using FundHubAPI.Services.JWT;
using FundHubAPI.Services.Repositories.CategoriesRepository;
using FundHubAPI.Services.Repositories.NewsRepository;
using FundHubAPI.Services.Repositories.ProjectsRepository;
using FundHubAPI.Services.Repositories.UsersRepository;
using FundHubAPI.Services.StartupService;
using FundHubAPI.Services.Users;

namespace FundHubAPI.Services;

public static class ServicesRegisterationExtension
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DataContext>();
        serviceCollection.AddScoped<IAuthentication,Authentication.Authentication>();
        serviceCollection.AddScoped<IJWT,Jwt>();
        serviceCollection.AddScoped<IUsers,Users.Users>();
        serviceCollection.AddScoped<IProjectsRepository,ProjectsRepository>();
        serviceCollection.AddScoped<ICategoryRepository,CategoryRepository>();
        serviceCollection.AddScoped<INewsRepository,NewsRepository>();
        serviceCollection.AddScoped<IUserRepository,UserRepository>();
        serviceCollection.AddScoped<Startup>();
        serviceCollection.AddAutoMapper(typeof(AutoProfile));
    }
}