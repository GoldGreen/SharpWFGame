using System;
using System.Collections.Generic;
using System.Linq;

namespace GameNewEra
{
    public class MainHero : ObjectWithAnimation, IBattle
    {
        //Форма инвентаря.
        public Inventar Inventar { get; set; }

        //Делегат изменения хп в главной форме
        public GetHp ChangeHpVisual { get; }

        //То какой цвет и толщина будет у лазера.
        public System.Drawing.Pen Weapon { get; private set; }

        //Параметры боевой части.
        public double Hp { get; private set; }

        public double Armor { get; private set; }
        public int Damage { get; private set; }
        public int RangeAttack { get; private set; }

        //В зависимости от строки в combobox в инвентаре объекта
        //боевые параметры объекта будут изменятся.
        public Dictionary<string, double[]> TypeOfCorpus { get; private set; }

        //Обычная перезарядка.
        public int Reload { get; private set; } = 0;

        //Флаги для главной формы.
        public bool FlagAnimation = true;

        public bool Life = true;
        public bool InBattle = false;

        public MainHero(System.Drawing.Bitmap[] Pictures, int Width, int High, int Hp, int Damage, int RangeAttack, double Armor, GetHp ChangeHpVisual, System.Drawing.Pen Weapon, MainWindow mainWindow, int X = 0, int Y = 0)
            : base(Pictures, Width, High, X, Y)
        {
            this.Hp = Hp;
            this.ChangeHpVisual = ChangeHpVisual;
            this.Weapon = Weapon;

            this.Armor = Armor;
            this.Damage = Damage;
            this.RangeAttack = RangeAttack;

            Inventar = new Inventar("Герой", mainWindow, this);
            TypeOfCorpus = new Dictionary<string, double[]>();

            Inventar.AddToCorpus("Standart", Pictures, new double[] { Armor, Damage, RangeAttack });
            Inventar.comboBox1.Text = "Standart";
        }

        //Добавление в словарь имя корпуса - боевые параметры(Функция исаользуется в инвентаре).
        public void AddTypeADR(string Type, double[] ParametrsArmorDamageRange)
        {
            if (ParametrsArmorDamageRange.Length != 3)
                throw new ArgumentOutOfRangeException("Должно быть 3 аргумента");

            if (ParametrsArmorDamageRange[0] < 0.1)
                throw new ArgumentException("Недопустимое значние брони(1 элемент массива)");

            if (TypeOfCorpus.Keys.Contains(Type))
                TypeOfCorpus.Remove(Type);

            TypeOfCorpus.Add(Type, ParametrsArmorDamageRange);
        }

        //получение параметров исходя из строки(ключ словаря).
        public void GetNewBody(string Type)
        {
            Armor = TypeOfCorpus[Type][0];
            Damage = (int)TypeOfCorpus[Type][1];
            RangeAttack = (int)TypeOfCorpus[Type][2];
        }

        //Аттака другого объекта Aim.
        public void Attack(IBattle Aim)
        {
            Aim.TakeDamage(Damage);
        }

        //Получить урон.
        public void TakeDamage(int CountDamage)
        {
            this.Hp -= (1 - Armor) * CountDamage;
            if (this.Hp < 1)
            {
                Hp = 0;
                Life = false;
            }
        }

        //Стандарные операции с перезарядкой.
        public void SetReload(int Reload)
        {
            this.Reload = Reload;
        }

        public void ReloadTime()
        {
            Reload--;
        }

        //После смерти, если это враг, у врага и главного героя Hp восстанавливается.
        public void RegenHp()
        {
            Hp = 100;
            ChangeHpVisual(100);
        }

        //Как только пройден 1 уровень, возможность выбирать новые корабли
        //из combobox  инвентаря становится реальной.
        public void OpenNewShips() => Inventar.comboBox1.Enabled = true;
    }
}