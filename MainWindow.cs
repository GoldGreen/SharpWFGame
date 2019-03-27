using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameNewEra
{
    internal delegate void Battle(object sender, BattleEventArgs e);

    public partial class MainWindow : Form
    {
        //Текущая система героя.
        public SystemInGame NowSystem;

        //Та система, в которой враг будет.
        public SystemInGame NextSystem;

        //Карта- буква M.
        public Map Map;

        //Флаг для перемещения главного героя по нажатию правой кнопки.
        private bool FlagRightClick = false;

        //Флаг для того, чтобы картинка курсора исчезла, когда герой долетит до точки.
        private bool CursorMove = false;

        //Флаг того что игра идёт.
        public static bool GameGoing;

        //Событие битвы.
        private event EventHandler<BattleEventArgs> Damaged;

        /// <summary>
        /// Главный герой
        /// </summary>
        public MainHero MainHero;

        /// <summary>
        /// Враг
        /// </summary>
        public static Enemy Enemy;

        /// <summary>
        /// Упрощенное рисование.
        /// </summary>
        /// <param name="ObjectGraphic"> Объект рисования (e.Drawing)</param>
        /// <param name="Example"> Объект, класс которого наследуется от MainObject </param>
        public static void Draw(Graphics ObjectGraphic, MainObject Example)
        {
            ObjectGraphic.DrawImage(Example.Picture, Example.RegionObject);
        }

        //Получение позиции курсора.
        public Point GetCursorPosition() => PointToClient(Cursor.Position);

        //Массивы картинок Врага.
        public static Bitmap[] SpaceEnemy = new Bitmap[8]
        {
            HeroEnemyPict.SpaceBlue0,
            HeroEnemyPict.SpaceBlue45,
            HeroEnemyPict.SpaceBlue90,
            HeroEnemyPict.SpaceBlue135,
            HeroEnemyPict.SpaceBlue180,
            HeroEnemyPict.SpaceBlue225,
            HeroEnemyPict.SpaceBlue270,
            HeroEnemyPict.SpaceBlue315
        };

        public static Bitmap[] SpaceEnemy2 = new Bitmap[8]
        {
            HeroEnemyPict.SpacePurple0,
            HeroEnemyPict.SpacePurple45,
            HeroEnemyPict.SpacePurple90,
            HeroEnemyPict.SpacePurple135,
            HeroEnemyPict.SpacePurple180,
            HeroEnemyPict.SpacePurple225,
            HeroEnemyPict.SpacePurple270,
            HeroEnemyPict.SpacePurple315
        };

        public static Bitmap[] Boss = new Bitmap[8]
        {
            HeroEnemyPict.Boss0,
            HeroEnemyPict.Boss45,
            HeroEnemyPict.Boss90,
            HeroEnemyPict.Boss135,
            HeroEnemyPict.Boss180,
            HeroEnemyPict.Boss225,
            HeroEnemyPict.Boss270,
            HeroEnemyPict.Boss315
        };

        //Массивы картинок главного героя.
        public static Bitmap[] SpaceMainHero1 = new Bitmap[8]
        {
            HeroEnemyPict.Space0,
            HeroEnemyPict.Space45,
            HeroEnemyPict.Space90,
            HeroEnemyPict.Space135,
            HeroEnemyPict.Space180,
            HeroEnemyPict.Space225,
            HeroEnemyPict.Space270,
            HeroEnemyPict.Space315
        };

        public static Bitmap[] SpaceMainHero2 = new Bitmap[8]
       {
            HeroEnemyPict.SpaceBig0,
            HeroEnemyPict.SpaceBig45,
            HeroEnemyPict.SpaceBig90,
            HeroEnemyPict.SpaceBig135,
            HeroEnemyPict.SpaceBig180,
            HeroEnemyPict.SpaceBig225,
            HeroEnemyPict.SpaceBig270,
            HeroEnemyPict.SpaceBig315
       };

        public static Bitmap[] SpaceMainHero3 = new Bitmap[8]
       {
            HeroEnemyPict.SpaceOrange0,
            HeroEnemyPict.SpaceOrange45,
            HeroEnemyPict.SpaceOrange90,
            HeroEnemyPict.SpaceOrange135,
            HeroEnemyPict.SpaceOrange180,
            HeroEnemyPict.SpaceOrange225,
            HeroEnemyPict.SpaceOrange270,
            HeroEnemyPict.SpaceOrange315
       };

        //Лист систем для добавления системы, добавить сюда новую систему
        //и добавить обработчик врага для новой системы.
        private List<object[]> Systems = new List<object[]>
        {
            new object[] { 300, 300, "Система 2", VisualNature.RedStar, VisualNature.RedSystem },
            new object[] { 400, 350, "Система 3", VisualNature.RedStar, VisualNature.BlueSystem },
        };

        public MainWindow()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            UpdateStyles();

            InitializeComponent();

            InitializationGameObjects();
        }

        private void InitializationGameObjects()
        {
            //Время в игре остановлено
            GameGoing = false;

            //Сообщение о том что время остановлено и Визуальные HP объектов скрыты.
            label1.Show();
            progressBar1.Hide();
            progressBar2.Hide();

            BackgroundImage = new Bitmap(VisualNature.BackGround1, new Size(Width, Height));

            //Инициализация главного героя.
            MainHero = new MainHero(SpaceMainHero1, 100, 100, 100, 34, 310, 0.60,
                Hp => progressBar1.Value = (int)Hp, new Pen(Color.DarkRed, 5), this);

            //Инициализация врага.
            Enemy = new Enemy(SpaceEnemy, 100, 100, 100, 47, 268, 0.70,
                Hp => progressBar2.Value = (int)Hp, new Pen(Color.DarkOrange, 6), this, 900, 900);

            //Обработчик события своего.
            Damaged += SomeOneDamageSomeOne;

            MessageBox.Show("Нажатие на правую кнопку мыши заставит корабль перемещаться в позицию курсора, левый клик на корабль даст информацию о корабле, пробел останавливает время, M карта(С первого раза все может не получиться, но дальше интереснее)");

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //Тут происходит добавление новых корпусов в инвентарь главного героя, ничего делать больше не нужно
            MainHero.Inventar.AddToCorpus("WhiteCorpus", SpaceMainHero2, new double[] { 0.70, 47, 277 });
            MainHero.Inventar.AddToCorpus("OrangeCorpus", SpaceMainHero3, new double[] { 0.57, 60, 270 });

            //Тут происходит добавление новых корпусов в инвентарь врага,
            //Количество корпусов врага должно быть равно количеству систем.
            Enemy.Inventar.AddToCorpus("PurpleCorpus", SpaceEnemy2, new double[] { 0.75, 70, 245 });
            Enemy.Inventar.AddToCorpus("Boss", Boss, new double[] { 0.90, 120, 235 });

            //Прогрессбар главного босса.
            progressBar3.Hide();

            //Изменение текста для того, чтобы корпуса стали стандартными.
            MainHero.Inventar.comboBox1.Text = "Standart";
            Enemy.Inventar.comboBox1.Text = "Standart";

            //Иницаиализация карты.
            Map = new Map(this);
        }

        //Ничего кроме рисование и изменения флагов.
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            //Если курсор рядом с героем - курсор пропадёт.
            if (MainHero.InRange(pictureBox1.Location.X + 15, pictureBox1.Location.Y + 15, 20))
            {
                CursorMove = false;
                pictureBox1.Visible = false;
            }
            else if (CursorMove && !MainHero.InRange(pictureBox1.Location.X + 15, pictureBox1.Location.Y + 15, 10))
            {
                pictureBox1.Visible = true;
            }

            //Отрисовка главного героя.
            Draw(e.Graphics, MainHero);
            //Отрисовка врага.
            Draw(e.Graphics, Enemy);

            //Если объект попадает в рендж и перезарядка равна нулю, то идёт отрисовка линий.
            if (Enemy.FlagAnimation && Enemy.Reload != 0 && NowSystem == NextSystem)
            {
                e.Graphics.DrawLine(Enemy.Weapon, MainHero.X + 10, MainHero.Y + 10, Enemy.X + 10, Enemy.Y + 10);
            }

            // +-10, чтобы линии не сливались.

            if (MainHero.FlagAnimation && MainHero.Reload != 0)
            {
                e.Graphics.DrawLine(MainHero.Weapon, MainHero.X - 10, MainHero.Y - 10, Enemy.X - 10, Enemy.Y - 10);
            }
        }

        //отвечает только за обновление экрана и обновление координат.
        private void MainRefresh_Tick(object sender, EventArgs e)
        {
            //Если нажата правая кнопка идёт отрисовка курсора.
            if (FlagRightClick)
            {
                CursorMove = true;
                FlagRightClick = false;

                pictureBox1.Location = new Point(GetCursorPosition().X - 15, GetCursorPosition().Y - 15);
            }

            //Если время в игре не остановлено.
            if (GameGoing)
            {
                //Изменение координат героя относительно координат курсора
                //в момент нажатия правой кнопки мыши.
                MainHero.TakeDirection(pictureBox1.Location, 5, 2, 2, 3);

                //Изменение координат врага относительно координат героя.
                MainHero.Animation(MainHero.PositionObject);

                if (NowSystem == NextSystem)
                {
                    Enemy.TakeDirection(MainHero.X, MainHero.Y, 5, 1, 1, 2);
                    Enemy.Animation(Enemy.PositionObject);
                }
            }

            //Визуальное Hp т.е прогресс бары следую за героями.
            progressBar1.Location = new Point(MainHero.X - 38, MainHero.Y - 65);
            progressBar2.Location = new Point(Enemy.X - 38, Enemy.Y - 65);

            Refresh();
        }

        //Вся боевая система происходит в этом таймере.
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GameGoing)
            {
                if (MainHero.InRange(Enemy, MainHero.RangeAttack) && MainHero.Reload == 0)
                {
                    MainHero.InBattle = true;
                    MainHero.FlagAnimation = true;

                    //Вызывается событие битвы.
                    Damaged(sender, new BattleEventArgs(MainHero, Enemy));
                    MainHero.SetReload(2);
                }

                if (MainHero.Reload > 0)
                {
                    MainHero.ReloadTime();
                }

                if (Enemy.InRange(MainHero, Enemy.RangeAttack) && Enemy.Reload == 0)
                {
                    MainHero.InBattle = true;
                    Enemy.FlagAnimation = true;

                    //Вызывается событие битвы.
                    Damaged(sender, new BattleEventArgs(Enemy, MainHero));
                    Enemy.SetReload(3);
                }

                if (Enemy.Reload > 0)
                {
                    Enemy.ReloadTime();
                }
            }
        }

        private int i = 0;

        //Для второй и третьей системы,
        //при добавлении корпуса врага, тут тоже надо добавить элемент.
        private string[] Enemys = new string[] { "PurpleCorpus", "Boss" };

        //Сообытие боя.
        private void SomeOneDamageSomeOne(object sender, BattleEventArgs e)
        {
            e.WhoDamaged.Attack(e.WhoGetDamaged);
            //Изменение Hp после получения урона в прогрессбаре
            e.WhoGetDamaged.ChangeHpVisual(e.WhoGetDamaged.Hp);

            //Изменение Hp после получения урона в инвентаре
            e.WhoGetDamaged.Inventar.label8.Text = $"{e.WhoGetDamaged.Hp} Hp";

            if (!MainHero.Life && GameGoing)
            {
                GameGoing = false;
                MessageBox.Show("Игра закончена Плохо");
                Close();
            }
            if (!Enemy.Life && Enemy.Inventar.comboBox1.Text == "Boss")
            {
                GameGoing = false;
                MessageBox.Show("Игра закончена хорошо, Я сам не смог ее пройти с такими параметрами");
                Close();
            }
            if (!Enemy.Life)
            {
                //После убийства врага впервой системе, у героя откроются новые корабли.
                MainHero.OpenNewShips();

                //Флаги изменятся.
                Enemy.Life = true;
                Enemy.FlagAnimation = false;
                MainHero.InBattle = false;

                //Враг отправится далеко.
                Enemy.NewXY(1000, 1000);

                //Восстановление Hp обоим персонажам.
                Enemy.RegenHp();
                MainHero.RegenHp();

                //Изменение Hp в инвентарях.
                MainHero.Inventar.label8.Text = $"{MainHero.Hp} Hp";
                Enemy.Inventar.label8.Text = $"{Enemy.Hp} Hp";

                //Добавление новой системы на карту.
                Map.AddNewSystem(Systems[i], Enemys[i]);

                if (i + 1 < Systems.Count())
                    i++;
            }
        }

        private void MainWindow_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FlagRightClick = true;
            }

            if (e.Button == MouseButtons.Left && MainHero.InRange(new Point(GetCursorPosition().X, GetCursorPosition().Y), 30))
            {
                progressBar1.Hide();
                progressBar2.Hide();
                label1.Show();
                GameGoing = false;
                //Открытие инвентаря главного героя.
                MainHero.Inventar.ShowDialog();
            }

            if (e.Button == MouseButtons.Left && Enemy.InRange(new Point(GetCursorPosition().X, GetCursorPosition().Y), 30))
            {
                progressBar1.Hide();
                progressBar2.Hide();
                label1.Show();
                GameGoing = false;
                //Открытие инвентаря врага.
                Enemy.Inventar.ShowDialog();
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                //Изменение того идёт время или нет.
                GameGoing = !GameGoing;

                if (GameGoing)
                {
                    label1.Hide();
                    progressBar1.Show();

                    if (Enemy.Inventar.comboBox1.Text != "Boss")
                    {
                        progressBar2.Show();
                    }
                }
                else
                {
                    label1.Show();
                    progressBar1.Hide();
                    progressBar2.Hide();
                }
            }

            if (e.KeyCode == Keys.M)//Открытие карты.
            {
                GameGoing = false;

                label1.Show();
                progressBar1.Hide();
                progressBar2.Hide();

                Map.ShowDialog();
            }
        }
    }
}