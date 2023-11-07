using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.IO;
using System.Text;
using System.Net;

namespace hw_2_3
{
    internal class CodeWebPage
    {
        const string FILEPATH = "C:\\Users\\yanaz\\OneDrive\\Рабочий стол\\выбирай итмо и не  выбирай вообще\\ланит\\hw_s\\student_school_DO\\hw_2_3\\dataFiles\\forTask3";

        public void Command()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input url: ");
            string url = Console.ReadLine();
            string strToWrite = getResponse(url);

            if (strToWrite == string.Empty)
            {
                Command();
            }
            else
            {
                File.WriteAllText(FILEPATH, strToWrite, Encoding.UTF8);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Would u like to repeat command (y/n): ");
                string ans = Console.ReadLine();
                if (ans == "y")
                {
                    Command();
                }
            }
        }

        static string getResponse(string uri)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] buf = new byte[8192];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                int count = 0;
                do
                {
                    count = resStream.Read(buf, 0, buf.Length);

                    if (count != 0)
                    {
                        sb.Append(Encoding.Default.GetString(buf, 0, count));
                    }
                }
                while (count > 0);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("it is mistake here((((");
            }

            return string.Empty;
        }
    }
}