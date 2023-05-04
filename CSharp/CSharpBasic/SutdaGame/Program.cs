
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
    {"AC", 500}, {"AH", 500}, //13광땡, 18광땡
    {"CH", 1000} //38광땡
};

//deck 랜덤 섞기
string tempStr;
for (int i = 0; i < deck.Length; i++)
{
    Random rand = new Random();
    int a = rand.Next(0, deck.Length);
    tempStr = deck[i];
    deck[i] = deck[a];
    deck[a] = tempStr;
}

for (int i = 0; i < deck.Length; i++)
{
    Console.Write(deck[i]+" ");
}
Console.WriteLine();
Console.WriteLine();

List<string> player0 = new List<string>();
List<string> computer1 = new List<string>();
List<string> computer2 = new List<string>();
List<string> computer3 = new List<string>();

List<string> playerCardList = new List<string>();
List<int> score = new List<int>();

player0.Add(deck[1]);
player0.Add(deck[5]);

computer1.Add(deck[7]);
computer1.Add(deck[17]);

computer2.Add(deck[3]);
computer2.Add(deck[6]);

computer3.Add(deck[10]);
computer3.Add(deck[12]);

player0.Sort();
computer1.Sort();
computer2.Sort();
computer3.Sort();

Console.WriteLine("player0의 패");
Console.Write(player0[0]);
Console.WriteLine(player0[1]);
Console.WriteLine();

Console.WriteLine("computer1의 패");
Console.Write(computer1[0]);
Console.WriteLine(computer1[1]);
Console.WriteLine();

Console.WriteLine("computer2의 패");
Console.Write(computer2[0]);
Console.WriteLine(computer2[1]);
Console.WriteLine();

Console.WriteLine("computer3의 패");
Console.Write(computer3[0]);
Console.WriteLine(computer3[1]);
Console.WriteLine();

string concatPlayer0 = player0[0] + player0[1];
string concatCom1 = computer1[0] + computer1[1];
string concatCom2 = computer2[0] + computer2[1];
string concatCom3 = computer3[0] + computer3[1];

playerCardList.Add(concatPlayer0);
playerCardList.Add(concatCom1);
playerCardList.Add(concatCom2);
playerCardList.Add(concatCom3);

int scorePlayer0=0;
int scoreCom1=0;
int scoreCom2=0;
int scoreCom3 = 0;

int result = -1;

//플레이어와 컴퓨터 족보 체크 후 점수 넣기
scorePlayer0 = CountScore(player0, concatPlayer0);
scoreCom1 = CountScore(computer1, concatCom1);
scoreCom2 = CountScore(computer2, concatCom2);
scoreCom3 = CountScore(computer3, concatCom3);

score.Add(scorePlayer0);
score.Add(scoreCom1);
score.Add(scoreCom2);
score.Add(scoreCom3);

bool isDDaeng = false;
bool isGuangDDaeng = false;

//땡잡이 체크
for (int i = 0; i < score.Count; i++)
{
    if (score[i] >= 200 && score[i] <= 290)
    {
        isDDaeng= true;
    }
}
if(isDDaeng)
{
    for (int j = 0; j < playerCardList.Count; j++)
    {
        if (playerCardList[j] == "cg" || playerCardList[j] == "cG" || playerCardList[j] == "Cg" || playerCardList[j] == "CG")
        {
            score[j] = 410;
        }
    }
}


//암행어사 체크
for (int i = 0; i < score.Count; i++)
{
    if (score[i] == 500)
    {
        isGuangDDaeng= true;
    }
}
if (isGuangDDaeng)
{
    for (int j = 0; j < playerCardList.Count; j++)
    {
        if (playerCardList[j] == "dg" || playerCardList[j] == "dG" || playerCardList[j] == "Dg" || playerCardList[j] == "DG")
        {
            score[j] = 750;
        }
    }
}


for (int i = 0; i < score.Count; i++)
{
    Console.WriteLine("각자의 점수 : " + score[i]);
}
Console.WriteLine();

//점수 배열 중 최댓값이 승리
result = score.Max();
switch (score.IndexOf(result))
{
    case 0:
        Console.WriteLine("player0의 점수 : " + score[0]);
        Console.WriteLine("player0 이(가) 이겼습니다.");
        break;
    case 1:
        Console.WriteLine("computer1의 점수 : " + score[1]);
        Console.WriteLine("computer1 이(가) 이겼습니다.");
        break;
    case 2:
        Console.WriteLine("computer2의 점수 : " + score[2]);
        Console.WriteLine("computer2 이(가) 이겼습니다.");
        break;
    case 3:
        Console.WriteLine("computer3의 점수 : " + score[3]);
        Console.WriteLine("computer3 이(가) 이겼습니다.");
        break;
    default:
        break;
}

//족보있으면 족보대로 점수, 없으면 끗수계산해서 점수 계산
int CountScore(List<string> myCard, string myConcat)
{
    int myScore = 0;

    if (jokbo.ContainsKey(myConcat))
        myScore = jokbo[myConcat];
    else
        myScore = AddCardNum(myCard);

    return myScore;
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