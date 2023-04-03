using Inheritance;

Knight knight = new Knight(200, 50);
Wizard wizard = new Wizard(150, 70);
Goblin goblin = new Goblin(100, 20);

//공변성(Covariance)
//하위타입을 기반타입으로 참조가 가능한 성질 (기반이 상위에 있는 애) 추상클래스 인터페이스 등에서 성립
Creature[] creatures = new Creature[2];
creatures[0] = knight;
creatures[1] = goblin;

for (int i = 0; i < creatures.Length; i++)
{
    Console.WriteLine(creatures[i].Lv);
}

 
knight.Attack(goblin);

knight.SayHi();
wizard.SayHi();
Character character1 = knight;
Character character2 = wizard;
character1.SayHi();
character2.SayHi();

