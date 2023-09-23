using System;
namespace Lab3QueryBuilder
{
	public class Pokemon : IClassModel
	{
		public int Id { get; set; }
		public int DexNumber { get; set; }
		public string Name { get; set; }
		public string Form { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }



        public Pokemon()  //default constructor
		{
		
		}

        public Pokemon(int id, int dexnum, string name, string form, string type1, string type2, int total, int hp, int attack, int defense, int specialattack, int specialdefense, int speed, int generation)
        {
            Id = id;
            DexNumber = dexnum;
            Name = name;
            Form = form;
            Type1 = type1;
            Type2 = type2;
            Total = total;
            HP = hp;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialattack;
            SpecialDefense = specialdefense;
            Speed = speed;
            Generation = generation;


        }


	}
}

