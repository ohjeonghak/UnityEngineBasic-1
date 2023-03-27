
// 배열
// 메모리공간이 연속적인 데이터 포맷의 자료형
//배열의 선언
//자료형[] 이름 = new 자료형[개수];
//자료형[] 이름 = {값1, 값2, 값3 ...};

int[] intArr = new int[5];

//[] 인덱서
//배열의 인덱서
//{배열의 첫번째주소 + 인덱스*자료형} 의 주소부터 자료형크기만큼의 데이터에 접근
intArr[0] = 1;
//intArr[5] = 1;

//***********************************************
Dummy[] dummies = new Dummy[3]; //Dummy 객체 3개가 아니라 Dummy 객체를 참조할 수 있는 배열(공간 3개를 힙영역에 확보한 것)
dummies[0] = new Dummy();
dummies[1] = new Dummy();
dummies[2] = new Dummy();

int[][] intArrArr = new int[3][]; //int타입배열을 참조하는 크기 3개짜리 배열(배열의 배열)
intArrArr[0] = new int[3];
intArrArr[1] = new int[1];
intArrArr[2] = new int[2];

String name = "nang"; //String은 배열이 아니고 클래스
Console.WriteLine(name[0]);
Console.WriteLine(name[1]);
Console.WriteLine(name[2]);
Console.WriteLine(name[3]);

for (int i = 0; i < name.Length; i++)
{
    Console.WriteLine(name[i]);
}

class Dummy
{
    int a;
}

