using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Toyota.Entities

namespace Toyota
{
    class DBContext
    {
        public List<Model> Models { get; set; }

        public DBContext()
        {
            Models = new List<Model>();
            Seed();
        }

        public List<Model> SearchByColor(string color)
        {
                IEnumerable<Model> res =
                from model in Models
                from modification in model.Modifications
                from color in modification.Color
                where color.Name == Color
                select model;
            return res.ToList();
        }

        public void Seed()
        {
            Color red = new Color() { Name = "Red" };
            Color yellow = new Color() { Name = "Yello" };
            Color green = new Color() { Name = "Green" };

            Modification yarisElegant = new Modification() { Name = " Yaris Elegant " };
            yarisElegant.Color.Add(red);
            yarisElegant.Color.Add(yellow);

            Modification yarisCity = new Modification() { Name = " Yaris City " };
            yarisElegant.Color.Add(red);
            yarisElegant.Color.Add(green);

            Model yaris = new Model() { Name = " Yaris " };
            yaris.Modifications.Add(yarisElegant);
            yaris.Modifications.Add(yarisCity);

            Models.Add(yaris);
        }

        public void Echo(IEnumerable)

        public void Test()
        {
            var res = SearchByColor("Red");
            foreach (var r in res)
            {
                Console.WriteLine(r.Name + ": ");
                foreach (var m in r.Modifications)
                {
                    Console.Write("\n" + m.Name + " ( ");
                    foreach (var c in m.Colors)
                    {
                        Console.WriteLine(c.Name + ", ");
                    }
                    Console.Write(" )\n");
                }
            }
        }
    }
}
