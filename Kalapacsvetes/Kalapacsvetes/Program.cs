
using Kalapacsvetes;

string[] olvas = File.ReadAllLines("kalapacsvetes.txt");

List<Sportolo> sportolok = new List<Sportolo>();

foreach (string line in olvas.Skip(1))
{
    sportolok.Add(new Sportolo(line));
}

Console.WriteLine("4. feladat: {0} dobás eredménye található.", sportolok.Count);

double sum = 0;
int db = 0;

foreach (Sportolo e in sportolok)
{
    if (e.orszagkod == "HUN")
    {
        sum += e.eredmeny;
        db++;
    }
}

Console.WriteLine("5. feladat: A magyar sportolók átlagosan {0} métert dobtak.", sum / db);

Console.WriteLine("Adj meg egy évszámot: ");
string input = (Console.ReadLine());
int darab = 0;

foreach (Sportolo e in sportolok)
{
    if (e.datum.Substring(0, 4) == input)
    {
        darab++;

    }
}
if(darab != 0)
{
    Console.WriteLine("{0} db dobás került be ebben az évben.",darab);
    foreach (Sportolo e in sportolok)
    {
        if (e.datum.Substring(0, 4) == input)
        {
            Console.WriteLine(e.sportolo);

        }
    }
}
Console.WriteLine("7. feladat: Statisztika");
Dictionary<string,int> orszagok = new Dictionary<string,int>();
foreach(Sportolo k in sportolok)
{
    if (orszagok.ContainsKey(k.orszagkod))
    {
        orszagok[k.orszagkod]++;

    }
    else
    {
        orszagok.Add(k.orszagkod, 1);
    }

}
foreach(KeyValuePair<string,int> e in orszagok)
{
    Console.WriteLine("{0} - {1} dobás",e.Key,e.Value );
}

//8.feladat
StreamWriter iras = new StreamWriter("magyarok.txt");


for(int i = 0; i <= sportolok.Count; i++)
{
    if (sportolok[i].orszagkod == "HUN")
    {
        iras.WriteLine(i);
    }
}
iras.Close();

