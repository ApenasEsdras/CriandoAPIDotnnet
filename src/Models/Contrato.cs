namespace src.Models;

public class Contrato
{
    // faz novas chamadas com novos valores
    public Contrato()
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "000000";
        this.Pago = false;
    }
    public Contrato(string TokenID, double Valor){
        this.DataCriacao = DateTime.Now;
        this.TokenId = TokenID;
        this.Valor = Valor;
         this.Pago = false;
    }

    // prop = Propriedades da API
    public DateTime DataCriacao { get; set;}
    public string TokenId { get; set; }
    public double Valor { get; set; }
public bool Pago { get; set; }
    
}
