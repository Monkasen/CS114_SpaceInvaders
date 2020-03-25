using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Alien{
        private int type; // 1 = small, 2 = medium, 3 = large
        private int state = 1; // 1 = alive, 0 = dead

        public Alien() {

        }
        public Alien(int t) {
            type = t;
        }

        public void SetState(int s) {
            if (s == 0) {
                state = s;
            }
        }
    }
}
