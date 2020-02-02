using System.ComponentModel;

namespace MovieStore.Core.Enum
{
    public enum ProjectStatus : short
    {
        [Description("Not Started")]
        NotStarted = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("Done")]
        Done = 3,
        [Description("Cancelled")]
        Canceled = 4
    }
}
