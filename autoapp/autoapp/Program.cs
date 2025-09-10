using autoapp;
using System.Net.Http.Headers;

List<Auto> adatok = new List<Auto>();
string[] tomb = File.ReadAllLines("autok.csv");
foreach (string sor in tomb.Skip(1))
{
    adatok.Add(new Auto(sor));

}
Console.WriteLine("5. feladat: {0} db autót tároltunk el az állományban.",adatok.Count);
int eladottosz = 0;
int db = 0;
foreach (Auto sor in adatok)
{
   if(sor.eladottdbszam != 0)
    {
        eladottosz += sor.eladottdbszam;
        db++;
    }

}
int ossz = eladottosz / db;
Console.WriteLine("6. feladat: Átlagosan {0} db autót adtak el.", Math.Round((double)ossz), 1);
Console.WriteLine("7. feladat: Elmúlt 5 évben eladott járművek");

int ev = DateTime.Now.Year - 1;
int eladott = ev - 5;
foreach (Auto sor in adatok)
{
    if(sor.gyartasev >= eladott)
    {
        Console.WriteLine(" - " + sor.marka + " " + sor.modell + " " + sor.gyartasev);
    }
    
}
Console.WriteLine("8. feladatat: Legsikeresebb márkák listája az eladott darabszám alapján.");
Dictionary<string, int> utso = new Dictionary<string, int>();
foreach (Auto sor in adatok)
{
    if (sor.eladottdbszam != 0)
    {
        if (utso.ContainsKey(sor.marka))
        {
           utso[sor.marka] += sor.eladottdbszam;
        }
        else
        {
            utso.Add(sor.marka, sor.eladottdbszam);
        }
    }
}

foreach (var e in utso.OrderByDescending(x =>x.Value)){
    Console.WriteLine("- {0} {1} db ", e.Key,e.Value);
}
