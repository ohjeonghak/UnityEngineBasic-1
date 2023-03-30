using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Wizard : Character
    {
        protected override void Breath()
        {
            Console.WriteLine("wizard 이(가) 숨을 쉰다.");
        }
    }
}
