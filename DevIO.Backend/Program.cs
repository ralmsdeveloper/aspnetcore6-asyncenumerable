using DevIO.Backend;
using DevIO.Shared.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    IEnumerable<Pessoa> GetPessoas()
    { 
        foreach (var pessoa in Helper.GetPessoas())
        {
            yield return pessoa;
            Task.Delay(500).Wait();
        }
    }

    return GetPessoas();
});

app.MapGet("/stream", () =>
{
    async IAsyncEnumerable<Pessoa> GetPessoas()
    {
        foreach (var pessoa in Helper.GetPessoas())
        {
            yield return pessoa;
            await Task.Delay(500);
        }
    }

    return GetPessoas();
});

app.Run();
