var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(options =>
        options.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
app.MapControllers();
app.Run();
