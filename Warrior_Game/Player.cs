using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warrior_Game
{
    public class Player : Characters
    {
        private string _name;

        public Player(string nm) : base(200, 0)
        {
            _name = nm;
            SetDamage(RandomDamage());
        }

        

        public override void Heal(int index)
        {
            int index_1 = new Random().Next(10, 15);
            int index_2 = new Random().Next(35, 40);
            int index_3 = new Random().Next(75, 80);
            if (index == index_1 || index == index_2 || index == index_3)
            {
                int heal_point = new Random().Next(30, 50);

                if (_hp + heal_point > 200) _hp = 200;
                else _hp += heal_point;
                Console.WriteLine($"Hero Healed on position - {index - 1}\nHero healed by {heal_point} HP\nCurrent Hero HP - {_hp}\n");
            }

        }
        public override int RandomDamage()
        {
            return new Random().Next(30, 80);
        }

        public override bool CanAttack(int enemy_position)
        {
            if (enemy_position == GetPosition() + 1) return true;
            return false;
        }

        public override string Name()
        {
            return _name;
        }

        public override void CanTakeDamage(int enemy_damage)
        {
            _hp -= enemy_damage;
        }
    }
}
