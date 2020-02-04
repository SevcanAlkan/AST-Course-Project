namespace MovieStore.UI.Model
{
    public interface IFilterOption<T>
    {
        T ValueMember { get; set; }
        string DisplayMember { get; set; }
    }

    public abstract class FilterOption
    {

    }

    public class FilterOption<T> : FilterOption where T : struct, IFilterOption<T>
    {
        public T ValueMember { get; set; }
        public string DisplayMember { get; set; }
    }
}
