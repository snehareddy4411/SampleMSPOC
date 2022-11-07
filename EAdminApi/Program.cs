var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEKartProductRepository, EKartProductRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyOrigins",
    builder =>
    {        
        builder.WithOrigins("http://localhost:4200");        
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        
    }
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyOrigins");
app.UseHttpsRedirection();


app.UseAuthorization();
app.MapControllers();

app.Run();