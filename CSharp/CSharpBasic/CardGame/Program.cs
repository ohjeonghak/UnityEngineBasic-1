// 카드 A(6으로 저장) 7 8 9 10 J(11) Q(12) K(13)
// 클로버(c), 다이아(d), 하트(h), 스페이드(s)
//                0      1      2      3      4      5      6      7
String[] dec = {"06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
                "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
                "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
                "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"};

List<String> myCard = new List<String>();

myCard.Add(dec[0]); //06c
myCard.Add(dec[8]); //06d
myCard.Add(dec[9]); //07d
myCard.Add(dec[10]); //08d
myCard.Add(dec[11]); //09d

Console.WriteLine(myCard[0].Substring(0,2));  // 문자열 나누기 : Substring(start index, length)

int a = Convert.ToInt32(myCard[0].Substring(0, 2));

