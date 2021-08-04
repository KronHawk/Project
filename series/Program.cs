using System;

namespace series
{
    class Program
    {
        static serierepository repositorio = new serierepository();
        static void Main(string[] args)
        {
            string opcaomenu = opcaouser();
            while (opcaomenu != "X")
            {
                switch (opcaomenu)
                {
                    case "C":
                        Console.Clear();
                        opcaomenu = opcaouser();
                        break;
                    case "1":
                        ListarSeries();
                        opcaomenu = opcaouser();
                        break;
                    case "2":
                        InserirSerie();
                        opcaomenu = opcaouser();
                        break;
                    case "3":
                        AtualizarSerie();
                        opcaomenu = opcaouser();
                        break;
                    case "4":
                        ExcluirSerie();
                        opcaomenu = opcaouser();
                        break;
                    case "5":
                        VisualizarSerie();
                        opcaomenu = opcaouser();
                        break;
                    default:
                        break;
                }
            }
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie encontrada");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.RetornarId(), serie.RetornarTitle());
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie.");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o numero do genero das opções acima");
            int entradagenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da series:");
            string entradatitle = Console.ReadLine();

            Console.Write("Digite o ano da serie:");
            int entradaano = int.Parse(Console.ReadLine());

            Console.Write("Digite a descição da serie:");
            string entradadescription = Console.ReadLine();

            Services novaserie = new Services(id: repositorio.proximoId(),
                genero: (Genero)entradagenero,
                titulo: entradatitle,
                ano: entradaano,
                descricao: entradadescription);
            repositorio.insere(novaserie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Qual Id você deseja atualizar? ");
            int IndeceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o numero do genero das opções acima");
            int entradagenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da series:");
            string entradatitle = Console.ReadLine();

            Console.Write("Digite o ano da serie:");
            int entradaano = int.Parse(Console.ReadLine());

            Console.Write("Digite a descição da serie:");
            string entradadescription = Console.ReadLine();

            Services atualizaserie = new Services(id: IndeceSerie,
                genero: (Genero)entradagenero,
                titulo: entradatitle,
                ano: entradaano,
                descricao: entradadescription);
            repositorio.atualiza(IndeceSerie, atualizaserie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Qual o Id da Serie? ");
            int IdDelete = int.Parse(Console.ReadLine());

            repositorio.exclui(IdDelete);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Qual Id da Serie? ");
            int IDview = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarporId(IDview);
            Console.WriteLine(IDview);
        }


        private static string opcaouser()
        {
            Console.WriteLine("1- Listar");
            Console.WriteLine("2- Inerir");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Visualizar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
    }
}
