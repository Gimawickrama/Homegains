using homegains.Components;
using homegains.Components.Account;
using homegains.Controllers;
using homegains.Controllers.AdminController;
using homegains.Controllers.FullBodyController;
using homegains.Controllers.UserController;
using homegains.Data;
using homegains.services;
using homegains.services.DayPlanService;
using homegains.services.FigureMainService;
using homegains.services.ShedulesService;
using homegains.services.WorkService;
using homegains.Services.BmiCalculatorService;
using homegains.Services.DietPlanService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<AllConnections>();
builder.Services.AddScoped<AddPlan>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<IDayPlanService, DayPlanService>();
builder.Services.AddScoped<IFigureMainService, FigureMainService>();
builder.Services.AddScoped<IShedulesService, ShedulesService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IBmiCalculatorService, BmiCalculatorService>();
builder.Services.AddScoped<IDeitPlanService, DietPlanService>();

//Privacy Policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); //admins role only work
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User")); //user role only work ex client
});

//Class Services Create
builder.Services.AddScoped<FullBodyController>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
     .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
