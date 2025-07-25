﻿using System.Runtime.Intrinsics.X86;

namespace TileCost_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double SCRAP_RATE = 0.10; //assumption for circular calculations
            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr.
            const double LABOR_COST_PER_AREA_PER_HOUR = 86.0 / 20.0; //[$/(feet^2*hr)]
            //can only put in 20 square feet of flooring per hour at a cost of $86.00/hr. => Flooring performance = 20 feet2/hr
            const double FLOORING_TEAM_PERFORMANCE = 20; //[feet^2/hr]
            const string RECTANGULAR_STRING = "rectangular";
            const string CIRCULAR_STRING = "circular";

            string surfaceShape;

            //Team cost in [$/(feet^2*hr)]
            Console.WriteLine($"Debugging line | laborCostPerAreaPerHour = {LABOR_COST_PER_AREA_PER_HOUR}");

            do
            {
                //Pick a shape (rectangular or circular)
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Do you want a 'rectangular' or 'circular' surface flooring?");
                surfaceShape = Console.ReadLine();
                if (surfaceShape != RECTANGULAR_STRING && surfaceShape != CIRCULAR_STRING)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to enter 'rectangular' or 'circular'.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (surfaceShape != RECTANGULAR_STRING && surfaceShape != CIRCULAR_STRING);

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
                if (surfaceShape == RECTANGULAR_STRING)
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
                    materialCost = costPerUnitFlooring * surface * (1 + SCRAP_RATE);
                }

                //independent calculations and printing
                requiredFlooringTime = surface / FLOORING_TEAM_PERFORMANCE; //[hr]
                //Labor specific cost [$/(feet^2*hr)] * [feet^2] * [hr] = [$]
                flooringTeamCost = LABOR_COST_PER_AREA_PER_HOUR * surface * requiredFlooringTime;

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