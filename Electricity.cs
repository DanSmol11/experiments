using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcing_Scv
{
    public class Electricity
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
}
