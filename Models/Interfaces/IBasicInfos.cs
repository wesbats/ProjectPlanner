namespace ProjectPlanner.Models.Interfaces
{
    internal interface IBasicInfos
    {
        string Title { get; }

        internal void TitleUpdate(string title);
    }
}
