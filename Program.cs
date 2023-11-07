using ProjectPlanner.Contollers;

namespace ProjectPlanner
{
    class Program
    {
        static void Main()
        {
            HomeController.Start();
        }

        /*
        static void Main()
        {
            // Lê projetos já salvos
            IList<ISolution> projects = DB.Load();

            // Cria Projeto para teste
            //Project projetoTeste = new("ProjetoTeste3", "Descrição3");
            //projetoTeste.StatusUpdate(2);

            // Adiciona o projeto instanciado ao arquivo
            //(projects ??= new List<Project>()).Add(projetoTeste);

            // Testes

            // Cast temporario

            IList<IBasicInfos> lista = new List<IBasicInfos>() { new TaskUser("Tarefa1") };
            ((TaskUser)lista[0]).CompleteUpdate();
            Console.WriteLine(lista.GetType());
            lista[0].Print();

            while (true)
            {
                int selecao = Menu.MainMenu(projects);
                if (selecao == projects.Count + 1) { Save(); break; }
                if (selecao == projects.Count) CreateProject();

                Menu.TopBar();
                projects[selecao].Print();
            }


            void CreateProject()
            {
                Console.WriteLine("Sem projetos no momento.");
                projects.Add(new Solution(Menu.TextReturnMenu("Digite o titulo do projeto:")));
                Save();
            }

            //Salva objetos no arquivo
            void Save() => DB.Save(projects);
        }
        */
    }

}
