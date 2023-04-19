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

myCard.Add(deck[8]); //11d
myCard.Add(deck[9]); //08s
myCard.Add(deck[12]); //012c
myCard.Add(deck[13]); //08d
myCard.Add(deck[14]); //06d

//Console.WriteLine(myCard[0].Substring(0,2));  // 문자열 나누기 : Substring(start index, length)

for (int i = 0; i < myCard.Count; i++)
{
    myCardOnlyNum.Add(Convert.ToInt32(myCard[i].Substring(0, 2)));
    myCardOnlyShape.Add(myCard[i].Substring(2, 1));
}

//카드 모양 출력
for (int i = 0; i < myCardOnlyShape.Count; i++)
{
    Console.WriteLine(myCardOnlyShape[i]);
}

//플러쉬 확인
myCardOnlyShape.Sort();
bool isflush = false;

if (myCardOnlyShape[0] == myCardOnlyShape[myCardOnlyShape.Count-1])
{
    isflush = true;
    Console.WriteLine("플러쉬입니다.");
}
else
{
    Console.WriteLine("플러쉬가 아닙니다.");
}

//마운틴 확인
bool isMount = false;
myCardOnlyNum.Sort();

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
bool isStraight = false;

for (int i = 0; i < myCardOnlyNum.Count; i++)
{
    if (myCardOnlyNum[i] + 1 == myCardOnlyNum[i + 1])
    {

    }
}

bool isStFlush = false;
if(isStraight && isflush)
{
    isStFlush = true;
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
    case 6:
        Console.WriteLine("포커입니다.");
        break;
    default:
        break;
}
