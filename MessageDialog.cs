using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Layout;

namespace MyApp
{
    public static class MessageDialog
    {
        public static async Task Show(Window parent, string title, string message)
        {
            var dialog = new Window
            {
                Title = title,
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            var panel = new StackPanel
            {
                Margin = new Avalonia.Thickness(20)
            };

            panel.Children.Add(new TextBlock
            {
                Text = message,
                TextWrapping = Avalonia.Media.TextWrapping.Wrap
            });

            var btn = new Button
            {
                Content = "OK",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Avalonia.Thickness(0, 20, 0, 0)
            };

            btn.Click += (_, _) => dialog.Close();
            panel.Children.Add(btn);

            dialog.Content = panel;

            await dialog.ShowDialog(parent);
        }
    }
}