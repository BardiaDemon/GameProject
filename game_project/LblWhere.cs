using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace game_project
{

    class LblWhere
    {
        public readonly static string LEFT = "l", RIGHT = "r", BOTTOM = "b", TOP = "t";


        private CallBack callBack;

        private string lTRB;

        private int toWhere, xYMin, xYMax, maxBack;


        public LblWhere(string LTRB, int ToWhere, int XYMin, int XYMax , int MaxBack)
        {
            this.lTRB = LTRB;
            this.toWhere = ToWhere;
            this.xYMax = XYMax;
            this.xYMin = XYMin;
            this.maxBack = MaxBack;
        }


        public void setCallBack(CallBack callBack)
        {
            this.callBack = callBack;
        }

        public interface CallBack
        {
            void AfterDone(bool done , bool isLast);
        }

        public void moving(string where)
        {
            int x = frmMain.lblMove.Location.X;
            int y = frmMain.lblMove.Location.Y;

            if (where.Equals(RIGHT))
                frmMain.lblMove.Location = new System.Drawing.Point(x + 5, y);

            else if (where.Equals(BOTTOM))
                frmMain.lblMove.Location = new System.Drawing.Point(x, y + 5);

            else if (where.Equals(LEFT))
                frmMain.lblMove.Location = new System.Drawing.Point(x - 5, y);

            else if (where.Equals(TOP))
                frmMain.lblMove.Location = new System.Drawing.Point(x, y - 5);

            check();
        }


        private void check ()
        {
            int x = frmMain.lblMove.Location.X;
            int y = frmMain.lblMove.Location.Y;

            bool error = false;
            Console.Write((y > xYMax));
            Console.Write((y < xYMin));
            if (lTRB.Equals(RIGHT))
            {
                if (y > xYMax || y < xYMin || x < maxBack || x > toWhere+5)
                    callBack.AfterDone(!(error = true), isLast());
            }

            else if (lTRB.Equals(BOTTOM))
            {
                if (x > xYMax || x < xYMin || y<maxBack || y > toWhere+5)
                    callBack.AfterDone((!(error = true)), isLast());
            }

            else if (lTRB.Equals(LEFT))
            {
                if (y > xYMax || y < xYMin || x>maxBack || x < toWhere - 5)
                    callBack.AfterDone((!(error = true)), isLast());
            }

            else if (lTRB.Equals(TOP))
            {
                if (x > xYMax || x < xYMin || y>maxBack || y < toWhere - 5)
                    callBack.AfterDone((!(error = true)), isLast());
            }

            if (!error) callBack.AfterDone(true, isLast());

        }
            
        private bool isLast ()
        {
            int x = frmMain.lblMove.Location.X;
            int y = frmMain.lblMove.Location.Y;
            if (lTRB.Equals(RIGHT))
                return (x >= toWhere);    
            else if ( lTRB.Equals(BOTTOM))
                return (y >= toWhere);
            else if (lTRB.Equals(LEFT))
                return (x <= toWhere);
            else if (lTRB.Equals(TOP))
                return (y <= toWhere);

            return false;
        }

    }
}
