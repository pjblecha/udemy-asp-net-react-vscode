using aspnetserver.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(swaggerGenOpts =>
{
    swaggerGenOpts.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ASP.NET React Tutorial",
        Version = "v1"
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000");
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(swaggerUIOpts =>
{
    swaggerUIOpts.DocumentTitle = "ASP.NET React Tutorial";
    swaggerUIOpts.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Web API for React");
    swaggerUIOpts.RoutePrefix = string.Empty;
});

app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

string EndpointTag = "Posts Endpoints";

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/posts", async () => await PostsRepository.GetPostsAsync())
.WithName("GetAllPosts")
.WithTags("Posts Endpoints");
app.MapGet("/posts/{id}", async (int id) =>
{
    Post returnPost = await PostsRepository.GetPostByIdAsync(id);
    return returnPost != null ? Results.Ok(returnPost) : Results.BadRequest();
})
.WithName("GetPostByID")
.WithTags(EndpointTag);
app.MapPost("/posts", async (Post post) =>
{
    return await PostsRepository.CreatePostAsync(post) ? Results.Ok("Post Saved!") : Results.BadRequest();
})
.WithName("SavePost")
.WithTags(EndpointTag);
app.MapPut("/posts", async (Post post) =>
{
    return await PostsRepository.UpdatePostAsync(post) ? Results.Ok("Post Updated!") : Results.BadRequest();
})
.WithName("UpdatePost")
.WithTags(EndpointTag);
app.MapDelete("/posts", async (int id) =>
{
    return await PostsRepository.DeletePostAsync(id) ? Results.Ok("Post Deleted.") : Results.BadRequest();
})
.WithName("DeletePost")
.WithTags(EndpointTag);
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
