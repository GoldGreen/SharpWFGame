using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameNewEra
{
    public partial class LocationShip : UserControl
    {
        //Удобное получение координатсистемы на карте.
        public Point GetCursorPosition() => PointToClient(Cursor.Position);

        //Номер текущей системы
        public readonly int NumberSystem;

        //Текст в combobox врага относительно текущей системы.
        private string NewShip;

        //Задний фон главной формы.
        private Bitmap BackGround;

        //Ссылка на карту.
        private Map Map;

        public LocationShip() => InitializeComponent();

        public LocationShip(int X, int Y, string Text, Bitmap Picture, Bitmap NewBackGround, int i, string NewShip, Map map)
            : this()

        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint, true);

            UpdateStyles();

            Location = new Point(X, Y);

            label1.Text = Text;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Picture;

            BackGround = NewBackGround;
            NumberSystem = i;
            this.NewShip = NewShip;
            Map = map;
        }

        //Переход в новую систему.
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Проверки различного рода ограничений.
            if (Map.MainWindow.NowSystem == (SystemInGame)NumberSystem)
                MessageBox.Show("Корабль уже тут");
            else if (Map.MainWindow.MainHero.InBattle)
            {
                MessageBox.Show("Корабль игрока сейчас в бою. Полёт в другую систему невозможен");
            }
            else
            {
                //Смена фона.
                Map.MainWindow.BackgroundImage = (new Bitmap(BackGround, new Size(Map.MainWindow.Width, Map.MainWindow.Height)));
                //Изменение текущей системы.
                Map.MainWindow.NowSystem = (SystemInGame)NumberSystem;

                //Новый текст в инвентаре врага => его новый облик, параметры и т.д.
                MainWindow.Enemy.Inventar.comboBox1.Text = NewShip;

                //Главный герой на дефолтную позицию.
                Map.MainWindow.MainHero.NewXY(0, 768 / 2);

                //Закрытие карты и остановка времени игры.
                Map.Close();
                MainWindow.GameGoing = false;
            }
        }
    }
}