using System;

namespace DIO
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcaoUser();
            while(opcaoUser.ToUpper() != "X")
            {
                switch(opcaoUser)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUser = ObterOpcaoUser();
            }

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da serie: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da serie: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da série: ");
            int idInserido = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)} - ");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição da série ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Ano da serie ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Atribua sua nota a série 0 a 10 ");
            int entradaNota = int.Parse(Console.ReadLine());

            Serie atualizaSerie = new Serie(id: idInserido, genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo, descricao:entradaDescricao, 
                                        ano: entradaAno,nota: entradaNota);
            
            repositorio.Atualiza(idInserido, atualizaSerie);


        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)} - ");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição da série ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Ano da serie ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Atribua sua nota a série 0 a 10 ");
            int entradaNota = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo, descricao:entradaDescricao, 
                                        ano: entradaAno,nota: entradaNota);
            
            repositorio.Insere(novaSerie);
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar serie");

            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série foi encontrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} - {(excluido ? "*Excluido*": " ")}");
            }
        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("Analisador de Séries");
            Console.WriteLine("Informe a opcao: ");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries ");
            Console.WriteLine("2 - Inserir nova série ");
            Console.WriteLine("3 - Atualizar série ");
            Console.WriteLine("4 - Excluir série ");
            Console.WriteLine("5 - Visualizar série ");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("X - Sair ");

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
        }
    }
}
