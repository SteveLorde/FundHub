﻿using FundHubAPI.Data;
using FundHubAPI.Services.Repositories.NewsRepository;
using FundHubAPI.Services.Repositories.ProjectsRepository;
using FundHubAPI.Services.Repositories.UsersRepository;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.StartupService;

public class Startup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;

    public Startup(IServiceProvider serviceProvider, IWebHostEnvironment webenv)
    {
        _serviceprovider = serviceProvider;
        _webenv = webenv;
    }

    public void ExecuteServices()
    {
        var storagefolder = Path.Combine(_webenv.ContentRootPath, "Storage");
        Directory.CreateDirectory(storagefolder);
        var scopedb = _serviceprovider.CreateScope();
        var servicescopedb = scopedb.ServiceProvider;
        var dbservice = servicescopedb.GetRequiredService<DataContext>();
        dbservice.Database.Migrate();
        
        var scope1 = _serviceprovider.CreateScope();
        var newsservice = scope1.ServiceProvider.GetRequiredService<INewsRepository>();
        newsservice.CreateNewsFolders();
        
        var scope2 = _serviceprovider.CreateScope();
        var projectsservice = scope2.ServiceProvider.GetRequiredService<IProjectsRepository>();
        projectsservice.CreateFolders();
        
        var scope3 = _serviceprovider.CreateScope();
        var usersservice = scope3.ServiceProvider.GetRequiredService<IUserRepository>();
        usersservice.CreateFolders();

    }
        
        
}