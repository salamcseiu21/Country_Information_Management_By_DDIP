using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryCityInformationManagementSystem.Models
{
    public class Country
    {
        public Country(int id, string name, string about):this(name,about)
        {
            Id = id;
            
        }

        public Country(string name, string about):this()
        {
            Name = name;
            About = about;
        }

        public Country()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }

    }
}