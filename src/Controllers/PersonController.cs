// declara sobre o tipo de serviço vou usar
using Microsoft.AspNetCore.Mvc;
using src.Models;   

// Declara endereço de memoria virtual
namespace src.Controllers;

// Anotação q caacterza uma API Controller
[ApiController]
// A rota de acesso da API controller
[Route("[controller]")]

// Api Controller
// Os dois pontos mostra a ernaça vindo do Controller Base
public class PersonController : ControllerBase{

[HttpGet]
public Pessoa Get(){
    Pessoa pessoa = new Pessoa("Esdras", 21, "841940984");

    Contrato novoContrato = new Contrato("abc123", 50.63);
    

    // chamda dos novos contratos
    pessoa.contratos.Add(novoContrato);
    
    return pessoa;
}

// enciar dados para o servidor, possivel de auteração externa

[HttpPost]

//  No modulo abaixo temos (Pessoa = modelo; pessoa = Variavel)
public Pessoa Post([FromBody]Pessoa pessoa){
    return pessoa;
}

[HttpPut("{id}")]
public string Updata([FromRoute]int id, [FromBody]Pessoa pessoa){
    // para exibir no localHost
    Console.WriteLine(id);
     Console.WriteLine(pessoa);
    return "Dados do id " + id + " Atualizado";
}

[HttpDelete("{id}")]
public string Delete([FromRoute]int id){
    return "Delete pessoa com id" + id;
}

}