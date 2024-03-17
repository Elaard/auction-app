using MassTransit;
using Polly;
using Polly.Extensions.Http;
using SearchService.Consumers;
using SearchService.Data;
using SearchService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient<AuctionSvcHttpClient>()
    .AddPolicyHandler(GetPolicy());

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(x =>
{

    x.AddConsumersFromNamespaceContaining<ActionCreatedConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("search"));

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(() =>
{
    RavenDbStore.Init(app);
});


app.Run();

static IAsyncPolicy<HttpResponseMessage> GetPolicy()
 => HttpPolicyExtensions
 .HandleTransientHttpError()
 .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
 .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));