using System;
using System.Threading.Tasks;

namespace AsyncAwaitTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            app.Run();
        }
    }

    class App
    {
        private Food _fries = new Food("Fries", 5000);
        private Food _meat = new Food("Meat", 10000);

        public void Run()
        {
            //MakeFoodSync();
            Console.WriteLine("");
            //MakeFoodAsync();
            Console.WriteLine("");
            MakeFoodAsync2();
            Console.WriteLine("");
            //MakeFoodAsync3();
            Console.WriteLine("Al veel te ver");
            Console.ReadLine();
        }

        public void MakeFoodSync()
        {
            var start = DateTime.Now;
            Console.WriteLine("Start making food sync");

            _fries.Make();
            _meat.Make();

            var end = DateTime.Now;
            var total = end - start;
            Console.WriteLine($"Making food sync takes {total} seconds");
        }

        public void MakeFoodAsync()
        {
            var start = DateTime.Now;
            Console.WriteLine("Start making food async fout");

            _fries.MakeAsync().Wait(); // Wacht gewoon tot task klaar is, geen winst
            _meat.MakeAsync().Wait();

            var end = DateTime.Now;
            var total = end - start;
            Console.WriteLine($"Making food async takes {total} seconds");
        }

        public async void MakeFoodAsync2()
        {
            var start = DateTime.Now;
            Console.WriteLine("Start making food async ook fout");

            await _fries.MakeAsync();
            await _meat.MakeAsync();

            var end = DateTime.Now;
            var total = end - start;
            Console.WriteLine($"Making food async takes {total} seconds");

            //Task.Delay(_fries.MakeTime + _meat.MakeTime).Wait(); // Niet nodig maar anders staat output tussen MakeFoodAsync3()
        }

        public void MakeFoodAsync3()
        {
            var start = DateTime.Now;
            Console.WriteLine("Start making food async");

            Task makeMeat = _meat.MakeAsync();
            Task.Delay(5000).Wait();
            Task makeFries = _fries.MakeAsync();
            
            makeFries.Wait();
            makeMeat.Wait();

            var end = DateTime.Now;
            var total = end - start;
            Console.WriteLine($"Making food async takes {total} seconds");
        }
    }

    class Food
    {
        public string FoodToMake { get; set; }
        public int MakeTime { get; set; }

        public Food(string foodToMake, int makeTime)
        {
            FoodToMake = foodToMake;
            MakeTime = makeTime;
        }

        public void Make()
        {
            Console.WriteLine($"Start making {FoodToMake}.");
            Task.Delay(MakeTime).Wait();
            Console.WriteLine($"{FoodToMake} ready.");
        }

        public async Task MakeAsync()
        {
            Console.WriteLine($"Start making {FoodToMake}.");
            await Task.Delay(MakeTime);   
            Console.WriteLine($"{FoodToMake} ready.");
        }
    }
}
