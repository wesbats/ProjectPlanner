using ProjectPlanner.Models.Classes;
using ProjectPlanner.Models.Interfaces;
using System.Text.Json.Serialization;

namespace ProjectPlanner.Models.Abstracts
{
    internal abstract class BranchBase : IBranch
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Branch> BranchsSolutions { get; set; } = new();
        public List<TaskUser> BranchsTasks { get; set; } = new();
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

        public BranchBase() { }
        public void TitleUpdate(string title) => Title = title;
        public void DescriptionUpdate(string description) => Description = description;
        public void StatusUpdate(int status) => Status = status;
        public void CreateTask(string title) => BranchsTasks.Add(new TaskUser(title));
        public void CreateProject(string title) => BranchsSolutions.Add(new Branch(title));
        public void Remove(int counter)
        {
            Type type = GetBranchs()[counter].GetType();
            if(type == typeof(Branch)) BranchsSolutions.Remove((Branch)GetBranchs()[counter]);
            if(type == typeof(TaskUser)) BranchsTasks.Remove((TaskUser)GetBranchs()[counter]);
        }
        public IBranch GetSolution() => this;
        public IList<IBasicInfos> GetBranchs()
        {
            List<IBasicInfos> branchs = new List<IBasicInfos>();
            branchs.AddRange(BranchsSolutions);
            branchs.AddRange(BranchsTasks);

            return branchs;
        }
    }
}
