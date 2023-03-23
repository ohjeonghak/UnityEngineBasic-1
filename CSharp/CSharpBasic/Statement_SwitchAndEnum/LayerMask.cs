using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statement_SwitchAndEnum
{
    //Attribute 란?
    //타입의 메타데이터를 정의하는 형태의 클래스
    //메타데이터 : 데이터의 데이터

    //flags Attribute
    //중복된 Flag들을 각 요소들에 대한 문자열로 변환해주는 기능을 가지고 있는 Attribute
    [Flags]
    public enum LayerMask
    {
        None = 0 << 0,   //....00000000
        NPC = 1 << 0,    //....00000001
        Enemy = 1 << 1,  //....00000010
        Player = 1 << 2, //....00000100
        Ground = 1 << 3, //....00001000
        Wall = 1 << 4,   //....00010000
        //EnemyNPC = NPC | Enemy //....00000011 비트별로 하나씩 주면(비트플래그) 값이 안겹침 중복X, int라서 비트 32개로만 표현가능
    }

    public enum LayerMaskDummy
    {
        None, //....00000000
        NPC, //....00000001
        Enemy, //....00000010
        Player, //....00000011
        Ground, //....00000100
        Wall, //....00000101
        //EnemyNPC = NPC | Enemy //....00000011 == LayerMaskDummy.Player
    }
}
