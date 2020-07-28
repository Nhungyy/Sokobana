using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] map = { { 1, 0, 1, 1, 1, 0, 0, 1 },
                       { 1, 2, 1, 1, 1, 0, 0, 1 },
                       { 1, 0, 0, 1, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 3, 0, 1 },
                       { 1, 0, 0, 1, 0, 0, 0, 1 },
                       { 1, 3, 0, 1, 0, 0, 0, 1 },
                       { 1, 0, 0, 1, 1, 0, 0, 1 },
                       { 1, 0, 3, 1, 1, 0, 0, 1 },
                       { 1, 0, 0, 0, 1, 0, 0, 1 },
                       { 1, 0, 0, 0, 1, 0, 0, 1 },
                       { 1, 0, 1, 1, 1, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 1, 0, 1, 0, 0, 1, 1 },
                       { 1, 0, 0, 1, 0, 0, 1, 1 },
                       { 1, 0, 0, 1, 0, 0, 1, 1 },
                       { 1, 0, 0, 1, 0, 0, 1, 1 },
                       { 1, 0, 0, 1, 0, 0, 0, 1 },
                       { 1, 1, 1, 1, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 0, 1 },
                       { 1, 0, 0, 0, 0, 0, 1, 1 },
                       { 1, 1, 1, 1, 1, 1, 1, 1} };

        private int heroX = 0;
        private int heroY = 0;
        private int step = 10;

        public MainWindow()
        {
            InitializeComponent();



            for (int x = 0; x < 29; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (map[x, y] == 3)
                    {
                        Image box = new Image();
                        box.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\box.png", UriKind.Absolute));
                        box.Width = step;
                        box.Height = step;
                        //d.Content = " ";
                        box.HorizontalAlignment = HorizontalAlignment.Left;
                        box.VerticalAlignment = VerticalAlignment.Top;
                        box.Margin = new Thickness(x * step, y * step, 0, 0);
                        this.mainGrid.Children.Add(box);
                    }
                    if (map[x, y] == 2)
                    {
                        Image hero = new Image();
                        hero.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\hero.png", UriKind.Absolute));
                        heroX = x;
                        heroY = y;
                        //Button hero = new Button();
                        hero.Width = step;
                        hero.Height = step;
                        //hero.Content = "x";
                        hero.HorizontalAlignment = HorizontalAlignment.Left;
                        hero.VerticalAlignment = VerticalAlignment.Top;
                        hero.Margin = new Thickness(heroX * step, heroY * step, 0, 0);
                        this.mainGrid.Children.Add(hero);

                    }

                    if (map[x, y] == 1)
                    {
                        //Button w = new Button();
                        Image wall = new Image();
                        wall.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\wall.png", UriKind.Absolute));
                        wall.Width = step;
                        wall.Height = step;
                        //w.Content = " ";
                        wall.HorizontalAlignment = HorizontalAlignment.Left;
                        wall.VerticalAlignment = VerticalAlignment.Top;
                        wall.Margin = new Thickness(x * step, y * step, 0, 0);
                        this.mainGrid.Children.Add(wall);
                    }
                }
            }


        }

        private void mainGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Right)
            {
                if (map[heroX + 1, heroY] != 1)
                {
                    if (map[heroX + 1, heroY] != 3)
                    {
                        heroX++;
                    }
                }
            }

            if (e.Key == Key.Left)
            {
                if (map[heroX - 1, heroY] != 1)
                {
                    if (map[heroX - 1, heroY] != 3)
                    {
                        heroX--;
                    }
                }
            }

            if (e.Key == Key.Down)
            {
                if (map[heroX, heroY + 1] != 1)
                {
                    if (map[heroX, heroY + 1] != 3)
                    {
                        heroY++;
                    }
                }
            }

            if (e.Key == Key.Up)
            {
                if (map[heroX, heroY - 1] != 1)
                {
                    if (map[heroX, heroY - 1] != 3)
                    {
                        heroY--;
                    }
                }
            }
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}