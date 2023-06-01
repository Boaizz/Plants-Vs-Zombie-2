using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram.Cards
{
    public class Card : GameObject //card for seed
    {
        private int _sunCost;
        public Card(string name, string filename) : base(name, filename)
        {
        }

        public int SunCost
        {
            get
            {
                return _sunCost;
            }
            set
            {
                _sunCost = value;
            }
        }
    }
}
