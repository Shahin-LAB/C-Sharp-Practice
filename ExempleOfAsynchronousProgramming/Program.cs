
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExempleOfAsynchronousProgramming
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello Shahin, Working the Delegation of 70-483: Programming in C# Asynchronous Programming");

            //Before Load Stock data
            //CallGetStocks();
        }
        private async void CallGetStocks()
        {
            try
            {
                await GetStocks();
                //var cd= new calldata();

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
                //Notes.text += ex.Message;

            }

        }
        public async void calldata()
        {
            await GetDataFromFile();
        }
        public async Task GetDataFromFile()
        {
            await Task.Run(() =>
            {
                string filepath = @"C:\Shahin\Innofactor\Exam 70-483-Programming in C#\LAB-70-483-C#\1.ManageProgramFlow\Exemple\ExempleOfAsynchronousProgramming\ListofCountry.csv";
                CsvReader reader = new CsvReader(filepath);

                List<Country> countries = reader.ReadAllCountries();

                foreach (Country country in countries)
                {
                    Console.WriteLine($"{country.Poulation} : {country.Name}");
                    //Console.ReadKey();
                }
                //Dispatcher.Invoke(() =>
                //{

                //});


            });



            //using (var client = new HttpClient())
            //{
            //    var response = await client.GetAsync($"http://83.251.251.107:7000/(S(qbukteh2gd1gdrnkd1rfk0xs))/default.aspx/{Ticker.Text}");

            //    try
            //    {
            //        response.EnsureSuccessStatusCode();
            //        var content = await response.Content.ReadAsStringAsync();
            //        var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);
            //        Stocks.ItemSource = data;

            //    }
            //    catch (Exception ex)
            //    {
            //        var error = ex.Message;
            //        Console.WriteLine(error);
            //    }

            //}
        }

        class Country
        {
            public string Name { get; }
            public string Code { get; }
            public string Region { get; }
            public int Poulation { get; }

            public Country(string name, string code, string region, int population)
            {
                this.Name = name;
                this.Code = code;
                this.Region = region;
                this.Poulation = population;
            }

        }
        class CsvReader
        {
            private string _csvFilePath;
            public CsvReader(string csvFilePath)
            {
                this._csvFilePath = csvFilePath;
            }
            public List<Country> ReadAllCountries()
            {
                List<Country> countries = new List<Country>();

                using (StreamReader sr = new StreamReader(_csvFilePath))
                {
                    //read header line 
                    sr.ReadLine();


                    string csvLine;
                    while ((csvLine = sr.ReadLine()) != null)
                    {
                        countries.Add(ReadCountryFromCSVFile(csvLine));
                    }
                }
                return countries;
            }

            public Country ReadCountryFromCSVFile(string csvLine)
            {
                string[] parts = csvLine.Split(new char[] { ';' });

                string name = parts[0];
                string code = parts[1];
                string region = parts[2];
                int population = int.Parse(parts[3]);

                return new Country(name, code, region, population);
            }

        }
        public async Task GetStocks()
        {

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://83.251.251.107:7000/(S(qbukteh2gd1gdrnkd1rfk0xs))/default.aspx/");

                try
                {
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);
                    //Stocks.ItemSource = data;

                    //foreach (Country country in countries)
                    //{
                    //    Console.WriteLine($"{country.Poulation} : {country.Name}");
                    //    //Console.ReadKey();
                    //}

                }
                catch (Exception ex)
                {
                    var error = ex.Message;
                    Console.WriteLine(error);
                }

            }
        }

        public class StockPrice
        {
            public string Ticker { get; set; }
            public DateTime TradeDate { get; set; }
            public decimal? Open { get; set; }
            public decimal? High { get; set; }
            public decimal? Low { get; set; }
            public decimal? Close { get; set; }
            public int Volume { get; set; }
            public decimal Change { get; set; }
            public decimal ChangePercent { get; set; }
        }
    }
}
