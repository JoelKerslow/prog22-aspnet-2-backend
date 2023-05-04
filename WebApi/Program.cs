using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
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

#endregion

#region Services

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CustomerProfileService>();

#endregion

#region Identity

builder.Services.AddDefaultIdentity<IdentityUser>(x =>
{
	x.User.RequireUniqueEmail = true;
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>();

#endregion

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
