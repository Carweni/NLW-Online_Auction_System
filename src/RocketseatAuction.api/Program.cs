using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocketseatAuction.api.Contracts;
using RocketseatAuction.api.Filters;
using RocketseatAuction.api.Repositories;
using RocketseatAuction.api.Repositories.DataAccess;
using RocketseatAuction.api.Services;
using RocketseatAuction.api.UseCases.Auctions.GetCurrent;
using RocketseatAuction.api.UseCases.Offers.CreateOffer;
using RocketseatAuction.API.Repositories.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<ILoggedUser, LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<RocketseatAuctionDbContext>(option =>
{
    option.UseSqlite(@"Data Source=C:\databese_path\database.db");

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();