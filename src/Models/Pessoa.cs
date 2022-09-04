using System.Collections.Generic;

namespace src.Models;

// Crindo caracteristicas
public class Pessoa
{

// Metodo Construtor
    public Pessoa()
    {
        this.Nome ="templete";
        this.Idade = 0;
        this.contratos = new List<Contrato>();
        this.Ativado = true;  
    }

    public Pessoa(string Nome, int Idade, string CPF){
        this.Nome = Nome;
        this.Idade = Idade;
        this.CPF = CPF;
        this.contratos = new List<Contrato>(); 
        this.Ativado = true;  
    }

    // Introduçaõ de lista de atributos: nome, idade, cpf, ativa
    public int id { get; set; }
    public string Nome {get; set;}
    public int Idade { get; set; }

    // Com o ? o conteudo pode receber nullos
    public string? CPF { get; set; }
    public bool Ativado { get; set; }

    public List<Contrato> contratos { get; set; }
}