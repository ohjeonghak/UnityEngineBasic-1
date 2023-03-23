using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    //구조체
    //사용자 정의 자료형
    //값 타입★ 메모리영역할당해서 직접 읽고씀

    // 구조체 vs 클래스
    // 1. 객체의 크기가 16 byte 초과 -> 그냥 클래스 쓰는 것을 권장
    //기본적으로 값타입 연산이 참조타입 연산보다 빠르기때문에 구조체의 연산이 빠르나,
    //크기가 16byte를 초과하게 되면 레지스터가 두번이상 값을 읽거나 써야하고, (레지 최대 16)
    //이 경우에 값타입연산으로써의 장점보다 느려진다.

    // 2. 함수인자, 복잡한 수식 등의 연산으로 인해 값의 전달이 빈번하게 일어날 경우 구조체를 선택

    // 기본적으로 실수는 double 씀
    // 게임엔진에서는 double보다는 float 사용함. 벡터 등 연산할 때 크기 줄어들면 구조체 사용가능해서
    // 축에 대한 연산 많이함 x,y,z축

    public struct Stats
    {
        //멤버 변수
        public int STR;
        public int DEX;
        public int INT;
        public int LUK;

        //멤버 함수
        public int GetCombotPower()
        {
            return STR + DEX + INT + LUK;
        }
    }
}
