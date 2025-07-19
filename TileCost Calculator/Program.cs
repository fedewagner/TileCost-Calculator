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
            
            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr.
            //Team cost in [$/(feet^2*hr)]
            const double laborCostPerAreaPerHour = 86.0 / 20.0; //[$/(feet^2*hr)]
            Console.WriteLine($"Debugging line | laborCostPerAreaPerHour = {laborCostPerAreaPerHour}");
            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr. => Flooring performance = 20 feet2/hr
            const double flooringTeamPerformance = 20; //[feet^2/hr]

            //ask width, length and specific cost;
            Console.Write("Enter width in [feet]: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Enter length in [feet]: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Enter cost per flooring unit in [$/feet^2]: ");
            costPerUnitFlooring = double.Parse(Console.ReadLine());
            //calculations;
            surface = width * length;
            materialCost = costPerUnitFlooring * surface;
            requiredFlooringTime = surface / flooringTeamPerformance; //[hr]

            //Labor specific cost [$/(feet^2*hr)] * [feet^2] * [hr] = [$]
            flooringTeamCost = laborCostPerAreaPerHour * surface * requiredFlooringTime;

            //print results;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Total surface to cover: {surface} [feet^2]");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Material cost: {materialCost} [$]");
            Console.WriteLine($"Flooring team cost: {flooringTeamCost} [$]");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Total cost ====>: {flooringTeamCost + materialCost} [$]");
            Console.WriteLine($"Required flooring time: {requiredFlooringTime} [hr]");
            
        }
    }
}