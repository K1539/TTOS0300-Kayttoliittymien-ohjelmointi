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
using System.Windows.Shapes;

namespace SnakeWPF
{
    /// <summary>
    /// The classic old Snake game in WPF
    /// </summary>
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public partial class Game : Window
    {
        //Variables and consts
        private const int minimi = 5;
        private const int maxWidth = 620;
        private const int maxHeight = 380;
        private const int snakeWidth = 10;
        private int snakeLength = 100;
        private int easiness = 20; //timerin ajastinaika (ms)
        private int score = 0;
        private List<Point> bonusPoints = new List<Point>(); //omena-kokoelma
        private const int bonusCount = 20;
        private List<Point> snakeParts = new List<Point>();
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right; //alussa
        private Random rnd = new Random(); //x & y -pisteiden arvontaa varten
        
        public Game()
        {
            InitializeComponent();
            //tarvittavat alustukset

            //piirretään omenat ja käärme
            IniBonusPoints();
            PaintSnake(startingPoint);
            currentPosition = startingPoint;

            //start game
        }
        private void IniBonusPoints()
        {
            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n);
            }
        }
        private void PaintBonus(int index)
        {
            //Arvotaan omenalle pisteeli x ja y -koordinaatti
            Point point = new Point(rnd.Next(minimi, maxWidth),
                                    rnd.Next(minimi, maxHeight));
            //omenan piirto
            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Red;
            omena.Width = snakeWidth;
            omena.Height = snakeWidth;
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);
            paintCanvas.Children.Insert(index, omena);
            bonusPoints.Insert(index, point);

        }
        private void PaintSnake(Point currentpoint)
        {
            Ellipse snake = new Ellipse();
            snake.Fill = Brushes.Green;
            snake.Width = snakeWidth;
            snake.Height = snakeWidth;
            Canvas.SetTop(snake, currentpoint.Y);
            Canvas.SetLeft(snake, currentpoint.X);
            int count = paintCanvas.Children.Count;
            paintCanvas.Children.Add(snake);
            snakeParts.Add(currentPosition);
            //rajoitetaan käärmeen pituutta
            //TODO
        }
        private void GameOver()
        {
            MessageBox.Show("Your Score: " + score);
            this.Close();
        }
        private void GameOverShow()
        {
            //TODO
        }
    }
}
