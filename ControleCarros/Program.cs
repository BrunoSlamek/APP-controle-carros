using System;
using ControleCarros.Classes;

namespace ControleCarros
{
    class Program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarCarros();
						break;
					case "2":
						InserirCarro();
						break;
					case "3":
						AtualizarCarro();
						break;
					case "4":
						ExcluirCarro();
						break;
					case "5":
						VisualizarCarro();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado! Até a próxima.");
			Console.ReadLine();
        }

        private static void ExcluirCarro()
		{
			Console.Write("Digite o id do carro: ");
			int indiceCarro = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceCarro);
		}

        private static void VisualizarCarro()
		{
			Console.Write("Digite o id do carro: ");
			int indiceCarro = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceCarro);

			Console.WriteLine(serie);
		}

        private static void AtualizarCarro()
		{
			Console.Write("Digite o id do carro: ");
			int indiceCarro = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite a marca do Carro: ");
			string entradaMarca = Console.ReadLine();

            Console.Write("Digite o modelo: ");
			string entradaModelo = Console.ReadLine();

            Console.Write("Digite a cor: ");
			string entradaCor = Console.ReadLine();

			Console.Write("Digite o ano: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o tipo de combustivel: ");
			string entradaCombustivel = Console.ReadLine();

			Carro atualizaCarro = new Carro(id: indiceCarro,
										genero: (Genero)entradaGenero,
										marca: entradaMarca,
                                        modelo: entradaModelo,
                                        cor: entradaCor,
										ano: entradaAno,
                                        combustivel: entradaCombustivel);

			repositorio.Atualiza(indiceCarro, atualizaCarro);
		}
        private static void ListarCarros()
		{
			Console.WriteLine("Listar carros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum carro está cadastrado.");
				return;
			}

			foreach (var carro in lista)
			{
                var excluido = carro.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} - {2} {3}", carro.retornaId(), carro.retornaMarca(), carro.retornaCor(),(excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirCarro()
		{
			Console.WriteLine("Inserir novo carro");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite a marca do Carro: ");
			string entradaMarca = Console.ReadLine();

            Console.Write("Digite o modelo: ");
			string entradaModelo = Console.ReadLine();

            Console.Write("Digite a cor: ");
			string entradaCor = Console.ReadLine();

			Console.Write("Digite o ano: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o tipo de combustivel: ");
			string entradaCombustivel = Console.ReadLine();

			Carro novoCarro = new Carro(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										marca: entradaMarca,
                                        modelo: entradaModelo,
                                        cor: entradaCor,
										ano: entradaAno,
                                        combustivel: entradaCombustivel);

			repositorio.Insere(novoCarro);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Seja bem vindo ao seu controle de frota");
            Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Carros");
			Console.WriteLine("2- Inserir novo carro");
			Console.WriteLine("3- Atualizar Carro");
			Console.WriteLine("4- Excluir Carro");
			Console.WriteLine("5- Visualizar Carro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
