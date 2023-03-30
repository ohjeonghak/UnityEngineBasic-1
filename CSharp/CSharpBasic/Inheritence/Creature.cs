using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    //abstract class : 추상 클래스. 해당 클래스는 추상을 위한 용도로 정의된 클래스이므로 객체화가 안됨
    internal abstract class Creature
    {
        public int Lv
        {
            get
            {
                return _lv;
            }
        }
        private int _lv;

        //protected : 이 클래스를 상속받는 하위 클래스(자식클래스)만 접근 가능한 제한자
        //abstract : 함수 앞에 붙으면 이 함수를 멤버로 가지는 클래스를 상속받은 자식클래스타입에서 이 함수의 구현부를 구현해야함
        protected abstract void Breath();
     
    }
}
