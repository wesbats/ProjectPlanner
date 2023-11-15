using ProjectPlanner.Models.Interfaces;

namespace ProjectPlanner.Models.Classes
{
    internal class TaskUser : ITask
    {
        public string Title { get; set; } = "";
        public bool Complete { get; set; } = false;

        public TaskUser() { }
        public TaskUser(string title) => Title = title != "" ? title : "Task sem título";
        public void TitleUpdate(string title) => Title = title != "" ? title : "Task sem título";
        public void CompleteUpdate() => Complete = !Complete;
        public ITask GetTask() => this;
    }
}
