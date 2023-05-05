using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SutdaGame
{
    internal class Player
    {
        //이름
        //카드 배열
        //땡잡이 유무?
        //광땡 유무?
        //점수
        //concat

        public string name;
        List<string> _cards = new List<string>();
        bool _ddaengWin;
        bool _guangWin;
        string _concatCard;
        int _score;

        public List<string> Cards
        {
            get
            {
                return _cards;
            }
            set
            {
                _cards = value;
               
            }
        }

        public bool DdaengWin
        {
            get
            {
                return _ddaengWin;
            }
            set
            {
                _ddaengWin = value;
            }
        }

        public bool GuangWin
        {
            get
            {
                return _guangWin;
            }
            set
            {
                _guangWin = value;
            }
        }

        public string Concat
        {
            get
            {
                return _concatCard;
            }
            set
            {
                _concatCard = value;
            }
        }

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }



    }
}
