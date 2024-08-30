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
            // 商品ID指定変数
            int itemID = 0;

            // 繰り返し判定変数
            bool loop = true;
            // 所持金
            int ownGold = 1500;

            // 所持品個数配列
            int[] itemNum = new int[5]
            {
                0,0,0,0,0
            };

            // ショップ処理
            while (loop == true)
            {
                Console.Clear();

                string numStr;
                Console.WriteLine("==========================================");
                Console.WriteLine("Merchant：なんでも買ってってくれ！");
                Console.WriteLine("==========================================");
                Console.WriteLine("1,いしころ:$1,500[所有数:" + itemNum[0] + "]");
                Console.WriteLine("2,パジュラ:$200[所有数:" + itemNum[1] + "]");
                Console.WriteLine("3,靴:$100[所有数:" + itemNum[2] + "]");
                Console.WriteLine("4,この店の敷物:$398,000[所有数:" + itemNum[3] + "]");
                Console.WriteLine("5,お食事券:$500[所有数:" + itemNum[4] + "]");
                Console.WriteLine("==========================================");
                
                Console.Write("\n[所持金:$" + ownGold + "]商品ID(0で退出):");
                numStr = Console.ReadLine();

                // 終了処理
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
                        
                        // アイテム数を加算
                        switch (itemID)
                        {
                            case 1: //いしころ
                                itemNum[0]++;
                                break;
                            case 2: //パジュラ
                                itemNum[1]++;
                                break;
                            case 3: //靴
                                itemNum[2]++;
                                break;
                            case 4: //この店の敷物
                                itemNum[3]++;
                                break;
                            case 5: //お食事券
                                itemNum[4]++;
                                break;

                            default:
                                break;
                        }
                        Console.WriteLine("Merchant：売れたぞ！！！！");
                        Console.ReadLine();
                    }
                    else // 金が足りなかった場合、処理しない
                    {
                        Console.WriteLine("Merchant：文無しかい？");
                        Console.ReadLine();
                    }
                }
                else // ID以外を入力した場合、処理しない
                {
                    Console.WriteLine("Merchant：そんなものないよ！");
                    Console.ReadLine();
                }


            }
        }
    }
}