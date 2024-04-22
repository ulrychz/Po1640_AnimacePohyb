namespace Po1640_AnimacePohyb.Models
{
    public class Postava
    {
        public Postava(string obrazek, string popisek, int sirkaObrazku) 
        { 
            Obrazek = obrazek;
            Popisek = popisek;
            SirkaObrazku = sirkaObrazku;
            AkualniPozice = -1;
        }
        private List<Souradnice> PoziceList { get; set; } = new List<Souradnice>();
        public string Obrazek { get; private set; }
        public int AkualniPozice { get; set; }
        public string Popisek { get;  }
        private int SirkaObrazku { get; set; }

        public string Style
        {
            get
            {
                if (AkualniPozice<0)
                {
                    return $"width:{SirkaObrazku}px;";
                }
                else
                {
                    var poz = PoziceList[AkualniPozice];
                    return poz.Style + $"width:{SirkaObrazku*poz.VelikostObrazku/100}px;";
                }
            }
        }

        private bool Dopredu { get; set; } = true;
        private bool HlavaVpravo { get; set; } = true;
        public string TransformRotateY => HlavaVpravo ? "transform: rotateY(0deg);" : "transform: rotateY(180deg);";
        public int Progress => (int)Math.Round((double)(AkualniPozice + 1) / PoziceList.Count * 100);
        public void PridejPozici(int pozX, int pozY, int velikostObrazku)
        {
            var souradnice = new Souradnice(pozX, pozY, velikostObrazku);
            PoziceList.Add(souradnice);
        }

        public void Presun()
        {
            if (Dopredu)
            {
                if (AkualniPozice == PoziceList.Count-1)
                {
                    Dopredu = false;
                }
            }
            else
            {
                if (AkualniPozice == 0)
                {
                    Dopredu = true;
                }
            }
            var predchoziPozice = AkualniPozice;
            if (Dopredu)
            {
                AkualniPozice++;
            }
            else
            {
                AkualniPozice--;
            }
            HlavaVpravo = predchoziPozice<0 || PoziceList[predchoziPozice].PozX < PoziceList[AkualniPozice].PozX;
        }
    }
}
