using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Magician
    {
        private float _mana;

        //Calls the default constructor for the wizard, and then calls the base classes constructor.
        public Magician() : base()
        {
            _mana = 100;
        }

        public Magician(float healthVal, string nameVal, float damageVal, float manaVal)
            
        {
            _mana = manaVal;
        }

        
    }
}

