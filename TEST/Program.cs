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
            List<MoyenDeTransport> list = new List<MoyenDeTransport>();

            TransportMarin transportMarin = new TransportMarin("Bateau", 500, (float)10.5, "WaterBoat", "Ferry");
            TransportAerien transportAerien = new TransportAerien("Avion", 600, (float)100.7, "PowerPlane", "AirBus978");
            Voiture voiture = new Voiture("Audi", 6, (float)50.2, "CabrioletA3", "Essence", 3);
            Train train = new Train("Thalys", 560, (float)900.5, "TGV");
            Autocar autocar = new Autocar("Leonard", 100, (float)50.6, "R203", "Diesel");

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
            Console.ReadLine();

        }
    }
}
