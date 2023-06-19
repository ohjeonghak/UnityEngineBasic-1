namespace Array
{
    // 배열
    // 연속적인 데이터 타입(특정 타입이 메모리상에 연속적으로 붙어있는 형태)
    internal class Program
    {
        static void Main(string[] args)
        {
            // 배열은 참조타입.
            // new 자료형[배열크기] 하게 되면 힙영역에 배열을 할당하고 해당 배열 참조를 반환.
            int[] intArr = new int[3];
            intArr = new int[3] { 1, 2, 3 };

            int[] intArr2 = { 1, 2, 3 };

            // 인덱서 []
            // 인덱스  접근용 연산자
            // 타입의 크기 * 인덱스 ( 인텍서입력) 뒤에 주소를 참조하는 연산자
            // 호출방법 : 변수이름[인덱스];
            Console.WriteLine(intArr[0]);
            Console.WriteLine(intArr[1]);
            Console.WriteLine(intArr[2]);
            //Console.WriteLine(intArr[3]);

            for (int i = 0; i < intArr.Length; i++)
            {
                Console.WriteLine(intArr[i]);
            }

            intArr.CopyTo(intArr2, 0);
            System.Array.Copy(intArr, intArr2, 2);
            intArr.Clone();

            String name = "Luke";
            string name2 = "Kai";
            Console.WriteLine(name[0]);
            for (int i = 1; i < name.Length; i++)
            {
                Console.WriteLine(name[i]);
            }

            name2 = "A" + "B" + "C"; // "ABC"
            {
                Console.WriteLine(name2[0]);
            }
        }
    }
}