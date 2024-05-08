using HospitalPaymentSystem.Core.Abstractions;
using HospitalPaymentSystem.Core.Services;
using HospitalPaymentSystem.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPatientServices, PatientServices>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IRepository, Repository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Patient/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Index}/{id?}");

app.Run();
