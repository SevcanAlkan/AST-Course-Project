using MovieStore.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UI.Model
{
    public interface IToolbarItem
    {
        string Name { get; set; }
        int OrderNum { get; set; }
    }

    public class ToolbarFilter : IToolbarItem
    {
        public string Name { get; set; }
        public int OrderNum { get; set; }

        public FilterTypeEnum Type { get; set; }

        public string Text { get; set; }
        public string LabelText { get; set; }

        public List<FilterOption> Items { get; set; }
    }

    public class ToolbarButton : IToolbarItem
    {
        public string Name { get; set; }
        public int OrderNum { get; set; }
    }
}
