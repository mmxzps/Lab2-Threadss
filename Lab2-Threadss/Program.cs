using Lab2_Threadss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Practicing_Ovnings
{
    internal class Program
    {
        static async Task Main(string[] args)
        {   //Enabling the using of emojis.
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Car car1 = new Car("🚗Volvo");
            Car car2 = new Car("🛺BMW");

            Console.ForegroundColor = ConsoleColor.Magenta;
            await Console.Out.WriteLineAsync("-----------------------------------------------");
            Console.WriteLine("\t  🚦The race has begun!🚦");
            await Console.Out.WriteLineAsync("-----------------------------------------------");
            Console.ResetColor();
            await Console.Out.WriteLineAsync();

            Task t1 = Task.Run(() => car1.RaceAsync());
            Task t2 = Task.Run(() => car2.RaceAsync());
            Task status = Task.Run(() => GetStatus(car1, car2));

            await Console.Out.WriteLineAsync($"{car1.Name} started💨");
            await Console.Out.WriteLineAsync($"{car2.Name} started💨");

            await Task.WhenAny(t1, t2);

            Task winner = Task.Run(() => Winner(car1, car2));
            await winner;
        }
        public static async Task GetStatus(Car car1, Car car2)
        {
            while (true)
            {
                await Console.Out.WriteLineAsync();
                await Console.Out.WriteLineAsync("👉🏾👉🏾Press enter to see status of the cars👈🏾👈🏾");
                await Console.Out.WriteLineAsync();
                Console.ReadLine();
                await Console.Out.WriteLineAsync("🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰");
                await Console.Out.WriteLineAsync($"{car1.Name} drove {car1.Distance}km at {car1.Speed}km/h, Time:{car1.Stopwatch.Elapsed.TotalSeconds:F2} seconds");
                await Console.Out.WriteLineAsync($"{car2.Name} drove {car2.Distance}km at {car2.Speed}km/h, Time:{car2.Stopwatch.Elapsed.TotalSeconds:F2} seconds");
                await Console.Out.WriteLineAsync("🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰🟰");
            }
        }
        public static async Task Winner(Car car1, Car car2)
        {
            if (car1.Stopwatch.Elapsed == car2.Stopwatch.Elapsed && car1.Distance == car2.Distance)
            {
                await Console.Out.WriteLineAsync("\n\n\n");
                await Console.Out.WriteLineAsync("Its a draw!");
                await Console.Out.WriteLineAsync("➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");
                await Console.Out.WriteLineAsync($"{car1.Name} drove {car1.Distance}km at {car1.Speed}km/h, Time:{car1.Stopwatch.Elapsed.TotalSeconds:F4} seconds");
                await Console.Out.WriteLineAsync($"{car2.Name} drove {car2.Distance}km at {car2.Speed}km/h, Time:{car2.Stopwatch.Elapsed.TotalSeconds:F4} seconds");
                await Console.Out.WriteLineAsync("➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");
            }
            else if (car1.Stopwatch.Elapsed > car2.Stopwatch.Elapsed && car1.Distance < car2.Distance)
            {
                await Console.Out.WriteLineAsync("\n\n\n");
                await Console.Out.WriteLineAsync($"🏆🏆🏆{car2.Name} Won!🏆🏆🏆");
                await Console.Out.WriteLineAsync("➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");
                await Console.Out.WriteLineAsync($"{car1.Name} drove {car1.Distance}km at {car1.Speed}km/h, Time:{car1.Stopwatch.Elapsed.TotalSeconds:F4} seconds");
                await Console.Out.WriteLineAsync($"{car2.Name} drove {car2.Distance}km at {car2.Speed}km/h, Time:{car2.Stopwatch.Elapsed.TotalSeconds:F4} seconds");
                await Console.Out.WriteLineAsync("➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");

            }
            else
            {
                await Console.Out.WriteLineAsync("\n\n\n");
                await Console.Out.WriteLineAsync($"🏆🏆🏆{car1.Name} Won!🏆🏆🏆");
                await Console.Out.WriteLineAsync("➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");
                await Console.Out.WriteLineAsync($"{car1.Name} drove {car1.Distance}km at {car1.Speed}km/h, Time:{car1.Stopwatch.Elapsed.TotalSeconds:F4} seconds");
                await Console.Out.WriteLineAsync($"{car2.Name} drove {car2.Distance}km at {car2.Speed}km/h, Time:{car2.Stopwatch.Elapsed.TotalSeconds:F4} seconds");
                await Console.Out.WriteLineAsync("➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            await Console.Out.WriteLineAsync("-----------------------------------------------");
            Console.WriteLine("\t\tRace is over!");
            await Console.Out.WriteLineAsync("-----------------------------------------------");
            Console.ResetColor();
        }
    }
}