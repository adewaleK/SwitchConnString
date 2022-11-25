using SwitchConn2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//connectring strings
Dictionary<string, string> connStr = new Dictionary<string, string>();
connStr.Add("DB1", builder.Configuration["ConnectionStrings: ApplicationDbContextConnection"]);
connStr.Add("DB2", builder.Configuration["ConnectionStrings: ApplicationDbContextConnection2"]);
DbContextFactory.SetConnectionString(connStr);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
