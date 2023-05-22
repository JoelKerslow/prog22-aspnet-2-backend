using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using WebApi.Contexts;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Contexts

builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Data")));
builder.Services.AddDbContext<IdentityContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));
#endregion

#region Repositories

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<CustomerProfileRepository>();
builder.Services.AddScoped<ShowcaseRepository>();
builder.Services.AddScoped<OrderReviewRepository>();
builder.Services.AddScoped<ProductReviewRepository>();
builder.Services.AddScoped<CartRepository>();
builder.Services.AddScoped<PromoCodeRepository>();
builder.Services.AddScoped<OrderRepository>();


#endregion

#region Services

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CustomerProfileService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductReviewService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<PromoCodeService>();

#endregion

#region Identity

builder.Services.AddDefaultIdentity<IdentityUser>(x =>
{
	x.User.RequireUniqueEmail = true;
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>();

#endregion

#region Authentication

builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
	x.Events = new JwtBearerEvents
	{
		OnTokenValidated = context =>
		{
			if (string.IsNullOrEmpty(context?.Principal?.FindFirst("id")?.Value) || string.IsNullOrEmpty(context?.Principal?.Identity?.Name))
				context?.Fail("Unauthorized");

			return Task.CompletedTask;
		}
	};

	x.RequireHttpsMetadata = true;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
		ValidateLifetime = true,
		ValidateIssuer = true,
		ValidIssuer = builder.Configuration.GetSection("TokenValidation").GetValue<string>("ValidIssuer"),
		ValidateAudience = true,
		ValidAudience = builder.Configuration.GetSection("TokenValidation").GetValue<string>("ValidAudience"),
		ClockSkew = TimeSpan.FromSeconds(0),
	};
});

#endregion

#region Swagger

builder.Services.AddSwaggerGen(config =>
{
	config.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });
	config.OperationFilter<ApiHeaderParameters>();
});

#endregion

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
