//Você pode alterar na url "carros" para "motos" ou "caminhoes" de acordo com a sua necessidade. testes feito usando tabela fit disponivel no git, testando usando httpcliente e filtro json com C#.

using HttpClientcarros;
using System.Text.Json;

Console.WriteLine("Digite o tipo de veiculo!(Carros, Motos ou Caminhões)");
var TipoVeiculo = Console.ReadLine();
var endereco = $@"https://parallelum.com.br/fipe/api/v1/{TipoVeiculo}/marcas";
var client = new HttpClient();
try
{
    HttpResponseMessage? response = await client.GetAsync(endereco);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    //Console.WriteLine(responseBody);
    List<veiculo> Veiculos = JsonSerializer.Deserialize<List<veiculo>>(responseBody);

    foreach (var veiculo in Veiculos)
    {
        Console.WriteLine(veiculo.nome);
    }


}
catch (Exception)
{

    throw;
}