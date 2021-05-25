using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bérek2020
{
  class Feladatok
  {
	List<DolgozoAdat> adatokLista = new List<DolgozoAdat>();
	string bekertReszleg = "";
	  
	public void MasodikFeladat()
	{
	  using (StreamReader sr = new StreamReader("bérek2020.txt", Encoding.UTF8))
	  {
		sr.ReadLine();	//Fejléc átugrása
		while (!sr.EndOfStream)
		{
		  DolgozoAdat d = new DolgozoAdat();
		  string [] s = sr.ReadLine().Split(';');
		  d.nev = s[0];
		  d.nem = s[1];
		  d.reszleg = s[2];
		  d.belepes = int.Parse(s[3]);
		  d.ber = int.Parse(s[4]);
		  adatokLista.Add(d);
		}
	  }  
	}

	public void HarmadikFeladat()
	{
	  Console.WriteLine($"3. Feladat: Dolgozók száma: {adatokLista.Count} fő");  
	}

	public void NegyedikFeladat()
	{
	  Console.WriteLine($"4. Feladat: Bérek átlaga: {(double)adatokLista.Average(x => x.ber)/1000:00.0} eFt");  
	}

	public void OtodikFeladat()
	{
	  Console.Write("5. Feladat: Kérem a részleg nevét: ");  
	  bekertReszleg = Console.ReadLine();
	}

	public void HatodikFeladat()
	{
	  try
	  {
		int index = adatokLista.IndexOf(adatokLista.Where(x => x.reszleg == bekertReszleg).OrderByDescending(x => x.ber).First());
		Console.WriteLine("6. Feladat: A legtöbbet kereső dolgozó a megadott részlegen");
		Console.WriteLine($"\tNév: {adatokLista[index].nev}");
		Console.WriteLine($"\tNem: {adatokLista[index].nem}");
		Console.WriteLine($"\tBelépés: {adatokLista[index].belepes}");
		Console.WriteLine($"\tBér: {adatokLista[index].ber:### ###} Forint");
	  }
	  catch (InvalidOperationException)
	  {
		Console.WriteLine("6. Feladat: A megadott részleg nem létezik a cégnél!");
	  }
	}

	public void HetedikFeladat()
	{
	  Console.WriteLine($"7. Feladat: Statisztika");
	  adatokLista.GroupBy(x => x.reszleg).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} - {x.Count()} fő"));
	}

  }
}
