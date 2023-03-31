using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Goblin : Monster, IAttackable
    {
        public int AttackPower
        {
            get
            {
                return _attackPower;
            }
        }
        private int _attackPower;

        public Goblin(int hp, int attackPower)
            :base(hp) // base 키워드 : 상위타입 참조 (base()하면 기본생성자 참조하겠다는 뜻)
        {
           this._attackPower= attackPower;
        }

        public void Attack(IDamageable target)
        {
            target.Damage(this, _attackPower);
        }

        protected override void Breath()
        {
            Console.WriteLine("Goblin 이(가) 숨을 쉰다.");
        }
    }
}
