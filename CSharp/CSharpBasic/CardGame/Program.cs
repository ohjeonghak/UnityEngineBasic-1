// 카드 A(6으로 저장) 7 8 9 10 J(11) Q(12) K(13)
// 클로버(c), 다이아(d), 하트(h), 스페이드(s)
//                0      1      2      3      4      5      6      7
String[] deck = {"06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
                "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
                "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
                "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"};

List<String> myCard = new List<String>();
List<int> myCardOnlyNum = new List<int>(); //숫자만
List<string> myCardOnlyShape = new List<string>(); //모양만

myCard.Add(deck[0]);
myCard.Add(deck[9]); 
myCard.Add(deck[3]); 
myCard.Add(deck[5]); 
myCard.Add(deck[15]); 

//Console.WriteLine(myCard[0].Substring(0,2));  // 문자열 나누기 : Substring(start index, length)

//숫자와 모양 나누어서 저장
for (int i = 0; i < myCard.Count; i++)
{
    myCardOnlyNum.Add(Convert.ToInt32(myCard[i].Substring(0, 2)));
    myCardOnlyShape.Add(myCard[i].Substring(2, 1));
}

//카드 출력
for (int i = 0; i < myCard.Count; i++)
{
    Console.Write(myCard[i] + " ");
}
Console.WriteLine();
Console.WriteLine();

//모양 정렬
myCardOnlyShape.Sort();

//플러쉬 확인
bool isFlush = false;

if (myCardOnlyShape[0] == myCardOnlyShape[myCardOnlyShape.Count-1])
{
    isFlush = true;
    Console.WriteLine("플러쉬입니다.");
}
else
{
    Console.WriteLine("플러쉬가 아닙니다.");
}

//숫자 정렬
myCardOnlyNum.Sort();

//마운틴 확인
bool isMount = false;

if (myCardOnlyNum[0]==06 && myCardOnlyNum[1]==10 && myCardOnlyNum[2]==11 && myCardOnlyNum[3]==12 && myCardOnlyNum[4]==13)
{
    isMount= true;
    Console.WriteLine("마운틴입니다.");
}
else
{
    Console.WriteLine("마운틴이 아닙니다.");
}

//스트레이트 확인
//count를 해서 4가 되면 스트레이트로 판단하는 방법도 있음
bool isStraight = false;

for (int i = 1; i < myCardOnlyNum.Count; i++)
{
    if (myCardOnlyNum[i-1] + 1 == myCardOnlyNum[i])
    {
        isStraight = true;
    }
    else
    {
        isStraight= false;
        break;
    }
}

if(isStraight)
{
    Console.WriteLine("스트레이트입니다.");
}
else
{
    Console.WriteLine("스트레이트가 아닙니다.");
}

//스트레이트 플러쉬 확인
bool isStFlush = false;
if(isStraight && isFlush)
{
    isStFlush = true;
    Console.WriteLine("스트레이트 플러쉬입니다.");
}

//페어 확인
int pair = 0;

for (int i = 0; i < myCardOnlyNum.Count; i++)
{
    for (int j = i+1; j < myCardOnlyNum.Count; j++)
    {
        if (myCardOnlyNum[i] == myCardOnlyNum[j])
        {
            pair++;
        }
    }
}

switch (pair)
{
    case 1:
        Console.WriteLine("원페어입니다.");
        break;
    case 2:
        Console.WriteLine("투페어입니다.");
        break;
    case 3:
        Console.WriteLine("트리플입니다.");
        break;
    case 4:
        Console.WriteLine("풀하우스입니다.");
        break;
    case 6:
        Console.WriteLine("포커입니다.");
        break;
    default:
        break;
}

//로얄 스트레이트 플러쉬
bool isLoyal = false;
if(isFlush && isMount)
{
    isLoyal= true;
    Console.WriteLine("로얄 스트레이트 플러쉬입니다.");
}

if(pair==0 || isFlush==false || isStraight == false || isMount == false)
{
    Console.WriteLine();
    Console.WriteLine("족보를 완성하지 못했습니다.");
    Console.WriteLine($"가장 높은 카드는 {myCardOnlyNum[myCardOnlyNum.Count - 1]}{myCardOnlyShape[myCardOnlyShape.Count-1]} 입니다.");
}

//c 누르면 카드 바꾸는 함수 호출
//게임 종료와 카드 변경 선택하기
//카드 변경하면 변경하고 로직 다시 첨부터 실행

int change = 3;

void changeCard()
{
    if(change <= 0)
    {
        Console.WriteLine("카드 변경 기회를 전부 사용했습니다.");
    }

    Console.WriteLine("변경하고 싶은 카드의 인덱스를 입력하세요.");
    int input = Convert.ToInt32(Console.ReadLine());   

    Random random = new Random();
    int num = random.Next(0, deck.Length);
   
    myCard.RemoveAt(input);
    myCard.Add(deck[num]);

    change--;
}