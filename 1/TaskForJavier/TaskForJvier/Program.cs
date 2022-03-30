using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Electricity
    {
        public int Utility_Number;
        public string Utility_Name;
        public string Utility_State;
        public string Utility_Type;
        public float Demand_Summer_Peak;
        public float Demand_Winter_Peak;
        public float Sources_Generation;
        public float Sources_Purchased;
        public float Sources_Other;
        public float Sources_Total;
        public float Uses_Retail;
        public float Uses_Resale;
        public float Uses_No_Charge;
        public float Uses_Consumed;
        public float Uses_Losses;
        public float Uses_Total;
        public float Revenues_Retail;
        public float Revenue_Delivery;
        public float Revenue_Resale;
        public float Revenue_Adjustments;
        public float Revenue_Transmission;
        public float Revenue_Other;
        public float Revenue_Total;
        public float Retail_Residential_Revenue;
        public float Retail_Residential_Sales;
        public float Retail_Residential_Customers;
        public float Retail_Commercial_Revenue;
        public float Retail_Commercial_Sales;
        public float Retail_Commercial_Customers;
        public float Retail_Industrial_Revenue;
        public float Retail_Industrial_Sales;
        public float Retail_Industrial_Customers;
        public float Retail_Transportation_Revenue;
        public float Retail_Transportation_Sales;
        public float Retail_Transportation_Customers;
        public float Retail_Total_Revenue;
        public float Retail_Total_Sales;
        public float Retail_Total_Customers;

        public Electricity()
        {

        }
        public Electricity(int uNumber, string uName, string uState, string uType, float dSummerPeak, float dWinterPeak, float sGeneration, float sPurchased,
            float sOther, float sTotal, float usRetail, float usResale, float usNoCharge, float usConsumed, float usLosses, float usTotal, float revRetail,
            float revDelivery, float revResale, float revAdjustmets, float revTransmission, float revOther, float revTotal, float retResidentialRevenue,
            float retResidentialSales, float retResidentialCustomers, float retCommercialRevenue, float retCommercialSales, float retCommercialCustomers,
            float retIndustrialRevenue, float retIndustrialSales, float retIndustrialCustomers, float retTransportationRevenue, float retTransportationSales,
            float retTransportationCustomers, float retTotalRevenue, float retTotalSales, float retTotalCustomers)
        {
            Utility_Number = uNumber;
            Utility_Name = uName;
            Utility_State = uState;
            Utility_Type = uType;
            Demand_Summer_Peak = dSummerPeak;
            Demand_Winter_Peak = dWinterPeak;
            Sources_Generation = sGeneration;
            Sources_Purchased = sPurchased;
            Sources_Other = sOther;
            Sources_Total = sTotal;
            Uses_Retail = usRetail;
            Uses_Resale = usResale;
            Uses_No_Charge = usNoCharge;
            Uses_Consumed = usConsumed;
            Uses_Losses = usLosses;
            Uses_Total = usTotal;
            Revenues_Retail = revRetail;
            Revenue_Delivery = revDelivery;
            Revenue_Resale = revResale;
            Revenue_Adjustments = revAdjustmets;
            Revenue_Transmission = revTransmission;
            Revenue_Other = revOther;
            Revenue_Total = revTotal;
            Retail_Residential_Revenue = retResidentialRevenue;
            Retail_Residential_Sales = retResidentialSales;
            Retail_Residential_Customers = retResidentialCustomers;
            Retail_Commercial_Revenue = retCommercialRevenue;
            Retail_Commercial_Sales = retCommercialSales;
            Retail_Commercial_Customers = retCommercialCustomers;
            Retail_Industrial_Revenue = retIndustrialRevenue;
            Retail_Industrial_Sales = retIndustrialSales;
            Retail_Industrial_Customers = retIndustrialCustomers;
            Retail_Transportation_Revenue = retTransportationRevenue;
            Retail_Transportation_Sales = retTransportationSales;
            Retail_Transportation_Customers = retTransportationCustomers;
            Retail_Total_Revenue = retTotalRevenue;
            Retail_Total_Sales = retTotalSales;
            Retail_Total_Customers = retTotalCustomers;
        }
    }

    class Result
    {
        public string State;
        public float AveragePeakDemand;

        public Result()
        {

        }

        public Result(string state, float avgPeakDemand)
        {
            State = state;
            AveragePeakDemand = avgPeakDemand;
        }

        public static void SortByState(List<Result> result)
        {
            result.Sort(Name);
        }

        public string GetState()
        {
            return State;
        }

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
    }
    class Program
    {


        static void Main(string[] args)
        {
            List<Electricity> list = new List<Electricity>();
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            Console.WriteLine("Enter file path (Example: C:/Users/Danik/Desktop/Test.csv)");
            Console.Write("->");
            string[] getFilePath = Console.ReadLine().Split('/');
            string filePath = "";
            for(int i = 0; i < getFilePath.Length - 1; i++)
            {
                filePath += (getFilePath[i] + "\\");
            }
            filePath += getFilePath[getFilePath.Length - 1];
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Electricity(int.Parse(s[0]), s[1], s[2], s[3], float.Parse(s[4]), float.Parse(s[5]), float.Parse(s[6]), float.Parse(s[7]), float.Parse(s[8]), float.Parse(s[9]), float.Parse(s[10]), float.Parse(s[11]), float.Parse(s[12]), float.Parse(s[13]), float.Parse(s[14]), float.Parse(s[15]), float.Parse(s[16]), float.Parse(s[17]), float.Parse(s[18]), float.Parse(s[19]), float.Parse(s[20]), float.Parse(s[21]), float.Parse(s[22]), float.Parse(s[23]), float.Parse(s[24]), float.Parse(s[25]), float.Parse(s[26]), float.Parse(s[27]), float.Parse(s[28]), float.Parse(s[29]), float.Parse(s[30]), float.Parse(s[31]), float.Parse(s[32]), float.Parse(s[33]), float.Parse(s[34]), float.Parse(s[35]), float.Parse(s[36]), float.Parse(s[37])));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Error! Print ESC to finish.");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            Console.WriteLine("=============================");

            List<Result> resullist = new List<Result>();
            float averageSummerPeak = 0;
            int countOfEachState = 1;
            Console.WriteLine("Average summer peak table:");
            Console.WriteLine("=============================================================================================");
            for (int i = 0; i < list.Count; i++)
            {
                averageSummerPeak += list[i].Demand_Summer_Peak;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i].Utility_State == list[j].Utility_State && list[i].Utility_Number != list[j].Utility_Number)
                    {
                        averageSummerPeak += list[j].Demand_Summer_Peak;
                        countOfEachState++;
                    }
                }
                resullist.Add(new Result(list[i].Utility_State, averageSummerPeak / countOfEachState));
                Console.WriteLine($"Average summer peak - {averageSummerPeak / countOfEachState}, state - {list[i].Utility_State}");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                averageSummerPeak = 0;
                countOfEachState = 1;
            }
            Console.WriteLine("Sorted Array by State:");
            Console.WriteLine("=============================================================================================");
            Result.SortByState(resullist);
            foreach (var v in resullist)
            {
                Console.WriteLine($"State : {v.State} | Avg - {v.AveragePeakDemand} |");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

    }
}
