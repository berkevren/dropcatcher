namespace DropCatcher.DataModel
{
    public class YuyuteiProduct
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public YuyuteiProduct(string id, string explanation)
        {
            this.Id = id;
            this.Name = explanation;
        }

        public static YuyuteiProduct[] GetMarvelChaseProducts()
        {
            return new YuyuteiProduct[]
            {
                SpiderManMR,
                CaptainMarvelMR,
                BlackPantherMR,
                DrStrangeMR,
                ScarletWitchMR,
                BlackWidowMR,
                SpiderGwenSR,
                SpidermanSR,
                VenomSR,
                BlackPantherSR,
                WarMachineSR,
                ScarletWitchSR,
            };
        }

        public static YuyuteiProduct[] GetKadokawaChaseProducts()
        {
            return new YuyuteiProduct[]
            {
                MioSP,
                YukiSBR,
                AineSBR,
                MioRRR,
                YukiRRR,
                AineRRR,
                YumiSR,
                MariaSR,
                YukiSR,
            };
        }

        #region constants
        #region Marvel
        public readonly static YuyuteiProduct SpiderManMR = new(id: "MAR/S89-031MR", explanation: "Spiderman MR");
        public readonly static YuyuteiProduct CaptainMarvelMR = new(id: "MAR/S89-033MR", explanation: "Captain Marvel MR");
        public readonly static YuyuteiProduct BlackPantherMR = new(id: "MAR/S89-035MR", explanation: "Black Panther MR");
        public readonly static YuyuteiProduct DrStrangeMR = new(id: "MAR/S89-038MR", explanation: "Dr Strange MR");
        public readonly static YuyuteiProduct ScarletWitchMR = new(id: "MAR/S89-077MR", explanation: "Scarlet Witch MR");
        public readonly static YuyuteiProduct BlackWidowMR = new(id: "MAR/S89-042MR", explanation: "Black Widow MR");
        public readonly static YuyuteiProduct SpiderGwenSR = new(id: "MAR/S89-044S", explanation: "Spider Gwen SR");
        public readonly static YuyuteiProduct SpidermanSR = new(id: "MAR/S89-041S", explanation: "Spiderman SR");
        public readonly static YuyuteiProduct VenomSR = new(id: "MAR/S89-087S", explanation: "Venom SR");
        public readonly static YuyuteiProduct BlackPantherSR = new(id: "MAR/S89-049S", explanation: "Black Panther SR");
        public readonly static YuyuteiProduct WarMachineSR = new(id: "MAR/S89-050S", explanation: "War Machine SR");
        public readonly static YuyuteiProduct ScarletWitchSR = new(id: "MAR/S89-086S", explanation: "Scarlet Witch SR");

        #endregion

        #region Kadokawa
        public readonly static YuyuteiProduct MioSP = new(id: "Sst/W62-051SP", explanation: "Mio SP");
        public readonly static YuyuteiProduct YukiSBR = new(id: "Sst/W62-056SBR", explanation: "Yuki SBR");
        public readonly static YuyuteiProduct AineSBR = new(id: "Shh/W62-078SBR", explanation: "Aine SBR");
        public readonly static YuyuteiProduct MioRRR = new(id: "Sst/W62-071R", explanation: "Mio RRR");
        public readonly static YuyuteiProduct YukiRRR = new(id: "Sst/W62-T06R", explanation: "Yuki RRR");
        public readonly static YuyuteiProduct AineRRR = new(id: "Shh/W62-103R", explanation: "Aine RRR");
        public readonly static YuyuteiProduct YumiSR = new(id: "Sst/W62-058S", explanation: "Yumi SR");
        public readonly static YuyuteiProduct MariaSR = new(id: "Sst/W62-061S", explanation: "Maria SR");
        public readonly static YuyuteiProduct YukiSR = new(id: "Sst/W62-T09S", explanation: "Yuki SR");
        #endregion
        #endregion
    }
}
