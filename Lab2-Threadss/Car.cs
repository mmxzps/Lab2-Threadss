using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2_Threadss
{
    internal class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public object lockTime { get; set; } = new object();

        public Car(string name)
        {
            Name = name;
            Speed = 12;
            Distance = 0;
            Stopwatch = Stopwatch.StartNew();
        }
        public async Task RaceAsync()
        {
            bool raceOn = true;

            while (raceOn)
            {
                //Gets problem every 3sec
                Task.Delay(3000);
                ProblemsAsync();

                if (Distance < 40)
                {
                    Distance = Distance + Speed;
                    await Task.Delay(500);
                    //So we get correct time for each car
                    lock (lockTime)
                    {
                        Stopwatch.Start();
                    }
                }
                else
                {
                    raceOn = false;
                    await Console.Out.WriteLineAsync($"=======================================================\n\n🏁🏁{Name} finished!🏁🏁");
                    Stopwatch.Stop();
                }
            }
        }
        public async Task ProblemsAsync()
        {
            Random random = new Random();
            int randomProblems = random.Next(1, 51);

            if (randomProblems == 1)
            {
                await Console.Out.WriteLineAsync($"⚠️⚠️{Name} Stopped to add gasoline, he lost 30 second! ❌⛽⏳⚠️⚠️");
                 await Console.Out.WriteLineAsync();
                Thread.Sleep(30000);
            }
            else if (randomProblems <= 3)
            {
                await Console.Out.WriteLineAsync($"⚠️⚠️{Name} Got a flat tire and changed it. He lost 20 second! 😵‍💫🛞⏳⚠️⚠️");
                await Console.Out.WriteLineAsync();
                Thread.Sleep(20000);
            }
            else if (randomProblems <= 8)
            {
                await Console.Out.WriteLineAsync($"⚠️⚠️ {Name} Hit a bird on his windshield and washed it for 10 second! 🦢🩸⏳⚠️⚠️");
                await Console.Out.WriteLineAsync();
                Thread.Sleep(10000);
            }
            else if (randomProblems <= 18)
            {
                await Console.Out.WriteLineAsync($"⚠️⚠️{Name} Have engine problem, his speed reduced by 1 km/h.🔧🆘⚠️⚠️");
                await Console.Out.WriteLineAsync();
                Speed--;
            }

        }
    }
}
