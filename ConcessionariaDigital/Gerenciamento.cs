using System.Text.Json;

namespace ConcessionariaDigital;

public class Gerenciamento
{
  public List<Marca> Marcas { get; set; } = new List<Marca>();
  public List<Carro> Carros { get; set; } = new List<Carro>();


  public Gerenciamento()
  {
    this.IniciarListas();
  }

  public void IniciarListas()
  {
    if(File.Exists("marcas.json") == false)
    {
      File.Create("marcas.json").Close();
    }
    if (File.Exists("carros.json") == false)
    {
      File.Create("carros.json").Close();
    }

    using(StreamReader reader = new StreamReader(File.OpenRead("marcas.json")))
    {
      try
      {
        string content = reader.ReadToEnd();
        this.Marcas = JsonSerializer.Deserialize<List<Marca>>(content);
        reader.Close();
      }
      catch
      {

      }
    }

    using (StreamReader reader = new StreamReader(File.OpenRead("carros.json")))
    {
      try
      {
        string content = reader.ReadToEnd();
        this.Carros = JsonSerializer.Deserialize<List<Carro>>(content);
        reader.Close();
      }
      catch
      {

      }
    }
  }

  public void BuscarCarroPeloNome()
  {
    Console.WriteLine("Digite o nome do carro:");
    string nomeCarro = Console.ReadLine();
    Carro carro = this.Carros.Find(c => c.Modelo == nomeCarro);
    if (carro != null)
    {
      Console.WriteLine("Modelo: " + carro.Modelo);
      Console.WriteLine("Ano: " + carro.Ano);
      Console.WriteLine("Preço recomendado: " + carro.PrecoRecomendado);
      Console.WriteLine("Marca: " + carro.Marca.Nome);
    }
    else
    {
      Console.WriteLine("Carro não encontrado");
    }
  }
  

  public void SalvarListas()
  {
    if(File.Exists("marcas.json") == true)
    {
      File.Delete("marcas.json");
    }
    if (File.Exists("carros.json") == true)
    {
      File.Delete("carros.json");
    }

    using(StreamWriter writer = new StreamWriter(File.OpenWrite("marcas.json")))
    {
      string content = JsonSerializer.Serialize(this.Marcas);
      writer.Write(content);
      writer.Flush();
      writer.Close();
    }
    using(StreamWriter writer = new StreamWriter(File.OpenWrite("carros.json")))
    {
      string content = JsonSerializer.Serialize(this.Carros);
      writer.Write(content);
      writer.Flush();
      writer.Close();
    }
  }

  public void CadastrarCarro(Carro carro)
  {
    this.Carros.Add(carro);
  }

  public void CadastrarMarca(Marca marca)
  {
    this.Marcas.Add(marca);
  }

  public void EditarMarca(Marca marca)
  {
    Marca marcaParaEditar = this.Marcas.Find(m => m.Nome == marca.Nome);
    marcaParaEditar.Nome = marca.Nome;
  }

  public void DeletarMarca(Marca marca)
  {
    this.Marcas.Remove(marca);
  }
    
}