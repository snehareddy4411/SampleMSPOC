using Microsoft.AspNetCore.Authentication.JwtBearer;

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

builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:8080/auth/realms/TeamOne";
                o.Audience = "account";
                o.RequireHttpsMetadata = false;

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();

                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";

                        //if (Environment.IsDevelopment())
                        //{
                            return c.Response.WriteAsync(c.Exception.ToString());
                        //}

                        //return c.Response.WriteAsync("An error occured processing your authentication.");
                    }
                };
            });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyOrigins");
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();