
//switch case 구문

//switch (인자)
//{
//	case 값1:
//		{
//			인자 == 값1인 경우 실행할 내용
//		}
//		break; //현재 구문을 빠져나오는 분기문
//	case 값2:
//	case 값3:
//		{
//			(인자 == 값2) | (인자 == 값3)인 경우 실행할 내용
//		}
//		break;
//	default:
//		{
//			인자의 값과 매칭되는 case가 없을 경우 실행할 내용
//		}
//		break;
//}

// 0 : Idel
// 1 : Move
// 2 : Jump
// 3 : Attack

using Statement_SwitchAndEnum;


int state = 3;

switch (state)
{
	case 0:
		Console.WriteLine("상태가 0이다");
		break;
	case 1:
        Console.WriteLine("상태가 1이다");
        break;
	case 2:
        Console.WriteLine("상태가 2이다");
        break;
	default:
        Console.WriteLine("알 수 없는 상태이다");
        break;
}

PlayerState playerState = PlayerState.Idel;

//명시적 캐스팅
//R-value를 L-value에 대입하기위해서 형 변환을 해야하고, 그것을 명시하는 것
int tmp = (int)playerState;
playerState = (PlayerState)0;

//암시적 캐스팅
//R-value를 L-value에 대입하기위해서 별도로 형 변환을 하지 않아도 연산이 가능한 경우
//보통 자료형의 승격이 일어나는 경우 암시적 캐스팅이 가능함
//승격 : 동일한 포맷의 자료형인데 더 사이즈가 큰 자료형을 연산하는 레지스터로 연산할 때
float f1 = 0.7f;
double d1 = 1.2;
d1 = f1; //double register로 float data를 읽으면 승격이 일어나므로 연산가능
f1 = (float)d1; //float register로 double data를 읽으면 데이터 손실이 나기때문에 명시적 캐스팅 해줘야함

switch (playerState)
{
	case PlayerState.Idel:
		Console.WriteLine("플레이어의 상태는 Idle");
		break;
	case PlayerState.Move:
        Console.WriteLine("플레이어의 상태는 Move");
        break;
	case PlayerState.Jump:
        Console.WriteLine("플레이어의 상태는 Jump");
        break;
	case PlayerState.Attack:
        Console.WriteLine("플레이어의 상태는 Attack");
        break;
	case PlayerState.Skill:
        Console.WriteLine("플레이어의 상태는 Skill");
        break;
	default:
		break;
}

Player player = new Player();
player.Layer = 2;

if((LayerMask)player.Layer == LayerMask.Player ||
	(LayerMask)player.Layer == LayerMask.Enemy ||
	(LayerMask)player.Layer == LayerMask.NPC)
{
	Console.WriteLine("생명체 감지");
}

LayerMask targetMask = LayerMask.Enemy | LayerMask.NPC;

Console.WriteLine(targetMask);

if((1 << player.Layer & (int)targetMask)>0) //비트마스크 연산. 비트에 1 생기면 감지된거니까 값은 0보다 큼
{
	Console.WriteLine("타겟감지");
}