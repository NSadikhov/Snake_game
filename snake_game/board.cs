using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_game
{
    public partial class board : Form
    {
        public Button food = new Button();
        public Button snake = new Button();
        public Random rand = new Random();
        public Timer timer = new Timer();
        public List<Button> liste = new List<Button>();
        public board()
        {
            InitializeComponent();
            BackColor = Color.White;
            Snake();
            Food();
            timer.Interval = 300;
            timer.Start();
        }
        public void Snake()
        {
            snake.Width = 20;
            snake.Height = 20;
            snake.Name = "snake";
            snake.BackColor = Color.Red;
            snake.FlatAppearance.BorderSize = 5;
            snake.FlatAppearance.BorderColor = Color.Green;
            snake.FlatStyle = FlatStyle.Flat;
            snake.Top = 220;
            snake.Left = 280;
            Controls.Add(snake);
            snake.KeyUp += new KeyEventHandler(key);
            liste.Add(snake);

        }
        public void Food()
        {
            food = new Button();
            food.Width = 20;
            food.Height = 20;
            food.BackColor = Color.Red;
            food.Top = rand.Next(0, 20) * 20;
            food.Left = rand.Next(0, 25) * 20;
            food.FlatStyle = FlatStyle.Flat;
            food.FlatAppearance.BorderSize = 5;
            food.FlatAppearance.BorderColor = Color.White;
            Controls.Add(food);
            food.Enabled = false;
        }
        public void Grow_right(object sender, EventArgs e)
        {
            snake.Left += snake.Width;
            if (snake.Left == 620)
            {
                snake.Left = 0;
            }
            eat();
            for (int i = liste.Count - 1; i > 0; i--)
            {
                liste[i].Left = liste[i - 1].Left - 20;
                liste[i].Top = liste[i - 1].Top;
                if (i >= 2)
                {
                    liste[i].Left = liste[i - 1].Left;
                    liste[i].Top = liste[i - 1].Top;
                }
            }
        }
        public void Grow_up(object sender, EventArgs e)
        {
            if (snake.Top == -20)
            {
                snake.Top = 460;
            }
            snake.Top -= snake.Height;
            eat();
            for (int i = liste.Count - 1; i > 0; i--)
            {
                liste[i].Left = liste[i - 1].Left;
                liste[i].Top = liste[i - 1].Top + 20;
                if (i >= 2)
                {
                    liste[i].Left = liste[i - 1].Left;
                    liste[i].Top = liste[i - 1].Top;
                }
            }
        }
        public void Grow_left(object sender, EventArgs e)
        {
            if (snake.Left == -20)
            {
                snake.Left = 600;
            }
            snake.Left -= snake.Width;
            eat();
            for (int i = liste.Count - 1; i > 0; i--)
            {
                liste[i].Left = liste[i - 1].Left + 20;
                liste[i].Top = liste[i - 1].Top;
                if (i >= 2)
                {
                    liste[i].Left = liste[i - 1].Left;
                    liste[i].Top = liste[i - 1].Top;
                }
            }
        }
        public void Grow_down(object sender, EventArgs e)
        {
            if (snake.Top == 460)
            {
                snake.Top = -20;
            }
            snake.Top += snake.Height;
            eat();
            for (int i = liste.Count - 1; i > 0; i--)
            {
                liste[i].Left = liste[i - 1].Left;
                liste[i].Top = liste[i - 1].Top - 20;
                if (i >= 2)
                {
                    liste[i].Left = liste[i - 1].Left;
                    liste[i].Top = liste[i - 1].Top;
                }
            }
        }
        public void key(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    timer.Tick += new EventHandler(Grow_up);
                    timer.Tick -= new EventHandler(Grow_down);
                    timer.Tick -= new EventHandler(Grow_left);
                    timer.Tick -= new EventHandler(Grow_right);
                    break;
                case Keys.Down:
                    timer.Tick += new EventHandler(Grow_down);
                    timer.Tick -= new EventHandler(Grow_up);
                    timer.Tick -= new EventHandler(Grow_left);
                    timer.Tick -= new EventHandler(Grow_right);
                    break;
                case Keys.Left:
                    timer.Tick += new EventHandler(Grow_left);
                    timer.Tick -= new EventHandler(Grow_up);
                    timer.Tick -= new EventHandler(Grow_down);
                    timer.Tick -= new EventHandler(Grow_right);
                    break;
                case Keys.Right:
                    timer.Tick += new EventHandler(Grow_right);
                    timer.Tick -= new EventHandler(Grow_up);
                    timer.Tick -= new EventHandler(Grow_down);
                    timer.Tick -= new EventHandler(Grow_left);
                    break;
            }
        }
        public void eat()
        {
            if (snake.Location == food.Location)
            {
                if (timer.Interval == 60)
                {
                    timer.Interval = 60;
                }
                else
                {
                    timer.Interval -= 20;

                }
                food.BackColor = Color.Green;
                food.FlatAppearance.BorderSize = 0;
                liste.Add(food);
                Food();
                food.Top = rand.Next(0, 20) * 20;
                food.Left = rand.Next(0, 25) * 20;
                Controls.Add(food);
            }
        }
    }
}