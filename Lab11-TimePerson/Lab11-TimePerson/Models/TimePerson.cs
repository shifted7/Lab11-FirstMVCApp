using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lab11_TimePerson.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        public static List<TimePerson> GetPersons(int begYear, int endYear)
        {
            // create a list of Time persons (instantiate a new list)
            List<TimePerson> Persons = new List<TimePerson>();

            // get the path of your timeperson.csv file
            // getting the path is not as simple as ../../../ have to use 
            // the Path or Environment class
            string filename = "\\..\\..\\personOfTheYear.csv";
            string path = Environment.CurrentDirectory + filename;
            
            // once you get the file path, 
            // read all the lines and save it into an array of strings
            string[] dataStringArray = File.ReadAllLines(path);
            // traverse through the strings for each line item
            // use LINQ to filter out with the years that you brought in against your list of persons
            var query = from entry in dataStringArray
                        where entry.Split(",")[0] != "Year" && Int32.Parse(entry.Split(",")[0]) >= begYear && Int32.Parse(entry.Split(",")[0]) <= endYear
                        select entry.Split(",");
            foreach(var item in query)
            {
                // Persons.Add(new TimePerson(Int32.Parse(item[0]), item[1], item[2], item[3], Int32.Parse(item[4]), Int32.Parse(item[5]), item[6], item[7], item[8]));
            }



            //return your list of persons

            return Persons;
        }

        public TimePerson(int year, string honor, string name, string country, int birthyear, int deathyear, string title, string category, string context)
        {
            Year = year;
            Honor = honor;
            Name = name;
            Country = country;
            BirthYear = birthyear;
            DeathYear = deathyear;
            Title = title;
            Category = category;
            Context = context;
        }
    }
}
