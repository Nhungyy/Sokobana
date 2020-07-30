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

        int[,] map = { { 1, 1, 1, 1, 1, 1, 1, 1 },
                       { 1, 0, 1, 1, 1, 0, 0, 1 },
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
                       { 1, 0, 0, 1, 1, 0, 0, 1 },
                       { 1, 0, 0, 0, 1, 0, 0, 1 },
                       { 1, 0, 0, 0, 1, 0, 0, 1 },
                       { 1, 0, 0, 1, 1, 0, 0, 1 },
                       { 1, 0, 3, 1, 0, 0, 0, 1 },
                       { 1, 0, 3, 1, 0, 0, 0, 1 },
                       { 1, 0, 3, 1, 0, 0, 1, 1 },
                       { 1, 0, 0, 1, 0, 0, 1, 1 },                       
                       { 1, 1, 1, 1, 1, 1, 1, 1} };

        /*
                int[,] map = { { 1, 1, 1, 1, },
                    { 0, 0, 0, 0, },
                    { 1, 0, 0, 1, },
                    { 1, 1, 1, 1, } };
        */
        private int heroX = 0;
        private int heroY = 0;
        private const int step = 10;
        private Image hero;

        private float correctionX = 5.2f;
        private float correctionY = 3.2f;
        private float divX = 2.27f;
        private float divXG = 1.0f;
        private float divY = 3.3f;
        private float groundCorrectionX = step / 8.5f;
        private float groundCorrectionY = step / 2.9f;

        private float getX(int x, int y)
        {
            float globalX = -(y * step / 1.8f);
            float moveX = (step / divXG) * y;
            return x * step / divX + moveX + globalX;
        }

        private float getY(int x, int y)
        {
            float globalY = (y + 1) * step / 1.5f;
            float moveY = (step / divY) * x;
            return y * step - moveY - globalY;
        }

        public MainWindow()
        {
            InitializeComponent();

            float globalY = step;
            float globalX = step;

            float moveX = 0; //correctionY * 4;
            float moveY = 0;

            for (int y = 0; y < 8; y++) //8
            {
                for (int x = 0; x < 21; x++) //21
                {
                    float Ox = getX(x, y); // x * step / divX + moveX + globalX;
                    float Oy = getY(x, y); //  y * step - moveY - globalY;

                    if (map[x, y] == 3)
                    {
                        Image box = new Image();
                        box.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\box.png", UriKind.Absolute));
                        box.Width = step;
                        box.Height = step;
                        box.HorizontalAlignment = HorizontalAlignment.Left;
                        box.VerticalAlignment = VerticalAlignment.Top;
                        box.Margin = new Thickness(Ox, Oy, 0, 0);
                        this.mainGrid.Children.Add(box);
                    }
                    if (map[x, y] == 2)
                    {
                        hero = new Image();
                        hero.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\hero.png", UriKind.Absolute));
                        heroX = x;
                        heroY = y;
                        hero.Width = step;
                        hero.Height = step;
                        hero.HorizontalAlignment = HorizontalAlignment.Left;
                        hero.VerticalAlignment = VerticalAlignment.Top;
                        hero.Margin = new Thickness(Ox, Oy, 0, 0);
                        this.mainGrid.Children.Add(hero);

                    }
                    if (map[x, y] == 1)
                    {
                        Image wall = new Image();
                        wall.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\wall.png", UriKind.Absolute));
                        wall.Width = step;
                        wall.Height = step;
                        wall.HorizontalAlignment = HorizontalAlignment.Left;
                        wall.VerticalAlignment = VerticalAlignment.Top;
                        wall.Margin = new Thickness(Ox, Oy, 0, 0);
                        this.mainGrid.Children.Insert(y * 21, wall);
                    }

                    if (map[x, y] != 1)
                    {
                        Image ground = new Image();
                        ground.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\ground.png", UriKind.Absolute));
                        ground.Width = step;
                        ground.Height = step;
                        ground.HorizontalAlignment = HorizontalAlignment.Left;
                        ground.VerticalAlignment = VerticalAlignment.Top;
                        ground.Margin = new Thickness(Ox - groundCorrectionX, Oy + groundCorrectionY, 0, 0);
                        this.mainGrid.Children.Insert(y * 21, ground);
                    }
                    moveY += step / divY;
                    // moveX += correctionX;
                }
                globalY += step / 1.5f;
                globalX -= step / 1.8f;
                moveY = 0;
                moveX += step / divXG;
                //moveX = 0;
                //  moveY -= correctionY;
            }
        }
        private void mainGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                hero.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\hero.png", UriKind.Absolute));
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
                hero.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\heroback.png", UriKind.Absolute));
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
                hero.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\heroright.png", UriKind.Absolute));
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
                hero.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\heroleft.png", UriKind.Absolute));
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

            hero.Margin = new Thickness(getX(heroX, heroY), getY(heroX, heroY), 0, 0);
        }
    }
}