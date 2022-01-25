using System;
using System.Collections.Generic;
using System.Text;

namespace Toyota.Entity
{
    class Colour
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String SecondId { get; set; }

        public Colour()
        {
            this.Id = Guid.NewGuid();
        }

        public Colour(String name, String Sid)
        {
            this.Id = Guid.NewGuid();  //create new guid for entity "Colour"
            this.Name = name;
            this.SecondId = Sid;
        }

       
        public String Show()
        {
            return this.Name.PadRight(15) + this.SecondId;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void ChangeName(String newName)
        {
            this.Name = newName;
        }

        public void ChangeSid(String newSid)  // Change change SecondId for "Colour"
        {
            this.SecondId = newSid;
        }

    }
}
