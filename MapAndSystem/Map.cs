using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameNewEra
{
    public enum SystemInGame
    {
        first,
        second,
        last
    }

    // Тип систем.

    public partial class Map : Form
    {
        //Номер системы (Новый USerControl).
        private int i = 0;

        //Ссылка на гланвую форму.
        public MainWindow MainWindow;

        public Map()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint, true);
            UpdateStyles();
            InitializeComponent();
        }

        public Map(MainWindow mainWindow, string NewShip = "Standart")

            : this()
        {
            MainWindow = mainWindow;

            //При создании объекта карты, добавляется единственная текущая система.
            Controls.Add(new LocationShip(200, 200, "Звезда 1", VisualNature.RedStar, VisualNature.BackGround1, i++, NewShip, this));
        }

        //Добавление новой системы с параметрами на карту.
        public void AddNewSystem(object[] ItemsNewSystem, string NewShip)
        {
            try
            {
                Controls.Add(new LocationShip((int)ItemsNewSystem[0], (int)ItemsNewSystem[1], (string)ItemsNewSystem[2], (Bitmap)ItemsNewSystem[3], (Bitmap)ItemsNewSystem[4], i, NewShip, this));
                MainWindow.NextSystem = (SystemInGame)i++;
            }
            catch
            {
                throw new ArgumentException("Не правильный тип параметров");
            }
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
                Close();
        }
    }
}