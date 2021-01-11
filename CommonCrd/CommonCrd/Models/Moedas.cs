namespace CommonCrd.Models
{
    public class Moeda
    {
        public string SymMoeda;
        public string ExtMoeda;

        public Moeda(string symMoeda, string extMoeda)
        {
            SymMoeda = symMoeda; ExtMoeda = extMoeda;
        }
    }
}