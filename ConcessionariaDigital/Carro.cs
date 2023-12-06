namespace ConcessionariaDigital;

public class Carro
{
  public String Modelo { get; set; }
  public String Ano { get; set; }
  public String PrecoRecomendado { get; set; }
  public Marca Marca { get; set; }


  public void AdicionarMarca(Marca marca)
  {
    if (this.Marca == null)
    {
      this.Marca = marca;
    }
    
  }

  

}