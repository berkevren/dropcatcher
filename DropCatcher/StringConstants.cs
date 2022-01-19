namespace DropCatcher
{
    public class StringConstants
    {
        public static class EmailAddresses
        {
            public const string Berkzeguet = "berkzeguet@hotmail.com";
            public const string BerkzeguetPassword = "=,E':'_w*VWKg8B";
            public const string BerkAbbasoglu = "berkabbasoglu@hotmail.com";
            public const string CemEkm = "cemekmekcioglu@icloud.com";
        }
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
