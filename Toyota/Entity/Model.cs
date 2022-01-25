using System;
using System.Collections.Generic;
using System.Text;

namespace Toyota.Entity
{
    class Model
    {

        public Guid Id { get; set; }
        public String Name { get; set; }
        public String SecondId { get; set; }

        public List<Modification> Modifications { get; set; }

        public Model()
        {
            this.Id = Guid.NewGuid();
        }

        public Model(String name, String Sid)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.SecondId = Sid;
        }

        public bool AddModification(Modification m)
        {
            if (Modifications == null)
            {
                Modifications = new List<Modification>();
                Modifications.Add(m);

                return true;
            }

            Modifications.Add(m);
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
            return this.Name + this.SecondId;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

}

