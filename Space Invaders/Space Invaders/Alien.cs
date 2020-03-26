using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Alien{
        private int type; // 1 = small, 2 = medium, 3 = large
        private int state = 1; // 1 = alive, 0 = dead
        private Image alienImage;

        public Alien() {

        }
        public Alien(int t, Image i) {
            type = t;
            alienImage = i;
        }

        public void SetImage(Image i) {
            alienImage = i;
        }

        public void SetState(int s) {
            if (s == 0) {
                state = s;
            }
        }

        public int GetAlienType() {
            return type;
        }

        public Image GetImage() {
            return alienImage;
        }

        public int GetState() {
            return state;
        }
    }
}
