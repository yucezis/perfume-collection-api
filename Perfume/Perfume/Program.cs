using Microsoft.EntityFrameworkCore;
using Perfume.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Baðlantýsý
builder.Services.AddDbContext<PerfumeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Controller ve Sonsuz Döngü Korumasý
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// 3. SWAGGER SERVÝSLERÝ (O yeþil ekranýn beyni burasý)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. HTTP Ýstek Hattý (Pipeline)
if (app.Environment.IsDevelopment())
{
    // SWAGGER ARAYÜZÜNÜ ÇÝZEN KISIM (Burasý eklendi)
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();