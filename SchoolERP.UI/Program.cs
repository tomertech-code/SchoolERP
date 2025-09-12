using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolERP.BLL.Interfaces;
using SchoolERP.BLL.Services;
using SchoolERP.Business.Services;
using SchoolERP.Common.Logging;
using SchoolERP.Data.DbContext;
using SchoolERP.Data.Entities;
using SchoolERP.Data.Interfaces;
using SchoolERP.Data.Repositories;
using SchoolERP.Data.Seeding;
var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<SchoolERPDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolERPDB")));

// Add Identity (with Roles)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<SchoolERPDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

     // Register the service

// Add custom services BEFORE Build
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentComplaintService, StudentComplaintService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IExamResultService, ExamResultService>();
builder.Services.AddSingleton<FileUploadService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 Run Seeder AFTER Build but BEFORE app.Run()

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    await DbSeeder.SeedRolesAndAdminAsync(roleManager, userManager);
}

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // 👈 Required before Authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();