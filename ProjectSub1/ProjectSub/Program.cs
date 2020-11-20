using System;
using System.Threading.Tasks;
using System.IO;                            // input-output pour utiliser stream-reader et stream writer
using System.Text.RegularExpressions;       // regex


namespace ProjectSub
{
    class Program
    {

        private static Regex unit = new Regex(
            @"(?<sequence>\d+)\r\n(?<start>\d{2}\:\d{2}\:\d{2},\d{3}) --\> " + @"(?<end>\d{2}\:\d{2}\:\d{2},\d{3})\r\n(?<text>[\s\S]*?\r\n\r\n)",
            RegexOptions.Compiled | RegexOptions.ECMAScript);

        //on utilise regex pour decouper chaque sous-titre, permettant de les afficher en invdividu au lieu de tout srt entier

        // Stream reader permet de recuperer le fichier contenant les subtitle

        static void Main(string[] args)
        {
            String filePath = "sub.txt";    //C:\Users\33615\source\repos\ProjectSub\ProjectSub\bin\Debug\netcoreapp3.1\sub.txt
            WriteToFile(filePath);
            ReadFromFile(filePath);
            
        }
        public static void ReadFromFile(string filePath)   
        {
          StreamReader reader = new StreamReader(filePath);      //stream reader object de variable string

            while (!reader.EndOfStream)                          // lire tout les lignes de txt file
            {   
                Console.WriteLine(reader.ReadLine());             
            }

            reader.Close();
        }

        //Stream writer permet de mettre de nouveau text dns le fichier
        
        public static void WriteToFile(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath, true); //True pour ne pas replacer les anciens noms

            String temp = String.Empty;

            do
            {
                Console.Write("Enter");         
                temp = Console.ReadLine();

                if(temp != "-1")                //quitter en ecrivant -1
                {
                    writer.WriteLine(temp);
                }

            } while (temp != "-1");


            writer.Close();
        }
        
    }
}
         
        // L'idée etait d'utliser regex pour couper chauque sous titres
        // Stream reader pour les affichier
        // stream writer pour remplacer l'ancien avec le suivant avec le temps
           