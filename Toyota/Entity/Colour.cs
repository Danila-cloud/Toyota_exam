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
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.SecondId = Sid;
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
