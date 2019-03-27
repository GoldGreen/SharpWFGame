namespace GameNewEra
{
    public delegate void GetHp(double HitPoint);

    //Делегат изменения хп в главной форме

    public interface IBattle
    {
        //Параметры боевой части.
        double Hp { get; }

        int Damage { get; }
        double Armor { get; }
        int RangeAttack { get; }

        //Стандарные операции с перезарядкой.
        int Reload { get; }

        void SetReload(int Reload);

        void ReloadTime();

        //Боевая система.
        void TakeDamage(int CountDamage);

        void Attack(IBattle Aim);

        GetHp ChangeHpVisual { get; }

        Inventar Inventar { get; }

        //Получить новые параметры.
        void GetNewBody(string Type);

        void RegenHp();

        //Добавлени в словарь.
        void AddTypeADR(string Type, double[] ParametrsArmorDamageRange);
    }
}