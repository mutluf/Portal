using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portal.Application.Abstractions;
using Portal.Domain.Entities.Users;
using Portal.Persistence;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Portal.Infrastructure;
using Serilog.Core;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using Portal.WebAPI;
using Microsoft.AspNetCore.HttpLogging;
using Serilog.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt=>opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    // Swagger belgelerini oluþturun

    // Kimlik doðrulama gerektir
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT authorization header using the Bearer scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddPersistenceService();

#region columnoptions
SqlColumn sqlColumn = new SqlColumn();
sqlColumn.ColumnName = "UserName";
sqlColumn.DataType = System.Data.SqlDbType.NVarChar;
sqlColumn.PropertyName = "UserName";
sqlColumn.DataLength = 50;
sqlColumn.AllowNull = true;
ColumnOptions columnOpt = new ColumnOptions();
columnOpt.Store.Remove(StandardColumn.Properties);
columnOpt.Store.Add(StandardColumn.LogEvent);
columnOpt.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };
#endregion

Logger log = new LoggerConfiguration()

    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(
    connectionString: builder.Configuration.GetConnectionString("MicrosoftSQL"),
     sinkOptions: new MSSqlServerSinkOptions
     {
         AutoCreateSqlTable = true,
         TableName = "logs",
     },
     appConfiguration: null,
     columnOptions: columnOpt
    )
    .Enrich.FromLogContext()
    .Enrich.With<CustomUserNameColumn>()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,

        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        NameClaimType = ClaimTypes.Name,
    };
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
            var userName = context.Principal.FindFirstValue(ClaimTypes.Name);
            var user = await userManager.FindByNameAsync(userName);
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                context.Principal.Identities.First().AddClaim(new Claim(ClaimTypes.Role, role));
            }
        }
    };
}
);

builder.Services.AddInfrastructureServices();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ITokenHandler, Portal.Infrastructure.Services.TokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHangfireDashboard();
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null; // burayý kontrol et authorize koymayýnca isim gelmiyor.
    LogContext.PushProperty("UserName", userName);


    await next();
}

);
app.MapControllers();

app.Run();
