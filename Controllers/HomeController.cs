using ProjectPlanner.Models.Classes;
using ProjectPlanner.Models.Interfaces;
using ProjectPlanner.Views;

namespace ProjectPlanner.Controllers
{
    internal class HomeController
    {
        public static void Run()
        {
            //Inicia o controlador da Branch e carrega as Branchs salvas no Json.
            BranchController Branch = new();

            //Inicia o menu principal
            while (true)
            {
                //Verifica se já existe alguma branch, se não existir, cria a primeira branch
                if (!Branch.Any())
                {
                    Branch.Add(Menu.Text("Crie sua primeira Branch:"));
                }

                //Inicia o Menu Principal
                int[]? SelectedMainMenu = Menu.MainMenu(Branch.In());

                //Processa a seleção do Menu Principal
                if (SelectedMainMenu != null)
                {
                    //Verifica se tecla Enter pressionada
                    if (SelectedMainMenu[1] == (int)MenuPress.Enter)
                    {
                        //Verifica saida
                        int branchCout = Branch.Count();
                        if (SelectedMainMenu[0] == branchCout + 1)
                        {
                            Branch.Save();
                            break;
                        }
                        //Verifica se Nova Branch
                        else if (SelectedMainMenu[0] == branchCout)
                        {
                            Branch.Add(Menu.Text("Escreva o nome da branch:"));
                            Branch.Save();
                        }
                        //Verifica se branch selecionada
                        else if (SelectedMainMenu[0] < branchCout)
                        {
                            Branch branchSelectedMainMenu = (Branch)Branch.In()[(int)SelectedMainMenu[0]].GetSolution();
                            while (JoinBranch(branchSelectedMainMenu) != null) ;

                            int? JoinBranch(IBranch branch)
                            {
                                while (true)
                                {
                                    int[]? selectedMenuBranchChildren = Menu.Branch(branch);
                                    if (selectedMenuBranchChildren != null)
                                    {
                                        //Verifica se branch selecionada
                                        if (selectedMenuBranchChildren[1] == (int)MenuPress.Enter)
                                        {
                                            //Verifica se voltar selecionado
                                            if (selectedMenuBranchChildren[0] == branch.GetBranchs().Count() + 2)
                                            {
                                                break;
                                            }
                                            //Verifica se Nova Task selecionada
                                            else if (selectedMenuBranchChildren[0] == branch.GetBranchs().Count() + 1)
                                            {
                                                Branch.AddTask(Menu.Text("Digite o nome da Task:"), branch);
                                                Branch.Save();
                                            }
                                            //Verifica se Nova Branch selecionada
                                            else if (selectedMenuBranchChildren[0] == branch.GetBranchs().Count())
                                            {
                                                Branch.Add(Menu.Text("Digite o nome da Branch:"), branch);
                                                Branch.Save();
                                            }
                                            //Verifica se branch selecionada
                                            else if (selectedMenuBranchChildren != null)
                                            {
                                                IBasicInfos selectedBranchChildren = branch.GetBranchs()[(int)selectedMenuBranchChildren[0]];
                                                if (selectedBranchChildren.GetType() == typeof(Branch))
                                                {
                                                    JoinBranch((Branch)selectedBranchChildren);
                                                }
                                                else
                                                {
                                                    ((TaskUser)selectedBranchChildren).CompleteUpdate();
                                                    Branch.Save();
                                                }
                                            }
                                        }
                                        //Verifica se tecla R pressionada
                                        else if (selectedMenuBranchChildren[1] == (int)MenuPress.R && selectedMenuBranchChildren[0] < branch.GetBranchs().Count())
                                        {
                                            IBasicInfos selectedBranchChildren = branch.GetBranchs()[(int)selectedMenuBranchChildren[0]];
                                            selectedBranchChildren.TitleUpdate(Menu.Text("Digite o novo título:"));
                                            Branch.Save();
                                        }
                                        //Verifica se telca Delete pressionada
                                        else if (selectedMenuBranchChildren[1] == (int)MenuPress.Delete && selectedMenuBranchChildren[0] < branch.GetBranchs().Count())
                                        {
                                            IBasicInfos selectedBranchChildren = branch.GetBranchs()[(int)selectedMenuBranchChildren[0]];
                                            if (selectedBranchChildren.GetType() == typeof(Branch))
                                            {
                                                string remove = Menu.Text($"Deseja apagar {selectedBranchChildren.Title}? (Y/N)").ToLower();
                                                if (remove == "sim" || remove == "s" || remove == "y" || remove == "yes")
                                                {
                                                    branch.BranchsSolutions.Remove((Branch)selectedBranchChildren);
                                                    Branch.Save();
                                                }
                                            }
                                            else
                                            {
                                                string remove = Menu.Text($"Deseja apagar {branch.Title}? (Y/N)").ToLower();
                                                if (remove == "sim" || remove == "s" || remove == "y" || remove == "yes")
                                                {
                                                    branch.BranchsTasks.Remove((TaskUser)selectedBranchChildren);
                                                    Branch.Save();
                                                }
                                            }
                                        }
                                    }
                                }
                                return null;
                            }
                        }
                    }
                    //Verifica se telca R pressionada
                    else if (SelectedMainMenu[1] == (int)MenuPress.R && SelectedMainMenu[0] < Branch.Count())
                    {
                        Branch branch = (Branch)Branch.In()[(int)SelectedMainMenu[0]].GetSolution();
                        branch.TitleUpdate(Menu.Text("Digite o novo título"));
                        Branch.Save();
                    }
                    //Verifica se telca Delete pressionada
                    else if (SelectedMainMenu[1] == (int)MenuPress.Delete && SelectedMainMenu[0] < Branch.Count())
                    {
                        Branch branch = (Branch)Branch.In()[(int)SelectedMainMenu[0]].GetSolution();
                        string remove = Menu.Text($"Deseja apagar {branch.Title}? (Y/N)").ToLower();
                        if (remove == "sim" || remove == "s" || remove == "y" || remove == "yes")
                        {
                            Branch.Remove(branch);
                            Branch.Save();
                        }
                    }
                }
            }
        }
    }
}
