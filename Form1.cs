using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
namespace checkers_sharp
{
    public partial class Form1 : Form
    {
     
        int[,] map = new int[8, 8];
        int row, col;
        int curRow, curCol;
        Image whiteFigure;
        Image blackFigure;
        Image whitekingFigure;
        Image blackkingFigure;
        Button[,] buttons = new Button[8, 8];
        int currentPlayer;
        bool currentPlayerKing=false;
        int white = 0, black = 0;
        int yellow = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
          
            this.Width = 700;
            this.Height = 440;
         
            whiteFigure = new Bitmap(new Bitmap(@"w.png"), new Size(45, 45));
            blackFigure = new Bitmap(new Bitmap(@"b.png"), new Size(45, 45));
            whitekingFigure= new Bitmap(new Bitmap(@"wk.png"), new Size(45, 45));
            blackkingFigure = new Bitmap(new Bitmap(@"bk.png"), new Size(45, 45));
            label3.Text = white + "";
            label4.Text = black + "";

        }



        public Form1()
        {
            InitializeComponent();

        }





        public void Init()
        {
            currentPlayer = 1;
            map = new int[8, 8] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { -1,0,-1,0,-1,0,-1,0 },
                { 0,-1,0,-1,0,-1,0,-1 },
                { -1,0,-1,0,-1,0,-1,0 }
            };
            CreateMap();
        }


        public void CreateMap()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * 50, i * 50);
                    button.Size = new Size(50, 50);
                    button.Tag = new int[] { i, j };
                    button.Click += new EventHandler(OnFigurePress);
                    buttons[i, j] = button;
                    Controls.Add(button);
                }
            DrawAllCells();
        }
//------------------------------------------------------------------------------------------------------------
        public void DrawAllCells()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    DrawCell(i, j);
        }

//-------------------------------------------------------------------------------------------------------------
        public void DrawCell(int row, int col)
        {
            if ((row + col) % 2 != 0)
            {
                buttons[row, col].BackColor = Color.Gray;
                buttons[row, col].Image = null;
            }
            else
            {
                buttons[row, col].BackColor = Color.White;
                buttons[row, col].Image = null;
            }

            if (map[row, col] == 3)
                buttons[row, col].BackColor = Color.Yellow;
            if (map[row, col] == 1)
                buttons[row, col].Image = whiteFigure;
            if (map[row, col] == -1)
                buttons[row, col].Image = blackFigure;
            if (map[row, col] == 2)
                buttons[row, col].Image = whitekingFigure;
            if (map[row, col] == -2)
                buttons[row, col].Image = blackkingFigure;
        }




  //-------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            
        
            Init();
            Text = "Քայլը կարմիրներինն է";
            DeactivateAllButtons();
        }


       

        private void OnAgainButtonClick(object sender, EventArgs e)
        {
            Application.Restart();
        }


        public bool ShowPossibleSteps(int row, int col)
        {
            curRow = row;
            curCol = col;
            if (col + 2 < 8 && (row + 2 * currentPlayer) < 8 && (row + 2 * currentPlayer) >= 0)
                if (map[row + 2 * currentPlayer, col + 2] == 0 &&
                   ( map[row + 1 * currentPlayer, col + 1] == currentPlayer * -1|| map[row + 1 * currentPlayer, col + 1] == 2*currentPlayer * -1))
                {
                    map[row + 2 * currentPlayer, col + 2] = 3;
                    DrawCell(row + 2 * currentPlayer, col + 2);

                    return true;
                }
            if (col - 2 >= 0 && (row + 2 * currentPlayer) < 8 && (row + 2 * currentPlayer) >= 0)
                if (map[row + 2 * currentPlayer, col - 2] == 0 &&
                    (map[row + 1 * currentPlayer, col - 1] == currentPlayer * -1|| map[row + 1 * currentPlayer, col - 1] == 2*currentPlayer * -1))
                {
                    map[row + 2 * currentPlayer, col - 2] = 3;
                    DrawCell(row + 2 * currentPlayer, col - 2);
                    return true;
                }

           
            return false;
        }



        public void ShowPossibleSteps1(int row, int col)
        {
                curRow = row;
                    curCol = col;
            currentPlayerKing = false;
            if (col + 1 < 8 && (row + currentPlayer) < 8 && (row + currentPlayer) >= 0)
                        if (map[row + currentPlayer, col + 1] == 0)
                        {
                            map[row + currentPlayer, col + 1] = 3;
                            DrawCell(row + currentPlayer, col + 1);
    }
                    if (col - 1 >= 0 && (row + currentPlayer) < 8 && (row + currentPlayer) >= 0)
                        if (map[row + currentPlayer, col - 1] == 0)
                        {
                            map[row + currentPlayer, col - 1] = 3;
                            DrawCell(row + currentPlayer, col - 1);
}


           if (col + 2 < 8 && (row + 2 * currentPlayer) < 8 && (row + 2 * currentPlayer) >= 0)
             if (map[row + 2 * currentPlayer, col + 2] == 0 &&
       ( map[row + 1 * currentPlayer, col + 1] == currentPlayer * -1 || map[row + 1 * currentPlayer, col + 1] ==2* currentPlayer * -1))
            {
        map[row + 2 * currentPlayer, col + 2] = 3;
        DrawCell(row + 2 * currentPlayer, col + 2);
         }
        if (col - 2 >= 0 && (row + 2 * currentPlayer) < 8 && (row + 2 * currentPlayer) >= 0)
    if (map[row + 2 * currentPlayer, col - 2] == 0 &&
       ( map[row + 1 * currentPlayer, col - 1] == currentPlayer * -1 || map[row + 1 * currentPlayer, col - 1] == 2*currentPlayer * -1))
    {
        map[row + 2 * currentPlayer, col - 2] = 3;
        DrawCell(row + 2 * currentPlayer, col - 2);
    }


if(map[row, col] == currentPlayer * 2)
            {

                currentPlayerKing = true;
                if (col + 1 < 8 && (row + 1) < 8 && (row -1) >= 0)
                    if (map[row + 1, col + 1] == 0)
                    {
                        map[row + 1, col + 1] = 3;
                        DrawCell(row + 1, col + 1);
                    }
                if (col - 1 >= 0 && (row + 1) < 8 && (row + 1) >= 0)
                    if (map[row+ 1, col - 1] == 0)
                    {
                        map[row + 1, col - 1] = 3;
                        DrawCell(row + 1, col - 1);
                    }
               if (col + 1 < 8 && (row - 1) < 8 && (row - 1) >= 0)
                    if (map[row - 1, col + 1] == 0)
                    {
                        map[row - 1, col + 1] = 3;
                        DrawCell(row - 1, col + 1);
                    }
                if (col - 1 >= 0 && (row - 1) < 8 && (row - 1) >= 0)
                    if (map[row - 1, col - 1] == 0)
                    {
                        map[row - 1, col - 1] = 3;
                        DrawCell(row - 1, col - 1);
                    }
               

                if (col + 2 < 8 && (row + 2) < 8 && (row + 2) >= 0)
                    if (map[row + 2 , col + 2] == 0 &&
              (map[row + 1 , col + 1] == currentPlayer * -1 || map[row + 1 , col + 1] == 2 * currentPlayer * -1))
                    {
                        map[row + 2 , col + 2] = 3;
                        DrawCell(row + 2, col + 2);
                    }
                if (col - 2 >= 0 && (row + 2 ) < 8 && (row + 2) >= 0)
                    if (map[row + 2, col - 2] == 0 &&
                       (map[row + 1, col - 1] == currentPlayer * -1 || map[row + 1 * currentPlayer, col - 1] == 2 * currentPlayer * -1))
                    {
                        map[row + 2, col - 2] = 3;
                        DrawCell(row + 2, col - 2);

                    }
                if (col + 2 < 8 && (row - 2) < 8 && (row - 2) >= 0)
                    if (map[row - 2, col + 2] == 0 &&
              (map[row - 1, col + 1] == currentPlayer * -1 || map[row - 1, col + 1] == 2 * currentPlayer * -1))
                    {
                        map[row - 2, col + 2] = 3;
                        DrawCell(row - 2, col + 2);
                    }
                if (col - 2 >= 0 && (row - 2) < 8 && (row - 2) >= 0)
                    if (map[row - 2, col - 2] == 0 &&
                       (map[row - 1, col - 1] == currentPlayer * -1 || map[row - 1 * currentPlayer, col - 1] == 2 * currentPlayer * -1))
                    {
                        map[row - 2, col - 2] = 3;
                        DrawCell(row - 2, col - 2);

                    }





            }
        }


        public bool ShowPossibleStepsEat(int row, int col)
        {
            curRow = row;
            curCol = col;
            if (col + 2 < 8 && (row + 2 * currentPlayer) < 8 && (row + 2 * currentPlayer) >= 0)
                if (map[row + 2 * currentPlayer, col + 2] == 0 &&
                    (map[row + 1 * currentPlayer, col + 1] == currentPlayer * -1|| map[row + 1 * currentPlayer, col + 1] == currentPlayer * -1*2))
                {
           
                   
                    return true;
                }
            if (col - 2 >= 0 && (row + 2 * currentPlayer) < 8 && (row + 2 * currentPlayer) >= 0)
                if (map[row + 2 * currentPlayer, col - 2] == 0 &&
                    (map[row + 1 * currentPlayer, col - 1] == currentPlayer * -1|| map[row + 1 * currentPlayer, col - 1] == currentPlayer * -1*2))
                {
                   
                    
                   
                    return true;
                }

         
          
            
            return false;
        }


        ///mi qani qar

       

    
        public void OnFigurePress(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int[] indexes = (int[])clickedButton.Tag;
            row = indexes[0];  //0 togh
            col = indexes[1];  //1 syun                                       
            if (map[row, col] == 0)
            {
                Text = "Դատարկ վանդակ";
                return;
            }
            if (map[row, col] != currentPlayer && map[row, col] != 3 && map[row, col]!= currentPlayer * 2)
            {
                if (currentPlayer == -1)
                    Text = "Քայլը սևերինն է";
                else Text = "Քայլը կարմիրներինն է";
                return;
            }
            if (map[row, col] == currentPlayer || map[row, col] == currentPlayer*2)
            {
                Zeroing();
                if (currentPlayer == -1)
                    Text = "Քայլը սևերինն է";
                else
                    Text = "Քայլը կարմիրներինն է";
                yellow = 0;
                  ShowPossibleSteps1(row, col);              
                return;
            }      
            if (map[row, col] == 3)
            {                          
                if (row == 0 || row == 7 || currentPlayerKing == true)
                {
                    map[row, col] = currentPlayer*2;
                }
                else map[row, col] = currentPlayer;              
                map[curRow, curCol] = 0;
                DrawCell(row, col);
                DrawCell(curRow, curCol);
                int i = 0, j = 0;
                FindYellow3(i, j);
                map[i, j] = 0;
                DrawCell(i, j);             
                if (Math.Abs(curRow - row) % 2 == 0 && Math.Abs(curCol - col) % 2 == 0)
                {
                      map[(curRow + row) / 2, (curCol + col) / 2] = 0;
                        DrawCell((curRow + row) / 2, (curCol + col) / 2);
                        yellow++;
                        if (currentPlayer == -1 )
                        {
                            white++;
                            label4.Text = white + "";
                        }
                        else
                        {
                            black++;
                            label3.Text = black + "";
                        }                   
                    if (ShowPossibleStepsEat(row, col) == true)
                    {
                        if (yellow > 0)
                        {
                            ShowPossibleSteps(row, col);
                            return;

                        }
                        else
                        {
                            ShowPossibleSteps1(row, col);
                            yellow++;
                            return;
                        }
                    }                                                                 
            }       
                if (currentPlayer == 1 && ShowPossibleStepsEat(row, col)==false)
                    Text = "Քայլը սևերինն է";
                else
                    Text = "Քայլը կարմիրներինն է";
                currentPlayerKing = false ;
                currentPlayer = (currentPlayer == 1) ? -1 : 1;             
                if(label3.Text==12+"")
                {

                    MessageBox.Show(textBox1.Text + " դուք հաղթեցիք" );
                    Application.Restart();
                }
                else if(label4.Text==12+"")
                {
                    MessageBox.Show(textBox2.Text + " դուք հաղթեցիք");
                    Application.Restart();
                }
            }   
        }
        public void Zeroing()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (map[i, j] == 3)
                    {
                        map[i, j] = 0;
                        DrawCell(i, j);
                    }
                
                }
            }
        }
        public void FindYellow3( int row,  int col)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (buttons[i, j].BackColor == Color.Yellow)
                    {
                        buttons[i, j].BackColor = Color.Gray;
                        map[i, j] = 0;
                    }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                Text = "Գրեք խաղացողների անունները";
            else
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                ActivateAllButtons();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                label4.Visible = true;
                label3.Visible = true;
            }
        }

 
        public void DeactivateAllButtons()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                  {
                    buttons[i, j].Enabled = false;
                }
            }
        }
        public void ActivateAllButtons()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j].Enabled = true;
                }
            }
        }
    }
}
