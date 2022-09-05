// declara sobre o tipo de serviço vou usar
using Microsoft.AspNetCore.Mvc;
using  Microsoft.EntityFrameworkCore;
// LIberar o statusCode
using System.Net;

// eu criei estes abaixo
using src.Models;   
using src.Persistence;


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
public ActionResult<Pessoa> Post([FromBody]Pessoa pessoa){

    try
    {
    // addc
    _context.Pessoas.Add(pessoa);
    // salvar
    _context.SaveChanges();
    }
    catch (System.Exception)
    {
        return BadRequest();
    }
    // retorn ar
    return Created("criado", pessoa);
}

[HttpPut("{id}")]
public ActionResult<Object> Updata(
    [FromRoute]int id, 
    [FromBody]Pessoa pessoa
    )
 {

    var result = _context.Pessoas.SingleOrDefault(e => e.Id ==id);

    if(result is null){
        return NotFound(new{
            msg = "Registro não encontrado",
            status = HttpStatusCode.NotFound
        });
    }
    // Analise de erro
    try
    {
        // Salvar dados direto no banco de dados
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();
 
    }
    catch (System.Exception)
    { 
        return BadRequest(new{
        msg = "Erra na soliciatçaõ de atualização do " + id + " Atualizado",
        status = HttpStatusCode.OK
      });
    }

    // para exibir no localHost
    // Console.WriteLine(id);
    // Console.WriteLine(pessoa);
    return Ok(new{
        msg = "Dados do id " + id + " Atualizado",
        status = HttpStatusCode.OK
      });
}

[HttpDelete("{id}")]
public ActionResult<Object > Delete([FromRoute]int id){
    var result = _context.Pessoas.SingleOrDefault(e => e.Id ==id);

// condicional pra retornar status 400 do dalad o cliente
    if(result is null){
        return BadRequest(new{
            msg = "Conteudo Invalido, solicitação invalida",
            status = HttpStatusCode.BadRequest
        });
    }
    _context.Pessoas.Remove(result);
    _context.SaveChanges();

    return Ok(new{
        msg = "Delete pessoa com id" + id,
        status = HttpStatusCode.OK
      });
}                             
}