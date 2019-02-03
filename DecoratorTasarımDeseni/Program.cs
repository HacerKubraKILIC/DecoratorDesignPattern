using System;

namespace DecoratorOrnek
{

    public abstract class Pizza
    {
        protected string fiyat;

        public string Fiyat
        {
            get { return fiyat; }
            set { fiyat = value; }
        }

        public Pizza()
        {
            this.fiyat = "20 tl";
        }

        public Pizza(string fiyat)
        {
            this.fiyat = fiyat;
        }

        public abstract void Render();
    }

    public class BüyükBoy : Pizza
    {
        public BüyükBoy()
        {
        }

        public BüyükBoy(string fiyat)
            : base(fiyat)
        {
        }

        public override void Render()
        {
            Console.WriteLine("{0} pizza siparişi verildi", fiyat);
        }
    }

    public class OrtaBoy : Pizza
    {
        public OrtaBoy()
        {
        }

        public OrtaBoy(string fiyat)
            : base(fiyat)
        {
        }

        public override void Render()
        {
            Console.WriteLine("{0} pizza siparişi verildi", fiyat);
        }
    }


    public abstract class PizzaDecorator : Pizza
    {
        private Pizza tPizza;

        public Pizza TPizza
        {
            get { return tPizza; }
            set { tPizza = value; }
        }

        public PizzaDecorator(Pizza tPizza, string fiyat)
        {
            this.tPizza = tPizza;
            this.tPizza.Fiyat = fiyat;
        }
    }

    public class InceEkmek : PizzaDecorator
    {
        public InceEkmek(Pizza pizza, string fiyat)
            : base(pizza, fiyat)
        {
        }

        public override void Render()
        {
            this.TPizza.Render();
        }

        public void ScrollBy(int amount)
        {
            Console.WriteLine("{0}  ince ekmek siparişi verildi",
                TPizza.Fiyat, amount);
            Render();
        }
    }

    public class SarımsakKenar : PizzaDecorator
    {
        public SarımsakKenar(Pizza pizza, string fiyat)
            : base(pizza, fiyat)
        {
        }

        public override void Render()
        {
            this.TPizza.Render();
        }

        public void SetTheme(String name)
        {
            Console.WriteLine("{0} sarımsak kenar siparişi verildi.",
                TPizza.Fiyat, name);
            Render();
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pizza wnd1 = new BüyükBoy("Sipariş varildi");     
            Pizza wnd2 = new OrtaBoy("Seçenekler üzerine fiyat hesaplandı");   
            Pizza wnd3 = new OrtaBoy("Sipariş hazır"); 
            InceEkmek decorator1 = new InceEkmek(wnd2, "Stok Raporu Ekranı");
            SarımsakKenar decorator2 = new SarımsakKenar(wnd1, "Sipariş varildi");
            SarımsakKenar decorator3 = new SarımsakKenar(wnd3, "Sipariş hazır");
            SarımsakKenar decorator4 = new SarımsakKenar(wnd2, "Seçenekler üzerine fiyat hesaplandı");

            decorator1.ScrollBy(5);
            decorator2.SetTheme("İnce kanar");
            decorator3.SetTheme("Sarımsak kanar");
            decorator4.SetTheme("ince ekmak");
            Console.ReadKey();
        }
    }
}
