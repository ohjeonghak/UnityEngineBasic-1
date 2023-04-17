int num = 832;
string numTostring = num.ToString();

Console.WriteLine("컴퓨터가 값을 생각했어요");

//string input = Console.ReadLine();
string input = "425";

//Console.WriteLine("input의 값은 : " + input);
//Console.WriteLine("num의 타입은 : " + num.GetType);
//Console.WriteLine("input의 타입은 : " + input.GetType);

//Console.WriteLine(input[0]);
//Console.WriteLine(numTostring[0]);

//if (input[0] == numTostring[0])
//{
//    Console.WriteLine("둘이 값이 같습니다.");
//}
//else
//{
//    Console.WriteLine("달라요.");
//}

int count = 10;
string input2;

//for j에서 다 다르면 out 1

while(count > 0)
{
    Console.Write("값을 입력하세요 : ");
    input2 = Console.ReadLine();


    int strikes = 0;
    int balls = 0;
    int outs = 0;
    int none = 0;

    for (int i = 0; i < input2.Length; i++)
    {
        for (int j = 0; j < numTostring.Length; j++)
        {
            if (input2[i] == numTostring[j])
            {
                if (i == j)
                {
                    strikes++;
                    continue;
                }
                else
                {
                    balls++;
                    continue;
                }

            }
            else
            {
                none++;
            }

        }
        if (none == 3)
        {
            outs++;
        }
        none = 0;

    }

    Console.WriteLine($"{strikes} 스트라이크");
    Console.WriteLine($"{balls} 볼");
    Console.WriteLine($"{outs} 아웃");
   

    if (strikes == 3)
    {
        Console.WriteLine();
        Console.WriteLine("축하합니다. 이겼습니다.");
        return;
    }

    count--;
    Console.WriteLine($"남은 기회 : {count}회");
    Console.WriteLine();
    Console.WriteLine();
}

if(count == 0)
{
    Console.WriteLine("남은 기회가 없습니다. 졌습니다. ");
}

