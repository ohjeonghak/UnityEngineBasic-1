using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Player
    {
        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                if (_hp == value)
                    return;

                _hp = value;
                //onHpChanged(value); //value를 _hp에 넣었는데 다른 스레드에서 _hp를 변경했을 수도 있음 근데 _hp넣으면 잘못된 값 들어갈 수 있어서 value넣음
                //onHpChanged.Invoke(value); //invoke는 대리자에 등록된 함수들의 RaceCondition을 방지하기위해 사용하는 함수
                onHpChanged?.Invoke(value); //null check : ?.invoke 대리자에 등록된 함수가 없을경우 호출하지 않는 구문
            }
        }
        private int _hp;
        private int _hpMax = 100;
        public delegate void HpChangedHandler(int hp);
        public HpChangedHandler onHpChanged;

        public Player()
        {
            _hp = _hpMax;
        }
        
    }
}
