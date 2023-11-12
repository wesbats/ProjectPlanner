using ProjectPlanner.Models.Interfaces;

namespace ProjectPlanner.Models.Abstracts
{
    internal abstract class TaskBase : ITask
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public bool Complete { get; set; } = false;

        public void TitleUpdate(string title) => Title = title != ""? title : "Task sem título";
        public void DescriptionUpdate(string description) => Description = description;
        public void CompleteUpdate() => Complete = !Complete;
        public ITask GetTask() => this;
    }
}
