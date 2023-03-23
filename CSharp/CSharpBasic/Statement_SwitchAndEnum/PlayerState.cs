using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statement_SwitchAndEnum
{
    //enum 키워드
    //열거형 사용자정의 자료형을 정의할 때 사용하는 키워드(키워드=예약어)
    //기본적으로 값은 int 타입임
    public enum PlayerState
    {
        Idel,
        Move,
        Jump,
        Attack = 10,
        Skill
    }
}
