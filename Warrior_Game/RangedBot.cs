using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warrior_Game
{
    class RangedBot : Characters
    {
        private string _name;

        public RangedBot(string nm, int index) : base(80, index)
        {
            _name = nm;
            SetDamage(RandomDamage());
        }
        public override int RandomDamage()
        {
            return new Random().Next(10, 20);
        }

        public override bool CanAttack(int hero_index)
        {
            if (hero_index == GetPosition() - 3 || hero_index == GetPosition() - 2 || hero_index == GetPosition() - 1) return true;
            return false;
        }

        public override string Name()
        {
            return _name;
        }

        public override void Heal(int index)
        {
            throw new NotImplementedException();
        }

        public override void CanTakeDamage(int hero_damage)
        {
            _hp -= hero_damage;
        }
    }
}
