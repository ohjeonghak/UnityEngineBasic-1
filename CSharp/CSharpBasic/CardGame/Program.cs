// 카드 A(6으로 저장) 7 8 9 10 J(11) Q(12) K(13)
// 클로버(c), 다이아(d), 하트(h), 스페이드(s)
//                0      1      2      3      4      5      6      7
string[] deck = {"06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
                "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
                "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
                "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"};

List<string> myCard = new List<string>();
List<int> myCardOnlyNum = new List<int>(); //숫자만
List<string> myCardOnlyShape = new List<string>(); //모양만
List<int> cardIndex = new List<int>(); //랜덤으로 뽑은 인덱스 저장

Random random= new Random();
int index;
for (int i = 0; i < 6;)
{
    index = random.Next(0, deck.Length);
    if (!cardIndex.Contains(index))
    {
        cardIndex.Add(index);
        i++;
    }
}

//myCard에 카드 넣기
for (int i = 0; i < 5; i++)
{
    myCard.Add(deck[cardIndex[i]]);
}

//Console.WriteLine(myCard[0].Substring(0,2));  // 문자열 나누기 : Substring(start index, length)

//카드 출력하고 바꿀지말지 선택 후 비교하고 종료

gameStart();

void gameStart()
{
    bool isFlush = false;
    bool isMount = false;
    bool isStraight = false;
    int pair = 0;

    //숫자와 모양 나누어서 저장
    for (int i = 0; i < myCard.Count; i++)
    {
        myCardOnlyNum.Add(Convert.ToInt32(myCard[i].Substring(0, 2)));
        myCardOnlyShape.Add(myCard[i].Substring(2, 1));
    }

    //카드 출력
    Console.WriteLine("나의 카드는");
    for (int i = 0; i < myCard.Count; i++)
    {
        Console.Write(myCard[i] + " ");
    }
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("카드를 변경하려면 c, 그대로 진행하려면 g를 입력하세요.");
    string key = Console.ReadLine();
    while (true)
    {
        if (key == "c")
        {
            changeCard();
            break;
        }
        else if (key == "g")
            break;
        else
        {
            Console.WriteLine("잘못된 입력입니다. c와 g 중에서 입력하세요.");
            continue;
        }
    }
    Console.WriteLine();

    //모양 정렬
    myCardOnlyShape.Sort();
    //숫자 정렬
    myCardOnlyNum.Sort();

    //플러쉬 확인
    if (myCardOnlyShape[0] == myCardOnlyShape[myCardOnlyShape.Count - 1])
    {
        isFlush = true;
        Console.WriteLine("플러쉬입니다.");
    }

    //마운틴 확인
    if (myCardOnlyNum[0] == 06 && myCardOnlyNum[1] == 10 && myCardOnlyNum[2] == 11 && myCardOnlyNum[3] == 12 && myCardOnlyNum[4] == 13)
    {
        isMount = true;
        Console.WriteLine("마운틴입니다.");
    }

    //스트레이트 확인
    //count를 해서 4가 되면 스트레이트로 판단하는 방법도 있음
    for (int i = 1; i < myCardOnlyNum.Count; i++)
    {
        if (myCardOnlyNum[i - 1] + 1 == myCardOnlyNum[i])
        {
            isStraight = true;
            Console.WriteLine("스트레이트입니다.");
        }
        else
        {
            isStraight = false;
            break;
        }
    }

    //페어 확인
    for (int i = 0; i < myCardOnlyNum.Count; i++)
    {
        for (int j = i + 1; j < myCardOnlyNum.Count; j++)
        {
            if (myCardOnlyNum[i] == myCardOnlyNum[j])
            {
                pair++;
            }
        }
    }

    //족보 완성 여부 체크
    if (isMount && isFlush)
    {
        Console.WriteLine("로얄 스트레이트 플러쉬입니다.");
    }
    else if (isFlush && isStraight)
    {
        Console.WriteLine("스트레이트 플러쉬입니다.");
    }
    else if (pair == 6)
    {
        Console.WriteLine("포커입니다.");
    }
    else if (pair == 4)
    {
        Console.WriteLine("풀하우스입니다.");
    }
    else if (pair == 3)
    {
        Console.WriteLine("트리플입니다.");
    }
    else if (pair == 2)
    {
        Console.WriteLine("투페어입니다.");
    }
    else if (pair == 1)
    {
        Console.WriteLine("원페어입니다.");
    }
    else
    {
        Console.WriteLine("족보를 완성하지 못했습니다.");
    }
}

void changeCard()
{
    Console.WriteLine("변경하고 싶은 카드의 인덱스를 입력하세요.");
    int input = Convert.ToInt32(Console.ReadLine());
   
    myCard.RemoveAt(input);
    myCard.Add(deck[cardIndex[cardIndex.Count-1]]);

    myCardOnlyNum.Clear();
    myCardOnlyShape.Clear();
    //for (int i = 0; i < myCard.Count; i++)
    //{
    //    myCardOnlyShape.RemoveAt(0);
    //}

    //숫자와 모양 나누어서 저장
    for (int i = 0; i < myCard.Count; i++)
    {
        myCardOnlyNum.Add(Convert.ToInt32(myCard[i].Substring(0, 2)));
        myCardOnlyShape.Add(myCard[i].Substring(2, 1));
    }

    Console.WriteLine("새로운 나의 카드는");
    for (int i = 0; i < myCard.Count; i++)
    {
        Console.Write(myCard[i] + " ");
    }
    Console.WriteLine();
}