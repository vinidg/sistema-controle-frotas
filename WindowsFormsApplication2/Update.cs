using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Sistema_Controle

{
   class Update
    {
        bool yn, avisar;

        public bool Avisar
        {
            get { return avisar; }
            set { avisar = value; }
        }
        public bool Yn
        {
            get { return yn; }
            set { yn = value; }
        }
        public void up()
        {
            
            string donwloadurl = "";
            Version newVersion = null;

            string xmlURL = @"\\\10.1.0.7\\Mapa_de_Leitos\\Sistemas - Vinicius\\Sistema de Controle de Ambulancias\\update.xml";
           // string xmlURL = @"\\\10.1.0.7\\Mapa_de_Leitos\\Sistemas - Vinicius\\Sistema de Controle de Ambulancias\\updateHomologacao.xml";
            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(xmlURL);
                reader.MoveToContent();
                string elemeto = "";

                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "coolapp"))
                {
                    while(reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elemeto = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                switch(elemeto)
                                {
                                    case "version":
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        donwloadurl = reader.Value;
                                        break;

                                }
                            }
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                if(reader != null)
                
                    reader.Close();
            }
            Version appverion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (appverion.CompareTo(newVersion) < 0)
            {
                avisar = true;
                yn = true;
                Process.Start(donwloadurl);
            }
            else
            {
                avisar = false;
                yn = false;
                Console.WriteLine("Atualizado");
            }
        }
    }
}
