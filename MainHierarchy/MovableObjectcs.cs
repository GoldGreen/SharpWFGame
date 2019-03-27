using System;

namespace GameNewEra
{
    public enum Seen
    {
        P0,
        P45,
        P90,
        P135,
        P180,
        P225,
        P270,
        P315
    }

    public class MovableObjectcs : MainObject
    {
        //Позиция объекта в зависимости, в какую сторону он движется.
        public Seen PositionObject { get; private set; }

        public MovableObjectcs(System.Drawing.Bitmap Picture, int Width, int High, int X = 0, int Y = 0)
            : base(Picture, Width, High, X, Y)
        {
        }

        //Метод получающий точку в двух разных форматах, и относительно этой точки задается PositionObject.
        public void TakeDirection(System.Drawing.Point NextStep, int Inaccuracy, int ChangeX, int ChangeY, int Diagonal)
        {
            if (Math.Abs(NextStep.X - X) < Inaccuracy && Math.Abs(NextStep.Y - Y) < Inaccuracy)
            {
                PositionObject = Seen.P0;
            }
            else if (Math.Abs(NextStep.X - X) < Inaccuracy && NextStep.Y < Y)
            {
                ChangeXY(0, -Diagonal);
                PositionObject = Seen.P90;
            }
            else if (Math.Abs(NextStep.X - X) < Inaccuracy && NextStep.Y > Y)
            {
                ChangeXY(0, Diagonal);
                PositionObject = Seen.P270;
            }
            else if (NextStep.X > X && Math.Abs(NextStep.Y - Y) < Inaccuracy)
            {
                ChangeXY(Diagonal, 0);
                PositionObject = Seen.P0;
            }
            else if (NextStep.X < X && Math.Abs(NextStep.Y - Y) < Inaccuracy)
            {
                ChangeXY(-Diagonal, 0);
                PositionObject = Seen.P180;
            }
            else if (NextStep.X > X && NextStep.Y > Y)
            {
                ChangeXY(ChangeX, ChangeY);
                PositionObject = Seen.P315;
            }
            else if (NextStep.X < X && NextStep.Y < Y)
            {
                ChangeXY(-ChangeX, -ChangeY);
                PositionObject = Seen.P135;
            }
            else if (NextStep.X > X && NextStep.Y < Y)
            {
                ChangeXY(ChangeX, -ChangeY);
                PositionObject = Seen.P45;
            }
            else if (NextStep.X < X && NextStep.Y > Y)
            {
                ChangeXY(-ChangeX, ChangeY);
                PositionObject = Seen.P225;
            }
        }

        public void TakeDirection(int NextStepX, int NextStepY, int Inaccuracy, int ChangeX, int ChangeY, int Diagonal)
        {
            if (Math.Abs(NextStepX - X) < Inaccuracy && Math.Abs(NextStepY - Y) < Inaccuracy)
            {
                PositionObject = Seen.P0;
            }
            else if (Math.Abs(NextStepX - X) < Inaccuracy && NextStepY < Y)
            {
                ChangeXY(0, -Diagonal);
                PositionObject = Seen.P90;
            }
            else if (Math.Abs(NextStepX - X) < Inaccuracy && NextStepY > Y)
            {
                ChangeXY(0, Diagonal);
                PositionObject = Seen.P270;
            }
            else if (NextStepX > X && Math.Abs(NextStepY - Y) < Inaccuracy)
            {
                ChangeXY(Diagonal, 0);
                PositionObject = Seen.P0;
            }
            else if (NextStepX < X && Math.Abs(NextStepY - Y) < Inaccuracy)
            {
                ChangeXY(-Diagonal, 0);
                PositionObject = Seen.P180;
            }
            else if (NextStepX > X && NextStepY > Y)
            {
                ChangeXY(ChangeX, ChangeY);
                PositionObject = Seen.P315;
            }
            else if (NextStepX < X && NextStepY < Y)
            {
                ChangeXY(-ChangeX, -ChangeY);
                PositionObject = Seen.P135;
            }
            else if (NextStepX > X && NextStepY < Y)
            {
                ChangeXY(ChangeX, -ChangeY);
                PositionObject = Seen.P45;
            }
            else if (NextStepX < X && NextStepY > Y)
            {
                ChangeXY(-ChangeX, ChangeY);
                PositionObject = Seen.P225;
            }
        }

        //Испольуется в методе TakeDirecton для более наглядного представления.
        private void ChangeXY(int changeX, int changeY)
        {
            NewXY(X + changeX, Y + changeY);
        }
    }
}