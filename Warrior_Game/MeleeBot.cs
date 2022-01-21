using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warrior_Game
{
    public class MeleeBot : Characters
    {
        private string _name;

        public MeleeBot(string nm, int index) : base(100, index)
        {
            _name = nm;
            SetDamage(RandomDamage());
        }
        public override int RandomDamage()
        {
            return new Random().Next(10, 30);
        }

        public override bool CanAttack(int hero_index)
        {
            if (hero_index == GetPosition() - 1) return true;
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
