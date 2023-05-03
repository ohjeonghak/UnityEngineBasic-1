//족보 비교해서 없으면 끗수 계산
//끗수 계산해서 비교

//                 0    1    2    3    4    5    6    7    8    9
string[] deck = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", 
                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

//Dictionary - 키와 값 저장
Dictionary<string, int> jokbo = new Dictionary<string, int>()
{
    {"df", 100}, {"dF", 100}, {"Df", 100}, {"DF", 100}, //세륙(4,6)
    {"dj", 110}, {"dJ", 110}, {"Dj", 110}, {"DJ", 110}, //장사(4,10)
    {"aj", 120}, {"aJ", 120}, {"Aj", 120}, {"AJ", 120}, //장삥(1,10)
    {"ai", 130}, {"aI", 130}, {"Ai", 130}, {"AI", 130}, //구삥(1,9)
    {"ad", 140}, {"aD", 140}, {"Ad", 140}, {"AD", 140}, //독사(1,4)
    {"ab", 150}, {"aB", 150}, {"Ab", 150}, {"AB", 150}, //알리(1,2)
    {"aA", 200}, {"bB", 210}, {"cC", 220}, {"dD", 230}, {"eE", 240}, //땡
    {"fF", 250}, {"gG", 260}, {"hH", 270}, {"iI", 280}, {"jJ", 290}, //땡
    {"AC", 350}, {"AH", 350}, //13광땡, 18광땡
    {"CH", 500} //38광땡
};

//deck 랜덤 섞기
//string tempStr;
//for (int i = 0; i < deck.Length; i++)
//{
//    Random rand = new Random();
//    int a = rand.Next(0, deck.Length);
//    tempStr = deck[i];
//    deck[i] = deck[a];
//    deck[a] = tempStr;
//}

//for (int i = 0; i < deck.Length; i++)
//{
//    Console.Write(deck[i]+" ");
//}

//player 4명 - 카드 2장씩 가짐
//2장의 카드 배열 후 족보 체크, 점수를 매겨서 더 높은 쪽이 승리

List<string> player0 = new List<string>();
List<string> computer1 = new List<string>();
List<string> computer2 = new List<string>();
List<string> computer3 = new List<string>();

player0.Add(deck[1]);
player0.Add(deck[5]);

computer1.Add(deck[6]);
computer1.Add(deck[18]);

computer2.Add(deck[15]);
computer2.Add(deck[9]);

computer3.Add(deck[10]);
computer3.Add(deck[3]);

player0.Sort();
computer1.Sort();
computer2.Sort();
computer3.Sort();

Console.WriteLine("player0의 패");
Console.Write(player0[0]);
Console.WriteLine(player0[1]);

Console.WriteLine("computer1의 패");
Console.Write(computer1[0]);
Console.WriteLine(computer1[1]);

Console.WriteLine("computer2의 패");
Console.Write(computer2[0]);
Console.WriteLine(computer2[1]);

Console.WriteLine("computer3의 패");
Console.Write(computer3[0]);
Console.WriteLine(computer3[1]);

string concatPlayer0 = player0[0] + player0[1];
string concatCom1 = computer1[0] + computer1[1];
string concatCom2 = computer2[0] + computer2[1];
string concatCom3 = computer3[0] + computer3[1];

int scorePlayer0;
int scoreCom1;
int scoreCom2;
int scoreCom3;

int[] score = new int[4];

void Play()
{
    int result = -5;

    //플레이어 족보 체크
    if(jokbo.ContainsKey(concatPlayer0))
        scorePlayer0 = jokbo[concatPlayer0];
    else
        scorePlayer0 = AddCardNum(player0);

    //컴퓨터 족보 체크
    if (jokbo.ContainsKey(concatCom1))
        scoreCom1 = jokbo[concatCom1];
    else
        scoreCom1 = AddCardNum(computer1);

    if (jokbo.ContainsKey(concatCom2))
        scoreCom2 = jokbo[concatCom2];
    else
        scoreCom2 = AddCardNum(computer2);

    if (jokbo.ContainsKey(concatCom3))
        scoreCom3 = jokbo[concatCom3];
    else
        scoreCom3 = AddCardNum(computer3);

    score[0] = scorePlayer0;
    score[1] = scoreCom1;
    score[2] = scoreCom2;
    score[3] = scoreCom3;

    //땡잡이 체크
    //for (int i = 0; i < score.Length; i++)
    //{
    //    if (score[i] >= 200 && score[i] <= 290)
    //    {

    //    }
    //}
    if (scorePlayer0>=200 && scorePlayer0 <=290)
    {
        if (concatCom1 == "cG" || concatCom1 == "cg" || concatCom1 == "Cg" || concatCom1 == "CG")
        {
            scoreCom1 += 300;
        }
    }

    //암행어사 체크
    if(scorePlayer0 == 350)
    {
        if(concatCom1 == "dg" || concatCom1 == "dG" || concatCom1 == "Dg" || concatCom1 == "DG")
        {
            scoreCom1 += 400;
        }
    }

    //비교결과 저장
    result = scorePlayer0.CompareTo(computer1);

    switch (result)
    {
        case 1:
            Console.WriteLine("player0의 점수 : "+scorePlayer0);
            Console.WriteLine("computer1의 점수 : "+scoreCom1);
            Console.WriteLine("player0의 승리");
            break;
        case 0:
            Console.WriteLine("player0의 점수 : " + scorePlayer0);
            Console.WriteLine("computer1의 점수 : " + scoreCom1);
            Console.WriteLine("무승부");
            break;
        case -1:
            Console.WriteLine("player0의 점수 : " + scorePlayer0);
            Console.WriteLine("computer1의 점수 : " + scoreCom1);
            Console.WriteLine("computer1의 승리");
            break;
        default:
            break;
    }
}

//끗수 계산
//1+9, 2+8, 3+7, 4+6, 5+5 -> 망통 제일 낮은 점수
//인덱스 더한 수의 일의자리 = 8 이면 망통 (2차이남)
//[0]이랑 같은 애 찾았으면 또 deck이랑 비교할 필요 없음 남은 애만 비교해서 찾으면 됨 - 어케해 => 루프 바깥이랑 안쪽 반대로 썼음
int AddCardNum(List<string> mycard)
{
    int temp = 0;
    for (int i = 0; i < mycard.Count; i++)
    {
        for (int j = 0; j < deck.Length; j++)
        {
            if (mycard[i] == deck[j])
            {
                temp += j;
                break;
            }
        }
    }
    int endNum = (temp + 2) % 10; //끗수

    switch (endNum)
    {
        case 0:
            return 10;
        case 1:
            return 15;
        case 2:
            return 20;
        case 3:
            return 25;
        case 4:
            return 30;
        case 5:
            return 35;
        case 6:
            return 40;
        case 7:
            return 45;
        case 8:
            return 50;
        case 9:
            return 55;
        default:
            return -1;
    }
}