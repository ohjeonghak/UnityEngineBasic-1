//right 값을 left 값에 대입
//R-Value : 값을 참조하기 위한 (읽기위한) 값
//L-Value : 값을 대입하기 위한 (쓰기위한) 값
int a = 14;
int b = 6;
int c = 0;

//산술 연산자
//더하기, 빼기, 곱하기, 나누기, 나머지
//==========================================================================

//더하기
c = a + b;
Console.WriteLine(c);

//빼기
c = a - b;

//곱하기
c = a * b;

//나누기, 정수 나눗셈은 몫만 반환
c = a / b;
Console.WriteLine(c);

//나머지
//실수나머지를 했을 때는 정수 나머지 연산 결과 반환
c = a % b;
Console.WriteLine(c);


//증감연산자
//==================================================================

//증가 연산
c = 0;
//++c; //피연산자 1 증가시키고 해당 피연산자 그대로 반환(증가시킨거 반환)
Console.WriteLine(++c); //전위 연산
//c++; //임시 변수를 만들고 피연산자 값을 기억한다음 피연산자 값을 1증가시키고 임시변수 값을 반환
Console.WriteLine(c++); //후위 연산
Console.WriteLine(c);

//감소 연산
c--;
--c;

//관계 연산
//같음, 다름, 크기 비교 연산
//연산결과가 참일경우 true, 거짓일경우 false를 반환함
//=================================================================

//같음
Console.WriteLine(a == b);

//다름
Console.WriteLine(a != b);

//큼
Console.WriteLine(a > b);

//크거나 같음
Console.WriteLine(a >= b);

//작음
Console.WriteLine(a < b);

//작거나 같음
Console.WriteLine(a <= b);

//복합 대입 연산자
//더해서, 빼서, 곱해서, 나누어서, 나머지연산 후 대입하는 연산
//=======================================================================

c = 20;
c += b;
c -= b;
c *= b;
c /= b;
c %= b;

//논리 연산자
//논리형의 피연산자들을 대상으로 연산을 수행
//or, and, xor, not
//==========================================
Console.WriteLine("======논리연산======");
bool A = true;
bool B = true;

//or
//A와 B 둘 중 하나라도 true이면 true, 아니면 false
Console.WriteLine(A | B);

//and
//A와 B 둘 다 true이면 true, 아니면 false
Console.WriteLine(A & B);

//xor
//A와 B 둘중 하나만 true면 true(다르면 true 같으면 false)
Console.WriteLine(A ^ B);

//not
//피연산자가 true면 false
Console.WriteLine(!A);

//조건부 논리연산자
//Conditional or, Conditional and
//===========================================

//Conditional or -> A가 true면 B가 뭐든 결과는 true -> B 안읽음
Console.WriteLine(A || B);

//Conditional and -> A가 false면 B가 뭐든 결과는 false -> B 안읽음
Console.WriteLine(A && B);


A |= B; //A = A|B; 잘 안씀 코드 가독성위해 쓰는 정도


//비트 연산자
//정수형에 대해서만 연산을 수행함
//==========================================


//or
//a == 14 == 00001110 (앞에 0 생략)
//b == 6 ==  00000110
Console.WriteLine(a | b);

//and
Console.WriteLine(a & b);

//xor
Console.WriteLine(a^b);

//not
//00000000 00000000 00000000 00001110
//11111111 11111111 11111111 11110001
Console.WriteLine(~a);

//2의 보수 : 이진법에서 모든 자릿수를 반전하고 +1, ~a + 1
//2의 보수의 2의 보수하면 다시 양수 뿅

//shift - left
Console.WriteLine(a << 1);

//shift - right
//00001110 -> 00000011 범위 넘어가면 날아감
Console.WriteLine(a >> 2);
