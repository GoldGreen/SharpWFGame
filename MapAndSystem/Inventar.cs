using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameNewEra
{
    public partial class Inventar : Form
    {
        //Объект с параметрами, нужными для инвентаря.
        private IBattle Object;

        private MainWindow MainWindow;

        public Dictionary<string, System.Drawing.Bitmap[]> PictureType { get; private set; }

        public Inventar()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Inventar(string Text, MainWindow mainWindow, IBattle Object)
            : this()
        {
            label1.Text = Text;
            this.Object = Object;

            PictureType = new Dictionary<string, System.Drawing.Bitmap[]>();
            comboBox1.Enabled = false;
            MainWindow = mainWindow;
        }

        //Добавление нового корпуса в инвентарь объекта.
        public void AddToCorpus(string NameOfCorpus, System.Drawing.Bitmap[] Pictures, double[] ParametrsArmorDamageRange)
        {
            //Если найден такой корпус, то предыдущая версия стирается.
            if (comboBox1.Items.Contains(NameOfCorpus))
            {
                comboBox1.Items.Remove(NameOfCorpus);
                PictureType.Remove(NameOfCorpus);
            }

            //Добавление строки в combobox инвентаря.
            comboBox1.Items.Add(NameOfCorpus);

            //Добавление в словарь инвентаря.
            PictureType.Add(NameOfCorpus, Pictures);

            //Добавление в словарь объекта IBattle.
            Object.AddTypeADR(NameOfCorpus, ParametrsArmorDamageRange);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Focus();

            //Картинка инвентаря первый элемент нового корабля объекта.
            pictureBox1.Image = PictureType[comboBox1.Text][0];

            (Object as ObjectWithAnimation).ChangeAllPicture(PictureType[comboBox1.Text]);

            //Получение новых параметров у объекта.
            Object.GetNewBody(comboBox1.Text);

            //Запись параметров объекта в инвентарь.
            label5.Text = Object.Damage.ToString();
            label6.Text = Object.Armor.ToString();
            label7.Text = Object.RangeAttack.ToString();

            //Финальная система.
            if (comboBox1.Text == "Boss" && Object is Enemy)
            {
                MainWindow.Enemy.NewWH(3);

                MainWindow.progressBar2.Hide();
                MainWindow.progressBar3.Show();

                (Object as Enemy).ChangeHpVisual = Hp => MainWindow.progressBar3.Value = (int)Hp;
            }
        }

        private void Inventar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                Close();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                Close();
        }

        private void button1_Click(object sender, EventArgs e) => Close();
    }
}