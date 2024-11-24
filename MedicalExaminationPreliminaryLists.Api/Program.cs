using System.Text;
using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using TFOMSUploadServer.Infrastructure.Repositories;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDiagnosisDictionaryRepository, DiagnosisDictionaryRepository>();
builder.Services.AddTransient<IDispensaryObservationRepository, DispensaryObservationRepository>();
builder.Services.AddTransient<IMedProfileDictionaryRepository, MedProfileDictionaryRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<IZAPRepository, ZAPRepository>();
builder.Services.AddTransient<IUploadFileRepository, UploadFileRepository>();



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TFOMSContextConnection"));
    //options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

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
