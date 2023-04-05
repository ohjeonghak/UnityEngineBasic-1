using Collections;

//bool Match(int x)
//{
//    return x > 4;
//}

MyDynamicArray myDynamicArray= new MyDynamicArray();
myDynamicArray.Add(5);
myDynamicArray.Add(3);
myDynamicArray.Add(9);
myDynamicArray.Add(7);
int tmpIndex = myDynamicArray.FindIndex(7); //boxing이 일어나는순간 힙 영역에 새로 object 7이 생기는거
if(myDynamicArray.Remove(tmpIndex))
{
    Console.WriteLine($"{tmpIndex} of myDynamicArray has removed");
}
myDynamicArray.RemoveAt(tmpIndex);

for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.WriteLine(myDynamicArray[i]);
}

int tmpValue = (int)myDynamicArray.Find(x => (int)x > 4);
//int tmpValue = myDynamicArray.Find(Match); 함수만들어서 이렇게 할 수 있지만 가독성 떨어지고 굳이,,

//object : c# 모든 타입의 기반 타입
object obj = (object)1; //형변환 생략, boxing : object 타입 변환, 힙 영역에 object 타입 객체를 만들고 값을 할당
obj = "안녕";
obj = 'A';
tmpValue = (int)obj; //unboxing : object 객체의 데이터를 내가 원하는 자료형으로 형변환하는 것
//boxing unboxing 면접 질문★