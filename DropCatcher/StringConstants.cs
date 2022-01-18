using System;
using System.Collections.Generic;
using System.Text;

namespace DropCatcher
{
    public class StringConstants
    {
        public static class TargetDivs
        {
            public static readonly string YuyuteiMarvelMR = "//li[@class='card_unit rarity_MR']  ";
            public static readonly string YuyuteiKadokawaSP = "//li[@class='card_unit rarity_SP']  ";
            public static readonly string YuyuteiKadokawaSBR = "//li[@class='card_unit rarity_SBR']  ";
            public static readonly string YuyuteiKadokawaRRR = "//li[@class='card_unit rarity_RRR']  ";
        }

        public static class TargetUrls
        {
            public static readonly string YuyuteiMarvel = "https://yuyu-tei.jp/game_ws/sell/sell_price.php?ver=mar&menu=newest";
            public static readonly string YuyuteiKadokawa = "https://yuyu-tei.jp/game_ws/sell/sell_price.php?name=&vers%5B%5D=kadokawas&rare=&type=&kizu=0";
        }
    }
}
