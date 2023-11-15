using ProjectPlanner.Models.Interfaces;

namespace ProjectPlanner.Views
{
    internal class Menu
    {
        internal static int[]? MainMenu(IList<IBranch> mainBranch)
        {
            TopBar.Printer();

            if (mainBranch.Any())
            {
                IList<string> options = TransformListText(mainBranch);
                options.Add("Novo projeto");
                options.Add("Sair");
                return MenuSelecao.Read(options, null);
            }
            else
            {
                return null;
            }
        }

        internal static string Text(string descrpiotion)
        {
            TopBar.Printer();
            Console.WriteLine(descrpiotion);
            return Console.ReadLine() ?? "";
        }

        internal static int[]? Branch(IBranch branch)
        {
            TopBar.Printer();
            IList<string> options = TransformListText(branch);
            options.Add("Nova Branch");
            options.Add("Nova Task");
            options.Add("Voltar");
            if (options.Count != 0)
            {
                return MenuSelecao.Read(options, branch.Title);
            }
            else
            {
                return null;
            }
        }

        internal static IList<string> TransformListText<T>(IList<T> list)
            where T : IBasicInfos
        {
            IList<string> options = new List<string>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    string title = item.Title;

                    if (item is ITask task)
                    {
                        title += $" - {(task.Complete ? "Finalizada" : "Pendente")}";
                    }
                    options.Add(title);
                }
            }
            return options;
        }

        internal static IList<string> TransformListText(IBranch list)
        {
            IList<string> options = new List<string>();
            if (list.GetBranchs().Count != 0)
            {
                foreach (var item in list.GetBranchs())
                {
                    string title = item.Title;

                    if (item is ITask task)
                    {
                        title += $" - {(task.Complete ? "Finalizada" : "Pendente")}";
                    }
                    options.Add(title);
                }
            }
            return options;
        }
    }
}
