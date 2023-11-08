namespace ProjectPlanner.Models.Interfaces
{
    interface IBranch : IBasicInfos
    {
        int? Status { get; }
        List<IBranch> BranchsSolutions { get; }
        List<ITask> BranchsTasks { get; }

        void CreateProject(string title);
        void CreateTask(string title);
        IBranch GetSolution();
        IList<IBasicInfos> GetBranchs();
    }
}
