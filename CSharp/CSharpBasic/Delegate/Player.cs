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
                if (value <= _hpMin)
                    OnHpMin?.Invoke();
                OnHpChanged?.Invoke(value); //null check : ?.invoke 대리자에 등록된 함수가 없을경우 호출하지 않는 구문
            }
        }
        private int _hp;
        private int _hpMax = 100;
        private int _hpMin = 0;
        //public delegate void HpChangedHandler(int hp);
        //public event HpChangedHandler OnHpChanged; //event 한정자 : 대리자를 외부 클래스에서 직접 호출하거나 invoke할 수 없도록 제한
        public event Action<int> OnHpChanged;
        public event Action OnHpMin;
        private PlayerUI _playerUI;

        //public delegate void SamethingHandler(int a, int b); //delegate로 파라미터 여러개받을 때는 이렇게 따로 또 만듦
        //public SamethingHandler OnSomehow;

        // Generic - 컴파일할 때 타입이 새로 정의됨
        public Action<int, int> action; //반환 타입이 없음. 파라미터는 0개~16개까지 정의되어있음 받고싶은 파라미터 <> 안에 쓰기
        public Func<int, float> func; //반환 타입이 있음. <>안에 파라미터 먼저 반환하고싶은 타입은 맨 마지막에(out)
        public Predicate<int> predicate; //반환 타입이 bool, 파라미터 1개~16개, 특정 대상에 대해 조건을 비교할 때 사용

        public Player()
        {
            _hp = _hpMax;
        }
        
    }
}
