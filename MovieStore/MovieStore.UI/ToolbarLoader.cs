using MovieStore.UI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace MovieStore.UI
{
    public static class ToolbarLoader
    {
        public static void Load(ref ToolBar tb, List<ToolbarFilter> filters)
        {
            foreach (var item in filters.OrderBy(o => o.OrderNum))
            {
                switch (item.Type)
                {
                    case Enums.FilterTypeEnum.ComboBox:

                        break;
                    case Enums.FilterTypeEnum.TextBox:


                        if (item.LabelText != string.Empty)
                        {
                            tb.Items.Add(GetLabel(item.Name, item.LabelText));
                        }

                        tb.Items.Add(GetTextBox(item));
                        break;
                }

                tb.Items.Add(new Separator());
            }

            tb.Items.RemoveAt(tb.Items.Count - 1);
        }

        private static TextBox GetTextBox(ToolbarFilter rec)
        {
            TextBox txt = new TextBox();
            txt.Name = rec.Name;
            txt.Foreground = Brushes.Black;
            txt.Width = 100;

            return txt;
        }

        private static Label GetLabel(string name, string text)
        {
            Label lbl = new Label();
            lbl.Name = $"lbl{name}";
            lbl.Content = text + ": ";
            lbl.Foreground = Brushes.White;

            return lbl;
        }
    }
}
