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
            };
        }

        public static YuyuteiProduct[] GetKadokawaChaseProducts()
        {
            return new YuyuteiProduct[]
            {
                MioSP,
                YukiSBR,
                MioRRR,
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
        #endregion

        #region Kadokawa
        public readonly static YuyuteiProduct MioSP = new(id: "Sst/W62-051SP", explanation: "Mio SP");
        public readonly static YuyuteiProduct YukiSBR = new(id: "Sst/W62-056SBR", explanation: "Yuki SBR");
        public readonly static YuyuteiProduct MioRRR = new(id: "Sst/W62-071R", explanation: "Mio RRR");
        #endregion
        #endregion
    }
}
