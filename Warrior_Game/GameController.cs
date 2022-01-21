using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Warrior_Game
{
    public class GameController
    {
        private Player hero = new Player("H");
        private MeleeBot melee_1 = new MeleeBot("M", 6);
        private MeleeBot melee_2 = new MeleeBot("M", 28);
        private MeleeBot melee_3 = new MeleeBot("M", 67);
        private RangedBot range_1 = new RangedBot("R", 23);
        private RangedBot range_2 = new RangedBot("R", 48);
        private RangedBot range_3 = new RangedBot("R", 89);
        private List<Characters> lst = new List<Characters>();


        public void ShowGame()
        {
            lst.Add(melee_1);
            lst.Add(range_1);
            lst.Add(melee_2);
            lst.Add(range_2);
            lst.Add(melee_3);
            lst.Add(range_3);

            int map_length = 100;
            int index = 0;

            Console.WriteLine($"\tThe Game Has Started\n\nHero health before fight - {hero.GetHP()}\n");
            for (int i = 2; i <= map_length; i++)
            {
                hero.Move();
                //Thread.Sleep(500);
                hero.Heal(i);
                if (lst[index].GetPosition() == i)
                {
                    Console.WriteLine($"\n      N{index + 1} Fight");
                    Console.WriteLine(new string('_', 20));
                    Console.WriteLine($"\nHero HP - {hero.GetHP()}\nHero Position  - {hero.GetPosition()}");
                    Console.WriteLine($"Enemy Position - {lst[index].GetPosition()}");
                    if (lst[index].Name() == "M") Console.WriteLine("Enemy is Close warrior!\n");
                    else if (lst[index].Name() == "R") Console.WriteLine("Enemy is Range warrior!\n");

                    while (hero.GetHP() > 0 && lst[index].GetHP() > 0)
                    {
                        if (hero.CanAttack(lst[index].GetPosition()))
                        {
                            Console.WriteLine("Hero Can Do Damage!");
                            lst[index].CanTakeDamage(hero.RandomDamage());
                        }
                        if (lst[index].CanAttack(hero.GetPosition()))
                        {
                            Console.WriteLine("Enemy Can Do Damage!");
                            hero.CanTakeDamage(lst[index].RandomDamage());
                        }

                        Console.WriteLine($"\n\nHero Health  - {hero.GetHP()}");
                        Console.WriteLine($"Enemy Health - {lst[index].GetHP()}");
                        if (hero.GetHP() <= 0)
                        {
                            Console.WriteLine("Hero is dead! Game Over!\n\n");
                            Console.WriteLine($"    End Of Game");
                            Console.WriteLine(new string('_', 20) + "\n\n");
                            i = 100;
                        }
                        else if (lst[index].GetHP() <= 0)
                        {
                            Console.WriteLine("Enemy is Dead! Keep Moving!\n");
                            Console.WriteLine($"    Fight's Over");
                            Console.WriteLine(new string('_', 20) + "\n\n");
                        }
                    }

                    if (index == 5) continue;
                    else index++;

                }
                else
                {
                    Console.WriteLine($"Hero keeps moving\nPosition - {hero.GetPosition()}\n");
                    if (lst[index].CanAttack(hero.GetPosition()))
                    {
                        hero.CanTakeDamage(lst[index].RandomDamage());
                        Console.WriteLine($"Ranged Enemy Can Do Damage!\nRanged Enemy Damage - {lst[index].RandomDamage()}\nHero out of range" +
                            $"\nHero Current HP - {hero.GetHP()}\n\n");
                    }
                }

                if (hero.GetPosition() == 99)
                {
                    Console.WriteLine($"\nHero Position - { hero.GetPosition() + 1}\n");
                    Console.WriteLine($"\tEnd Of Game");
                    Console.WriteLine("Congratulation, You have won!");
                    Console.WriteLine(new string('_', 30) + "\n\n");
                }
            }

        }
      
    }
}
