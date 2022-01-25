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

        public List<Colour> Colours { get; set; }

        public Modification()
        {
            this.Id = Guid.NewGuid();  //create new guid for entity "Modification"
        }

        public Modification(String name, String Sid)
        {
            this.Id = Guid.NewGuid();  //create new guid for entity "Modification"
            this.Name = name;
            this.SecondId = Sid;
        }


        public void ChangeSid(String newSid)    // Change change SecondId for "Modification"
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

        public bool AddColor(Colour c)
        {
            if (Colours == null)
            {
                Colours = new List<Colour>();
                Colours.Add(c);

                return true;
            }

            Colours.Add(c);
            return true;
        }

        public void ChangeName(String newName)
        {
            this.Name = newName;
        }
    }
}
