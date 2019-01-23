using ConsoleUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaZaposlenika
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<Zaposlenik> zaposlenici = kreirajInicijalnePodatke();
            List<Zaposlenik> zaIspis = new List<Zaposlenik>();

            ConsoleKeyInfo izbor;

            do
            {
                prikaziIzbornik();
                izbor = Console.ReadKey(true);                

                switch (izbor.Key.ToString())
                {
                    case "F1":
                        zaposlenici.Add(dodajZaposlenika());
                        Console.WriteLine("\nUspješno ste dodali novog zaposlenika.");
                        pricekajPotvrduZaNastavak();                                             
                        break;
                    case "F2":
                        ažurirajZaposlenika(zaposlenici);
                        Console.WriteLine("\nUspješno ste ažurirali zaposlenika.");
                        pricekajPotvrduZaNastavak();
                        break;
                    case "F3":
                        prekiniRadniOdnos(zaposlenici);
                        Console.WriteLine("\nUspješno ste izvršili prekid radnog odnosa zaposlenika.");
                        pricekajPotvrduZaNastavak();
                        break;
                    case "F4":
                        ispisiZaposlenike(zaposlenici);
                        pricekajPotvrduZaNastavak();
                        break;
                    case "F5":
                        zaIspis.Clear();                       
                        foreach (Zaposlenik zaposlenik in zaposlenici)
                        {
                            if (zaposlenik.getDatumPrekidaZaposlenja() == default(DateTime))
                            {
                                zaIspis.Add(zaposlenik);
                            }
                        }
                        ispisiZaposlenike(zaIspis);
                        pricekajPotvrduZaNastavak();
                        break;
                    case "F6":
                        zaIspis.Clear();                       
                        foreach (Zaposlenik zaposlenik in zaposlenici)
                        {
                            if (zaposlenik.getDatumPrekidaZaposlenja() != default(DateTime))
                            {
                                zaIspis.Add(zaposlenik);
                            }
                        }
                        ispisiZaposlenike(zaIspis);
                        pricekajPotvrduZaNastavak();
                        break;
                    case "F12":
                        break;
                    default:
                        Console.WriteLine("Izabrali ste radnju koja ne postoji.");
                        pricekajPotvrduZaNastavak();
                        break;                      
                }               
                
            } while (izbor.Key.ToString() != "F12");
            
            Console.WriteLine();
            Console.WriteLine("Hvala na korištenju!");
            Console.WriteLine();
        }

        private static void pricekajPotvrduZaNastavak()
        {
            Console.WriteLine();
            Console.WriteLine("Stisnite bilo koju tipku za nastavak.");
            Console.ReadLine();
            Console.Clear();
        }

        private static void prekiniRadniOdnos(List<Zaposlenik> zaposlenici)
        {
            Console.WriteLine();
            Console.WriteLine("PREKID RADNOG ODNOSA ZAPOSLENIKA");
            int counter = 1;

            foreach (Zaposlenik zaposlenik in zaposlenici)
            {
                Console.WriteLine("{0}. {1} {2}", counter, zaposlenik.getIme(), zaposlenik.getPrezime());
                counter++;
            }

            Console.WriteLine();
            Console.Write("Izaberite redni broj zaposlenika kojem želite prekinuti radni odnos: ");
            int i;
            int.TryParse(Console.ReadLine(), out i);

            Console.WriteLine("Datum zasnivanja radnog odnosa odabranog zaposlenika je: " + zaposlenici[i - 1].getDatumZaposlenja().ToString("dd.MM.yyyy"));
            Console.WriteLine("Unosite datum prekida radnog odnosa: ");
            int dan, mjesec, godina;
            Console.Write("Dan: ");
            int.TryParse(Console.ReadLine(), out dan);
            Console.Write("Mjesec: ");
            int.TryParse(Console.ReadLine(), out mjesec);
            Console.Write("Godina: ");
            int.TryParse(Console.ReadLine(), out godina);
            zaposlenici[i - 1].setDatumPrekidaZaposlenja(new DateTime(godina, mjesec, dan));
        }

        private static void ažurirajZaposlenika(List<Zaposlenik> zaposlenici)
        {
            Console.WriteLine();
            Console.WriteLine("AŽURIRANJE ZAPOSLENIKA");            
            int counter = 1;

            foreach (Zaposlenik zaposlenik in zaposlenici)
            {
                Console.WriteLine("{0}. {1} {2}", counter, zaposlenik.getIme(), zaposlenik.getPrezime());
                counter++;
            }

            Console.WriteLine();
            Console.Write("Izaberite redni broj zaposlenika kojeg želite ažurirati: ");
            int i;
            int.TryParse(Console.ReadLine(), out i);

            Console.WriteLine("\nIme: " + zaposlenici[i-1].getIme());
            Console.Write("Izmjeniti ime (D/N)? ");
            if (Console.ReadLine().ToUpper() == "D")
            {
                Console.Write("Novo ime: ");
                zaposlenici[i - 1].setIme(Console.ReadLine());
            }

            Console.WriteLine("\nPrezime: " + zaposlenici[i - 1].getPrezime());
            Console.Write("Izmjeniti prezime (D/N)? ");
            if (Console.ReadLine().ToUpper() == "D")
            {
                Console.Write("Novo prezime: ");
                zaposlenici[i - 1].setPrezime(Console.ReadLine());
            }

            Console.WriteLine("\nOIB: " + zaposlenici[i - 1].getOIB());
            Console.Write("Izmjeniti oib (D/N)? ");
            if (Console.ReadLine().ToUpper() == "D")
            {
                bool isOK = true;
                string newOIB;
                do
                {
                    Console.Write("Novi OIB: ");
                    newOIB = Console.ReadLine();
                    isOK = validateOIB(newOIB);
                    if (!isOK)
                    {
                        Console.WriteLine("Krivi unos. OIB mora imati 11 znakova i samo brojke.");
                    }
                } while (!isOK);
                zaposlenici[i - 1].setOIB(newOIB);
            }

            Console.WriteLine("\nRadno mjesto: " + zaposlenici[i - 1].getNazivRadnogMjesta());
            Console.Write("Izmjeniti radno mjesto (D/N)? ");
            if (Console.ReadLine().ToUpper() == "D")
            {
                Console.Write("Novo radno mjesto: ");
                zaposlenici[i - 1].setNazivRadnogMjesta(Console.ReadLine());
            }

            Console.WriteLine("\nDatum zaposlenja: " + zaposlenici[i - 1].getDatumZaposlenja().ToString("dd.MM.yyyy"));
            Console.Write("Izmjeniti datum zaposlenja (D/N)? ");
            if (Console.ReadLine().ToUpper() == "D")
            {
                Console.WriteLine("Unosite novi datum zaposlenja: ");
                int dan, mjesec, godina;
                Console.Write("Dan: ");
                int.TryParse(Console.ReadLine(), out dan);
                Console.Write("Mjesec: ");
                int.TryParse(Console.ReadLine(), out mjesec);
                Console.Write("Godina: ");
                int.TryParse(Console.ReadLine(), out godina);
                zaposlenici[i - 1].setDatumZaposlenja(new DateTime(godina, mjesec, dan));
            }
        }

        private static Zaposlenik dodajZaposlenika()
        {
            bool isOK = true;          
            string ime;
            string prezime;
            string oib;
            string radnoMjesto;
            do
            {
                Console.WriteLine();
                Console.WriteLine("UNOS NOVOG ZAPOSLENIKA");
                Console.Write("Ime: ");
                ime = Console.ReadLine();
                Console.Write("Prezime: ");
                prezime = Console.ReadLine();
                Console.Write("OIB: ");
                oib = Console.ReadLine();
                isOK = validateOIB(oib);                
                Console.Write("Naziv radnog mjesta: ");
                radnoMjesto = Console.ReadLine();

                if (!isOK)
                {
                    Console.WriteLine("Krivi unos. OIB mora imati 11 znakova i samo brojke.");
                }

            } while (!isOK);

            return 
                new Zaposlenik(ime, prezime, oib, radnoMjesto, DateTime.Now);
        }

        private static bool validateOIB(string oib)
        {
            if (oib.Length == 11 && oib.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;     
            }
        }

        private static void prikaziIzbornik()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------- EVIDENCIJA ZAPOSLENIKA ---------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine();                  
            Console.WriteLine("Izaberite željenu radnju: ");
            Console.WriteLine("F1 - dodavanje novog zaposlenika");
            Console.WriteLine("F2 - ažuriranje postojećeg zaposlenika");
            Console.WriteLine("F3 - prekidanje radnog odnosa zaposlenika");
            Console.WriteLine("F4 - ispis svih zaposlenika");
            Console.WriteLine("F5 - ispis aktivnih zaposlenika");
            Console.WriteLine("F6 - ispis zaposlenika sa prekinutim radnim odonosom");
            Console.WriteLine("F12 - izlaz");
            Console.WriteLine("---------------------------------------");            
        }

        private static List<Zaposlenik> kreirajInicijalnePodatke()
        {
            Zaposlenik zaposlenik1 = new Zaposlenik("Pero", "Perić", "20503306112", "Direktor", new DateTime(2015, 01, 01));
            Zaposlenik zaposlenik2 = new Zaposlenik("Ivan", "Ivić", "48842128182", "Voditelj", new DateTime(2015, 02, 01));
            Zaposlenik zaposlenik3 = new Zaposlenik("Goran", "Goranović", "77540369702", "Poslovođa", new DateTime(2015, 03, 01));
            Zaposlenik zaposlenik4 = new Zaposlenik("Marko", "Marković", "19290518606", "Radnik", new DateTime(2015, 04, 01));
            Zaposlenik zaposlenik5 = new Zaposlenik("Jovanka", "Jović", "46292311684", "Radnica", new DateTime(2015, 04, 01));

            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            zaposlenici.Add(zaposlenik1);
            zaposlenici.Add(zaposlenik2);
            zaposlenici.Add(zaposlenik3);
            zaposlenici.Add(zaposlenik4);
            zaposlenici.Add(zaposlenik5);

            return zaposlenici;                 
        }

        private static void ispisiZaposlenike(List<Zaposlenik> zaposlenici)
        {
            ConsoleTableSettings settings = new ConsoleTableSettings('|', '-');
            ConsoleTable table = new ConsoleTable(new[] { "IME PREZIME", "OIB", "RADNO MJESTO", "DATUM ZAPOSLENJA", "DATUM PREKIDA ZAPOSLENJA" }, settings);
            
            foreach (Zaposlenik zaposlenik in zaposlenici)
            {
                string imePrezime = zaposlenik.getIme() + " " + zaposlenik.getPrezime();
                string datumZaposlenja = zaposlenik.getDatumZaposlenja().ToString("dd.MM.yyyy");
                string datumPrekidaZaposlenja;
                if (zaposlenik.getDatumPrekidaZaposlenja() == default(DateTime))
                {
                    datumPrekidaZaposlenja = "";
                }
                else
                {
                    datumPrekidaZaposlenja = zaposlenik.getDatumPrekidaZaposlenja().ToString("dd.MM.yyyy");
                }

                table.AddRow(new[] {imePrezime, zaposlenik.getOIB(), zaposlenik.getNazivRadnogMjesta(), datumZaposlenja, datumPrekidaZaposlenja });

            }
            table.WriteToConsole();
        }
 
    }
}
