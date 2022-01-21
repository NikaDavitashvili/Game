using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warrior_Game
{
    public abstract class Characters
    {
        protected int _hp;
        protected int _damage;
        protected int _positionIndex;

        public Characters(int hp, int position)
        {
            _hp = hp;
            _positionIndex = position;
        }

        public int GetHP()
        {
            return _hp;
        }
        public void Move()
        {
            _positionIndex++;
        }

        protected void SetDamage(int damage)
        {
            _damage = damage;
        }
        public int GetPosition()
        {
            return _positionIndex;
        }

        public abstract string Name();
        public abstract void Heal(int index);
        public abstract int RandomDamage();

        public abstract bool CanAttack(int enemy_index);

        public abstract void CanTakeDamage(int enemy_damage);

    }
}
