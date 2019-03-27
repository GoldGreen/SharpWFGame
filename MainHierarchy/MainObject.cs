using System;

namespace GameNewEra
{
    public abstract class MainObject
    {
        //Текущие координаты объекта.
        public int X { get; protected set; }

        public int Y { get; protected set; }

        //Текущие ширина и высота объекта.
        public int Width { get; private set; }

        public int High { get; private set; }

        //Картинка Объекта
        public System.Drawing.Bitmap Picture { get; protected set; }

        //Область объекта (прямоугольник, чтобы не использовать глупый picturebox).
        public System.Drawing.Rectangle RegionObject { get; protected set; }

        protected MainObject(System.Drawing.Bitmap Picture, int Width, int High, int X = 0, int Y = 0)
        {
            this.Picture = Picture;
            this.Width = Width;
            this.High = High;
            NewXY(X, Y);
        }

        //Изменение текущих координат.
        public void NewXY(int X, int Y)
        {
            this.X = X;
            this.Y = Y;

            RegionObject = new System.Drawing.Rectangle(this.X - (Width / 2), this.Y - (High / 2), Width, High);
        }

        //Изменение высоты и ширины объекта в одинаковое кол-во раз.
        public void NewWH(int Power)
        {
            Width *= Power;
            High *= Power;
            RegionObject = new System.Drawing.Rectangle(this.X - (Width / 2), this.Y - (High / 2), Width, High);
        }

        //Три перегруженных метода, чтобы понять - находится ли данная точка в области объекта
        public bool InRange(MainObject WhoHited, int Range)
            => Math.Abs(X - WhoHited.X) < Range && Math.Abs(Y - WhoHited.Y) < Range;

        public bool InRange(System.Drawing.Point WhoHited, int Range)
            => Math.Abs(X - WhoHited.X) < Range && Math.Abs(Y - WhoHited.Y) < Range;

        public bool InRange(int WhoX, int WhoY, int Range)
            => Math.Abs(X - WhoX) < Range && Math.Abs(Y - WhoY) < Range;
    }
}