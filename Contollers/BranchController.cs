using ProjectPlanner.Models.Classes;
using ProjectPlanner.Models.Interfaces;

namespace ProjectPlanner.Contollers
{
    internal class BranchController
    {
        IList<IBranch> mainBranch = DBController.Load();

        /// <summary>
        /// Retorna a Branch principal.
        /// </summary>
        /// <returns>IList<IBranch></returns>
        internal IList<IBranch> In()
        {
            return mainBranch;
        }

        /// <summary>
        /// Cria uma nova Branch.
        /// </summary>
        internal void Add(string titleNewBranch)
        {
            mainBranch.Add(new Branch(titleNewBranch != "" ? titleNewBranch : "Branch sem título"));
            return;
        }

        /// <summary>
        /// Cria uma Branch na Branch atual.
        /// </summary>
        /// <param name="titleNewBranch"></param>
        /// <param name="branch"></param>
        internal void Add(string titleNewBranch, IBranch branch)
        {
            branch.CreateProject(titleNewBranch != "" ? titleNewBranch : "Branch sem título");
        }

        /// <summary>
        /// Cria uma Task na Branch atual.
        /// </summary>
        /// <param name="titleNewTask"></param>
        /// <param name="branch"></param>
        internal void AddTask(string titleNewTask, IBranch branch)
        {
            branch.CreateTask(titleNewTask != "" ? titleNewTask : "Task sem título");
        }

        /// <summary>
        /// Apaga uma Branch.
        /// </summary>
        internal void Remove(Branch branch)
        {
            mainBranch.Remove(branch);
        }

        /// <summary>
        /// Retorna a quantidade de branchs registradas.
        /// </summary>
        /// <returns>int</returns>
        internal int Count()
        {
            return mainBranch.Count;
        }

        /// <summary>
        /// Solicita a o DBController salvar a Branch Principal.
        /// </summary>
        internal void Save()
        {
            DBController.Save(mainBranch);
        }

        /// <summary>
        /// Solicita ao DBController os dados salvos da Branch Principal.
        /// </summary>
        /// <returns></returns>
        internal void Load()
        {
            mainBranch = DBController.Load();
        }
    }
}
