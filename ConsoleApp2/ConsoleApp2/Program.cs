namespace NévTér
{
    public class Program
    {
        public static void Main(string[] args) { }
    }
    public class Osztályozó
    {
        public string Osztályoz(double életkor)
        {
            if (életkor < 0) throw new Exception("alsó hiba");     //-1 -> alsó hiba
            if (életkor < 2) return "csecsemő";                    //1 -> csecsemő
            if (életkor < 10) return "gyerek";                     //6 ->gyerek
            if (életkor < 18) return "tini";                       //15 ->tini
            if (életkor < 130) return "felnőtt";                   //64 ->felnőtt
             throw new Exception("felső hiba");                    //132 -> felső hiba


        }
    }
}