//using 키워드 : namespace를 가져다 쓰기위함
using ClassObjectInstance;

//new 키워드 : 동적할당키워드
//메인에서 만든거염
SwordMan swordMan1 = new SwordMan();
SwordMan swordMan2 = new SwordMan();
int a = 3;

//멤버접근연산자
swordMan1.Name = "짱짱";
swordMan1.Lv = 1;

swordMan2.Name = "똠양꿍";
swordMan2.Lv = 2;

//swordMan1.Slash();
//swordMan2.Slash();

//함수 호출 시 함수 내용 코드 전체 복사해서 스택에 쌓임

ClassObjectInstance.SwordMan sw1 = new ClassObjectInstance.SwordMan();
ClassObjectInstance.UISystems.Characters.SwordMan sw2 = new ClassObjectInstance.UISystems.Characters.SwordMan();


//person 클래스 객체

Person kim = new Person();
Person lee = new Person();
Person choi = new Person();

kim.Name = "김아무개";
kim.Age = 216;
kim.Height = 123.1f;
kim.Weight = 300.0;
kim.IsAvailable = false;

lee.Name = "이아무개";
lee.Age = 39;
lee.Height = 323.5f;
lee.Weight = 232.2;
lee.IsAvailable = true;

choi.Name = "최아무개";
choi.Age = 142;
choi.Height = 53.1f;
choi.Weight = 144.4;
choi.IsAvailable = true;

kim.Introduce();
lee.Introduce();
choi.Introduce();

