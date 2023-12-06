using ConcessionariaDigital;

internal class Program
{
  private static Gerenciamento gerenciamento;

  private static void Main(string[] args)
  {
    var stopKey = "0";
    var selectedOption = "";
    gerenciamento = new Gerenciamento();


    //Cadastrar marca, Cadastrar carro, Listar marcas, Listar carros, Buscar marca pelo nome, buscar carro pelo nome, Sair
    while (selectedOption != stopKey)
    {
      Console.WriteLine();
      Console.WriteLine("Digite a opção desejada:");
      Console.WriteLine("1 - Cadastrar marca");
      Console.WriteLine("2 - Cadastrar carro");
      Console.WriteLine("3 - Listar carros de uma marca");
      Console.WriteLine("4 - Buscar marca pelo nome");
      Console.WriteLine("5 - Buscar carro pelo nome");
      Console.WriteLine("6 - Deletar marca");
      Console.WriteLine("7 - Editar marca");
      Console.WriteLine("0 - Sair");
      selectedOption = Console.ReadLine();

     ExecutarOpcaoSelecionada(selectedOption);
      }
    }

    static void ExecutarOpcaoSelecionada(string opcao)
    {
      switch (opcao)
      {
        case "1":
          CadastrarMarca();
          break;
        case "2":
          CadastrarCarro();
          break;
        case "3":
          ListarCarros();
          break;
        case "4":
          BuscarMarcaPeloNome();
          break;
        case "5":
          BuscarCarroPeloNome();
          break;
        case "6":
          DeletarMarca();
          break;
        case "7":
          EditarMarca();
          break;

        case "0":
        gerenciamento.SalvarListas();
        Console.WriteLine("Saindo...");
          break;
        default:
          break;
      }
    }
  

  //Metodos de cadastro
    static void CadastrarMarca()
    {
      Marca marca = new Marca();
      Console.WriteLine("Digite o nome da marca:");
      marca.Nome = Console.ReadLine();
      gerenciamento.CadastrarMarca(marca);
    }

    static void CadastrarCarro()
    {
      Carro carro = new Carro();
      Console.WriteLine("Digite o modelo do carro:");
      carro.Modelo = Console.ReadLine();
      Console.WriteLine("Digite o ano do carro:");
      carro.Ano = Console.ReadLine();
      Console.WriteLine("Digite o preço recomendado do carro:");
      carro.PrecoRecomendado = Console.ReadLine();
      Console.WriteLine("Adicione ou crie uma marca para o carro:");
      Console.WriteLine("Digite o nome da marca:");
      string nomeMarca = Console.ReadLine();
      if (gerenciamento.Marcas.Exists(m => m.Nome == nomeMarca))
      {
        carro.Marca = gerenciamento.Marcas.Find(m => m.Nome == nomeMarca);
      }
      else
      {
        Marca marca = new Marca();
        marca.Nome = nomeMarca;
        carro.Marca = marca;
        gerenciamento.CadastrarMarca(marca);
      }
      
      gerenciamento.CadastrarCarro(carro);

    }

  //Metodos de busca
  static void BuscarCarroPeloNome()
  
  {
    Console.WriteLine("Digite o nome do carro:");
    string nomeCarro = Console.ReadLine();
    Carro carro = gerenciamento.Carros.Find(c => c.Modelo == nomeCarro);
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

  //buscar marca pelo nome e listar os carros dela
  static void BuscarMarcaPeloNome()
  {
    Console.WriteLine("Digite o nome da marca:");
    string nomeMarca = Console.ReadLine();
    Marca marca = gerenciamento.Marcas.Find(m => m.Nome == nomeMarca);
    if (marca != null)
    {
      Console.WriteLine("Marca encontrada");
      Console.WriteLine("Nome: " + marca.Nome);
      Console.WriteLine("Carros:");
      foreach (Carro carro in gerenciamento.Carros)
      {
        if (carro.Marca.Nome == nomeMarca)
        {
          Console.WriteLine("=====================================");
          Console.WriteLine();
          Console.WriteLine("Modelo: " + carro.Modelo);
          Console.WriteLine("Ano: " + carro.Ano);
          Console.WriteLine("Preço recomendado: " + carro.PrecoRecomendado);
          Console.WriteLine("Marca: " + carro.Marca.Nome);
        }
      }
    }
    else
    {
      Console.WriteLine("Marca não encontrada");
    }

  }

  //Metodos de listagem
  static void ListarCarros()
  {
    Console.WriteLine("Digite o nome da marca:");
    string nomeMarca = Console.ReadLine();
    Marca marca = gerenciamento.Marcas.Find(m => m.Nome == nomeMarca);
    if (marca != null)
    {
      foreach (Carro carro in gerenciamento.Carros)
      {
        if (carro.Marca.Nome == nomeMarca)
        {
          Console.WriteLine("=====================================");
          Console.WriteLine();
          Console.WriteLine("Modelo: " + carro.Modelo);
          Console.WriteLine("Ano: " + carro.Ano);
          Console.WriteLine("Preço recomendado: " + carro.PrecoRecomendado);
          Console.WriteLine("Marca: " + carro.Marca.Nome);
        }
      }
    }
    else
    {
      Console.WriteLine("Marca não encontrada");
    }
}

  //Metodo de apagar Marca
  static void DeletarMarca()
  {
    Console.WriteLine("Digite o nome da marca:");
    string nomeMarca = Console.ReadLine();
    Marca marca = gerenciamento.Marcas.Find(m => m.Nome == nomeMarca);
    if (marca != null)
    {
      gerenciamento.Marcas.Remove(marca);
      Console.WriteLine("Marca deletada com sucesso");
    }
    else
    {
      Console.WriteLine("Marca não encontrada");
    }
  }

  static void EditarMarca()
  {
    Console.WriteLine("Digite o nome da marca:");
    string nomeMarca = Console.ReadLine();
    Marca marca = gerenciamento.Marcas.Find(m => m.Nome == nomeMarca);
    if (marca != null)
    {
      Console.WriteLine("Digite o novo nome da marca:");
      string novoNomeMarca = Console.ReadLine();
      marca.Nome = novoNomeMarca;
      gerenciamento.EditarMarca(marca);
      Console.WriteLine("Marca editada com sucesso");
    }
    else
    {
      Console.WriteLine("Marca não encontrada");
    }
  }
}
