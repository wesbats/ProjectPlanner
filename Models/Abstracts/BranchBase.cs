using ProjectPlanner.Models.Classes;
using ProjectPlanner.Models.Interfaces;

namespace ProjectPlanner.Models.Abstracts
{
    internal abstract class BranchBase : IBranch
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public List<IBranch> BranchsSolutions { get; set; } = new();
        public List<ITask> BranchsTasks { get; set; } = new();
        private int? status { get; set; }
        public int? Status
        {
            get => status;
            set
            {
                if (value >= 0)
                {
                    if (value > 4)
                    {
                        status = null;
                    }
                    else
                    {
                        status = value;
                    }
                }
                else if (value == null) status = null;
            }
        }

        public void TitleUpdate(string title) => Title = title;
        public void DescriptionUpdate(string description) => Description = description;
        public void StatusUpdate(int status) => Status = status;
        public void CreateTask(string title) => BranchsTasks.Add(new TaskUser(title));
        public void CreateProject(string title) => BranchsSolutions.Add(new Branch(title));
        public IBranch GetSolution() => this;
    }
}
