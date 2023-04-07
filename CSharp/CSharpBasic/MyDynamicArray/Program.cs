using Collections;
using System.Collections;
using System.Collections.Generic;

//yield
//IEnumerator / IEnumerable 로 반복기를 구현할 때 MoveNext() 에 해당하는 기능을 구현해줄 때 사용
//다음 요소 값 반환할 때
IEnumerator MakeToastWorkFlow()
{
    Console.WriteLine("토스트만들기() : 1. 인덕션을 켠다.");
    yield return null;
    Console.WriteLine("토스트만들기() : 2. 인덕션에 팬을 올린다.");
    yield return null;
    Console.WriteLine("토스트만들기() : 3. 팬에 버터를 두른다.");
    yield return null;
    Console.WriteLine("토스트만들기() : 4. 팬에 식빵을 올린다.");
}

IEnumerator<string> MakeToastWorkFlow2()
{
    yield return "토스트만들기() : 1. 인덕션을 켠다.";
    yield return "토스트만들기() : 2. 인덕션에 팬을 올린다.";
    yield return "토스트만들기() : 3. 팬에 버터를 두른다.";
    yield return "토스트만들기() : 4. 팬에 식빵을 올린다.";
}

IEnumerable<int> WorkflowSample()
{
    yield return 1;
    yield return 2;
    yield return 3;
}

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
//myDynamicArray.RemoveAt(tmpIndex);

for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.WriteLine(myDynamicArray[i]);
}

int tmpValue = (int)myDynamicArray.Find(x => (int)x > 4);
//int tmpValue = myDynamicArray.Find(Match); 함수만들어서 이렇게 할 수 있지만 가독성 떨어지고 굳이,,

//object : c# 모든 타입의 기반 타입
object obj = (object)1; //형변환 생략, boxing : object 타입 변환, 힙 영역에 object 타입 객체를 만들고 값을 할당
obj = "안녕";
obj = 'a';
//tmpValue = (int)obj; //unboxing : object 객체의 데이터를 내가 원하는 자료형으로 형변환하는 것
//boxing unboxing 면접 질문★
//장점 : 모든 타입을 캐스팅해서 쓸 수 있음, 단점 : int등으로 선언한거보다 연산 무거움, 단점 보완 : 제네릭사용


MyDynamicArray<Dummy> dummies = new MyDynamicArray<Dummy>();
MyDynamicArray<float> floats = new MyDynamicArray<float>();

floats.Add(3.2f);
floats.Add(2.5f);
floats.Add(7.3f);
floats.Add(2.1f);

//using 구문 : IDisposable 객체의 Dispose() 호출을 보장하는 구문 , 여러개 쓸 수 있음
//밑에처럼 하면 dispose 안써도 됨
using (IEnumerator<float> enumerator = floats.GetEnumerator())
using (IEnumerator<Dummy> enumerator2 = dummies.GetEnumerator())
//using (enumerator)
{
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
    enumerator.Reset();
}
//enumerator.Dispose();


//위에 while문이랑 밑에 foreach랑 같은거 foreach(current의 타입 item in IEnumerable) current를 반환함
//for문은 데이터 원본을 순회하는거라 데이터를 직접 건드릴 수 있음
//foreach는 enumerator로 순회하는거라 데이터 못건듦
foreach (float item in floats)
{
    Console.WriteLine(item);
}


//IEnumerator변수 안만들고 걍 함수가져다넣어서 movenext하면 안됨
IEnumerator toastEnumerator = MakeToastWorkFlow();
while (toastEnumerator.MoveNext()) { }

IEnumerator toastEnumerator2 = MakeToastWorkFlow2();
//반환타입있을 때 이렇게
while (toastEnumerator2.MoveNext())
{
    Console.WriteLine(toastEnumerator2.Current);
}

IEnumerator<int> e1 = WorkflowSample().GetEnumerator();
while (e1.MoveNext())
{
    Console.WriteLine(e1.Current);
}
IEnumerable<int> eSample = WorkflowSample();
foreach (var item in eSample)
{
    Console.WriteLine(item);
}





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