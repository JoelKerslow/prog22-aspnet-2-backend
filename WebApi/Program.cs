using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
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

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
