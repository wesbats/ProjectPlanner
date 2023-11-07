using ProjectPlanner.Models.Abstracts;

namespace ProjectPlanner.Models.Classes
{
    internal class TaskUser : TaskBase
    {
        public TaskUser() { }
        public TaskUser(string title) => Title = title;
    }
}
