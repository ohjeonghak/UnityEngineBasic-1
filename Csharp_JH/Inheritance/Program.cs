using System.Threading;
using System.Xml.Serialization;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.hp = 10;
            HpBar knightHpBar = new HpBar();
            IDamageable damageable = knight;
            knight.onHpChanged += knightHpBar.Refresh;
            knight.onHpChanged += knightHpBar.Refresh;
            knight.onHpChanged += knightHpBar.Refresh;
            knight.onHpChanged += knightHpBar.Refresh;
            //knight.onHpChanged = knightHpBar.Refresh;
            
            // 람다식표현의 예
            knight.onHpChanged += (value) =>
            {
                Console.WriteLine(value);
            };
            // 익명함수
            // (value) =>
            //    {
            //        Console.WriteLine(value);
            //    };
            // 람다식 표현
            // 컴파일러가 알아서 유추할 수 있는 내용을 모두 지운뒤. => 이 기호로 람다식이라는 명시만 해주면 된다.
            while (true)
            {
                knight.hp -= 1;
                Thread.Sleep(100);
            }



            //Creature creature1 = new Creature(); //추상클래스는 인스턴스화 불가능
            //creature1.Breath();

            NPC npc1 = new NPC();
            npc1.Breath();
            npc1.Interaction();

            // 공변성 : 하위타입을 기반타입으로 참조할 수 있는 성질
            Creature creature2 = new NPC();
            // NPC npc2 = new Creature(); 
            // 인스턴스 멤버함수 호출시 caller(this) 에 인스턴스 참조를 넘겨주는데, 기반 타임 객체를 넘겨주면 할당되지 않는 멤버에 접근하게되므로 불가능
            creature2.Breath();
            
            // is  : 왼쪽 객체가 오른쪽 타입으로 캐스팅이 가능하다면 true. 아니면 false 를 반환하는 키워드
            if (creature2 is NPC)
            {
                ((NPC)creature2).Interaction();
            }

            // as : 왼쪽 객체를 오른쪽 타입으로 캐스팅 시도하고 성공하면 캐스팅된 타입창조반환, 실패시 null 반환
            NPC tmpNPC = creature2 as NPC;
            if (tmpNPC != null)
            {
                tmpNPC.Interaction();
            }

            // creature2.Interaction(); // 객체가  어떤 멤버들을 가지고 있던지, 참조변수타입에 따라서만 멤버접근이 가능 

            //npc2.Interaction();
            Character[] charcacters = { new Knight(), new Magician(), new SwordMan() };
            for (int i = 0; i < charcacters.Length; i++)
            {
                charcacters[i].UniqueSkill();

                if (charcacters[i] is Knight)
                    Console.WriteLine("기사 발견");
            }


        }
        public void Test()
        {
            PrintSomething(3);
            PrintSomething<double>(3);
        }

        public void PrintSomething(int value)
        {
            Console.WriteLine(value);
        }
        public void PrintSomething(float value)
        {
            Console.WriteLine(value);
        }
        public void PrintSomething(string value)
        {
            Console.WriteLine(value);
        }
        public void PrintSomething(int value1, string value2)
        {
            Console.WriteLine(value1 + value2);
        }

        public void PrintSomething<T>(T value)
        {
            Console.WriteLine(value);
        }
    }
}