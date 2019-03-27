using System.Collections.Generic;

namespace GameNewEra
{
    public class ObjectWithAnimation : MovableObjectcs
    {
        //Словарь для более простой смены картинки объекта(Без if),
        //где ключ - позиция объекта.
        public Dictionary<Seen, System.Drawing.Bitmap> PictureAnimation { get; private set; }

        public ObjectWithAnimation(System.Drawing.Bitmap[] Pictures, int Width, int High, int X = 0, int Y = 0)
            : base(Pictures[0], Width, High, X, Y)
        {
            PictureAnimation = new Dictionary<Seen, System.Drawing.Bitmap>();
            {
                PictureAnimation.Add(Seen.P0, Pictures[0]);
                PictureAnimation.Add(Seen.P45, Pictures[1]);
                PictureAnimation.Add(Seen.P90, Pictures[2]);
                PictureAnimation.Add(Seen.P135, Pictures[3]);
                PictureAnimation.Add(Seen.P180, Pictures[4]);
                PictureAnimation.Add(Seen.P225, Pictures[5]);
                PictureAnimation.Add(Seen.P270, Pictures[6]);
                PictureAnimation.Add(Seen.P315, Pictures[7]);
            }
        }

        //Метод для изменения картинки от позиции объекта
        public void Animation(Seen Position)
        {
            Picture = PictureAnimation[Position];
        }

        //Замена визуальной составляющей объекта
        public void ChangeAllPicture(System.Drawing.Bitmap[] NewPicture)
        {
            PictureAnimation.Clear();

            PictureAnimation.Add(Seen.P0, NewPicture[0]);
            PictureAnimation.Add(Seen.P45, NewPicture[1]);
            PictureAnimation.Add(Seen.P90, NewPicture[2]);
            PictureAnimation.Add(Seen.P135, NewPicture[3]);
            PictureAnimation.Add(Seen.P180, NewPicture[4]);
            PictureAnimation.Add(Seen.P225, NewPicture[5]);
            PictureAnimation.Add(Seen.P270, NewPicture[6]);
            PictureAnimation.Add(Seen.P315, NewPicture[7]);
            Animation(PositionObject);
        }
    }
}