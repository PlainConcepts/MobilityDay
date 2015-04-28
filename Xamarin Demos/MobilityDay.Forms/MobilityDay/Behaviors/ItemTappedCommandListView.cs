using System.Windows.Input;
using Xamarin.Forms;

namespace MobilityDay.Behaviors
{
    public class ItemTappedCommandListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty = BindableProperty.CreateAttached<ItemTappedCommandListView, ICommand>(o => GetItemTappedCommand(o), default(ICommand), BindingMode.OneWay, null, PropertyChanged);

        private static void PropertyChanged(BindableObject bindable, ICommand oldValue, ICommand newValue)
        {
            var listView = bindable as ListView;
            if (listView != null)
            {
                listView.ItemTapped += ListViewOnItemTapped;
            }
        }

        private static void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = sender as ListView;
            if (list != null)
            {
                list.SelectedItem = null;
                var command = GetItemTappedCommand(list);
                if (command != null && command.CanExecute(e.Item))
                {
                    command.Execute(e.Item);
                }
            }
        }

        public static ICommand GetItemTappedCommand(BindableObject bindableObject)
        {
            return (ICommand)bindableObject.GetValue(ItemTappedCommandProperty);
        }

        public static void SetItemTappedCommand(BindableObject bindableObject, object value)
        {
            bindableObject.SetValue(ItemTappedCommandProperty, value);
        }
    }
}
