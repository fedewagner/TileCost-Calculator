using System.Runtime.Intrinsics.X86;

namespace TileCost_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double scrap_rate = 0.10; //assumption for circular calculations
            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr.
            const double labor_cost_per_area_per_hour = 86.0 / 20.0; //[$/(feet^2*hr)]
            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr. => Flooring performance = 20 feet2/hr
            const double flooring_team_performance = 20; //[feet^2/hr]
            const string rectangular_string = "rectangular";
            const string circular_string = "circular";

            string surfaceShape;

            //Team cost in [$/(feet^2*hr)]
            Console.WriteLine($"Debugging line | laborCostPerAreaPerHour = {labor_cost_per_area_per_hour}");

            do
            {
                //Pick a shape (rectangular or circular)
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Do you want a 'rectangular' or 'circular' surface flooring?");
                surfaceShape = Console.ReadLine();
                if (surfaceShape != rectangular_string && surfaceShape != circular_string)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to enter 'rectangular' or 'circular'.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (surfaceShape != rectangular_string && surfaceShape != circular_string);

            Console.ForegroundColor = ConsoleColor.White;

            double width;
            double length;
            double costPerUnitFlooring;
            double materialCost;
            double surface;
            double flooringTeamCost;
            double flooringTime;
            double requiredFlooringTime;
            double totalCost;
            double radious;

            {
                if (surfaceShape == rectangular_string)
                {
                    //Calculate surface asking different dimensions(Radius => surface pi*Radious^2)
                    //add 10% extra in material calculation for scrap and extra work
                    //ask width, length and specific cost;
                    Console.Write("Enter width in [feet]: ");
                    width = double.Parse(Console.ReadLine());
                    Console.Write("Enter length in [feet]: ");
                    length = double.Parse(Console.ReadLine());
                    Console.Write("Enter cost per flooring unit in [$/feet^2]: ");
                    costPerUnitFlooring = double.Parse(Console.ReadLine());

                    //shape related calculations;
                    surface = width * length;
                    materialCost = costPerUnitFlooring * surface;
                }
                else
                {
                    //Calculate surface asking different dimensions(Radius => surface pi*Radious^2)
                    //add 10% extra in material calculation for scrap and extra work
                    //ask width, length and specific cost;
                    Console.Write("Enter circular radious in [feet]: ");
                    radious = double.Parse(Console.ReadLine());
                    Console.Write("Enter cost per flooring unit in [$/feet^2]: ");
                    costPerUnitFlooring = double.Parse(Console.ReadLine());

                    //shape related calculations;
                    surface = Double.Pi * Math.Pow(radious, 2.0);
                    materialCost = costPerUnitFlooring * surface * (1 + scrap_rate);
                }

                //independent calculations and printing
                requiredFlooringTime = surface / flooring_team_performance; //[hr]
                //Labor specific cost [$/(feet^2*hr)] * [feet^2] * [hr] = [$]
                flooringTeamCost = labor_cost_per_area_per_hour * surface * requiredFlooringTime;

                //print results;
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Total surface to cover: {System.Math.Round(surface, 2)} [feet^2]");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Material cost: {System.Math.Round(materialCost, 2)} [$]");
                Console.WriteLine($"Flooring team cost: {System.Math.Round(flooringTeamCost, 2)} [$]");
                Console.WriteLine("------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Total cost ====>: {System.Math.Round(flooringTeamCost + materialCost, 2)} [$]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Required flooring time: {System.Math.Round(requiredFlooringTime, 2)} [hr]");
            }
        }
    }
}