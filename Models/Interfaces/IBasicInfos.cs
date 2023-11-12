namespace ProjectPlanner.Models.Interfaces
{
    internal interface IBasicInfos
    {
        string Title { get; }
        string Description { get; }

        internal void TitleUpdate(string title);
        internal void DescriptionUpdate(string description);
    }
}
