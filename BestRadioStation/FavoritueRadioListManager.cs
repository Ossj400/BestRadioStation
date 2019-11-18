using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BestRadioStation
{
    class FavoritueRadioListManager
    {
        string dir;
        public string[] newlinesDel;
        public string createDirectory()
        {
            string path = (Environment.CurrentDirectory);
            var dir = (path + @"\RadioStationsList\List.txt");
            if (File.Exists(dir) == false)
            {
                Directory.CreateDirectory("RadioStationsList");
                StreamWriter str = File.CreateText(path + @"\RadioStationsList\List.txt");
            }
            return dir;
        }

        public void addToList(string radioUrl, string radioName)
        {
            dir = createDirectory();

            using (StreamWriter str = File.AppendText(dir))    // inserting this data without any formatting 
            {
                str.WriteLine(radioName);
                str.WriteLine(radioUrl);
            }
        }
        public string[] readFromList()
        {
            var dir = (Environment.CurrentDirectory + @"\RadioStationsList\List.txt");
            string[] lines = File.ReadAllLines(dir, Encoding.UTF8);
            string[] newlines = new string[lines.Length];
            int i = 0;
            int j = 1;
            foreach (string line in lines)
            {
                if (((i + 2) % 2) == 0 && line.Length > 3)
                {
                    try
                    {
                        newlines[i] = string.Format("{0}).{1}", j, line.Remove(0, 3));
                        j = j + 1;
                        i = i + 1;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    newlines[i] = line;
                    i = i + 1;
                }

            }
            return newlines;
        }

        public string[] delete(int id)
        {
            var dir = (Environment.CurrentDirectory + @"\RadioStationsList\List.txt");
            string[] newlinestemp = readFromList();
            newlinesDel = new string[newlinestemp.Length - 2];
            int i = 0;
            int j = 0;
            using (StreamWriter writer = new StreamWriter(dir))
            foreach (string line in newlinestemp)
            {          
                    if (i != id && i !=id+1 )
                    {
                        newlinesDel[j] = line;
                        writer.WriteLine(newlinesDel[j]);
                        j = j + 1;
                    }   
                i = i + 1;
            }
            return newlinesDel;
        }
    }
}
