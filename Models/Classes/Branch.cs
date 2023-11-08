using ProjectPlanner.Models.Abstracts;

namespace ProjectPlanner.Models.Classes
{
    internal class Branch : BranchBase
    {
        public Branch() { }
        internal Branch(string title) => Title = title == "" ? "Branch sem nome" : title;

    }
}
