using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //商品ID指定変数
            int itemID = 0;

            bool loop = true;
            int ownGold = 1500;

            List<int> ownItems = new List<int>();

            //ハンド番号判定ループ
            while (loop == true)
            {
                Console.Clear();

                string numStr;
                Console.WriteLine("==========================================");
                Console.WriteLine("Merchant：なんでも買ってってくれ！");
                Console.WriteLine("==========================================");
                Console.WriteLine("1,いしころ:$1,500");
                Console.WriteLine("2,パジュラ:$200");
                Console.WriteLine("3,靴:$100");
                Console.WriteLine("4,この店の敷物:$398,000");
                Console.WriteLine("5,お食事券:$500");
                Console.WriteLine("==========================================");

                foreach (int item in ownItems)
                {
                    switch (item)
                    {
                        case 1: //いしころ
                            Console.WriteLine("いしころ×" + itemNum[0,1]++);
                            break;
                        case 2: //パジュラ
                            Console.WriteLine("パジュラ×" + itemNum[0, 2]++);
                            break;
                        case 3: //靴
                            Console.WriteLine("靴×" + itemNum[0, 3]++);
                            break;
                        case 4: //この店の敷物
                            Console.WriteLine("この店の敷物×" + itemNum[0, 4]++);
                            break;
                        case 5: //お食事券
                            Console.WriteLine("お食事券×" + itemNum[0, 5]++);
                            break;
                    }
                }
                Console.Write("\n[所持金:$" + ownGold + "]商品ID(0で退出):");
                numStr = Console.ReadLine();

                if (int.TryParse(numStr, out itemID)
                    && itemID ==0)
                {
                    loop = false;
                    Console.WriteLine("退出");
                    Console.ReadLine();
                }
                    else if (int.TryParse(numStr, out itemID)
                    && (itemID >= 1 && itemID <= 5))
                { //数値以外または範囲外の文字列を入力した際、再入力
                    // 購入処理
                    BuyItem buyItem = new BuyItem();

                    // 清算結果を代入
                    int result = buyItem.Liquidation(itemID, ownGold);
                    if (result != ownGold)
                    {
                        ownGold = result;
                        ownItems.Add(itemID);
                        Console.WriteLine("売れたぞ！！！！");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("文無しかい？");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("そんなものないよ！");
                    Console.ReadLine();
                }


            }
        }
    }
}