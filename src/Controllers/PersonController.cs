// declara sobre o tipo de serviço vou usar
using Microsoft.AspNetCore.Mvc;
using src.Models;   
using src.Persistence;
using  Microsoft.EntityFrameworkCore;

// Declara endereço de memoria virtual
namespace src.Controllers;

// Anotação q caacterza uma API Controller
[ApiController]
// A rota de acesso da API controller
[Route("[controller]")]

// Api Controller
// Os dois pontos mostra a ernaça vindo do Controller Base
public class PersonController : ControllerBase{

// ligação com Banco de dados
private DatabaseContext _context { get; set; }

public PersonController(DatabaseContext context)
{
this._context = context;
}
// 

[HttpGet]

// public Pessoa Get(){
    // Pessoa pessoa = new Pessoa("Esdras", 21, "841940984");

    // Contrato novoContrato = new Contrato("abc123", 50.63);    

    // chamda dos novos contratos
    // pessoa.contratos.Add(novoContrato);
    // return pessoa;    
// }

// criar uam lista de pessas no banco de dados
public ActionResult<List<Pessoa>>Get(){
    var result = _context.Pessoas.Include(p => p.contratos).ToList();
    // sera executado quando nãi ouver nenehum conteudo
    if(!result.Any()) return NoContent();
     return  Ok(result);
}

// enciar dados para o servidor, possivel de auteração externa

[HttpPost]
//  No modulo abaixo temos (Pessoa = modelo; pessoa = Variavel)
public Pessoa Post([FromBody]Pessoa pessoa){
    // addc
    _context.Pessoas.Add(pessoa);
    // salvar
    _context.SaveChanges();
    // retornar
    return pessoa;
}

[HttpPut("{id}")]
public string Updata([FromRoute]int id, [FromBody]Pessoa pessoa){
    // Salvar dados direto no banco de dados
    _context.Pessoas.Update(pessoa);
    _context.SaveChanges();

    // para exibir no localHost
    // Console.WriteLine(id);
    // Console.WriteLine(pessoa);
    return "Dados do id " + id + " Atualizado";
}

[HttpDelete("{id}")]
public string Delete([FromRoute]int id){
    var result = _context.Pessoas.SingleOrDefault(e => e.Id ==id);

    _context.Pessoas.Remove(result);
    _context.SaveChanges();
    return "Delete pessoa com id" + id;
}                             
}