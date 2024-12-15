using CodeLouCapstone.App.Components.Services;
using CodeLouCapstone.App.Components;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
//.AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient<IDeckService, DeckService>(client => client.BaseAddress = new Uri("http://localhost:5265/"));
builder.Services.AddHttpClient<ICardService, CardService>(client => client.BaseAddress = new Uri("http://localhost:5265/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    //.AddInteractiveWebAssemblyRenderMode();

app.Run();
