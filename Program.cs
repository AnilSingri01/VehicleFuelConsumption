using System;
using System.IO;

namespace VehicleConsumption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading Vehicle Meta data information");
            string[] fileLines = File.ReadAllLines(@"C:\Downloads\Vehicle Fuel Consumption.txt");
            double priceperLitre = 0.0;
            if (args.Length > 0)
            {
                priceperLitre = Convert.ToDouble(args[0]);
            }
            else
            {
                Console.WriteLine("Enter the cost for fuel per litre");
                priceperLitre = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Price Per Litre {0}", priceperLitre);
                Console.WriteLine();
            }
            //Read all the lines
            foreach (var line in fileLines)
            {
                if (line == fileLines[0])
                {

                    Console.WriteLine("\t" + "Vehicle-----KMperLitre---LitresPerKM----MilesPerGallon----CostPerKM----CostPerMile");
                }
                else
                {
                    string[] vehicleInfo = line.Split(',');

                    if (vehicleInfo.Length >= 1)
                    {
                        var kmpl = 100 / Convert.ToDouble(vehicleInfo[1].ToString());
                        var LitresPerKM = 1 / (100 / Convert.ToDouble(vehicleInfo[1].ToString()));
                        var milespergallon = kmpl * 2.352145;
                        var costperkm = priceperLitre * LitresPerKM;
                        var costpermile = costperkm / 0.621371192;
                        
                        Console.WriteLine("\t" + vehicleInfo[0] + "------" + Math.Round(kmpl,2) + "------" + Math.Round(LitresPerKM,2) + "--------" + Math.Round(milespergallon,2) + "--------" + Math.Round(costperkm,2) + "--------" + Math.Round(costpermile,2));
                    }

                }
            }
            Console.ReadLine();
        }
    }
}
