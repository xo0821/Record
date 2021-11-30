using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace Record
{
    //挑戰看看能疊加多少東西，不考慮最優寫法跟分配
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.story(new  NDC_Hero(){Name = "NDC_SSS"},new OaO_monster(){Name = "OoaoO"});
            Console.ReadLine();
        }
    }

    class  Book
    {
        public void story<THreo,Tmonster>(THreo hreo,Tmonster monster)
        where THreo:Iher
        where Tmonster:IMonster
        {
            Console.WriteLine(monster.Name+" kill "+hreo.Name);
        }
    }
    interface Ibiology
    {
    }
    class NDC_preson:Ibiology
    {
        public string Name { get; set; }
        private static List<NDC_preson> people;
        private static NDC_Hero _ndcHero;
        public NDC_preson()
        {
            people.Add(this);
        }

        void ChangeHero()
        {
            people.Remove(this);
            _ndcHero = new NDC_Hero() {Name = people[0].Name};
        }

    }
    class NDC_Hero:Iher
    {
        public string Name { get; set; }
    }
    class OaO_monster:IMonster
    {
        public string Name { get; set; }
    }
    interface Iher:Ibiology
    {
        public string Name { get; set; } 
    }
    interface IMonster
    {
        public string Name { get; set; }
    }
}