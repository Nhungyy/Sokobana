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
                       { 1, 0, 3, 1, 0, 0, 0, 1 },
                       { 1, 0, 0, 1, 1, 0, 0, 1 },
                       { 1, 0, 0, 1, 1, 0, 0, 1 },
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



                        Image chest = new Image();
                        chest.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\chest.png", UriKind.Absolute));
                        chest.Width = step;
                        chest.Height = step;
                        //d.Content = " ";
                        chest.HorizontalAlignment = HorizontalAlignment.Left;
                        chest.VerticalAlignment = VerticalAlignment.Top;
                        chest.Margin = new Thickness(x * step, y * step, 0, 0);
                        this.mainGrid.Children.Add(chest);
                    }
                    if (map[x, y] == 2)
                    {
                        heroX = x;
                        heroY = y;
                        //hero = new Button();
                        hero.Width = step;
                        hero.Height = step;
                        //hero.Content = "x";
                        hero.HorizontalAlignment = HorizontalAlignment.Left;
                        hero.VerticalAlignment = VerticalAlignment.Top;
                        hero.Margin = new Thickness(heroX * step, heroY * step, 0, 0);
                        //this.mainGrid.Children.Add(hero);

                    }

                    if (map[x, y] == 1)
                    {

                        Button w = new Button();
                        w.Width = step;
                        w.Height = step;
                        w.Content = " ";
                        w.HorizontalAlignment = HorizontalAlignment.Left;
                        w.VerticalAlignment = VerticalAlignment.Top;
                        w.Margin = new Thickness(x * step, y * step, 0, 0);

                        this.mainGrid.Children.Add(w);
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
            if(e.Key == Key.Escape)
            {
                Close();
            }

            hero.Margin = new Thickness(heroX * step, heroY * step, 0, 0);
        }
    }
}