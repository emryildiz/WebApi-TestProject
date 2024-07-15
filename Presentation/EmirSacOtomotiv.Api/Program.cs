using EmirSacOtomotiv.Api.Extensions;
using EmirSacOtomotiv.Application;
using EmirSacOtomotiv.Infrastructure;
using EmirSacOtomotiv.Infrastructure.Services.Storage.Local;
using EmirSacOtomotiv.Persistence;
using EmirSacOtomotiv.Persistence.Context;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();
builder.Services.AddDbContext<EmirSacOtomotivDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EmirSacOtomotivDb")));

builder.Services.AddStorage<LocalStorage>();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(b => b.AllowAnyHeader()
                                                           .AllowAnyOrigin()
                                                           .AllowAnyMethod()));

Logger log = new LoggerConfiguration().WriteTo.Console()
                                      .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                                      .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("Log"), "logs",
                                                          needAutoCreateTable: true,
                                                          columnOptions: new Dictionary<string, ColumnWriterBase>
                                                          {
                                                              { "message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
                                                              { "message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
                                                              { "level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
                                                              { "time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
                                                              { "exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
                                                              { "log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json) },
                                                          })
                                      .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"] ?? string.Empty)
                                      .Enrich.FromLogContext()
                                      .MinimumLevel.Information()
                                      .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit  = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());

app.UseCors();

app.UseSerilogRequestLogging();
app.UseHttpLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
