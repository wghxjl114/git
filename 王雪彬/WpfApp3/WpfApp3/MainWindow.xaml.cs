using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;

namespace Inspect.UI
{
    /// <summary>
    /// Interaction logic for EasterEgg.xaml
    /// </summary>
    public partial class EasterEgg: Window
    {
        enum Direction
        {
            UP, DOWN, LEFT, RIGHT
        };
        private Brush oldBrush = new SolidColorBrush(Color.FromArgb(100,255, 0, 0));//brush for snake
        private Brush newBrush = new SolidColorBrush(Color.FromArgb(100, 0, 0, 255));//brush for destination
        private Direction direct;//current direction

        private DispatcherTimer timer = new DispatcherTimer();

        private List<Rectangle> snake = new List<Rectangle>();
        private int snakeTail;
        private Rectangle dest;
        private double destTop, destLeft;
        private double W, H;

        private int speed;
        public static readonly DependencyProperty GradeProperty = DependencyProperty.Register("Grade",typeof(int), typeof(EasterEgg));
        public static readonly DependencyProperty ScoreProperty = DependencyProperty.Register("Score",typeof(int), typeof(EasterEgg));
        public int Grade

        {
            get
            {
                return Convert.ToInt32(GetValue(GradeProperty));
            }
            set { SetValue(GradeProperty, value); }
        }

        public int Score
        {
            get
            {
                return Convert.ToInt32(GetValue(ScoreProperty));
            }
            set
            {
                SetValue(ScoreProperty, value);
            }
        }

        public EasterEgg()
        {
            InitializeComponent();

            this.DataContext = this;//数据绑定
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.InitSnake();

            //start timer
            timer.Tick +=new EventHandler(timer_Elapsed);
            timer.Start();

        }

        
        private void timer_Elapsed(object sender,EventArgs e)
        {
            Walk();
        }
        private void Walk()
        {
            //尾变头
            Rectangle tail =snake[snakeTail];
            Rectangle head = snake[(snakeTail + snake.Count- 1) % snake.Count];
            double top =Convert.ToDouble(head.GetValue(Canvas.TopProperty));
            double left= Convert.ToDouble(head.GetValue(Canvas.LeftProperty));
            switch(direct)
            {
                case Direction.LEFT:
                    left -= 10;
                    break;
                case Direction.RIGHT:
                    left +=10;
                    break;
                case Direction.UP:
                    top -= 10;
                    break;
                case Direction.DOWN:
                    top +=10;
                    break;
            }

            //判断是否吃到目标
            if (top != destTop || left !=destLeft)//如果没有吃到目标
            {

                tail.SetValue(Canvas.TopProperty, top);

                tail.SetValue(Canvas.LeftProperty, left);
            }
            else

            {
                //snake变长
                dest.Fill =oldBrush;//目标变色，成为snake的一部分

                this.snake.Insert(snakeTail, dest);
                //分数增加

                this.Score = this.Score + 100;
                if (this.Score % 2000 ==0)//过关
                {
                    this.Grade = this.Grade +1;
                    this.timer.Interval = new TimeSpan(0, 0, 0, 0, speed -20 * Grade);
                }
                //产生新目标

                Rand();
            }

            //判断是否失败
            if (top <0 || left < 0 || top > this.H - 10.0 || left > this.W -10.0)//如果跑出边界
            {
                GameOver();

            }
            else//判断是否咬到自己
            {
                for (int i =0; i < snake.Count; i++)
                {
                    if (i ==snakeTail)
                        continue;
                    if ((double)snake[i].GetValue(Canvas.TopProperty) == top && (double)snake[i].GetValue(Canvas.LeftProperty) == left)
                        GameOver();

                }
            }
            snakeTail = (snakeTail + 1) %snake.Count;
        }
        
        private void GameOver()
        {
            this.timer.Stop();
            if(MessageBox.Show("再来一盘?", "游戏结束", MessageBoxButton.YesNo) ==MessageBoxResult.Yes)
            {

                this.InitSnake();
                this.timer.Start();

            }
            else
            {

                this.Close();
            }
        }
       
        private void Rand()
        {
            dest= Rect(newBrush);
            this.cavas.Children.Add(dest);

            Random rand = new Random(System.DateTime.Now.Millisecond);

            destTop = rand.Next(Convert.ToInt32(this.H) / 10) * 10.0;
            destLeft= rand.Next(Convert.ToInt32(this.W) / 10) * 10.0;

            dest.SetValue(Canvas.TopProperty, destTop);

            dest.SetValue(Canvas.LeftProperty, destLeft);
        }
        Rectangle Rect(Brush brush)
        {
            Rectangle rect = new Rectangle();
            rect.Height = 10;
            rect.Width =10;
            rect.Fill = brush;
            return rect;

        }
        /// <summary>
        /// 初始化Snake
        /// </summary>
        private void InitSnake()
        {

            this.snake.Clear();

            this.cavas.Children.Clear();

            //init destination
            Rand();

            //init  snake
                        Rectangle beginer = Rect(oldBrush);//the first part of snake
            this.cavas.Children.Add(beginer);

            this.snake.Add(beginer);
            beginer.SetValue(Canvas.TopProperty,0.0);
            beginer.SetValue(Canvas.LeftProperty, 0.0);

            this.direct = Direction.RIGHT;//initial direction
            this.snakeTail= 0;

            this.Score = 0;
            this.Grade =1;
            this.speed = 200;
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, speed);
        }
        
        private void Window_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.Key ==Key.Right)//→
                direct = (direct != Direction.LEFT ?Direction.RIGHT : direct);
            else if (e.Key ==Key.Left)//←
                direct = (direct != Direction.RIGHT ?Direction.LEFT : direct);
            else if (e.Key ==Key.Up)//↑
                direct = (direct != Direction.DOWN ? Direction.UP: direct);
            else if (e.Key == Key.Down)//↓

                direct = (direct != Direction.UP ? Direction.DOWN : direct);
            else if (e.Key == Key.Space && timer.IsEnabled)//空格键暂停

            {
                timer.Stop();
                return;

            }

            if (!timer.IsEnabled)//任意键继续

                timer.Start();
            else
                Walk();

        }
        
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.W =Convert.ToInt32(this.cavas.ActualWidth) ;
            this.H =Convert.ToInt32(this.cavas.ActualHeight) ;
        }

    }
}