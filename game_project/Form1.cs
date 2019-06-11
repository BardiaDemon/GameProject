using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace game_project
{
    
    
    
    public partial class frmMain : Form
    {
        int second = 40, mintue = 1;
        bool start = false;

        private static bool first = true;

        private static List<LblWhere> lblWhereL;

        public static Label lblMove , lblSTime;
        private static Timer timerT;
        
        public frmMain()
        {
            InitializeComponent();
            lblMove = lblTarget;
            lblSTime = lblTime;
            timerT = timerTime;
            reset();
            
        }
        
        private void FrmMain_MouseEnter(object sender, EventArgs e)
        {

        }
        
         private static void setMove ()
        {
            lblWhereL = new List<LblWhere> ();

            lblWhereL.Add(new LblWhere(LblWhere.RIGHT, 244, 561, 573,110)); // 1

            lblWhereL.Add(new LblWhere(LblWhere.TOP, 467, 244, 260,573)); // 2

            lblWhereL.Add(new LblWhere(LblWhere.LEFT, 28, 455, 469,260)); // 3

            lblWhereL.Add(new LblWhere(LblWhere.TOP, 82, 12, 28,467)); // 4

            lblWhereL.Add(new LblWhere(LblWhere.RIGHT, 615, 70, 82,12)); // 5

            lblWhereL.Add(new LblWhere(LblWhere.BOTTOM, 153, 615, 631,70));// 6

            lblWhereL.Add(new LblWhere(LblWhere.LEFT, 120, 153, 165,631)); // 7

      //      lblWhereL.Add(new LblWhere(LblWhere.RIGHT, 375, 153, 165));

            lblWhereL.Add(new LblWhere(LblWhere.BOTTOM, 375, 104, 120,153)); // 8

            lblWhereL.Add(new LblWhere(LblWhere.RIGHT, 244, 375, 387,104)); // 9

            lblWhereL.Add(new LblWhere(LblWhere.TOP, 249, 244, 260,387)); // 10

            lblWhereL.Add(new LblWhere(LblWhere.RIGHT, 615, 237, 249, 244)); // 11

            lblWhereL.Add(new LblWhere(LblWhere.BOTTOM, 375, 615, 631, 237)); // 12

            lblWhereL.Add(new LblWhere(LblWhere.LEFT, 539, 375, 387, 631)); // 13

            lblWhereL.Add(new LblWhere(LblWhere.TOP, 333, 517, 539, 388)); // 14

            lblWhereL.Add(new LblWhere(LblWhere.LEFT, 352, 321, 333, 539)); // 15

            lblWhereL.Add(new LblWhere(LblWhere.BOTTOM, 561, 336, 352, 321)); // 16

            lblWhereL.Add(new LblWhere(LblWhere.RIGHT, 465, 561, 573, 336)); // 17

            lblWhereL.Add(new LblWhere(LblWhere.TOP, 487, 465, 481, 573)); //18

            lblWhereL.Add(new LblWhere(LblWhere.RIGHT, 526, 480, 489,465)); //19

        }
        

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private static bool Next = true;
        private LblWhere lblWhere;
        private static int index = 0;

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {

            if (first)
            {
                first = false;
                timerT.Enabled = true;
                sec = 0;
                min = 0;
                h = 0;
            }

            if (Next)
            {
                if (index >= lblWhereL.Count)
                {
                    MessageBox.Show("بردی");
                    reset();
                    return;
                }
                else
                {
                    lblWhere = lblWhereL[index++];
                    lblWhere.setCallBack(setAndGet());
                    Next = false;
                }
  
            }

            switch (e.KeyData)
            {
                case Keys.Left:
                    lblWhere.moving (LblWhere.LEFT);
                    break;
                case Keys.Right:
                    lblWhere.moving(LblWhere.RIGHT);
                    break;
                case Keys.Up:
                    lblWhere.moving(LblWhere.TOP);
                    break;
                case Keys.Down:
                    lblWhere.moving(LblWhere.BOTTOM);
                    break;
            }
         
        }


        private static void reset()
        {
            frmMain.index = 0;
            frmMain.lblMove.Location = new Point(110, 566);
            frmMain.Next = true;
            frmMain.setMove();
            first = true;
            timerT.Enabled = false;
            lblSTime.Text = "زمان";
        }

        private LblWhere.CallBack setAndGet()
        {
            return new InterfaceLblWhere();
        }
        

        private class InterfaceLblWhere : LblWhere.CallBack
        {
            void LblWhere.CallBack.AfterDone(bool done, bool isLast)
            {
                if (!done)
                {
                    MessageBox.Show("باختی");
                    frmMain.reset();
                    
                }
                if (isLast) frmMain.Next = true;
            }
        }


        private void Label22_Click(object sender, EventArgs e)
        {

        }


        private void Lbl1_Leave(object sender, EventArgs e)
        {
          
        }

        private void FrmMain_Enter(object sender, EventArgs e)
        {
            

        }

        private void lbl4_Click(object sender, EventArgs e)
        {

        }

        private void lbl5_Click(object sender, EventArgs e)
        {

        }

        private void lblTarget_Click(object sender, EventArgs e)
        {

        }

        private int sec = 0, min = 0, h = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec >=59)
            {
                sec = 0;
                min++;
            }
            if (min>=59)
            {
                min = 0;
                h++;
            }
            string time = string.Format("{0}:{1}:{2}", 
                ((h < 10) ? "0" + h : h + ""),
                ((min < 10) ? "0" + min : min + ""),
                ((sec < 10) ? "0" + sec : sec + ""));

            lblSTime.Text = time;
        }

        private void lbl18_Click(object sender, EventArgs e)
        {

        }

    }
}
