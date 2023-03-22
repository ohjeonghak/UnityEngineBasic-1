using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectInstance
{
    internal class Person
    {
        public String Name;
        public int Age;
        public float Height;
        public double Weight;
        public bool IsAvailable;

        public void Introduce()
        {
            Console.WriteLine($"{Name}씨는 나이가 {Age}살, 키가 {Height}, 몸무게가 {Weight}, {IsAvailable}");
            //if(IsAvailable)
            //{
            //    Console.WriteLine("이용가능함");
            //}
            //else
            //{
            //    Console.WriteLine("이용불가능함");
            //}
        }
    }

   
}
