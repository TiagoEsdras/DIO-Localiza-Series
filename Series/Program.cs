using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
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
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static bool ListarSeries()
        {
            Console.WriteLine("Lista de Series");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return false;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
            return true;
        }
        private static void InserirSerie()
        {
            int id = repositorio.ProximoId();
            SetarDadosSerie(id);
        }
        private static void AtualizarSerie()
        {
            bool existeSerie = ListarSeries();
            if(existeSerie)
            {
                ListarSeries();
                Console.WriteLine();
                Console.Write("Digite o id da série a ser atualizada: ");
                int id = Convert.ToInt32(Console.ReadLine());
                SetarDadosSerie(id);
            }            
        }
        private static void ExcluirSerie()
        {
            bool existeSerie = ListarSeries();
            if (existeSerie)
            {
                ListarSeries();
                Console.WriteLine();
                Console.Write("Digite o id da série a ser excluida: ");
                int id = Convert.ToInt32(Console.ReadLine());
                repositorio.Exclui(id);
            }            
        }
        private static void VisualizarSerie()
        {
            ListarSeries();
            Console.WriteLine();
            Console.Write("Digite o id da série a ser exibida: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir Serie");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Excluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static void SetarDadosSerie(int id)
        {
            foreach (int value in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(value + " - " + Enum.GetName(typeof(Genero), value));
            }
            Console.WriteLine();

            Console.Write("Escolha o gênero dadas as opções acima: ");
            int genero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Ano de Lançamento: ");
            int ano = Convert.ToInt32(Console.ReadLine());            

            Serie serie = new Serie(id, (Genero)genero, titulo, descricao, ano);

            repositorio.Insere(serie);
        }
        
    }
}
