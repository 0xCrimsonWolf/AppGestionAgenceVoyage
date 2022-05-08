using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TEST
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*List<MoyenDeTransport> list = new List<MoyenDeTransport>();

            TransportMarin transportMarin = new TransportMarin("Bateau", 500, (float)10.5, "Diesel", "Default", "WaterBoat", "Ferry");
            TransportAerien transportAerien = new TransportAerien("Avion", 600, (float)100.7, "Kérozène", "Default",  "PowerPlane", "Airbus789");
            TransportTerrestre voiture = new TransportTerrestre("Audi", 6, (float)50.2, "Essence", "Default",  "Cabriolet", "Voiture");
            TransportTerrestre train = new TransportTerrestre("Thalys", 560, (float)900.5, "Electrique", "Default", "TGV", "Train");
            TransportTerrestre autocar = new TransportTerrestre("Leonard", 100, (float)50.6, "Diesel", "Default", "AR301", "Autocar");

            list.Add(transportMarin);
            list.Add(transportAerien);
            list.Add(autocar);
            list.Add(train);
            list.Add(voiture);

            Console.WriteLine(list[1].GetType()+ "\n");

            Console.WriteLine(transportMarin.ToString());
            Console.WriteLine(transportAerien.ToString());
            Console.WriteLine(voiture.ToString());
            Console.WriteLine(train.ToString());
            Console.WriteLine(autocar.ToString());
            Console.ReadLine();*/


            Logement villa = new Logement("Ville", "Villa De la Rosa", "Rue du Vieux Bac 17/3", 5, "Bonsoir !");
            Console.WriteLine(villa.ToString());
            Console.ReadLine();
        }
    }
}
