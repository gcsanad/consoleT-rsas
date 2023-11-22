namespace lud
{
    internal class Program
    {
        static void Main(string[] args)

        {   //1.Feladat
            List<Osveny> osvenyek = File.ReadAllLines("osvenyek.txt").Select(x => new Osveny(x)).ToList();
            List<int> dobasok = File.ReadAllText("dobasok.txt").Split(' ').Select(int.Parse).ToList();

            Console.WriteLine($"2.Feladat \n" +
                              $"A dobások száma: {dobasok.Count}");
            Console.WriteLine($"Az ösvények száma: {osvenyek.Count}");

            Console.WriteLine($"3.Feladat\nAz egyik leghosszabb a(z) {osvenyek.FindIndex(x => x.Beolvas.Length == osvenyek.Max(x => x.Beolvas.Length)) + 1}. ösvény, hossza: {osvenyek.Max(x => x.Beolvas.Length)}");

            Console.WriteLine("4.Feladat");
            Console.Write("\nAdja meg egy ösvény sorszámát!");
            int osvenySorszama = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("\nAdja meg a játékosok számát!");
            int jatekosokSzama = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("5.Feladat");
            string valasztottOsveny = osvenyek[osvenySorszama].Beolvas;
            Console.WriteLine($"M: {valasztottOsveny.Count(x => x == 'M')} darab\nV: {valasztottOsveny.Count(x => x == 'V')} darab\nE: {valasztottOsveny.Count(x => x == 'E')} darab");

            //6.Feladat
            //File.WriteAllText("kulonleges.txt", valasztottOsveny.Split().Select(x => $"A karakter indexe: "));
            File.WriteAllLines("kulonleges.txt", valasztottOsveny
                .Select((x, y) => new { MezoSorszama = y + 1, MezoTipus = x })
                .Where(x => x.MezoTipus != 'M')
                .Select(x => $"A mező sorszáma: {x.MezoSorszama}      A mező tipusa: {x.MezoTipus}"));

            //7.Feladat
            Console.WriteLine("7.feladat");
            int jatekosPozicioja = 0;
            int legmesszabb = dobasok.Select(x => jatekosPozicioja += x)
                .Select((x, y) => new { Pozicio = x, Korszam = y + 1 })
                .TakeWhile(x => valasztottOsveny[x.Pozicio - 1] != 'V' && x.Pozicio < valasztottOsveny.Length)
                .Last()
                .Pozicio;
            
            



        }


    }
}