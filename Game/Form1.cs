using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public class Back
    {
        public int X, Y, W, H;
        public Bitmap img;
        public List<Bitmap> imgs;
        public int st;
        public int re;
        public int ht;
        public int op;
    }

    public class CActor
    {
        public int X, Y, W, H;
        public List<Bitmap> im;
        public Bitmap img;
        public int IDR;
        public int WL;
        public int WR;
        public int DD;
        public int CC;
        public int jj;
        public int Sk;
        public int RS;
        public int Mk;
        public int Mkl;
        public int Js;
        public int Skat;
        public int P1;
        public int P2;
        public int P3;
        public int P4;
        public int DrID;
        public int DrWk;
        public int DrWkL;
        public int FlagR;
        public int FlagL;
        public int DAt1;
        public int DAt2;
        public int Brth;
        public int Fire;
        public int FID;
        public int FAT1;
        public int EMHP;
        public int flagfish;
        public int XOLD;
        public int GRR;
        public int GAT;
        public int HID;
        public int HAT1;
        public int flagharpy;
        public int EP;
        public int EF;


    }


    public partial class Form1 : Form
    {

        Bitmap unSeen;
        Bitmap World;
        Bitmap DD;
        int cxScreen, cyScreen;
        int XS = 0, YS = 0;

        List<Back> Backk = new List<Back>();
        List<Back> Buttons = new List<Back>();

        // Jake
        List<CActor> JakeID = new List<CActor>();
        List<CActor> JakeWk = new List<CActor>();
        List<CActor> JakeCr = new List<CActor>();
        List<CActor> JakeJp = new List<CActor>();
        List<CActor> JakePun = new List<CActor>();
        List<CActor> Jakeskate = new List<CActor>();
        List<CActor> JakeMoveSk = new List<CActor>();
        List<CActor> JakeJpSk = new List<CActor>();
        List<CActor> JakeAtSk = new List<CActor>();

        //Dragon
        List<CActor> JakeDr = new List<CActor>();
        List<CActor> JakeDrWk = new List<CActor>();
        List<CActor> DrAttack = new List<CActor>();
        List<CActor> DrFire = new List<CActor>();
        List<CActor> Fireballs = new List<CActor>();

        //Skateboard
        List<CActor> Skateboard = new List<CActor>();

        // GrandFather
        List<CActor> GrandFather = new List<CActor>();

        //Enemies 
        List<CActor> Fish = new List<CActor>();
        List<CActor> Harpy = new List<CActor>();


        // Effects

        List<CActor> Effects = new List<CActor>();



        int yy = 0;
        int flag = 0;
        int Drflag = 0;
        int esbatDr = 0;
        int skate = 0;
        int onskate = 0;
        int background = 0;
        int fire = 0;
        int Summon = 0;
        int TimeS = 0;
        int HitSS = 0;
        int esbatGD = 0;
        int AttackGD = 0;

        int punchflag = 0;
        int fireflag = 0;
        int ps = -1;
        int create = 0;

        Timer tt = new Timer();
        int counteridle;
        int counterenemy;
        int Counterr;

        Random RR = new Random();
        Random V = new Random();


        Random EE = new Random();
        Random F = new Random();


        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load +=new EventHandler(Form1_Load);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            tt.Tick += new EventHandler(tt_Tick);
            tt.Start();
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                for (int i = 0; i < Buttons.Count; i++)
                {
                    if (e.X >= Buttons[1].X
                        && e.X <= Buttons[1].X + Buttons[1].W
                        && e.Y >= Buttons[1].Y
                        && e.Y <= Buttons[1].Y + Buttons[1].H)
                    {
                        background = 1;
                    }

                    if (e.X >= Buttons[2].X
                     && e.X <= Buttons[2].X + Buttons[2].W
                     && e.Y >= Buttons[2].Y
                     && e.Y <= Buttons[2].Y + Buttons[2].H)
                    {
                        //-MessageBox.Show("Right & Left : moving  // Up & Down : Crouchcing & jumping" + " " +
                        //    "Toogle T" + " " +
                        //    "Toogle Q,W,E,R");
                    }
                }
                DrawDubb(this.CreateGraphics());

            }
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                if (e.X >= Buttons[0].X
                    && e.X <= Buttons[0].X + Buttons[0].W
                    && e.Y >= Buttons[0].Y
                    && e.Y <= Buttons[0].Y + Buttons[0].H)
                {
                    Buttons[0].X = 900;
                    Buttons[0].Y = 280;
                    Buttons[0].W = 300;
                    Buttons[0].H = 600;
                    Buttons[0].re = 1;
                }
                else
                {
                    Buttons[0].X = 900;
                    Buttons[0].Y = 280;
                    Buttons[0].W = 300;
                    Buttons[0].H = 100;
                    Buttons[0].re = 0;

                }

                if (e.X >= Buttons[1].X
                   && e.X <= Buttons[1].X + Buttons[1].W
                   && e.Y >= Buttons[1].Y
                   && e.Y <= Buttons[1].Y + Buttons[1].H)
                {
                
                    Buttons[1].st = 1;
                }
                else
                {   
                    Buttons[1].st = 0;
                }


                if (e.X >= Buttons[2].X
                 && e.X <= Buttons[2].X + Buttons[2].W
                 && e.Y >= Buttons[2].Y
                 && e.Y <= Buttons[2].Y + Buttons[2].H)
                {
                    Buttons[2].ht = 1;
                    
                }
                else
                {
                    Buttons[2].ht = 0;
                }


                if (e.X >= Buttons[3].X
                 && e.X <= Buttons[3].X + Buttons[3].W
                 && e.Y >= Buttons[3].Y
                 && e.Y <= Buttons[3].Y + Buttons[3].H)
                {

                    Buttons[3].op = 1;
                }
                else
                {
                    Buttons[3].op = 0;
                }





            }

            DrawDubb(this.CreateGraphics());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right)
            {
                if (Drflag == 1)
                {
                    JakeDrWk[0].FlagR = 0;
                    flag = 3;
                    JakeDrWk[0].DrWk = 0;
                    JakeDr[0].X = JakeDrWk[0].X;
                    JakeDr[0].Y = JakeDrWk[0].Y-20;
                    JakeDr[0].W = JakeDrWk[0].W;
                    JakeDr[0].H = JakeDrWk[0].H;
                    
                }
                if (onskate == 1)
                {
                    flag = 11;
                    JakeMoveSk[0].Mk = 0;
                    JakeID[0].X = JakeMoveSk[0].X;
                    JakeWk[0].X = JakeMoveSk[0].X;
                    Jakeskate[0].X = JakeMoveSk[0].X;

                }
                if ( Drflag == 0 && onskate == 0 )
                {
                    flag = 0;
                    JakeWk[0].WR = 0;
                    JakeID[0].X = JakeWk[0].X;
                }
            }

            //******************************************************//

            if (e.KeyCode == Keys.Left)
            {
                if (Drflag == 1)
                {
                    JakeDrWk[0].FlagL = 0;
                    flag = 3;
                    JakeDrWk[0].DrWkL = 8;
                    JakeDr[0].X = JakeDrWk[0].X;
                    JakeDr[0].Y = JakeDrWk[0].Y-20;
                    JakeDr[0].W = JakeDrWk[0].W;
                    JakeDr[0].H = JakeDrWk[0].H;
                }
                if (onskate == 1)
                {
                    flag = 11;
                    JakeMoveSk[0].Mkl = 7;
                    JakeID[0].X = JakeMoveSk[0].X;
                    JakeWk[0].X = JakeMoveSk[0].X;
                    Jakeskate[0].X = JakeMoveSk[0].X;

                }
                if ( Drflag == 0 && onskate == 0 )
                {
                    flag = 0;
                    JakeWk[0].WL = 10;
                    JakeID[0].X = JakeWk[0].X;
                }
            }

            //******************************************************//

            if (e.KeyCode == Keys.Q)
            {
                if (Drflag == 1)
                {
                    DrAttack[0].DAt1 = 0;
                    JakeDr[0].Y = DrAttack[0].Y;
                    JakeDr[0].W = DrAttack[0].W;
                    JakeDr[0].H = DrAttack[0].H;

                }
                if (onskate == 1)
                {
                    JakeAtSk[0].Skat = 0;
                }
                if ( Drflag == 0 && onskate == 0 )
                {
                    JakePun[0].P1 = 0;
                   // punchflag = 0;
                }
            }

            //******************************************************//


            if (e.KeyCode == Keys.W)
            {
                if (Drflag == 1)
                {
                    DrAttack[0].DAt2 = 8;
                    JakeDr[0].Y = DrAttack[0].Y;
                    JakeDr[0].W = DrAttack[0].W;
                    JakeDr[0].H = DrAttack[0].H;
                }
                else
                {
                    JakePun[0].P2 = 4;
                }
            }

            //******************************************************//

            if (e.KeyCode == Keys.E)
            {
                if (Drflag == 1)
                {   
                    DrFire[0].Brth = 0;
                    JakeDr[0].Y = JakeDrWk[0].Y-5;
                    JakeDr[0].W = JakeDrWk[0].W;
                    JakeDr[0].H = JakeDrWk[0].H;
                }
                else
                {
                    JakePun[0].P3 = 8;
                }
            }
            if (e.KeyCode == Keys.R)
            {
                JakePun[0].P4 = 16;
            }



        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up)
            {
                JakeDr[0].Y = 620;
                JakeDr[0].H = 170;
                JakeDr[0].W = 90;
            }
            JakeCr[0].CC = 0;
            JakeJp[0].jj = 0;
            JakeJpSk[0].Js = 0;


            if (e.KeyCode == Keys.Enter && Summon == 1)
            {
                HitSS = 1;

                GrandFather[0].X = JakeWk[0].X;
            }

            if (e.KeyCode == Keys.Right)
            {
                
                if (JakeWk[0].X+JakeWk[0].W >= Skateboard[0].X)
                {
                    skate = 1;
                }
                if (onskate==1)
                {
                    flag = 13 ;

                    if (JakeMoveSk[0].Mk <= JakeMoveSk[0].Mkl)
                    {
                        
                        JakeMoveSk[0].Mk++;
                        if (JakeMoveSk[0].X + JakeMoveSk[0].W >= this.ClientSize.Width / 2)
                        {
                            for (int i = 0; i < Fish.Count; i++)
                            {
                                Fish[i].X = Fish[i].XOLD - (4 * XS); ;
                            }
                            for (int i = 0; i < Harpy.Count; i++)
                            {
                                Harpy[i].X = Harpy[i].XOLD - (4 * XS);
                            }
                            XS += 2;
                        }
                        else
                        {
                            JakeMoveSk[0].X += 8;
                            JakeID[0].X += 8;
                            JakeWk[0].X += 8;
                        }
                    }
                    if (JakeMoveSk[0].Mk == JakeMoveSk[0].Mkl)
                    {
                        JakeMoveSk[0].Mk = 0;
                    }
                }


                if (Drflag == 1)
                {
                    flag = 6;
                    JakeDrWk[0].FlagR = 1;
                    if (JakeDrWk[0].DrWk <= JakeDrWk[0].DrWkL)
                    {
                        JakeDrWk[0].DrWk++;
                        if (JakeDrWk[0].X + JakeDrWk[0].W >= this.ClientSize.Width / 2)
                        {
                            for (int i = 0; i < Fish.Count; i++)
                            {
                                Fish[i].X = Fish[i].XOLD - (4 * XS);
                            }
                            for (int i = 0; i < Harpy.Count; i++)
                            {
                                Harpy[i].X = Harpy[i].XOLD - (4 * XS);
                            }
                            XS += 2;
                        }
                        else
                        {
                            JakeDrWk[0].X += 8;
                            JakeID[0].X += 8;
                            JakeWk[0].X += 8;
                        }
                        
                    }
                    if (JakeDrWk[0].DrWk == JakeDrWk[0].DrWkL)
                    {
                        JakeDrWk[0].DrWk = 0;
                    }
                }
                if ( Drflag == 0 && onskate ==0 )
                {

                    flag = 1;
                    this.Text = ("X  =  " + JakeWk[0].X.ToString() + "      " + "scroll =  " + XS.ToString()  );
                    if (JakeWk[0].WR <= JakeWk[0].WL)
                    {
                        JakeWk[0].WR++;

                        if (JakeWk[0].X + JakeWk[0].W >= this.ClientSize.Width / 2)
                        {
                            for (int i = 0; i < Fish.Count; i++)
                            {
                                Fish[i].X = Fish[i].XOLD - (4*XS);
                            }
                            for (int i = 0; i < Harpy.Count; i++)
                            {
                                Harpy[i].X = Harpy[i].XOLD - (4 * XS);
                            }
                            XS += 2;
                        }
                        else
                        {
                            JakeWk[0].X += 8;
                            JakeID[0].X += 8;
                        }
                    }
                    if (JakeWk[0].WR == JakeWk[0].WL)
                    {
                        JakeWk[0].WR = 0;
                    }
                }

            }


            //******************************************************//

            if (e.KeyCode == Keys.Left)
            {

                if (onskate == 1)
                {
                    flag = 14;

                    if (JakeMoveSk[0].Mkl <= JakeMoveSk[0].im.Count)
                    {

                        JakeMoveSk[0].Mkl++;

                        if (JakeMoveSk[0].X + JakeMoveSk[0].W >= this.ClientSize.Width / 2)
                        {
                            for (int i = 0; i < Fish.Count; i++)
                            {
                                Fish[i].X = Fish[i].XOLD - (4 * XS);
                            }
                            for (int i = 0; i < Harpy.Count; i++)
                            {
                                Harpy[i].X = Harpy[i].XOLD - (4 * XS);
                            }
                            XS -= 2;
                        }
                        else
                        {
                            JakeMoveSk[0].X -= 8;
                            JakeID[0].X -= 8;
                            JakeWk[0].X -= 8;
                        }
                    }
                    if (JakeMoveSk[0].Mkl == JakeMoveSk[0].im.Count)
                    {
                        JakeMoveSk[0].Mkl = 7;
                    }
                }


                if (Drflag == 1)
                {
                    flag = 7;
                    JakeDrWk[0].FlagL = 1;

                    if (JakeDrWk[0].DrWkL <= JakeDrWk[0].im.Count)
                    {
                        JakeDrWk[0].DrWkL++;
                        if (JakeDrWk[0].X + JakeDrWk[0].W >= this.ClientSize.Width / 2)
                        {
                            for (int i = 0; i < Fish.Count; i++)
                            {
                                Fish[i].X = Fish[i].XOLD - (4 * XS);
                            }
                            for (int i = 0; i < Harpy.Count; i++)
                            {
                                Harpy[i].X = Harpy[i].XOLD - (4 * XS);
                            }
                            XS -= 2;
                        }
                        else
                        {
                            JakeDrWk[0].X -= 8;
                            JakeID[0].X -= 8;
                            JakeWk[0].X -= 8;
                        }
                    }
                    if (JakeDrWk[0].DrWkL == JakeDrWk[0].im.Count)
                    {
                        JakeDrWk[0].DrWkL = 8;
                    }
                }
                if ( Drflag == 0 && onskate == 0)
                {
                    flag = 2;
                    if (JakeWk[0].WL <= JakeWk[0].im.Count)
                    {
                        JakeWk[0].WL++;
                        if (JakeWk[0].X + JakeWk[0].W >= this.ClientSize.Width / 2)
                        {
                            for (int i = 0; i < Fish.Count; i++)
                            {
                                Fish[i].X = Fish[i].XOLD - (4 * XS);
                            }
                            for (int i = 0; i < Harpy.Count; i++)
                            {
                                Harpy[i].X = Harpy[i].XOLD - (4 * XS);
                            }
                            XS -= 2;
                        }
                        else
                        {
                            JakeWk[0].X -= 8;
                            JakeID[0].X -= 8;
                        }
                    }
                    if (JakeWk[0].WL == JakeWk[0].im.Count)
                    {
                        JakeWk[0].WL = 10;
                    }
                }
            }

            //******************************************************//


            if (e.KeyCode == Keys.T)
            {
                flag = 3;
                Drflag = 1;

                JakeDr[0].X = JakeWk[0].X;
                JakeDr[0].Y = JakeWk[0].Y;

                JakeDrWk[0].X = JakeDr[0].X;
                JakeDrWk[0].Y = JakeDr[0].Y - 50;
            }



            //******************************************************//


            if (e.KeyCode == Keys.Y)
            {
                Drflag = 0;
                //flag = 0;
                flag = 24;
            }





            //******************************************************//
            if (e.KeyCode == Keys.Down)
            {
                flag = 4;

                JakeCr[0].X = JakeWk[0].X;
                JakeCr[0].Y = JakeWk[0].Y;
            }

            //******************************************************//


            if (e.KeyCode == Keys.Up)
            {
                if (Drflag == 1)
                {
                    flag = 6;
                    if (JakeDrWk[0].FlagR == 1)
                    {
                        JakeDrWk[0].X += 5;
      
                    }
                    if (JakeDrWk[0].FlagL == 1)
                    {
                        JakeDrWk[0].X -= 5;
                       
                    }
                    if (JakeDrWk[0].DrWk <= JakeDrWk[0].DrWkL)
                    {
                        JakeDrWk[0].DrWk++;
                        JakeDrWk[0].Y -= 10;
                    }
                    if (JakeDrWk[0].DrWk == JakeDrWk[0].DrWkL)
                    {
                        JakeDrWk[0].DrWk = 0;
                    }
                
                }


                if (onskate == 1)
                {
                    flag = 15;
                    JakeJpSk[0].X = JakeWk[0].X;
                    JakeJpSk[0].Y = JakeWk[0].Y;
                }
                if ( Drflag == 0 && onskate == 0)
                {
                    flag = 5;
                    JakeJp[0].X = JakeWk[0].X;
                    JakeJp[0].Y = JakeWk[0].Y;
                }

                yy = 0;
            }

            //******************************************************//

            if (e.KeyCode == Keys.Q)
            {
                if (Drflag == 1)
                {
                    flag = 16;
                    DrAttack[0].X = JakeDrWk[0].X;
                    DrAttack[0].Y = JakeDrWk[0].Y;
                    DrAttack[0].W = JakeDrWk[0].W;
                    DrAttack[0].H = JakeDrWk[0].H;
                }
                if (onskate == 1)
                {
                    flag = 22;
                    JakeAtSk[0].X = Jakeskate[0].X;
                    JakeAtSk[0].Y = Jakeskate[0].Y;
                }
                if ( Drflag == 0 && onskate == 0 )
                {
                    flag = 8;
                    JakePun[0].X = JakeWk[0].X;
                    JakePun[0].Y = JakeWk[0].Y;
                  
                }
            }

            //******************************************************//

            if (e.KeyCode == Keys.W)
            {
                if (Drflag == 1)
                {
                    flag = 17;
                    DrAttack[0].X = JakeDrWk[0].X;
                    DrAttack[0].Y = JakeDrWk[0].Y;
                    DrAttack[0].W = JakeDrWk[0].W;
                    DrAttack[0].H = JakeDrWk[0].H;
                }
                else
                {
                    flag = 9;
                    JakePun[0].X = JakeWk[0].X;
                    JakePun[0].Y = JakeWk[0].Y;
                }
            }

            //******************************************************//


            if (e.KeyCode == Keys.E)
            {
                if (Drflag == 1)
                {
                    flag = 18;
                    DrFire[0].X = JakeDrWk[0].X;
                    DrFire[0].Y = JakeDrWk[0].Y;
                    DrFire[0].W = JakeDrWk[0].W;
                    DrFire[0].H = JakeDrWk[0].H;
                    FireBall();
                }
                else
                {
                    flag = 10;
                    JakePun[0].X = JakeWk[0].X;
                    JakePun[0].Y = JakeWk[0].Y;
                }
            }

            //******************************************************//





            if (e.KeyCode == Keys.R)
            {

                flag = 21;
                JakePun[0].X = JakeWk[0].X;
                JakePun[0].Y = JakeWk[0].Y;
            }

            //******************************************************//
            if (e.KeyCode == Keys.S && skate ==1)
            {
                flag = 11;
                onskate = 1;
                Jakeskate[0].X = JakeWk[0].X;
                Jakeskate[0].Y = JakeWk[0].Y;

                JakeMoveSk[0].X = JakeWk[0].X;
                JakeMoveSk[0].X = JakeID[0].X;

            }

            //******************************************************//

            if (e.KeyCode == Keys.S && Jakeskate[0].Sk == 4 && flag == 11)
            {
                flag = 12;

                onskate = 0;
            }



           //DrawDubb(this.CreateGraphics());
        }

        void tt_Tick(object sender, EventArgs e)
        {

            if (TimeS == 400)
            {
                Summon = 1;
            }

            if (HitSS == 1 )
            {
                flag = 19;
                Summon = 0;
                TimeS = -100;
                if (GrandFather[0].GRR <= GrandFather[0].im.Count)
                {
                    GrandFather[0].GRR++;
                    if (GrandFather[0].GRR > 10 && GrandFather[0].GRR < 19)
                    {
                        GrandFather[0].Y -= 13;
                        GrandFather[0].W += 13;
                        GrandFather[0].H += 13;
                    }
                    


                }
                if (GrandFather[0].GRR == GrandFather[0].im.Count)
                {
                    if (esbatGD == 0)
                    {
                        GrandFather[0].GRR = 18;
                        GrandFather[0].Y = 520;
                        esbatGD = 1;
                    }
                    else
                    {
                        GrandFather[0].GRR = 18;
                        AttackGD = 1;
                        GrandFather[1].X = GrandFather[0].X;
                        GrandFather[1].Y = GrandFather[0].Y+110;
                        GrandFather[1].W = GrandFather[0].im[0].Width  +350;
                        GrandFather[1].H = GrandFather[0].im[0].Height +90;
                    }
                }
            }

            if (AttackGD == 1)
            {
                if (create == 0)
                {
                    FishAndHarpy();
                    create = 1;
                }
                if (GrandFather[1].GAT <= GrandFather[1].im.Count)
                {
                    GrandFather[1].GAT++;
                    if (GrandFather[1].GAT == 1)
                    {
                        GrandFather[1].X = GrandFather[0].X;
                        GrandFather[1].Y = GrandFather[0].Y + 110;
                        GrandFather[1].W = GrandFather[0].im[1].Width + 350;
                        GrandFather[1].H = GrandFather[0].im[1].Height + 90;
                    }
                    GrandFather[1].X += 3;
                    for (int i = 0; i < Fish.Count; i++)
                    {
                        if (GrandFather[1].X + GrandFather[1].W >= Fish[i].X)
                        {
                            Fish.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < Harpy.Count; i++)
                    {
                        if (GrandFather[1].X + GrandFather[1].W >= Harpy[i].X)
                        {
                            Harpy.RemoveAt(i);
                        }
                    }
                }
                if (GrandFather[1].GAT == GrandFather[1].im.Count)
                {
                    GrandFather[1].GAT = 0;
                }
            }
            if (Counterr % 10 == 0)
            {
                if (JakeDrWk[0].Y <= 540)
                {
                    yy += 5;
                    JakeDrWk[0].Y += yy;
                    if ( JakeDrWk[0].Y >= 520 )
                    flag = 3;
                }
            }

            if (counteridle % -1 == 0)
            {
                if (JakeID[0].IDR <= JakeID[0].im.Count)
                {
                    JakeID[0].IDR++;
                }
                if (JakeID[0].IDR == JakeID[0].im.Count)
                {
                    JakeID[0].IDR = 0;
                }
                if (flag == 3)
                {
                    if (JakeDr[0].DD <= JakeDr[0].im.Count)
                    {
                        JakeDr[0].DD++;
                        if (JakeDr[0].DD > 31 && JakeDr[0].DD < 36)
                        {
                            JakeDr[0].Y -= 13;
                            JakeDr[0].W += 13;
                            JakeDr[0].H += 13;
                        }
                    }
                    if (JakeDr[0].DD == JakeDr[0].im.Count)
                    {
                        if (esbatDr == 0)
                        {
                            JakeDr[0].DD = 35;
                            JakeDr[0].Y = 570;
                            JakeDrWk[0].W = JakeDr[0].W + 20;
                            JakeDrWk[0].H = JakeDr[0].H + 30;
                            esbatDr = 1;
                        }
                        else
                        {
                            JakeDr[0].DD = 35;
                        }

                    }
                }

                if (flag == 24)
                {

                    if (JakeDr[0].DD > 0)
                    {
                        JakeDr[0].DD--;
                    }
                    if (JakeDr[0].DD == 0)
                    {
                        flag = 0;
                    }



                }
                if (flag == 4)
                {
                    if (JakeCr[0].CC <= JakeCr[0].im.Count)
                    {
                        JakeCr[0].CC++;
                    }
                    if (JakeCr[0].CC == JakeCr[0].im.Count)
                    {
                        JakeCr[0].CC = 11;
                        flag = 0;
                    }
                }
                if (flag == 5)
                {
                    if (JakeJp[0].jj <= JakeJp[0].im.Count)
                    {
                        JakeJp[0].jj++;
                        JakeJp[0].Y -= 10;
                    }
                    if (JakeJp[0].jj == JakeJp[0].im.Count)
                    {
                        JakeJp[0].jj = 7;
                        flag = 0;
                    }
                }
                if (flag == 8)
                {
                    if (JakePun[0].P1 <= JakePun[0].P2)
                    {
                        JakePun[0].P1++;
                    }
                    if (JakePun[0].P1 == JakePun[0].P2)
                    {
                        for (int i = 0; i < Fish.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Fish[i].X)
                            {
                                punchflag = 1;
                                ps = i;
                                Fish[i].EMHP++;
                            }
                            if (Fish[i].EMHP >= 3)
                            {
                                Fish.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < Harpy.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Harpy[i].X)
                            {
                                Harpy[i].EMHP++;
                            }
                            if (Harpy[i].EMHP >= 3)
                            {
                                Harpy.RemoveAt(i);
                            }
                        }
                        JakePun[0].P1 = 0;
                        flag = 0;
                    }
                }
            //if (punchflag == 1)
            //{
            //    if (Effects[0].EP <= Effects[1].EF)
            //    {
            //        Effects[0].EP++;
            //        Effects[0].X = Fish[ps].X;
            //        Effects[0].Y = Fish[ps].Y;
            //        Effects[0].W = Fish[ps].W;
            //        Effects[0].H = Fish[ps].H;
            //    }
            //    if (Effects[0].EP == Effects[1].EF)
            //    {
            //        Effects[0].EP = 0;
            //        punchflag = 0;
            //    }
            //}
                if (flag == 9)
                {
                    if (JakePun[0].P2 <= JakePun[0].P3)
                    {
                        JakePun[0].P2++;
                    }
                    if (JakePun[0].P2 == JakePun[0].P3)
                    {
                        for (int i = 0; i < Fish.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Fish[i].X)
                            {
                                Fish[i].EMHP++;
                            }
                            if (Fish[i].EMHP >= 3)
                            {
                                Fish.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < Harpy.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Harpy[i].X)
                            {
                                Harpy[i].EMHP++;
                            }
                            if (Harpy[i].EMHP >= 3)
                            {
                                Harpy.RemoveAt(i);
                            }
                        }
                        JakePun[0].P1 = 4;
                        flag = 0;
                    }
                }
                if (flag == 10)
                {
                    if (JakePun[0].P3 <= JakePun[0].P4)
                    {
                        JakePun[0].P3++;
                    }
                    if (JakePun[0].P3 == JakePun[0].P4)
                    {
                        for (int i = 0; i < Fish.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Fish[i].X)
                            {
                                Fish[i].EMHP++;
                            }
                            if (Fish[i].EMHP >= 3)
                            {
                                Fish.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < Harpy.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Harpy[i].X)
                            {
                                Harpy[i].EMHP++;
                            }
                            if (Harpy[i].EMHP >= 3)
                            {
                                Harpy.RemoveAt(i);
                            }
                        }
                        JakePun[0].P3 = 8;
                        flag = 0;
                    }
                }

                if (flag == 21)
                {
                    if (JakePun[0].P4 <= JakePun[0].im.Count)
                    {
                        JakePun[0].P4++;
                    }
                    if (JakePun[0].P4 == JakePun[0].im.Count)
                    {
                        for (int i = 0; i < Fish.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Fish[i].X)
                            {
                                Fish[i].EMHP++;
                            }
                            if (Fish[i].EMHP >= 3)
                            {
                                Fish.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < Harpy.Count; i++)
                        {
                            if (JakePun[0].X + JakePun[0].W + 5 >= Harpy[i].X)
                            {
                                Harpy[i].EMHP++;
                            }
                            if (Harpy[i].EMHP >= 3)
                            {
                                Harpy.RemoveAt(i);
                            }
                        }
                        JakePun[0].P4 = 16;
                        flag = 0;
                    }
                }
                if (flag == 22)
                {
                    if (JakeAtSk[0].Skat <= JakeAtSk[0].im.Count)
                    {
                        JakeAtSk[0].Skat++;
                    }
                    if (JakeAtSk[0].Skat == JakeAtSk[0].im.Count)
                    {
                        for (int i = 0; i < Fish.Count; i++)
                        {
                            if (JakeAtSk[0].X + JakeAtSk[0].W + 5 >= Fish[i].X)
                            {
                                Fish[i].EMHP++;
                            }
                            if (Fish[i].EMHP >= 3)
                            {
                                Fish.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < Harpy.Count; i++)
                        {
                            if (JakeAtSk[0].X + JakeAtSk[0].W + 5 >= Harpy[i].X)
                            {
                                Harpy[i].EMHP++;
                            }
                            if (Harpy[i].EMHP >= 3)
                            {
                                Harpy.RemoveAt(i);
                            }
                        }
                       JakeAtSk[0].Skat = 0;
                        flag = 11 ;
                    }

                }

                if (flag == 11 && skate==1)
                {
                    if (Jakeskate[0].Sk < Jakeskate[0].RS)
                    {
                        Jakeskate[0].Sk++;
                    }
                    if (Jakeskate[0].Sk == Jakeskate[0].RS)
                    {
                        Jakeskate[0].Sk = 4;
                    }
                }
                if (flag == 12)
                {
                    if (Jakeskate[0].Sk > 0)
                    {
                        Jakeskate[0].Sk--;
                    }
                    if (Jakeskate[0].Sk == 0)
                    {
                        flag = 0;
                    }
                }
                if (flag == 15)
                {
                    if (JakeJpSk[0].Js <= JakeJpSk[0].im.Count)
                    {
                        JakeJpSk[0].Js++;
                        JakeJpSk[0].Y -= 4;
                    }
                    if (JakeJpSk[0].Js == JakeJpSk[0].im.Count)
                    {
                        flag = 11;
                    }
                }
                if (flag == 16)
                {
                    if (DrAttack[0].DAt1 <= DrAttack[0].DAt2)
                    {
                        DrAttack[0].DAt1++;
                    }
                    if (DrAttack[0].DAt1 == DrAttack[0].DAt2)
                    {
                        for (int i = 0; i < Fish.Count; i++)
                        {
                            if (DrAttack[0].X + DrAttack[0].W + 5 >= Fish[i].X)
                            {
                                Fish[i].EMHP++;
                            }
                            if (Fish[i].EMHP >= 3)
                            {
                                Fish.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < Harpy.Count; i++)
                        {
                            if (DrAttack[0].X + DrAttack[0].W + 5 >= Harpy[i].X)
                            {
                                Harpy[i].EMHP++;
                            }
                            if (Harpy[i].EMHP >= 3)
                            {
                                Harpy.RemoveAt(i);
                            }
                        }
                        DrAttack[0].DAt1 = 0;
                        flag = 3;
                    }
                }
                if (flag == 17)
                {
                    if (DrAttack[0].DAt2 <= DrAttack[0].im.Count)
                    {
                        DrAttack[0].DAt2++;
                    }
                    if (DrAttack[0].DAt2 == DrAttack[0].im.Count)
                    {
                        for (int i = 0; i < Fish.Count; i++)
                        {
                            if (DrAttack[0].X + DrAttack[0].W + 5 >= Fish[i].X)
                            {
                                Fish[i].EMHP++;
                            }
                            if (Fish[i].EMHP >= 3)
                            {
                                Fish.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < Harpy.Count; i++)
                        {
                            if (DrAttack[0].X + DrAttack[0].W + 5 >= Harpy[i].X)
                            {
                                Harpy[i].EMHP++;
                            }
                            if (Harpy[i].EMHP >= 3)
                            {
                                Harpy.RemoveAt(i);
                            }
                        }
                        DrAttack[0].DAt2 = 8;
                        flag = 3;
                    }
                }
                if (flag == 18)
                {
                    if (DrFire[0].Brth <= DrFire[0].im.Count)
                    {
                        DrFire[0].Brth++;
                    }
                    if (DrFire[0].Brth == DrFire[0].im.Count)
                    {
                        DrFire[0].Brth = 0;
                        fire = 1;
                        flag = 3;
                    }
                }
                if (fire == 1)
                {
                    for (int i = 0; i < Fireballs.Count; i++)
                    {
                        if (Fireballs[i].Fire <= Fireballs[i].im.Count)
                        {
                            Fireballs[i].Fire++;
                            Fireballs[i].X += 10;
                        }
                        if (Fireballs[i].Fire == Fireballs[i].im.Count-6)
                        {
                           Fireballs[i].Fire = 0;
                           // fire = 0;
                           // Fireballs.RemoveAt(i);
                           for (int k = 0; k < Fish.Count; k++)
                           {
                               try
                               {
                                   if (Fireballs[i].X + Fireballs[i].W >= Fish[k].X)
                                   {
                                       Fish[k].EMHP++;
                                      // Fireballs[i].Fire++;
                                       Fireballs.RemoveAt(0);


                                   }
                                   if (Fish[k].EMHP >= 3)
                                   {
                                       Fish.RemoveAt(k);
                                   }
                               }
                               catch
                               {
                               }
                           }


                           for (int k = 0; k < Harpy.Count; k++)
                           {
                               try
                               {
                                   if (Fireballs[i].X + Fireballs[i].W >= Harpy[k].X)
                                   {
                                       Harpy[k].EMHP++;
                                       //Fireballs[i].Fire++;
                                       Fireballs.RemoveAt(0);

                                   }
                                   if (Harpy[k].EMHP >= 3)
                                   {
                                       Harpy.RemoveAt(k);
                                   }
                               }
                               catch
                               {
                               }
                           }
                        }
                    }
                }
 


                
            }


            if (counterenemy % 1 == 0)
            {
                    for (int i = 0; i < Fish.Count; i++)
                    {
                      if (Fish[i].flagfish == 0)
                          {
                             if (Fish[i].FID <= Fish[i].FAT1)
                             {
                                 Fish[i].FID++;
                             }
                             if (Fish[i].FID == Fish[i].FAT1)
                             {
                                 Fish[i].FID = 0;
                             }
                             if (JakeID[0].X + JakeID[0].W + 70 >= Fish[i].X)
                             {
                                 Fish[i].X -= 3;
                             }
                             if (Fish[i].X <= JakeID[0].X + JakeID[0].W)
                             {

                             }
                         }
                      else
                      {
                          if (Fish[i].FAT1 <= Fish[i].im.Count)
                        {
                            Fish[i].FAT1++;
                   
                            
                        }
                        if (Fish[i].FAT1 == Fish[i].im.Count)
                        {
                            Fish[i].FAT1 = 4;
                        }
                      }
                   }




                 for (int i = 0; i < Harpy.Count; i++)
                 {
                     if (Harpy[i].flagharpy == 0)
                     {
                         if (Harpy[i].HID <= Harpy[i].HAT1)
                         {
                             Harpy[i].HID++;
                         }
                         if (Harpy[i].HID == Harpy[i].HAT1)
                         {
                             Harpy[i].HID = 0;
                         }
                     }
                     else
                     {
                         if (Harpy[i].HAT1 <= Harpy[i].im.Count)
                         {
                             Harpy[i].HAT1++;

                             if (JakeWk[0].X + JakeWk[0].W >= Harpy[i].X)
                             {

                             }
                             else
                             {
                                 Harpy[i].X -= 3;
                             }
                         }
                         if (Harpy[i].HAT1 == Harpy[i].im.Count)
                         {
                             Harpy[i].HAT1 = 6;
                         }
                     }
                 }


            }

            for (int i = 0; i < Fish.Count; i++)
            {
                if (JakeWk[0].X + JakeWk[0].W >= Fish[i].X - 10)
                {
                    Fish[i].flagfish = 1;
                }
            }
            for (int i = 0; i < Harpy.Count; i++)
            {
                if (JakeWk[0].X + JakeWk[0].W >= Harpy[i].X - 10)
                {
                    Harpy[i].flagharpy = 1;
                }
            }


            //Counterr++;
            TimeS++;
            counterenemy++;
            counteridle++;
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            unSeen = new Bitmap(this.ClientSize.Width,this.ClientSize.Height);
            DD = new Bitmap("Diamond.png");

            start();
            BackGround();
           
            CreateJake();
            Walk();
            Crouch();
            Jump();
            Punch();

            Dragon();
            DragonWalk();
            DragonAttack();
            BreatheFire();

            SkateBoard();
            JakeSkate();
            Movingskate();
            Jumpskate();
            AttackSkate();


            CreateGrandFather();

            Fishwoman();
            CreateHarpy();


            CreateEffects();

            World = new Bitmap("BackGround.PNG");

            cxScreen = 1000;
            cyScreen = this.ClientSize.Height;

            DrawDubb(this.CreateGraphics());
        }


        // BackGround
        void BackGround()
        {
            Back pnn = new Back();

            pnn.X = 0;
            pnn.Y = 0;
            pnn.W = this.ClientSize.Width;
            pnn.H = this.ClientSize.Height;

            pnn.img = new Bitmap("BG3.JPG");

            Backk.Add(pnn);
        }

        void start()
        {
            Back pnn = new Back();

            pnn.X = 900;
            pnn.Y = 280;
            pnn.W = 300;
            pnn.H = 100;

            pnn.imgs = new List<Bitmap>();
            for (int k = 0; k < 2; k++)
            {
                Bitmap pnm = new Bitmap("Ready" + (k + 1) + ".PNG");
              // pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.imgs.Add(pnm);
            }
            pnn.re = 0;


            Buttons.Add(pnn);

            Back pnn2 = new Back();

            pnn2.X = 950;
            pnn2.Y = 450;
            pnn2.W = 200;
            pnn2.H = 100;

            pnn2.imgs = new List<Bitmap>();
            for (int k = 0; k < 2; k++)
            {
                Bitmap pnm = new Bitmap("Start" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn2.imgs.Add(pnm);
            }
            pnn2.st = 0;

            Buttons.Add(pnn2);

            Back pnn3 = new Back();

            pnn3.X = 950;
            pnn3.Y = 550;
            pnn3.W = 200;
            pnn3.H = 100;

            pnn3.imgs = new List<Bitmap>();
            for (int k = 0; k < 2; k++)
            {
                Bitmap pnm = new Bitmap("Hotkeys" + (k + 1) + ".PNG");
                //pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn3.imgs.Add(pnm);
            }
            pnn3.ht = 0;

            Buttons.Add(pnn3);

            Back pnn4 = new Back();

            pnn4.X = 950;
            pnn4.Y = 650;
            pnn4.W = 200;
            pnn4.H = 100;

            pnn4.imgs = new List<Bitmap>();
            for (int k = 0; k < 2; k++)
            {
                Bitmap pnm = new Bitmap("Options" + (k + 1) + ".PNG");
                //pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn4.imgs.Add(pnm);
            }
            pnn4.op = 0;

            Buttons.Add(pnn4);


        }

        // props
        void SkateBoard()
        {
            CActor pnn = new CActor();

            pnn.X = 200;
            pnn.Y = 755;
            pnn.W = 90;
            pnn.H = 30;
            pnn.img = new Bitmap("skate.PNG");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));

            Skateboard.Add(pnn);
        }

        // jake
        void CreateJake()
        {
            CActor pnn = new CActor();
            pnn.X = 30;
            pnn.Y = 620;
            pnn.H = 170;
            pnn.W = 90;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 12; k++)
            {
                Bitmap pnm = new Bitmap( "IDR" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.IDR = 0;
            JakeID.Add(pnn);
        }
        void Walk()
        {
            CActor pnn = new CActor();
            pnn.X = JakeID[0].X;
            pnn.Y = JakeID[0].Y;
            pnn.H = JakeID[0].H;
            pnn.W = JakeID[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 10; k++)
            {
                Bitmap pnm = new Bitmap("w" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.WR = 0;
            for (int k = 0 ; k < 10; k++)
            {
                Bitmap pnm = new Bitmap("WL" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.WL = 10;


            JakeWk.Add(pnn);
        }
        void Crouch()
        {
            CActor pnn = new CActor();

            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 12; k++)
            {
                Bitmap pnm = new Bitmap("C" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.CC = 0;
            JakeCr.Add(pnn);
        }
        void Jump()
        {

            CActor pnn = new CActor();

            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 7; k++)
            {
                Bitmap pnm = new Bitmap("J" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.jj = 0;
            JakeJp.Add(pnn);
        }
        void Punch()
        {


            CActor pnn = new CActor();

            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 4; k++)
            {
                Bitmap pnm = new Bitmap("P" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.P1 = 0;

            for (int k = 0; k < 4; k++)
            {
                Bitmap pnm = new Bitmap("PP" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.P2 = 4;


            for (int k = 0; k < 8; k++)
            {
                Bitmap pnm = new Bitmap("PPP" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.P3 = 8;


            for (int k = 0; k < 10; k++)
            {
                Bitmap pnm = new Bitmap("PPPP" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }

            pnn.P4 = 16;





            JakePun.Add(pnn);




        }
        void JakeSkate()
        {
            CActor pnn = new CActor();
            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 5; k++)
            {
                Bitmap pnm = new Bitmap("SKB" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.Sk = 0;
            for (int k = 0; k < 5; k++)
            {
                Bitmap pnm = new Bitmap("SKB" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.RS = 5;

            Jakeskate.Add(pnn);

        }
        void Movingskate()
        {
            CActor pnn = new CActor();
            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 7; k++)
            {
                Bitmap pnm = new Bitmap("MKB" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.Mk = 0;

            for (int k = 0; k < 7; k++)
            {
                Bitmap pnm = new Bitmap("MKBL" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.Mkl = 7;



            JakeMoveSk.Add(pnn);


        }
        void Jumpskate()
        {
            CActor pnn = new CActor();
            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 14; k++)
            {
                Bitmap pnm = new Bitmap("JSK" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.Js = 0;

            JakeJpSk.Add(pnn);

        }
        void AttackSkate()
        {

            CActor pnn = new CActor();
            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 13; k++)
            {
                Bitmap pnm = new Bitmap("SKAT" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.Skat = 0;

            JakeAtSk.Add(pnn);


        }


        // Dragon
        void Dragon()
        {
            CActor pnn = new CActor();

            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 36; k++)
            {

                Bitmap pnm = new Bitmap("T" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.DD = 0;


            JakeDr.Add(pnn);
        }
        void DragonWalk()
        {
            CActor pnn = new CActor();

            pnn.X = JakeWk[0].X;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 8; k++)
            {

                Bitmap pnm = new Bitmap("DrWk" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.DrWk = 0;


            for (int k = 0; k < 8; k++)
            {

                Bitmap pnm = new Bitmap("DrIDL" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.DrWkL = 8;



            JakeDrWk.Add(pnn);

        }
        void DragonAttack()
        {
            CActor pnn = new CActor();

            pnn.X = JakeDr[0].X;
            pnn.Y = JakeDr[0].Y;
            pnn.H = JakeDr[0].H;
            pnn.W = JakeDr[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 8; k++)
            {
                Bitmap pnm = new Bitmap("DRAT" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.DAt1 = 0;

            for (int k = 0; k < 10; k++)
            {
                Bitmap pnm = new Bitmap("DRATT" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.DAt2 = 8;


            DrAttack.Add(pnn);
        }
        void BreatheFire()
        {
            CActor pnn = new CActor();

            pnn.X = JakeDrWk[0].X;
            pnn.Y = JakeDrWk[0].Y;
            pnn.H = JakeDrWk[0].H;
            pnn.W = JakeDrWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 8; k++)
            {
                Bitmap pnm = new Bitmap("DBRTH" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            for (int k = 0; k < 5; k++)
            {
                Bitmap pnm = new Bitmap("FIRE" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }

            pnn.Brth = 0;

            DrFire.Add(pnn);
        }
        void FireBall()
        {
            CActor pnn = new CActor();

            pnn.X = DrFire[0].X + DrFire[0].W + 5;
            pnn.Y = DrFire[0].Y + 40;
            pnn.W = 90;
            pnn.H = 90;

            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 14; k++)
            {
                Bitmap pnm = new Bitmap("FB" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.Fire = 0;

            Fireballs.Add(pnn);


        }

        // Enemies
        void Fishwoman()
        {
            int var = V.Next(5, 20);

            for (int i=0 ; i < var ; i++)
            {
                CActor pnn = new CActor();
                pnn.X = RR.Next(this.ClientSize.Width/2+100,5000);
                pnn.Y = JakeWk[0].Y;
                pnn.H = JakeWk[0].H;
                pnn.W = JakeWk[0].W;
                pnn.im = new List<Bitmap>();
                for (int k = 0; k < 4; k++)
                {
                    Bitmap pnm = new Bitmap("FID" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.FID = 0;

                for (int k = 0; k < 8; k++)
                {
                    Bitmap pnm = new Bitmap("FAT" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.XOLD = pnn.X;
                pnn.FAT1 = 4;
                pnn.flagfish = 0;
                pnn.EMHP = 0;
                Fish.Add(pnn);
            }
            
        }
        void CreateHarpy()
        {
            int var2 = F.Next(5, 20);

            for (int i = 0; i < var2; i++)
            {
                CActor pnn = new CActor();
                pnn.X = EE.Next(6000, 10000);
                pnn.Y = JakeWk[0].Y - 20;
                pnn.H = JakeWk[0].H+10;
                pnn.W = JakeWk[0].W+30;
                pnn.im = new List<Bitmap>();
                for (int k = 0; k < 6; k++)
                {
                    Bitmap pnm = new Bitmap("EID" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.HID = 0;

                for (int k = 0; k < 6; k++)
                {
                    Bitmap pnm = new Bitmap("EAT" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.XOLD = pnn.X;
                pnn.HAT1 = 6;
                pnn.flagharpy = 0;
                pnn.EMHP = 0;
                Harpy.Add(pnn);
            }

        }
    
        // GrandFather
        void CreateGrandFather()
        {
            CActor pnn = new CActor();

            pnn.X = JakeWk[0].X - 20 ;
            pnn.Y = JakeWk[0].Y;
            pnn.H = JakeWk[0].H;
            pnn.W = JakeWk[0].W;
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 19; k++)
            {
                Bitmap pnm = new Bitmap ("TG" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.GRR = 0;

            GrandFather.Add(pnn);

            CActor pnn2 = new CActor();

            pnn2.X = JakeWk[0].X - 20;
            pnn2.Y = JakeWk[0].Y;
            pnn2.H = JakeWk[0].H;
            pnn2.W = JakeWk[0].W;
            pnn2.im = new List<Bitmap>();
            for (int k = 0; k < 5; k++)
            {

                Bitmap pnm = new Bitmap("GT" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn2.im.Add(pnm);
            }
            pnn2.GAT = 0;

            GrandFather.Add(pnn2);


            
        }
        void CreateEffects()
        {
            CActor pnn = new CActor();
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 3; k++)
            {
                Bitmap pnm = new Bitmap("EP" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.EP = 0;

            Effects.Add(pnn);

            CActor pnn2 = new CActor();            
            pnn2.im = new List<Bitmap>();
            for (int k = 0; k < 7; k++)
            {
                Bitmap pnm = new Bitmap("EF" + (k + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn2.im.Add(pnm);
            }
            pnn2.EF = 3;

            Effects.Add(pnn2);
        }

        void FishAndHarpy()
        {
            for (int i = 0; i < Fish.Count; i++)
            {
                i = 0;
                Fish.RemoveAt(i);
            }

            for (int i = 0; i < Harpy.Count; i++)
            {
                i = 0;
                Harpy.RemoveAt(i);
            }








            int var = V.Next(10, 30);

            for (int i = 0; i < var; i++)
            {
                CActor pnn = new CActor();
                pnn.X = RR.Next(10000 , 15000);
                pnn.Y = JakeWk[0].Y;
                pnn.H = JakeWk[0].H;
                pnn.W = JakeWk[0].W;
                pnn.im = new List<Bitmap>();
                for (int k = 0; k < 4; k++)
                {
                    Bitmap pnm = new Bitmap("FID" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.FID = 0;

                for (int k = 0; k < 8; k++)
                {
                    Bitmap pnm = new Bitmap("FAT" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.XOLD = pnn.X;
                pnn.FAT1 = 4;
                pnn.flagfish = 0;
                pnn.EMHP = 0;
                Fish.Add(pnn);
            }
            /////////////////////////////////////////////////////////////////
            int var2 = F.Next(10, 30);

            for (int i = 0; i < var2; i++)
            {
                CActor pnn = new CActor();
                pnn.X = EE.Next(10000, 15000);
                pnn.Y = JakeWk[0].Y - 20;
                pnn.H = JakeWk[0].H + 10;
                pnn.W = JakeWk[0].W + 30;
                pnn.im = new List<Bitmap>();
                for (int k = 0; k < 6; k++)
                {
                    Bitmap pnm = new Bitmap("EID" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.HID = 0;

                for (int k = 0; k < 6; k++)
                {
                    Bitmap pnm = new Bitmap("EAT" + (k + 1) + ".PNG");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }
                pnn.XOLD = pnn.X;
                pnn.HAT1 = 6;
                pnn.flagharpy = 0;
                pnn.EMHP = 0;
                Harpy.Add(pnn);
            }
        }



        void  DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(unSeen);
            DrawScene(g2);
            g.DrawImage(unSeen, 0, 0);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            g.DrawImage(World,
               new Rectangle(0, 0, 4000, 1400),
               new Rectangle(XS, YS, cxScreen, cyScreen),
               GraphicsUnit.Pixel);

            if (Summon == 1)
            {
                g.DrawImage(DD,
                        10, 10);
            }

            
                for (int i = 0; i < Fish.Count; i++)
                {
                    if (Fish[i].flagfish == 0)
                    {
                        //if (i != ps)
                        //{
                            g.DrawImage(Fish[i].im[Fish[i].FID], Fish[i].X, Fish[i].Y, Fish[i].W, Fish[i].H);
                        //}
                    }
                    else
                    {
                        //if (i != ps)
                        //{
                            g.DrawImage(Fish[i].im[Fish[i].FAT1], Fish[i].X, Fish[i].Y, Fish[i].W, Fish[i].H);
                        //}
                    }
                }
                //if (punchflag == 1)
                //{
                //    g.DrawImage(Effects[0].im[Effects[0].EP], Effects[0].X, Effects[0].Y, Effects[0].W, Effects[0].H);
                //}

            for (int i = 0; i < Harpy.Count; i++)
            {
                if (Harpy[i].flagharpy == 0)
                {
                    g.DrawImage(Harpy[i].im[Harpy[i].HID], Harpy[i].X, Harpy[i].Y, Harpy[i].W, Harpy[i].H);
                }
                else
                {
                    g.DrawImage(Harpy[i].im[Harpy[i].HAT1], Harpy[i].X, Harpy[i].Y, Harpy[i].W, Harpy[i].H);
                }
            }

            if (background == 0)
            {
                for (int i = 0; i < Backk.Count; i++)
                {
                    g.DrawImage(Backk[0].img, Backk[0].X, Backk[0].Y, Backk[0].W, Backk[0].H);
                }
                for (int i = 0; i < Buttons.Count; i++)
                {
                    g.DrawImage(Buttons[0].imgs[Buttons[0].re], Buttons[0].X, Buttons[0].Y, Buttons[0].W, Buttons[0].H);

                    if (Buttons[0].re == 1)
                    {
                        g.DrawImage(Buttons[0].imgs[Buttons[0].re], Buttons[0].X, Buttons[0].Y, Buttons[0].W, Buttons[0].H);
                        g.DrawImage(Buttons[1].imgs[Buttons[1].st], Buttons[1].X, Buttons[1].Y, Buttons[1].W, Buttons[1].H);
                        g.DrawImage(Buttons[2].imgs[Buttons[2].ht], Buttons[2].X, Buttons[2].Y, Buttons[2].W, Buttons[2].H);
                        g.DrawImage(Buttons[3].imgs[Buttons[3].op], Buttons[3].X, Buttons[3].Y, Buttons[3].W, Buttons[3].H);
                    }
                
                }

            }
            else
            {
                if (skate == 0)
                {
                    for (int i = 0; i < Skateboard.Count; i++)
                    {
                        g.DrawImage(Skateboard[i].img, Skateboard[i].X, Skateboard[i].Y, Skateboard[i].W, Skateboard[i].H);
                    }
                }
                if (flag == 0)
                {
                    for (int i = 0; i < JakeID.Count; i++)
                    {
                        g.DrawImage(JakeID[i].im[JakeID[i].IDR], JakeID[i].X, JakeID[i].Y, JakeID[i].W, JakeID[i].H);
                    }
                }
                else
                {
                    if (flag == 1)
                    {
                        for (int i = 0; i < JakeWk.Count; i++)
                        {
                            g.DrawImage(JakeWk[i].im[JakeWk[i].WR], JakeWk[i].X, JakeWk[i].Y, JakeWk[i].W, JakeWk[i].H);
                        }
                    }
                    if (flag == 2)
                    {
                        for (int i = 0; i < JakeWk.Count; i++)
                        {
                            g.DrawImage(JakeWk[i].im[JakeWk[i].WL], JakeWk[i].X, JakeWk[i].Y, JakeWk[i].W, JakeWk[i].H);
                        }
                    }
                    if (flag == 3)
                    {
                        for (int i = 0; i < JakeDr.Count; i++)
                        {
                            g.DrawImage(JakeDr[i].im[JakeDr[i].DD], JakeDr[i].X, JakeDr[i].Y, JakeDr[i].W, JakeDr[i].H);
                        }
                    }
                    if (flag == 24)
                    {
                        for (int i = 0; i < JakeDr.Count; i++)
                        {
                            g.DrawImage(JakeDr[i].im[JakeDr[i].DD], JakeDr[i].X, JakeDr[i].Y, JakeDr[i].W, JakeDr[i].H);
                        }
                    }
                    if (flag == 4)
                    {
                        for (int i = 0; i < JakeCr.Count; i++)
                        {
                            g.DrawImage(JakeCr[i].im[JakeCr[i].CC], JakeCr[i].X, JakeCr[i].Y, JakeCr[i].W, JakeCr[i].H);
                        }
                    }
                    if (flag == 5)
                    {
                        for (int i = 0; i < JakeJp.Count; i++)
                        {
                            g.DrawImage(JakeJp[i].im[JakeJp[i].jj], JakeJp[i].X, JakeJp[i].Y, JakeJp[i].W, JakeJp[i].H);
                        }
                    }
                    if (flag == 6)
                    {
                        for (int i = 0; i < JakeDrWk.Count; i++)
                        {
                            g.DrawImage(JakeDrWk[i].im[JakeDrWk[i].DrWk], JakeDrWk[i].X, JakeDrWk[i].Y, JakeDrWk[i].W, JakeDrWk[i].H);
                        }
                    }
                    if (flag == 7)
                    {
                        for (int i = 0; i < JakeDrWk.Count; i++)
                        {
                            g.DrawImage(JakeDrWk[i].im[JakeDrWk[i].DrWkL], JakeDrWk[i].X, JakeDrWk[i].Y, JakeDrWk[i].W, JakeDrWk[i].H);
                        }
                    }

                    if (flag == 8)
                    {
                        for (int i = 0; i < JakePun.Count; i++)
                        {
                            g.DrawImage(JakePun[i].im[JakePun[i].P1], JakePun[i].X, JakePun[i].Y, JakePun[i].W, JakePun[i].H);
                        }
                    }
                    if (flag == 9)
                    {
                        for (int i = 0; i < JakePun.Count; i++)
                        {
                            g.DrawImage(JakePun[i].im[JakePun[i].P2], JakePun[i].X, JakePun[i].Y, JakePun[i].W, JakePun[i].H);
                        }
                    }
                    if (flag == 10)
                    {
                        for (int i = 0; i < JakePun.Count; i++)
                        {
                            g.DrawImage(JakePun[i].im[JakePun[i].P3], JakePun[i].X, JakePun[i].Y, JakePun[i].W, JakePun[i].H);
                        }
                    }
                    if (flag == 21)
                    {
                        for (int i = 0; i < JakePun.Count; i++)
                        {
                            g.DrawImage(JakePun[i].im[JakePun[i].P4], JakePun[i].X, JakePun[i].Y, JakePun[i].W, JakePun[i].H);
                        }
                    }
                  
                    if (flag == 11 && skate == 1)
                    {
                        for (int i = 0; i < Jakeskate.Count; i++)
                        {
                            g.DrawImage(Jakeskate[i].im[Jakeskate[i].Sk], Jakeskate[i].X, Jakeskate[i].Y, Jakeskate[i].W, Jakeskate[i].H);
                        }
                    }
                    if (flag == 12)
                    {
                        for (int i = 0; i < Jakeskate.Count; i++)
                        {
                            g.DrawImage(Jakeskate[i].im[Jakeskate[i].Sk], Jakeskate[i].X, Jakeskate[i].Y, Jakeskate[i].W, Jakeskate[i].H);
                        }
                    }
                    if (flag == 13)
                    {
                        for (int i = 0; i < JakeMoveSk.Count; i++)
                        {
                            g.DrawImage(JakeMoveSk[i].im[JakeMoveSk[i].Mk], JakeMoveSk[i].X, JakeMoveSk[i].Y, JakeMoveSk[i].W, JakeMoveSk[i].H);
                        }
                    }
                    if (flag == 14)
                    {
                        for (int i = 0; i < JakeMoveSk.Count; i++)
                        {
                            g.DrawImage(JakeMoveSk[i].im[JakeMoveSk[i].Mkl], JakeMoveSk[i].X, JakeMoveSk[i].Y, JakeMoveSk[i].W, JakeMoveSk[i].H);
                        }
                    }
                    if (flag == 15)
                    {
                        for (int i = 0; i < JakeJpSk.Count; i++)
                        {
                            g.DrawImage(JakeJpSk[i].im[JakeJpSk[i].Js], JakeJpSk[i].X, JakeJpSk[i].Y, JakeJpSk[i].W, JakeJpSk[i].H);
                        }
                    }
                    if (flag == 22)
                    {
                        for (int i = 0; i < JakeAtSk.Count; i++)
                        {
                            g.DrawImage(JakeAtSk[i].im[JakeAtSk[i].Skat], JakeAtSk[i].X, JakeAtSk[i].Y, JakeAtSk[i].W, JakeAtSk[i].H);
                        }
                    }
                    if (flag == 16)
                    {
                        for (int i = 0; i < DrAttack.Count; i++)
                        {
                            g.DrawImage(DrAttack[i].im[DrAttack[i].DAt1], DrAttack[i].X, DrAttack[i].Y, DrAttack[i].W, DrAttack[i].H);
                        }
                    }
                    if (flag == 17)
                    {
                        for (int i = 0; i < DrAttack.Count; i++)
                        {
                            g.DrawImage(DrAttack[i].im[DrAttack[i].DAt2], DrAttack[i].X, DrAttack[i].Y, DrAttack[i].W, DrAttack[i].H);
                        }
                    }
                    if (flag == 18)
                    {
                        for (int i = 0; i < DrFire.Count; i++)
                        {
                            g.DrawImage(DrFire[i].im[DrFire[i].Brth], DrFire[i].X, DrFire[i].Y, DrFire[i].W, DrFire[i].H);
                        }
                    }
                    if (fire == 1)
                    {

                        for (int i = 0; i < Fireballs.Count; i++)
                        {
                            g.DrawImage(Fireballs[i].im[Fireballs[i].Fire], Fireballs[i].X, Fireballs[i].Y, Fireballs[i].W, Fireballs[i].H);
                        }
                    }
                    if (flag == 19)
                    {
                        if (AttackGD == 0)
                        {
                            g.DrawImage(GrandFather[0].im[GrandFather[0].GRR], GrandFather[0].X, GrandFather[0].Y, GrandFather[0].W, GrandFather[0].H);
                        }
                        if (AttackGD == 1)
                        {
                            g.DrawImage(GrandFather[1].im[GrandFather[1].GAT], GrandFather[1].X, GrandFather[1].Y, GrandFather[1].W, GrandFather[1].H);
                        }
                    }
                }
            }


        }
    }
}
