using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class BuyItem
    {

        public int Liquidation(int id, int ownGold)
        {
            switch (id)
            {
                case 1: //いしころ
                    if (ownGold >= 1500) ownGold -= 1500;
                    break;
                case 2: //パジュラ
                    if (ownGold >= 200) ownGold -= 200;
                    break;
                case 3: //靴
                    if (ownGold >= 100) ownGold -= 100;
                    break;
                case 4: //この店の敷物
                    if (ownGold >= 398000) ownGold -= 398000;
                    break;
                case 5: //お食事券
                    if (ownGold >= 500) ownGold -= 500;
                    break;
            }

            return ownGold;
        }
    }
}
