using SutdaGame;

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

Dictionary<int, string> jokboNameOfScore = new Dictionary<int, string>()
{
    {10,"0끗"}, {15, "1끗"}, {20, "2끗"}, {25, "3끗"}, {30, "4끗"}, {35,"5끗"},
    {40, "6끗"}, {45, "7끗"}, {50, "8끗"}, {55, "9끗"},
    {100, "세륙(4,6)"}, {110, "장사(4,10)"} ,{120, "장삥(1,10)"}, {130, "구삥(1,9)"},
    {140,"독사(1,4)"}, {150, "알리(1,2)"}, {200,"1땡"}, {210,"2땡"}, {220, "3땡"},
    {230,"4땡"}, {240, "5땡"}, {250, "6땡"}, {260,"7땡"},{270,"8땡"},{280,"9땡"},{290,"10땡(장땡)"},
    {500, "광땡"}, {1000, "38광땡"}, {410,"땡잡이"}, {750,"암행어사"}
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

//필요한 변수 선언
int result = -1;
bool isDDaeng = false;
bool isGuangDDaeng = false;
int maxScore = 0;

//플레이어 객체 4개 생성
Player[] players = new Player[4];

for (int i = 0; i < players.Length; i++)
{
    players[i] = new Player();
    players[i].name = "플레이어" + (i + 1);
}

//테스트
#region
//players[0].Cards.Add(deck[1]);
//players[0].Cards.Add(deck[0]);

//players[1].Cards.Add(deck[2]);
//players[1].Cards.Add(deck[16]);

//players[2].Cards.Add(deck[10]);
//players[2].Cards.Add(deck[12]);

//players[3].Cards.Add(deck[3]);
//players[3].Cards.Add(deck[6]);
#endregion

//카드 분배 후 점수 계산
for (int i = 0;i < players.Length; i++)
{
    //각자 카드 두장씩 나눠주기 (deck을 랜덤으로 섞은 후 앞에서부터 두장씩 나눠줌)
    players[i].Cards.Add(deck[i * 2]);
    players[i].Cards.Add(deck[i * 2 + 1]);

    //받은 카드를 정렬 후
    players[i].Cards.Sort();

    //합쳐서 concat에 넣기
    players[i].Concat = players[i].Cards[0] + players[i].Cards[1];

    //족보 체크 후 점수 저장하기
    players[i].Score = CountScore(players[i].Cards, players[i].Concat);

    if (players[i].Concat == "AC")
        players[i].myJokbo = "13" + jokboNameOfScore[players[i].Score];

    else if (players[i].Concat == "AH")
        players[i].myJokbo = "18" + jokboNameOfScore[players[i].Score];

    else if (players[i].Concat == "cg" || players[i].Concat == "cG" || players[i].Concat == "Cg" || players[i].Concat == "CG")
        players[i].myJokbo = jokboNameOfScore[players[i].Score] + " or 땡잡이";

    else if (players[i].Concat == "dg" || players[i].Concat == "dG" || players[i].Concat == "Dg" || players[i].Concat == "DG")
        players[i].myJokbo = jokboNameOfScore[players[i].Score] + " or 암행어사";

    else
        players[i].myJokbo = jokboNameOfScore[players[i].Score];


    Console.WriteLine($"{players[i].name}의 정보");
    Console.WriteLine("카드 : " + players[i].Concat);
    Console.WriteLine("점수 : " + players[i].Score);
    Console.WriteLine("족보 : " + players[i].myJokbo);
    Console.WriteLine();
}

//클래스없이 짠 코드 ▼
#region

//각자 카드 2장씩 넣을 리스트
//List<string> player0 = new List<string>();
//List<string> computer1 = new List<string>();
//List<string> computer2 = new List<string>();
//List<string> computer3 = new List<string>();

//모든 플레이어의 카드를 concat 후 다 넣을 리스트
//List<string> playerCardList = new List<string>();
//모든 플레이어의 점수를 저장할 리스트
//List<int> score = new List<int>();

//player0.Add(deck[0]);
//player0.Add(deck[1]);

//computer1.Add(deck[2]);
//computer1.Add(deck[3]);

//computer2.Add(deck[4]);
//computer2.Add(deck[5]);

//computer3.Add(deck[6]);
//computer3.Add(deck[7]);

//player0.Sort();
//computer1.Sort();
//computer2.Sort();
//computer3.Sort();

//Console.WriteLine("player0의 패");
//Console.Write(player0[0]);
//Console.WriteLine(player0[1]);
//Console.WriteLine();

//Console.WriteLine("computer1의 패");
//Console.Write(computer1[0]);
//Console.WriteLine(computer1[1]);
//Console.WriteLine();

//Console.WriteLine("computer2의 패");
//Console.Write(computer2[0]);
//Console.WriteLine(computer2[1]);
//Console.WriteLine();

//Console.WriteLine("computer3의 패");
//Console.Write(computer3[0]);
//Console.WriteLine(computer3[1]);
//Console.WriteLine();

//string concatPlayer0 = player0[0] + player0[1];
//string concatCom1 = computer1[0] + computer1[1];
//string concatCom2 = computer2[0] + computer2[1];
//string concatCom3 = computer3[0] + computer3[1];

//playerCardList.Add(concatPlayer0);
//playerCardList.Add(concatCom1);
//playerCardList.Add(concatCom2);
//playerCardList.Add(concatCom3);

//int scorePlayer0=0;
//int scoreCom1=0;
//int scoreCom2=0;
//int scoreCom3 = 0;

//플레이어의 족보 체크 후 점수 넣기
//scorePlayer0 = CountScore(player0, concatPlayer0);
//scoreCom1 = CountScore(computer1, concatCom1);
//scoreCom2 = CountScore(computer2, concatCom2);
//scoreCom3 = CountScore(computer3, concatCom3);

//score.Add(scorePlayer0);
//score.Add(scoreCom1);
//score.Add(scoreCom2);
//score.Add(scoreCom3);

//result = score.Max();

#endregion

//땡잡이 체크
for (int i = 0; i < players.Length; i++)
{
    if (players[i].Score >= 200 && players[i].Score <= 280)
    {
        isDDaeng= true;
    }
}
if(isDDaeng)
{
    for (int i = 0; i < players.Length; i++)
    {
        if (players[i].Concat == "cg" || players[i].Concat == "cG" || players[i].Concat == "Cg" || players[i].Concat == "CG")
        {
            players[i].Score = 410;
            players[i].DdaengWin = true;
        }
    }
}

//암행어사 체크
for (int i = 0; i < players.Length; i++)
{
    if (players[i].Score == 500)
    {
        isGuangDDaeng= true;
    }
}
if (isGuangDDaeng)
{
    for (int i = 0; i < players.Length; i++)
    {
        if (players[i].Concat == "dg" || players[i].Concat == "dG" || players[i].Concat == "Dg" || players[i].Concat == "DG")
        {
            players[i].Score= 750;
            players[i].GuangWin = true;
        }
    }
}

Console.WriteLine("***************** 결과 *******************");
Console.WriteLine();

for (int i = 0; i < players.Length; i++)
{
    Console.WriteLine($"{players[i].name}의 최종 점수 : {players[i].Score}");

    if (players[i].DdaengWin)
    {
        Console.WriteLine($"{players[i].name}은(는) 땡잡이였습니다.");
    }
    else if (players[i].GuangWin)
    {
        Console.WriteLine($"{players[i].name}은(는) 암행어사였습니다.");

    }
    Console.WriteLine();
}
Console.WriteLine();

//점수 배열 중 최댓값이 승리
for (int i = 0; i < players.Length; i++)
{
    if (players[i].Score > maxScore)
    {
        maxScore = players[i].Score;
        result = i;
    }
}

//결과 출력
switch (result)
{
    case 0:
        Console.WriteLine($"★ {players[0].name}이(가) {players[0].Score}점으로 이겼습니다. ★");
        break;
    case 1:
        Console.WriteLine($"★ {players[1].name}이(가) {players[1].Score}점으로 이겼습니다. ★");
        break;
    case 2:
        Console.WriteLine($"★ {players[2].name}이(가) {players[2].Score}점으로 이겼습니다. ★");
        break;
    case 3:
        Console.WriteLine($"★ {players[3].name}이(가) {players[3].Score}점으로 이겼습니다. ★");
        break;
    default:
        break;
}

Console.WriteLine();

//점수 계산하는 함수
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

//끗수 계산하는 함수
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