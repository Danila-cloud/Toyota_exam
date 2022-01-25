using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Toyota.Entity
{
    class App
    {
        public List<Model> Models { get; set; }

        public void Logining(String line)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\danil\\source\repos\\Danila-cloud\\Exam-C-\\StepExamCarCharacters\\StepExamCarCharacters\\loging.txt");
                
                sw.WriteLine(line);

                sw.Close();
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
