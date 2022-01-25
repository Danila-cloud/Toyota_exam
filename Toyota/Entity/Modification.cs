using System;
using System.Collections.Generic;
using System.Text;

namespace Toyota.Entity
{
    class Modification
    {

        public Guid Id { get; set; }
        public String Name { get; set; }
        public String SecondId { get; set; }

        public List<Colour> Colors { get; set; }

        public Modification()
        {
            this.Id = Guid.NewGuid();
        }

        public Modification(String name, String Sid)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.SecondId = Sid;
        }

        public bool AddColor(Colour c)
        {
            if (Colors == null)
            {
                Colors = new List<Colour>();
                Colors.Add(c);

                return true;
            }

            Colors.Add(c);
            return true;
        }

        public void ChangeName(String newName)
        {
            this.Name = newName;
        }

        public void ChangeSid(String newSid)
        {
            this.SecondId = newSid;
        }

        public String Show()
        {
            return this.Name.PadRight(15) + this.SecondId;
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
