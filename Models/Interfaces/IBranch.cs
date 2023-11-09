using ProjectPlanner.Models.Classes;
using System.Text.Json.Serialization;

namespace ProjectPlanner.Models.Interfaces
{
    interface IBranch : IBasicInfos
    {
        int? Status { get; }
        List<Branch> BranchsSolutions { get; }
        List<TaskUser> BranchsTasks { get; }

        void CreateProject(string title);
        void CreateTask(string title);
        IBranch GetSolution();
        IList<IBasicInfos> GetBranchs();
    }
}
