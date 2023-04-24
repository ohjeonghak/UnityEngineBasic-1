//                 0      1     2     3     4     5     6     7     8     9
string[] deck = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", 
                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
for (int i = 0; i < deck.Length; i++)
{
    Console.Write(deck[i]+" ");
}
Console.WriteLine();

List<int> num = new List<int>();
List<string> word = new List<string>();


//Dictionary - 키와 값 저장
Dictionary<string, int> jokbo = new Dictionary<string, int>()
{
    {"aA", 200}
};



//deck 랜덤 섞기
//string temp;
//for (int i = 0; i < deck.Length; i++)
//{
//    Random rand = new Random();
//    int a = rand.Next(0, deck.Length);
//    temp = deck[i];
//    deck[i] = deck[a];
//    deck[a] = temp;
//}

for (int i = 0; i < deck.Length; i++)
{
    Console.Write(deck[i]+" ");
}

//player 4명 - 카드 2장씩 가짐

List<string> player0 = new List<string>();
List<string> computer1 = new List<string>();

player0.Add(deck[0]);
player0.Add(deck[1]);

player0.Sort();

Console.WriteLine(player0[0]);
Console.WriteLine(player0[1]);

computer1.Add(deck[6]);
computer1.Add(deck[18]);





