// See https://aka.ms/new-console-template for more information

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//     
// builder.Logging.AddSerilog();

builder.Services.InitializeService();