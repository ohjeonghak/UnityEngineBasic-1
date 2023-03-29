//const 키워드
//상수키워드. 이 상수로 선언된 변수는 초기화만 가능하며 초기화 이후 상수처럼 사용된다.
//이후 대입 연산 불가능
const int MAP_HEIGHT = 4;
const int MAP_WIDTH= 5;
int[,] map = new int[MAP_HEIGHT, MAP_WIDTH] //메모리에 2차원으로 할당되는거 아님
{
    {2, 0, 0, 0, 1 },
    {0, 1, 1, 1, 1 },
    {0, 0, 0, 1, 1 },
    {1, 1, 0, 0, 3 }
};
int y = 0;
int x = 0;
int targetY = 3;
int targetX = 4;

void DispalyMap()
{
    for (int i = 0; i < map.GetLength(0); i++) //map.GetLength 배열 몇차원인지 받아옴 앞에서부터 0차원
    {
        for (int j = 0; j <map.GetLength(1); j++)
        {
            if (map[i, j] == 0)
                Console.Write("□ ");
            if (map[i, j] == 1)
                Console.Write("■ ");
            if (map[i, j] == 2)
                Console.Write("▣ ");
            if (map[i, j] == 3)
                Console.Write("☆ ");

        }
        Console.WriteLine();
    }
    Console.WriteLine("======================================================");
}

void MoveRight()
{
    //맵 경계를 벗어나지 않는지 체크
    if (x >= map.GetLength(1) - 1)
    {
        Console.WriteLine("이동 실패. 맵 경계를 벗어남");
        return;
    }

    //벽이 있는지 체크
    if (map[y, x + 1] == 1)
    {
        Console.WriteLine("이동 실패. 벽이 막고있음");
        return;
    }

    map[y, x] = 0;
    x++;
    map[y, x] = 2;
    Console.WriteLine($"이동 완료. 현재좌표 : ({x},{y})");
    DispalyMap();
    Console.WriteLine();

}

void MoveLeft()
{
    //맵 경계를 벗어나지 않는지 체크
    if (x <= 0)
    {
        Console.WriteLine("이동 실패. 맵 경계를 벗어남");
        return;
    }

    //벽이 있는지 체크
    if (map[y, x - 1] == 1)
    {
        Console.WriteLine("이동 실패. 벽이 막고있음");
        return;
    }

    map[y, x] = 0;
    x--;
    map[y, x] = 2;
    Console.WriteLine($"이동 완료. 현재좌표 : ({x},{y})");
    DispalyMap();
    Console.WriteLine();

}

void MoveUp()
{
    //맵 경계를 벗어나지 않는지 체크
    if (y <= 0)
    {
        Console.WriteLine("이동 실패. 맵 경계를 벗어남");
        return;
    }

    //벽이 있는지 체크
    if (map[y - 1, x] == 1)
    {
        Console.WriteLine("이동 실패. 벽이 막고있음");
        return;
    }

    map[y, x] = 0;
    y--;
    map[y, x] = 2;
    Console.WriteLine($"이동 완료. 현재좌표 : ({x},{y})");
    DispalyMap();
    Console.WriteLine();

}

void MoveDown()
{
    //맵 경계를 벗어나지 않는지 체크
    if (y >= map.GetLength(0) - 1)
    {
        Console.WriteLine("이동 실패. 맵 경계를 벗어남");
        return;
    }

    //벽이 있는지 체크
    if (map[y + 1, x] == 1)
    {
        Console.WriteLine("이동 실패. 벽이 막고있음");
        return;
    }

    map[y, x] = 0;
    y++;
    map[y, x] = 2;
    Console.WriteLine($"이동 완료. 현재좌표 : ({x},{y})");
    DispalyMap();
    Console.WriteLine();
}

DispalyMap();

//게임루프
string? input; //?는 널 들어가도 된다는 뜻
while (true)
{
    Console.Write("키를 입력하세요 : ");
    input = Console.ReadLine();
    if (string.Compare(input, "R") == 0) MoveRight();
    else if (string.Compare(input, "L") == 0) MoveLeft();
    else if (string.Compare(input, "U") == 0) MoveUp();
    else if (string.Compare(input, "D") == 0) MoveDown();
    else
    {
        Console.WriteLine("잘못된 입력. R,L,U,D 중 하나를 입력하세요...");
        continue;
    }
    
    if(y == targetY && x == targetX)
    {
        Console.WriteLine("도착함!");
        break;
    }
}