using System;
using System.Threading;

namespace Day22
{
    struct Spell
    {
        public int Cost;
        public int Effect;
        public int Duration;

        public Spell(int cost, int effect, int duration)
        {
            this.Cost = cost;
            this.Effect = effect;
            this.Duration = duration;
        }
    }
    class Spellbook
    {
        public Spell MagicMissile;
        public Spell Drain;
        public Spell Shield;
        public Spell Poison;
        public Spell Recharge;

        public Spellbook()
        {
            this.MagicMissile = new Spell(53, 4, 0);
            this.Drain = new Spell(73, 2, 0);
            this.Shield = new Spell(113, 7, 6);
            this.Poison = new Spell(173, 3, 6);
            this.Recharge = new Spell(229, 101, 5);
        }
    }
    struct EffectTimer
    {
        public int Shield;
        public int Poison;
        public int Recharge;

        public EffectTimer(int s, int p, int r)
        {
            this.Shield = s;
            this.Poison = p;
            this.Recharge = r;
        }
    }
    class Fighter
    {
        public int Hp;
        public int Armor;
        public int Damage;
        public int Mana;

        public Fighter(int hp, int armor, int damage, int mana)
        {
            this.Hp = hp;
            this.Armor = armor;
            this.Damage = damage;
            this.Mana = mana;
        }

        public void Fight(Fighter boss)
        {
            Spellbook spells = new Spellbook();
            EffectTimer timer = new EffectTimer(0, 0, 0);
            string result = "";
            Text("start", 0, 0, 0);

            while (result == "")
            {

                Text("player turn", this.Hp, this.Mana, boss.Hp);
                int nextSpell = int.Parse(Console.ReadLine());
                int[] empty = new int[1];
                result = PlayerTurn(boss, spells, nextSpell, empty, timer, out timer, 0);
                if (result != "") { break; }

                Text("sleep", 600, 0, 0);
                Text("boss turn", this.Hp, boss.Hp, 0);
                
                result = BossTurn(boss, spells, timer, out timer);
                Text("sleep", 600, 0, 0);
            }

            Console.WriteLine();
            if (result == "win") 
            {
                Text("win", 0, 0, 0);
            }
            else 
            {
                if (this.Mana <= 0)
                {
                    Text("death mana", 0, 0, 0);
                }
                Text("death", 0, 0, 0); 
            }
        }
        private void Text(string input, int a, int b, int c)
        {
            if (input == "start")
            {
                Console.WriteLine("BIG BOSS FIGHT STARTS"); 
                Thread.Sleep(700); Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Spell book:");
                Console.WriteLine("1 Magic Missile - Deals 4 damage. Cost 53 Mana.");
                Console.WriteLine("2 Drain - Deals 2 damage & Heals 2 Hp. Cost 73 Mana.");
                Console.WriteLine("3 Shield - Activates 7 armor shield for 6 turns. Cost 113 Mana.");
                Console.WriteLine("4 Poison - Deals 3 damage 6 turns. Cost 173 Mana.");
                Console.WriteLine("5 Recharge - Recharges 101 mana 5 turns. Cost 229 Mana.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(700);
            }
            else if (input == "sleep")
            {
                Thread.Sleep(a);
            }

            else if (input == "player turn")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nPLAYER TURN");
                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{a} Hp ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{b} Mana");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Boss ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{c} Hp");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Cast Spell: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input == "boss turn")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\nBOSS TURN");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{a} Hp ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Boss ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{b} Hp");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (input == "melee attack")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"Boss deals {a - b} damage. ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{c} Hp");
            }

            else if (input == "effect shield")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Shield activated. Timer {a}.");
            }
            else if (input == "effect poison")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Poison claims {a} Hp. Timer {b}. ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Boss: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{c} Hp");
            }
            else if (input == "effect recharge")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Recharge gives {a} Mana. Timer {b}. ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Mana: {c}.");
            }

            else if (input == "cast 1")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("You cast Magic Missile. ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("It deals 4 damage. ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Boss ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{a} Hp");
            }
            else if (input == "cast 2")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("You cast Drain. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("It deals & heals 2 damage. ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Boss ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{a} Hp ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{b} Hp");
            }
            else if (input == "cast 3")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("You activate Shield. Player ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{a} Armor");
            }
            else if (input == "cast 4")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("You cast Poison. ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Boss ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("is poisoned");
            }
            else if (input == "cast 5")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("You cast ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Recharge");
            }

            else if (input == "win")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
                Console.WriteLine("Big Boss finally curls up in a ball and dies");
                Thread.Sleep(1500);
                Console.WriteLine("You Win!");
                Thread.Sleep(5000);
            }
            else if (input == "death mana")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
                Console.WriteLine("You're out of mana and can't defend yourself");
                Thread.Sleep(1500);
                Console.WriteLine("Boss makes a stab stab stab move");
            }
            else if (input == "death")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
                Console.WriteLine("You run out of Hp");
                Thread.Sleep(1500);
                Console.WriteLine("Oh dear, you're dead!");
                Thread.Sleep(5000);
            }
        }

        public string PlayerTurn(Fighter boss, Spellbook spells, int nextSpell, int[] manaCost, EffectTimer timerIn, out EffectTimer timer, int difficulty)
        {       
            timer = timerIn;
            this.Hp -= difficulty;
            if (this.Hp <= 0)
            {
                return "loss";
            }
            timer = EffectSpells(boss, spells, timer);
            if (boss.Hp <= 0)
            {
                return "win";
            }

            timer = CastSpell(boss, spells, nextSpell, timer, manaCost);
            if (this.Mana <= 0)
            {
                return "loss";
            }
            if (boss.Hp <= 0)
            {
                return "win";
            }
            return "";
        }  
        public string BossTurn(Fighter boss, Spellbook spells, EffectTimer timerIn, out EffectTimer timer)
        {
            timer = timerIn;
            timer = EffectSpells(boss, spells, timer);
            if (boss.Hp <= 0)
            {
                return "win";
            }

            MeleeAttack(boss, this);
            if (this.Hp <= 0)
            {
                return "loss";
            }
            return "";
        }
        
        private EffectTimer EffectSpells(Fighter boss, Spellbook spells, EffectTimer timer)
        {
            if (timer.Shield > 0)
            {
                timer.Shield--;
                Text("effect shield", timer.Shield, 0, 0);
            }
            else
            {
                this.Armor = 0;
            }
            if (timer.Poison > 0)
            {
                boss.Hp -= spells.Poison.Effect;
                timer.Poison--;
                Text("effect poison", spells.Poison.Effect, timer.Poison, boss.Hp);
                
            }
            if (timer.Recharge > 0)
            {
                this.Mana += spells.Recharge.Effect;
                timer.Recharge--;
                Text("effect recharge", spells.Recharge.Effect, timer.Recharge, this.Mana);
                
            }
            return timer;
        }
        private EffectTimer CastSpell(Fighter boss, Spellbook spells, int nextSpell, EffectTimer timer, int[] manaCost)
        {
            int preMana = this.Mana;
            if (nextSpell == 1)
            {
                boss.Hp -= spells.MagicMissile.Effect;
                this.Mana -= spells.MagicMissile.Cost;
                Text("cast 1", boss.Hp, 0, 0);
            }
            else if (nextSpell == 2)
            {
                boss.Hp -= spells.Drain.Effect;
                this.Hp += spells.Drain.Effect;
                this.Mana -= spells.Drain.Cost;
                Text("cast 2", boss.Hp, this.Hp, 0);
            }
            else if (nextSpell == 3)
            {
                timer.Shield = spells.Shield.Duration;
                this.Armor = spells.Shield.Effect;
                this.Mana -= spells.Shield.Cost;
                Text("cast 3", this.Armor, 0, 0);
            }
            else if (nextSpell == 4)
            {
                timer.Poison = spells.Poison.Duration;
                this.Mana -= spells.Poison.Cost;
                Text("cast 4", 0, 0, 0);
            }
            else if (nextSpell == 5)
            {
                timer.Recharge = spells.Recharge.Duration;
                this.Mana -= spells.Recharge.Cost;
                Text("cast 5", 0, 0, 0);
            }
            manaCost[0] += preMana - this.Mana;
            return timer;
        }
        private void MeleeAttack(Fighter attacker, Fighter target)
        {
            target.Hp -= attacker.Damage - target.Armor;
            Text("melee attack", attacker.Damage, target.Armor, this.Hp);
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // FUN PLAY
            Fighter bigBoss = new Fighter(55, 0, 8, 0);
            Fighter me = new Fighter(50, 0, 0, 500);
            me.Fight(bigBoss);
            return;


            ////
            //// ADVENT OF CODE
            //// Kommentera ut allt i "FightText" i Fighter Classen för att nedan ska funka bra.

            int[] bestNum = new int[1];
            bestNum[0] = int.MaxValue;
            Spellbook spells = new Spellbook();
            EffectTimer counter = new EffectTimer(0, 0, 0);

            int normal = 0;
            for (int i = 1; i < 6; i++)
            {
                int nextSpell = i;
                Fighter boss = new Fighter(55, 0, 8, 0);
                Fighter player = new Fighter(50, 0, 0, 500);
                LeastAmountOfManaWin(player, boss, spells, nextSpell, counter, normal, bestNum, 0);
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(bestNum[0]);

            bestNum[0] = int.MaxValue;
            int hard = 1;
            for (int i = 1; i < 6; i++)
            {
                int nextSpell = i;
                Fighter boss = new Fighter(55, 0, 8, 0);
                Fighter player = new Fighter(50, 0, 0, 500);
                LeastAmountOfManaWin(player, boss, spells, nextSpell, counter, hard, bestNum, 0);
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(bestNum[0]);
        }

        static void LeastAmountOfManaWin(Fighter player, Fighter boss, Spellbook spells, int nextSpell, EffectTimer counter, int difficulty, int[] bestNum, int totMana)
        {
            int[] totManaCost = new int[1]; 
            totManaCost[0] = totMana;
            if (totMana > bestNum[0])
            {
                return;
            }
            string result = player.PlayerTurn(boss, spells, nextSpell, totManaCost, counter, out counter, difficulty);
            if (result == "")
            {
                result = player.BossTurn(boss, spells, counter, out counter);
            }
            if (result == "")
            {
                for (int i = 1; i < 6; i++)
                {  
                    if (counter.Shield > 1 && i == 3 || counter.Poison > 1 && i == 4 || counter.Recharge > 1 && i == 5)
                    {
                        continue;
                    }
                    nextSpell = i;
                    Fighter newPlayer = new Fighter(player.Hp, player.Armor, player.Damage, player.Mana);
                    Fighter newBoss = new Fighter(boss.Hp, boss.Armor, boss.Damage, boss.Mana);
                    EffectTimer newCounter = new EffectTimer(counter.Shield, counter.Poison, counter.Recharge);
                    LeastAmountOfManaWin(newPlayer, newBoss, spells, nextSpell, newCounter, difficulty, bestNum, totManaCost[0]);
                }
            }
            else if (result == "win" && totManaCost[0] < bestNum[0])
            {
                bestNum[0] = totManaCost[0];
            }
        }
    }
}