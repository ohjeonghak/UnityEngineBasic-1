
Random random= new Random();

//배열로 중복없애기
//int[] answer = new int[3];
//for(int i = 0; i < answer.Length; i++)
//{
//    answer[i] = random.Next(0, 10);
//    for (int j = 0; j < i; j++)
//    {
//        if (answer[i] == answer[j])
//        {
//            i--;
//        }
//    }
//}

//자리 각각 비교해서 중복없애기
string answerString;
do
{
    answerString = random.Next(100, 1000).ToString();
} while (answerString[0] == answerString[1] || answerString[0] == answerString[2] || answerString[1] == answerString[2]);

Console.WriteLine("컴퓨터가 값을 생각했어요");
Console.WriteLine();

int count = 10;
string input;
//int input;

//게임 루프
while (count > 0)
{
    Console.Write("값을 입력하세요 : ");
    input = Console.ReadLine();

    //배열로 중복체크할 때 아래처럼 정수 배열 만들어줌
    //for문 돌 때 inputArray랑 answer 비교
    //input = Convert.ToInt32(Console.ReadLine());
    //int[] inputArray = { (input / 100) % 10, (input / 10) % 10, input % 10 };

    int strikes = 0;
    int balls = 0;
    int outs = 0;
    int none = 0;

    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < answerString.Length; j++)
        {
            if (input[i] == answerString[j])
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
    //Console.Write("정답은 ");
    //for (int i = 0; i < answer.Length; i++)
    //{
    //    Console.Write(answer[i]);
    //}
    //Console.WriteLine(" 이었습니다.");
    Console.WriteLine($"정답은 {answerString} 이었습니다.");
}

