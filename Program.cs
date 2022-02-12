using System;
using DIO.Series.Classes;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    class Program 
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
       
                 while (OpcaoUsuario.ToUpper() != "X")
                {
                  switch (OpcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSeries();
                            break;
                        case "3":
                            AtualizarSeries();
                            break;
                        case "4":
                            ExcluirSeries();
                            break;
                         case "5":
                            VisualizarSeries();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                
                        default:
                        throw new ArgumentOutOfRangeException();
                    }
            
                    OpcaoUsuario = ObterOpcaoUsuario();
                }

                Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
        }

        private static void ExcluirSeries()
		    {
			    Console.Write("Digite o id da série: ");
			    int indiceSeries = int.Parse(Console.ReadLine());

			    repositorio.Exclui(indiceSeries);
		    }

        private static void VisualizarSeries()
		    {
			    Console.Write("Digite o id da série: ");
			    int indiceSeries = int.Parse(Console.ReadLine());

			    var series = repositorio.RetornaPorId(indiceSeries);

			    Console.WriteLine(series);
		    }

        private static void AtualizarSeries()
		    {
			    Console.Write("Digite o id da série: ");
			    int indiceSeries = int.Parse(Console.ReadLine());

			    foreach (int i in Enum.GetValues(typeof(Genero)))
			    {
				    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			    }
			    Console.Write("Digite o gênero entre as opções acima: ");
			    int entradaGenero = int.Parse(Console.ReadLine());

			    Console.Write("Digite o Título da Série: ");
			    string entradaTitulo = Console.ReadLine();

			    Console.Write("Digite o Ano de Início da Série: ");
			    int entradaAno = int.Parse(Console.ReadLine());

			    Console.Write("Digite a Descrição da Série: ");
			    string entradaDescricao = Console.ReadLine();

			    Series atualizaSeries = new Series(id: indiceSeries,
										           genero: (Genero)entradaGenero,
										           titulo: entradaTitulo,
										           ano: entradaAno,
										           descricao: entradaDescricao);

			    repositorio.Atualiza(indiceSeries, atualizaSeries);
		}

        private static void ListarSeries()
            {
                Console.WriteLine("Listar Séries");
                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("nenhuma série cadastrada.");
                    return;
                }

                foreach (var series in lista)
                {
                    var excluido = series.retornaExcluido();

                    Console.WriteLine("#ID {0}: - {1} - {2}", Series.retornaId(), series.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                }
            }   
      
        private static void InserirSeries()
            {
                Console.WriteLine("Inserir nova série");
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetValues(typeof(Genero), i));
                }

                Console.WriteLine("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série");
                string entradaDescricao = Console.ReadLine();

                Series novaSeries = new Series(id: repositorio.ProximoId(),
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);
                repositorio.Insere(novaSeries);                             

            }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Lista séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

        
            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return ObterOpcaoUsuario;
        }
    }

}
