using EventosAPI.Data;
using EventosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// Configuração dos serviços (Dependency Injection)
// ============================================================

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serialização JSON com camelCase e formatação de enums como string
        options.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS — permite que o front-end (HTML) acesse a API
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Pasta de dados CSV (raiz do projeto PIM_V/data)
var pastaData = Path.Combine(builder.Environment.ContentRootPath, "..", "..", "data");

// Registro dos Services como Singleton (persistência em arquivo)
builder.Services.AddSingleton(new EventoService(pastaData));
builder.Services.AddSingleton(new AtividadeService(pastaData));
builder.Services.AddSingleton(new ParticipanteService(pastaData));
builder.Services.AddSingleton(new NotificacaoService(pastaData));
builder.Services.AddSingleton(provider =>
{
    var atividadeService = provider.GetRequiredService<AtividadeService>();
    var participanteService = provider.GetRequiredService<ParticipanteService>();
    var notificacaoService = provider.GetRequiredService<NotificacaoService>();
    return new InscricaoService(pastaData, atividadeService, participanteService, notificacaoService);
});
builder.Services.AddSingleton(provider =>
{
    var inscricaoService = provider.GetRequiredService<InscricaoService>();
    var participanteService = provider.GetRequiredService<ParticipanteService>();
    var atividadeService = provider.GetRequiredService<AtividadeService>();
    var eventoService = provider.GetRequiredService<EventoService>();
    return new CertificadoService(pastaData, inscricaoService, participanteService, atividadeService, eventoService);
});
builder.Services.AddSingleton(new FeedbackService(pastaData));
builder.Services.AddSingleton(new TermoLibrasService(pastaData));

// ============================================================
// Build e configuração do pipeline HTTP
// ============================================================

var app = builder.Build();

// Seed de dados iniciais (evento fictício, atividades, glossário Libras)
SeedData.Inicializar(pastaData);

// Swagger em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirFrontend");
app.MapControllers();

Console.WriteLine("==============================================");
Console.WriteLine("  EventosAPI - Semana de TI Inclusiva UNIP 2026");
Console.WriteLine("  API rodando em: http://localhost:5000");
Console.WriteLine("  Swagger UI:     http://localhost:5000/swagger");
Console.WriteLine("  Dados CSV em:   " + pastaData);
Console.WriteLine("==============================================");

app.Run("http://localhost:5000");
