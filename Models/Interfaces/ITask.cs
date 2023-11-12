namespace ProjectPlanner.Models.Interfaces
{
    internal interface ITask : IBasicInfos
    {
        bool Complete { get; }

        void CompleteUpdate();
        ITask GetTask();
    }
}
