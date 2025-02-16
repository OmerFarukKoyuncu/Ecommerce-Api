using ANK19_ETicaret.Areas.Customer.Controllers;
using BLL.DTO.CustomerProductDtos;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using BLL.MappingProfiles;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.

builder.Services.AddControllers ();
builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });

    // JWT Authentication i�in Security Definition ekle
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'"
    });

    // Security Requirement ekle
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
            new string[] {}
        }
    });
});
builder.Services.AddDbContext<AppDbContext> (options =>
{
   options.UseLazyLoadingProxies().
    UseSqlServer (builder.Configuration.GetConnectionString ("DefaultConnection"));
});

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(ManagerMappingProfile));
builder.Services.AddScoped<Repository<Category>>();
builder.Services.AddScoped<Repository<Seller>>();
builder.Services.AddScoped<Repository<Product>>();
builder.Services.AddScoped<Repository<ProductCategory>>();
builder.Services.AddScoped<Repository<Order>>();
builder.Services.AddScoped<Repository<OrderProduct>>();
builder.Services.AddScoped<IRepository<OrderProduct>, Repository<OrderProduct>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<Repository<Content>>();
builder.Services.AddScoped<Repository<Comment>>();
builder.Services.AddScoped<Repository<ShopCart>>(); 
builder.Services.AddScoped<Repository<ShopCartItem>>();

builder.Services.AddScoped<IRepository<RefundChange>,Repository<RefundChange>>();

builder.Services.AddScoped<Repository<Promotion>>();
builder.Services.AddScoped<Repository<ProductPromotion>>();

builder.Services.AddScoped< ICategoryManager, CategoryManager >();
builder.Services.AddScoped< ISellerManager, SellerManager >();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped< IProductManager, ProductManager >();

builder.Services.AddScoped<IProductPromotionsManager, ProductPromotionsManager>();
builder.Services.AddScoped<IPromotionsManager, PromotionsManager>();

builder.Services.AddScoped<ICustomerProductListManager, CustomerProductListManager>();

builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<IOrderProductManager, OrderProductManager>();
builder.Services.AddScoped<IContentManager, ContentManager>();
builder.Services.AddScoped<IShopCartManager, ShopCartManager>();
builder.Services.AddScoped<DataManager>();




builder.Services.AddScoped<IRefundManager, RefundManager>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()       // Herhangi bir origin'e izin verir
              .AllowAnyHeader()      // Herhangi bir header'a izin verir
              .AllowAnyMethod();     // Herhangi bir HTTP metoduna izin verir
    });
});
builder.Services.AddScoped<ICommentManager, CommentManager>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        RoleClaimType = ClaimTypes.Role,
        NameClaimType = ClaimTypes.NameIdentifier
    };
});


builder.Services.AddScoped<IOrderReportManager, OrderReportManager>();
builder.Services.AddCors();
builder.Services.AddScoped<IUserRoleManager, UserRoleManager>();

builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
var app = builder.Build ();
app.UseCors(builder =>
{
    builder.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment ())
//{
    app.UseSwagger ();
    app.UseSwaggerUI ();
//}
app.UseCors("AllowAll");
app.UseHttpsRedirection ();
app.UseAuthentication();

app.UseAuthorization ();

app.MapControllers ();
app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var fakeDataService = scope.ServiceProvider.GetRequiredService<DataManager>();

    //fakeDataService.GenerateCategory(10); // 10 sahte kullanıcı ekle
    //fakeDataService.GenerateProduct(40); // 10 sahte kullanıcı ekle

}


app.Run ();

