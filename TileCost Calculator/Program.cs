using System.Runtime.Intrinsics.X86;

namespace TileCost_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //done=> Ask the user to enter in width, length, and the cost per 1 unit of flooring.
            //done=> Have the program calculate how much it would cost to cover the area specified with the flooring.
            // Added Difficulty: Calculate how much flooring would be needed for non-rectangular rooms.
            // Also figure out how much labor costs would be given that the average flooring team
            // can only put in 20 square feet of flooring per hour at a cost of $86.00/hr.
            // Pick ONE ADDITIONAL SHAPE (triangle / circle / etc) and implement the second shape,
            // making the user select wich one they want to calculate (time for an if statement!)
            double width;
            double length;
            double surface;
            double costPerUnitFlooring;
            double materialCost;
            double flooringTeamCost;
            double flooringTime;
            double requiredFlooringTime;
            double totalCost;
            const double scrapRate = 0.10; //assumption for circular calculations
            string surfaceShape;
            double radious;

            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr.
            //Team cost in [$/(feet^2*hr)]
            const double laborCostPerAreaPerHour = 86.0 / 20.0; //[$/(feet^2*hr)]
            Console.WriteLine($"Debugging line | laborCostPerAreaPerHour = {laborCostPerAreaPerHour}");
            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr. => Flooring performance = 20 feet2/hr
            const double flooringTeamPerformance = 20; //[feet^2/hr]

            do
            {
                //Pick a shape (rectangular or circular)
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Do you want an 'rectangular' or 'circular' surface flooring?");
                surfaceShape = Console.ReadLine();
                if (surfaceShape != "rectangular" && surfaceShape != "circular")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to enter 'rectangular' or 'circular'.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (surfaceShape != "rectangular" && surfaceShape != "circular");

            Console.ForegroundColor = ConsoleColor.White;

            {
                if (surfaceShape == "rectangular")
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
                    surface =  Double.Pi * Math.Pow(radious, 2.0);
                    materialCost = costPerUnitFlooring * surface * (1 + scrapRate);
                    
                }

                //independent calculations and printing
                requiredFlooringTime = surface / flooringTeamPerformance; //[hr]
                //Labor specific cost [$/(feet^2*hr)] * [feet^2] * [hr] = [$]
                flooringTeamCost = laborCostPerAreaPerHour * surface * requiredFlooringTime;
                
                //print results;
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Total surface to cover: {System.Math.Round(surface,2)} [feet^2]");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Material cost: {System.Math.Round(materialCost,2)} [$]");
                Console.WriteLine($"Flooring team cost: {System.Math.Round(flooringTeamCost,2)} [$]");
                Console.WriteLine("------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Total cost ====>: {System.Math.Round(flooringTeamCost + materialCost,2)} [$]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Required flooring time: {System.Math.Round(requiredFlooringTime,2)} [hr]");
            }
        }
    }
}