
using MatchPointMasters.ModelBinders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MatchPointMasters.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MatchPointMastersDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MatchPointMastersDbContextConnection' not found.");

builder.Services.AddDbContext<MatchPointMastersDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MatchPointMastersDbContext>();

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Player Details",
        pattern: "/Player/Details/{id}/{information}",
        defaults: new { Controller = "Player", Action = "Details" }
        );

    endpoints.MapControllerRoute(
        name: "Match Details",
        pattern: "/Match/Details/{id}/{information}",
        defaults: new { Controller = "Match", Action = "Details" }
        );

    endpoints.MapControllerRoute(
        name: "Tournament Details",
        pattern: "/Tournament/Details/{id}/{information}",
        defaults: new { Controller = "Tournament", Action = "Details" }
        );

    endpoints.MapControllerRoute(
        name: "Article Details",
        pattern: "/Article/Details/{id}/{information}",
        defaults: new { Controller = "Article", Action = "Details" }
        );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();

});

await app.RunAsync();
