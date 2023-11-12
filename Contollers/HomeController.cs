using ProjectPlanner.Models.Classes;
using ProjectPlanner.Models.Interfaces;
using ProjectPlanner.Views;

namespace ProjectPlanner.Contollers
{
    internal class HomeController
    {
        public static void Start()
        {
            //Inicia o controlador da Branch e carrega as Branchs salvas no Json.
            BranchController Branch = new BranchController();

            //Inicia o menu principal
            while (true)
            {
                //Verifica se já existe alguma branch, se não existir, cria a primeira branch
                if (Branch.In().Count == 0)
                {
                    Branch.Add(Menu.Text("Crie sua primeira Branch:"));
                }

                //Inicia o Menu Principal
                int[]? SelectedMainMenu = Menu.MainMenu(Branch.In());

                //Processa a seleção do Menu Principal
                if(SelectedMainMenu != null){
                    //Verifica se tecla Enter pressionada
                    if(SelectedMainMenu[1] == 0)
                    {
                        //Verifica saida
                        if (SelectedMainMenu[0] == Branch.Count() + 1)
                        {
                            DBController.Save(Branch.In());
                            break;
                        }
                        //Verifica se Nova Branch
                        else if (SelectedMainMenu[0] == Branch.Count())
                        {
                            Branch.Add(Menu.Text("Escreva o nome da branch:"));
                            DBController.Save(Branch.In());
                        }
                        //Verifica se branch selecionada
                        else if (SelectedMainMenu[0] < Branch.Count())
                        {
                            Branch branchSelectedMainMenu = (Branch)Branch.In()[(int)SelectedMainMenu[0]].GetSolution();
                            while(InBranch(branchSelectedMainMenu) != null);
                            
                            int? InBranch(IBranch branch)
                            {
                                while(true)
                                {
                                    int[]? selectedMenuBranchChill = Menu.Branch(branch);
                                    if(selectedMenuBranchChill != null)
                                    {
                                        //Verifica se branch selecionada
                                        if(selectedMenuBranchChill[1] == 0)
                                        {
                                            //Verifica se voltar selecionado
                                            if(selectedMenuBranchChill[0] == branch.GetBranchs().Count() + 2)
                                            {
                                                break;
                                            }
                                            //Verifica se Nova Task selecionada
                                            else if(selectedMenuBranchChill[0] == branch.GetBranchs().Count() + 1)
                                            {
                                                Branch.AddTask(Menu.Text("Digite o nome da Task:"), branch);
                                                DBController.Save(Branch.In());
                                            }
                                            //Verifica se Nova Branch selecionada
                                            else if(selectedMenuBranchChill[0] == branch.GetBranchs().Count() )
                                            {
                                                Branch.Add(Menu.Text("Digite o nome da Branch:"), branch);
                                                DBController.Save(Branch.In());
                                            }
                                            //Verifica se branch selecionada
                                            else if(selectedMenuBranchChill != null)
                                            {
                                                IBasicInfos selectedBranchChill = branch.GetBranchs()[(int)selectedMenuBranchChill[0]];
                                                if(selectedBranchChill.GetType() == typeof(Branch)){
                                                    InBranch((Branch)selectedBranchChill);
                                                }
                                                else{
                                                    ((TaskUser)selectedBranchChill).CompleteUpdate();
                                                    DBController.Save(Branch.In());
                                                }
                                            }
                                        }
                                        //Verifica se tecla R pressionada
                                        else if(selectedMenuBranchChill[1] == 1)
                                        {
                                            IBasicInfos selectedBranchChill = branch.GetBranchs()[(int)selectedMenuBranchChill[0]];
                                            selectedBranchChill.TitleUpdate(Menu.Text("Digite o novo título:"));
                                            DBController.Save(Branch.In());
                                        }
                                        //Verifica se telca Delete pressionada
                                        else if(selectedMenuBranchChill[1] == 2)
                                        {
                                            IBasicInfos selectedBranchChill = branch.GetBranchs()[(int)selectedMenuBranchChill[0]];
                                            if(selectedBranchChill.GetType() == typeof(Branch))
                                            {
                                                string remove = Menu.Text($"Deseja apagar {selectedBranchChill.Title}? (Y/N)").ToLower();
                                                if(remove == "sim" || remove == "s" || remove == "y" || remove == "yes")
                                                {
                                                    branch.BranchsSolutions.Remove((Branch)selectedBranchChill);
                                                    DBController.Save(Branch.In());
                                                }
                                            }
                                            else
                                            {
                                                string remove = Menu.Text($"Deseja apagar {branch.Title}? (Y/N)").ToLower();
                                                if(remove == "sim" || remove == "s" || remove == "y" || remove == "yes")
                                                {
                                                    branch.BranchsTasks.Remove((TaskUser)selectedBranchChill);
                                                    DBController.Save(Branch.In());
                                                }
                                            }
                                        }
                                    }
                                }
                                return null;
                            }
                            DBController.Save(Branch.In());
                        }
                    }
                    //Verifica se telca R pressionada
                    else if(SelectedMainMenu[1] == 1){
                        Branch branch = (Branch)Branch.In()[(int)SelectedMainMenu[0]].GetSolution();
                        branch.TitleUpdate(Menu.Text("Digite o novo título"));
                        DBController.Save(Branch.In());
                    }
                    //Verifica se telca Delete pressionada
                    else if(SelectedMainMenu[1] == 2){
                        Branch branch = (Branch)Branch.In()[(int)SelectedMainMenu[0]].GetSolution();
                        string remove = Menu.Text($"Deseja apagar {branch.Title}? (Y/N)").ToLower();
                        if(remove == "sim" || remove == "s" || remove == "y" || remove == "yes")
                        {
                            Branch.Remove(branch);
                            DBController.Save(Branch.In());
                        }
                    }
                }
            }
        }
    }
}
