using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Toyota.Entity
{
    class App
    {
        public List<Model> Models { get; set; }

        public List<Colour> Colours { get; set; }

        public App()
        {
            Models = new List<Model>();
            Colours = new List<Colour>();
        }

        public List<Model> SearchByColor(String colour)
        {
            return Models.Where(model => model.Modifications.Exists(n => n.Colours.Exists(c => c.Name.Contains(colour)))).ToList();
        }

        public void AddModification(Model model)
        {
            Modification mod = new Modification();

            Console.Write(" Please, add modification's name: ");
            mod.Name = Console.ReadLine();

            Console.Write(" Please, add modification id: ");
            mod.SecondId = Console.ReadLine();

            AddColor(mod);

            model.AddModification(mod);

            String guid = mod.Id.ToString();
            Logining(" Modification was added!");
        }

        public void EditModel()
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose model which you want edit: ");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter model's index: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter new model's name: ");
            Models.ElementAt((id - 1)).ChangeName(Console.ReadLine());

            Console.Write(" Enter new vendor id of model: ");
            Models.ElementAt((id - 1)).ChangeSid(Console.ReadLine());

            String guid = Models.ElementAt((id - 1)).Id.ToString();
            Logining(" Model was edited!");
        }

        public void EditModification()
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose model which you want to edit it is modfication:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter model's index: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification which you want to edit:");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of modification: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter new name of modification: ");
            modifications.ElementAt((id - 1)).ChangeName(Console.ReadLine());

            Console.Write(" Enter new vendor id of modification: ");
            modifications.ElementAt((id - 1)).ChangeSid(Console.ReadLine());

            String guid = modifications.ElementAt((id - 1)).Id.ToString();
            Logining(" Modification was edited!");
        }

        public void EditColor()
        {
            int k = 0;
            int id = 0;
            int modId = 0;
            int colorId = 0;

            Console.WriteLine(" Choose model which you want to edit it is modfication`s color:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification which you want to edit it`s color:");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter modification's index: ");
            modId = Convert.ToInt32(Console.ReadLine());
            List<Colour> colors = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colours;

            k = 0;

            Console.WriteLine(" Choose color which you want to edit:");
            foreach (Colour c in colors)
            {
                Console.WriteLine($" {++k} " + c.Show());
            }

            Console.Write(" Enter colour's index: ");
            colorId = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter colour's new name: ");
            Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colours.ElementAt((colorId - 1)).ChangeName(Console.ReadLine());

            Console.Write(" Enter colour's new id: ");
            Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colours.ElementAt((colorId - 1)).ChangeSid(Console.ReadLine());

            String guid = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colours.ElementAt((colorId - 1)).Id.ToString();
            Logining(" Color edited!");
            Console.WriteLine(" Color edited!!!");
        }

        public void DeleteModel()
        {
            int k = 0;

            Console.WriteLine(" Choose model which you want to delete:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter model's index: ");
            String guid = Models.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1).Id.ToString();
            Models.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);

            Logining(" Model deleted!");
            Console.WriteLine(" Model deleted!!!");
        }

        public void DeleteModification()
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose model which you want to delete it is modfication:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter model's index: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification which you want to delete:");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter modification's index: ");
            String guid = Models.ElementAt((id - 1)).Modifications.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1).Id.ToString();
            Models.ElementAt((id - 1)).Modifications.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);

            Logining(" Modification deleted!");
            Console.WriteLine(" Modification deleted!!!");
        }

        public void DeleteColor()
        {
            int k = 0;
            int id = 0;
            int modId = 0;
            int colorId = 0;

            Console.WriteLine(" Choose model which you want to delete it is modfication`s colour: ");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter model's index: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification which you want to delete it is colour: ");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter modification's index: ");
            modId = Convert.ToInt32(Console.ReadLine());
            List<Colour> colors = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colours;

            k = 0;

            Console.WriteLine(" Choose color whichyou want to delete:");
            foreach (Colour c in colors)
            {
                Console.WriteLine($" {++k} " + c.Show());
            }

            Console.Write(" Enter color's index which you want to delete: ");
            colorId = Convert.ToInt32(Console.ReadLine()) - 1;
            String guid = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colours.ElementAt(colorId).Id.ToString();
            Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colours.RemoveAt(colorId);

            Logining(" Color was deleted!");
            Console.Write(" Color deleted!!! ");
        }

        public void ShowModelsWithColors(String colour)
        {
            List<Model> models = SearchByColor(colour);

            foreach (Model model in models)
            {
                if (model.Modifications.Exists(n => n.Colours.Exists(c => c.Name.Contains(colour))) == true)
                {
                    List<Modification> modif = model.Modifications.Where(n => n.Colours.Exists(c => c.Name.Contains(colour))).ToList();

                    if (modif.Count == 0)
                    {
                        Console.WriteLine("model was not founded!");
                    }
                    else
                    {
                        foreach (Modification m in modif)
                        {
                            List<Colour> colours = m.Colours.Where(c => c.Name.Contains(colour)).ToList();

                            Console.WriteLine($" {"Model".PadRight(20)}  {"Modification".PadRight(20)}  Colour");

                            foreach (Colour c in colours)
                            {
                                Console.WriteLine($" {model.Name.PadRight(20)}  {m.Name.PadRight(20)}  {c.SecondId} - {c.Name};");
                            }
                        }
                    }
                }
            }
        }
        public void AddModel()
        {
            Model mod = new Model();

            Console.Write(" Please, add model's name: ");
            mod.Name = Console.ReadLine();

            Console.Write(" Please, add model's id: ");
            mod.SecondId = Console.ReadLine();

            AddModification(mod);

            Models.Add(mod);

            String guid = mod.Id.ToString();
            Logining(" Model was added!");
        }
        public void AddColor(Modification m)
        {
            Colour col = new Colour();

            Console.Write(" Please, add colour's name: ");
            col.Name = Console.ReadLine();

            Console.Write(" Please, add colour id: ");
            col.SecondId = Console.ReadLine();

            m.AddColor(col);

            Colours.Add(col);

            String guid = col.Id.ToString();
            Logining(" Colour was added!");
        }
        public void Logining(String line)
        {
            try
            {
                StreamWriter stream_writer = new StreamWriter("C:\\Users\\danil\\source\repos\\Danila-cloud\\Exam-C-\\StepExamCarCharacters\\StepExamCarCharacters\\loging.txt");

                stream_writer.WriteLine(line);

                stream_writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void SerialXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Model>));
            using (FileStream fs = new FileStream("Models.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, Models);
            }
        }

    }
}
