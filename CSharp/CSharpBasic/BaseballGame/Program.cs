using System;

//string input = "425";

//Console.WriteLine("input의 값은 : " + input);
//Console.WriteLine("num의 타입은 : " + num.GetType);
//Console.WriteLine("input의 타입은 : " + input.GetType);

//Console.WriteLine(input[0]);
//Console.WriteLine(numTostring[0]);

int num = 832;
string numToString = num.ToString();

int count = 10;
string input;

Random random= new Random();
int randomNum = random.Next();
string answer = randomNum.ToString();

//for(int i = 0; i < answer.Length; i++)
//{

//}

//int[] answerArray = new int[3];
//for(int i = 0; i < answerArray.Length;i++)
//{
//    randomNum = random.Next(0,10);
//    answerArray[i] = randomNum;
  
//    for(int j = 0; j<i;j++)
//    {
//        if(answerArray[i] == answerArray[j])
//        {
//            i--;
//        }
//    } 
//}

//for(int i = 0; i<answerArray.Length;i++)
//{
//    Console.Write(answerArray[i]);
//}

//Console.WriteLine(answer);

Console.WriteLine("컴퓨터가 값을 생각했어요");
Console.WriteLine();

//게임 루프
while(count > 0)
{
    Console.Write("값을 입력하세요 : ");
    input = Console.ReadLine();

    //int[] inputArray = input.ToArray<int>;

    //for (int i = 0; i < inputArray.Length; i++)
    //{
    //    Console.Write(inputArray[i]);
    //    Console.WriteLine();
    //}

    int strikes = 0;
    int balls = 0;
    int outs = 0;
    int none = 0;

    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < answer.Length; j++)
        {
            if (input[i] == answer[j])
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
        //for j에서 다 다르면 out 1
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
        Console.WriteLine("정답입니다. 이겼습니다.");
        return;
    }

    count--;
    Console.WriteLine($"남은 기회 : {count}회");
    Console.WriteLine();
}

if(count == 0)
{
    Console.WriteLine("남은 기회가 없습니다. 졌습니다. ");
    Console.WriteLine($"정답은 {answer} 이었습니다.");
}

