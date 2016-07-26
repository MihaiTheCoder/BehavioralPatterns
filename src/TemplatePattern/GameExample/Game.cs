using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.GameExample
{
    /// <summary>
    /// Framework/Abstract class
    /// </summary>
    public abstract class Game
    {
        protected abstract void InitGame();

        protected abstract void StartGame();

        protected abstract void EndGame();
        
        public void Play()
        {
            InitGame();
            StartGame();
            EndGame();
        }        

    }
}
