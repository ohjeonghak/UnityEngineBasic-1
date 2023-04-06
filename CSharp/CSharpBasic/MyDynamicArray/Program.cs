using Collections;
using System.Collections;
using System.Collections.Generic;


//bool Match(int x)
//{
//    return x > 4;
//}
#region Dynamic Array
MyDynamicArray myDynamicArray = new MyDynamicArray();
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
//장점 : 모든 타입을 캐스팅해서 쓸 수 있음, 단점 : int등으로 선언한거보다 연산 무거움, 단점 보완 : 제네릭사용


MyDynamicArray<Dummy> dummies = new MyDynamicArray<Dummy>();
MyDynamicArray<float> floats = new MyDynamicArray<float>();

ArrayList arrayList = new ArrayList();
arrayList.Add(3);
arrayList.Add("철수");
arrayList.Contains(3); //boxing 일어나서 못찾음

//List가 훨씬 중요
List<Dummy> list = new List<Dummy>();
list.Add(new Dummy());
list.Find(dummy => dummy.x < 0);



#endregion

class Dummy : IComparable<Dummy>
{
    public int x, y, z;
    public int CompareTo(Dummy? other)
    {
        //어떤 조건 ? 조건이 참일 때 값 : 조건이 거짓일 때 값
        return other != null && x == other.x && y == other.y && z == other.z ? 0 : -1;

        if (other == null)
            return -1;
        if (x == other.x && y == other.y && z == other.z) 
            return 0;
        else
            return -1;
    }
}