
// while loop
// 소괄호 내의 조건이 참일 때 중괄호 내의 연산을 반복수행하는 문장
int count = 0;
while (count < 10)
{
    //if (count == 5)
    //    break;

    Console.WriteLine($"while 반복중... 현재 카운트 : {count}");

    //if (count == 5) 
    //    continue; //현재 반복문을 종료하고 다시 반복문 조건체크하러감

    count++;
}

// do while loop
// 일단 중괄호 내의 연산을 한 번 수행하고, 소괄호 내의 조건이 참일 때 중괄호 내의 연산을 반복수행하는 문장
do
{
    Console.WriteLine("안녕");
} while (false);

//for (반복문 시작하기 젤 처음에 한번 수행할 연산; 반복을 할 조건; 반복문 한번 끝날 때마다 할 연산)
//{

//}

for(int i= 0; i < 5; i++)
{
    Console.WriteLine($"for 반복문... 현재 카운트 : {i}");
}

for (int i = 2; i < 25; i+=2)
{
    Console.WriteLine($"2의 배수 출력중...{i}");
}
