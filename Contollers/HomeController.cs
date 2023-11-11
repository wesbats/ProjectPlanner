using System;
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
            // Branch.Load();

            //Verifica se já existe alguma branch, se não existir, cria a primeira branch
            if (Branch.In().Count == 0)
            {
                Branch.Add(Menu.Text("Crie sua primeira Branch:"));
            }

            //Inicia o menu principal
            while (true)
            {
                //Inicia o Menu Principal
                int? SelectedMainMenu = Menu.MainMenu(Branch.In());

                //Processa a seleção do Menu Principal
                if (SelectedMainMenu == Branch.Count() + 1)
                {
                    DBController.Save(Branch.In());
                    break;
                }
                else if (SelectedMainMenu == Branch.Count())
                {
                    Branch.Add(Menu.Text("Escreva o nome da branch:"));
                }
                else if (SelectedMainMenu != null)
                {
                    Branch branchSelectedMainMenu = (Branch)Branch.In()[(int)SelectedMainMenu].GetSolution();
                    while(InBranch(branchSelectedMainMenu) != null);
                        
                    int? InBranch(IBranch branch)
                    {
                        while(true)
                        {
                            int? selectedMenuBranchChill = Menu.Branch(branch);
                            if(selectedMenuBranchChill != null)
                            {
                                if(selectedMenuBranchChill == branch.GetBranchs().Count() + 3)
                                {
                                    break;
                                }
                                if(selectedMenuBranchChill == branch.GetBranchs().Count() + 2)
                                {
                                    // ((Branch)branch).Remove((int)branch);
                                }
                                else if(selectedMenuBranchChill == branch.GetBranchs().Count() + 1)
                                {
                                    Branch.AddTask(Menu.Text("Digite o nome da Task:"), branch);
                                }
                                else if(selectedMenuBranchChill == branch.GetBranchs().Count() )
                                {
                                    Branch.Add(Menu.Text("Digite o nome da Branch:"), branch);
                                }
                                else if(selectedMenuBranchChill != null)
                                {
                                    IBasicInfos selectedBranchChill = branch.GetBranchs()[(int)selectedMenuBranchChill];
                                    if(selectedBranchChill.GetType() == typeof(Branch)){
                                        InBranch((Branch)selectedBranchChill);
                                    }
                                    else{
                                        ((TaskUser)selectedBranchChill).CompleteUpdate();
                                    }
                                }
                            }
                        }
                        return null;
                    }
                    DBController.Save(Branch.In());
                }
            }
        }
    }
}
