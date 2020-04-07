using SpaceInvaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SpaceInvaders {
    class Player {
        public Player()
        {
        }
        
        private int type; // 1 = small, 2 = medium, 3 = large
        private int state = 1; // 1 = alive, 0 = dead
        private Image playerImage;
        private bool isShoot; //holds whether player is currently shooting
        private int xPos; //holds x position of player
        private int yPos; //hold y position of player

        public Player(Image i)
        {
            playerImage = i;
        }

        public void SetImage(Image i) //sets current sprite of player
        {
            playerImage = i;
        }

        public void SetState(int s) //sets dead or alive state
        {
            if (s == 0)
            {
                state = s;
            }
        }

        public bool IsFired() //checks if the player if firing
        {
            return (isShoot);
        }

        public void Fire(bool fireState) //fires a projectile
        {
                isShoot = fireState;
        }

        public int GetPos(char dim) //gets the position of one dimension
        {
            if (dim == 'x')
                return (xPos);
            else
                return (yPos);
        }

        public void SetPos(int pos, char dim) //sets the position of one dimension
        {
            if (dim == 'x')
                xPos = pos;
            else
                yPos = pos;
        }
    }
}
