using WalletLedgerApi.Services;
using WalletLedgerApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<WalletService>();
builder.Services.AddScoped<LedgerService>();
builder.Services.AddScoped<WalletBalanceService>();
builder.Services.AddScoped<LedgerEntryValidator>();
builder.Services.AddScoped<LedgerApplicationService>();
builder.Services.AddScoped<LedgerDashboardService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
