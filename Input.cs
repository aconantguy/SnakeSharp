using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace SnakeGame
{
    internal class Input
    {
        private static System.Collections.Hashtable keyTable = new System.Collections.Hashtable();

        public static bool KeyPress(System.Windows.Forms.Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }

            return (bool)keyTable[key];
        }

        public static void changeState(System.Windows.Forms.Keys key, bool state)
        {
            keyTable[key] = state;
        }

    }
}
