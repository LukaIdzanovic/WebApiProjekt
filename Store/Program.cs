using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;
using Store.Models;
using Store.Repository;
using Store.Repository.Common;
using Store.Service;
using Store.Service.Common;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

MapperConfiguration configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<PatientDto, Patient>().ReverseMap();
    cfg.CreateMap<MedicDto, Medic>().ReverseMap();
});
IMapper mapper = configuration.CreateMapper();

// Add services to the container.
//builder.Services.AddTransient<IPatientService, PatientService>();
//builder.Services.AddTransient<IMedicService, MedicService>();
//builder.Services.AddTransient<IPatientRepository, PatientRepository>();
//builder.Services.AddTransient<IPatientRepository, MedicRepository>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterType<PatientService>()
            .As<IPatientService>()
            .InstancePerDependency();
        builder.RegisterType<MedicService>()
            .As<IMedicService>()
            .InstancePerDependency();
        builder.RegisterType<PatientRepository>()
            .As<IPatientRepository>()
            .InstancePerDependency();
        builder.RegisterType<MedicRepository>()
            .As<IMedicRepository>()
            .InstancePerDependency();
        builder.RegisterInstance(mapper)
            .As<IMapper>()
            .SingleInstance();
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
