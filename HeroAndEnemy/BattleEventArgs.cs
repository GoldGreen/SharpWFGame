using System;

namespace GameNewEra
{
    public class BattleEventArgs : EventArgs
    {
        public IBattle WhoGetDamaged;
        public IBattle WhoDamaged;

        /// <summary>
        /// Два объекта IBattle для события
        /// </summary>
        /// <param name="Кто наносит урон"></param>
        /// <param name="Кто получает урон"></param>
        public BattleEventArgs(IBattle WhoDamaged, IBattle WhoGetDamaged)
        {
            this.WhoDamaged = WhoDamaged;
            this.WhoGetDamaged = WhoGetDamaged;
        }
    }
}