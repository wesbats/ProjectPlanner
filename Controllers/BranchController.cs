using ProjectPlanner.Models.Classes;
using ProjectPlanner.Models.Interfaces;

namespace ProjectPlanner.Controllers
{
    internal class BranchController
    {
        DBController DB = new();
        IList<IBranch> mainBranch;

        public BranchController()
        {
            mainBranch = Load();
        }

        /// <summary>
        /// Retorna a Branch principal.
        /// </summary>
        /// <returns>IList<IBranch></returns>
        internal IList<IBranch> In()
        {
            return mainBranch;
        }

        internal bool Any()
        {
            return mainBranch.Any();
        }

        /// <summary>
        /// Cria uma nova Branch.
        /// </summary>
        internal void Add(string titleNewBranch)
        {
            mainBranch.Add(new Branch(titleNewBranch != "" ? titleNewBranch : "Branch sem título"));
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
            DB.Save(mainBranch);
        }

        /// <summary>
        /// Solicita ao DBController os dados salvos da Branch Principal.
        /// </summary>
        /// <returns></returns>
        internal IList<IBranch> Load()
        {
            return DB.Load();
        }
    }
}
