using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Electricity
    {
        public string Utility_State { get; set; }
        public float Demand_Summer_Peak { get; set; }

        public static List<Electricity> LoadFile(string filename)
        {
            List<Electricity> electricities = null;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,
            };

            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, config))
            {
                electricities = csv.GetRecords<Electricity>().ToList();
            }

            return electricities;
        }
    }

    struct Result
    {
        public float AverageSummerPeak;
        public string State;

        static int Name(Result a, Result b)
        {
            if (String.Compare(a.GetState(), b.GetState()) != 0)
            {
                return String.Compare(a.GetState(), b.GetState());
            }
            else
            {
                return 0;
            }
        }
        public static void SortByState(List<Result> result)
        {
            result.Sort(Name);
        }

        public string GetState()
        {
            return State;
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            List<Electricity> list = new List<Electricity>();
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            Console.WriteLine("Enter file path (Example: C:/Users/Даник/Desktop/1/electricity.csv)");
            Console.Write("->");
            string[] getFilePath = Console.ReadLine().Split('/');
            string filePath = "";
            for(int i = 0; i < getFilePath.Length - 1; i++)
            {
                filePath += (getFilePath[i] + "\\");
            }
            filePath += getFilePath[getFilePath.Length - 1];

            var mainList = Electricity.LoadFile(filePath);

            List<Result> results = new List<Result>();


            float averageSummerPeak = 0;
            int step = 0;
            for (int i = 0; i < mainList.Count - 1; i++)
            {
                for (int j = i + 1; j < mainList.Count; j++)
                {
                    if (mainList[i].Utility_State == mainList[j].Utility_State && i != j)
                    {
                        averageSummerPeak += mainList[j].Demand_Summer_Peak;
                        step++;
                    }
                }
                averageSummerPeak /= step;
                results.Add(new Result() { AverageSummerPeak = averageSummerPeak, State = mainList[i].Utility_State });
                averageSummerPeak = 0;
                step = 0;
            }


            Console.WriteLine("Sorted Array by State:");
            Console.WriteLine("=============================================================================================");
            Result.SortByState(results);
            foreach (var v in results)
            {
                Console.WriteLine($"State : {v.State} | Avg - {v.AverageSummerPeak} |");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

    }
}
