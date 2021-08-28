using System;
using System.Collections.Generic;

namespace Day21
{
    class Fighter
    {
        public int Hp;
        public int Armor;
        public int Damage;
        public int GoldSpent;
        
        public Fighter(int hp, int armor, int damage)
        {
            this.Hp = hp;
            this.Armor = armor;
            this.Damage = damage;
            this.GoldSpent = 0;
        }

        public void Buy(Shop shop, int wep, int arm, int ri1, int ri2)
        {
            this.Damage = 
                shop.Weapons[wep].Damage + 
                shop.Rings[ri1].Damage + 
                shop.Rings[ri2].Damage;
            this.Armor = 
                shop.Armor[arm].Armor + 
                shop.Rings[ri1].Armor + 
                shop.Rings[ri2].Armor;
            this.GoldSpent = 
                shop.Weapons[wep].Cost +
                shop.Armor[arm].Cost + 
                shop.Rings[ri1].Cost + 
                shop.Rings[ri2].Cost;
        }

        public string Fight(Fighter boss)
        {
            while (this.Hp > 0 && boss.Hp > 0)
            {
                HitEachother(this, boss);
            }

            if (this.Hp > 0)
            {
                return "win";
            }
            else
            {
                return "loss";
            }
        }
        private void HitEachother(Fighter player, Fighter boss)
        {
            if (player.Damage > boss.Armor)
            {
                boss.Hp -= (player.Damage - boss.Armor);
                //Console.WriteLine($"The player deals {player.Damage} damage; the boss goes down to {boss.Hp} hit points");
            }
            else
            {
                boss.Hp--;
                //Console.WriteLine($"The player deals 1 damage; the boss goes down to {boss.Hp} hit points");
            }
            if (boss.Hp > 0)
            {
                if (boss.Damage > player.Armor)
                {
                    player.Hp -= (boss.Damage - player.Armor);
                    //Console.WriteLine($"The boss deals {boss.Damage} damage; the player goes down to {player.Hp} hit points");
                }
                else
                {
                    player.Hp--;
                    //Console.WriteLine($"The boss deals 1 damage; the player goes down to {player.Hp} hit points");
                }
            }
        }
    }

    struct Item
    {
        public int Cost;
        public int Damage;
        public int Armor;

        public Item(int cost, int damage, int armor)
        {
            this.Cost = cost;
            this.Damage = damage;
            this.Armor = armor;
        }
    }
    class Shop
    {
        public List<Item> Weapons;
        public List<Item> Armor; 
        public List<Item> Rings;

        public Shop()
        {
            this.Weapons = new List<Item>();
            this.Armor = new List<Item>();
            this.Rings = new List<Item>();

            Item empty = new Item(0, 0, 0);
            Weapons.Add(empty);
            Armor.Add(empty);
            Rings.Add(empty);
        }

        public void FillItemsRPGsim20XX()
        {
            Item Dagger = new Item(8, 4, 0);
            Item Shortsword = new Item(10, 5, 0);
            Item Warhammer = new Item(25, 6, 0);
            Item Longsword = new Item(40, 7, 0);
            Item Greataxe = new Item(74, 8, 0);
            Weapons.Add(Dagger);
            Weapons.Add(Shortsword);
            Weapons.Add(Warhammer);
            Weapons.Add(Longsword);
            Weapons.Add(Greataxe);

            Item Leather = new Item(13, 0, 1);
            Item Chainmail = new Item(31, 0, 2);
            Item Splintmail = new Item(53, 0, 3);
            Item Bandedmail = new Item(75, 0, 4);
            Item Platemail = new Item(102, 0, 5);
            Armor.Add(Leather);
            Armor.Add(Chainmail);
            Armor.Add(Splintmail);
            Armor.Add(Bandedmail);
            Armor.Add(Platemail);

            Item Damage1 = new Item(25, 1, 0);
            Item Damage2 = new Item(50, 2, 0);
            Item Damage3 = new Item(100, 3, 0);
            Item Defense1 = new Item(20, 0, 1);
            Item Defense2 = new Item(40, 0, 2);
            Item Defense3 = new Item(80, 0, 3);
            Rings.Add(Damage1);
            Rings.Add(Damage2);
            Rings.Add(Damage3);
            Rings.Add(Defense1);
            Rings.Add(Defense2);
            Rings.Add(Defense3);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.FillItemsRPGsim20XX();

            int[] sList = new int[4];
            List<int[]> shoppingLists = new List<int[]>();
            Combinations(sList, 0, 1, shoppingLists);
            int leastGoldSpentWin = int.MaxValue;
            int maxGoldSpentLose = 0;
            foreach (int[] list in shoppingLists)
            {
                Fighter boss = new Fighter(104, 1, 8);
                Fighter player = new Fighter(100, 0, 1);
                player.Buy(shop, list[0], list[1], list[2], list[3]);
                if (player.Fight(boss) == "win" && player.GoldSpent < leastGoldSpentWin)
                {
                    leastGoldSpentWin = player.GoldSpent;
                }
                if (player.Fight(boss) == "loss" && player.GoldSpent > maxGoldSpentLose)
                {
                    maxGoldSpentLose = player.GoldSpent;
                }
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(leastGoldSpentWin);
            Console.WriteLine("Part 2:");
            Console.WriteLine(maxGoldSpentLose);
        }
        static void Combinations(int[] nums, int index, int start, List<int[]> combs)
        {
            for (int i = start; i < 6; i++)
            {
                if (index == 3 && i != 0 && i == nums[2] )
                {
                    return;
                }
                nums[index] = i;

                int[] newNums = new int[nums.Length];
                for (int j = 0; j < 4; j++)
                {
                    newNums[j] = nums[j];
                }
                if (index != nums.Length - 1)
                {
                    Combinations(newNums, index + 1, 0, combs);
                }
                else
                {
                    combs.Add(newNums);
                }
            }
        }
    } 
}