using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//C# naming convention
//사용자정의 자료형의 이름: PascalCase (첫글자 대문자)
//public, protected, internal 멤버 변수 : PascalCase
//private 멤버 변수 : _camelCase
//지역변수 : camelCase
//함수: PascalCase



//namespace : 이름으로 메모리 공간을 식별하기위한 키워드
//일반적인 namespace 작명 : 팀/회사 이름, 기술스택이름, 기타세부카테고리

namespace ClassObjectInstance.UISystems.Characters
{
    internal class SwordMan
    {

    }
}

namespace ClassObjectInstance
{
    //클래스
    //캡슐화하기위한 사용자정의 자료형
    //추상화 : 객체들의 공통점을 추려내기
    internal class SwordMan
    {
        //접근 제한자 (Access Modifiers)
        //1. private: 외부 접근 불가능
        //2. public: 외부 접근 가능
        //3. internal: 동일 어셈블리에서 접근가능(동일 프로젝트 내에서만 접근 가능)
        //4. protected: 상속받은 자식 클래스에서만 접근 가능
        //클래스는 캡슐화를 위한 자료형이기 때문에 기본적으로 모든 멤버는 private이 디폴트
        

        //멤버 변수
        public String Name;
        public int Lv;
        //아래 Hp랑 Mp 같은내용
        public int HP { get; private set; }
        public int Mp
        {
            get
            {
                return _mp;
            }
            set
            {
                _mp = value;
            }
        }

        //프로퍼티, 일일이 getset하면 찾기 힘듦
        public float Exp
        {
            get
            {
                return _exp;
            }
            set //외부 set 접근 불가, get은 가능, get set 각각 접근지정 가능
            {
                if (value > _expMax)
                {
                    value = _expMax;
                }
                _exp = value;
            }
        }
        private int _mp;
        private float _exp;
        private float _expMax;
        private char _gender;

        //private이라서 멤버변수에게 접근할 때 get set 필요 캡슐화를 위해서
        public void setExp(float value)
        {
            if(value>_expMax)
            {
                value = _expMax;
            }
            _exp = value;
        }

        public float getExp()
        {
            //+ 현재 exp에 오류없는지 한번 검출하는 기능추가도 할 수 있음
            return _exp;
        }

        //클래스 생성자
        //정의하지 않아도 default 생성자가 생략되어있음
        //해당 클래스 타입의 객체를 힙영역에 할당하고 해당 객체의 참조를 반환★ 객체에다 주소 넣고 그 주소로 가서 넣는 방식(간접적)
        public SwordMan() {
        }

        //소멸자
        //해당 객체를 메모리영역에서 해제할 때 호출하는 함수
        ~SwordMan() {
        }

        //멤버 함수
        public void Slash()
        {
            //this 키워드 : 호출한 객체 자기자신의 참조(생략되어있었음)
            Console.WriteLine($"{this.Name} 이(가) 베기를 시전했다.");
        }
    }
}
