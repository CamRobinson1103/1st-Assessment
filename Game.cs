using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Game
    {
        private bool _gameOver;
        private Player _player;
        private Shop _shop;
        //Run the game
        public void Run()
        {
            
        }

        //Performed once when the game begins
        public void Start()
        {
            while (_gameOver == false)
            {
                Update();
            }
        }

        //Repeated until the game ends
        public void Update()
        {
            
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
