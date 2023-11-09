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
                    while (InBranch() != Branch.Count() + 2) ;
                    int? InBranch()
                    {
                        IBranch BranchSelected = (Branch)Branch.In()[(int)SelectedMainMenu].GetSolution();
                        int? selectedBranch = Menu.Branch(BranchSelected);
                        if (selectedBranch == null)
                        {
                            Branch.Add(Menu.Text($"Crie uma nova Branch para {BranchSelected.Title}"), BranchSelected);
                            return null;
                        }
                        return selectedBranch;
                    }
                    DBController.Save(Branch.In());
                }
            }
        }
    }
}
