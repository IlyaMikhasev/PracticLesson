using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PracticLesson
{
	public enum NumberTranslate {
		ноль = 0,
		один = 1,
		два,
		три,
		четыре,
		пять,
		шесть,
		семь,
		воссемь,
		девять,
		десять,
		одинадцать,
		двенадцать,
		тринадцать,
		четырнадцать,
		пятьнадцать,
		семнадцать,
		восемнадцать,
		девятнадцать,
		двадцать,
		тридцать = 30,
		сорок = 40,
		пятьдесят = 50,
		шестьдесят = 60,
		семьдесят = 70,
		восемьдесят = 80,
		девяносто = 90,
		сто = 100
	}
	public class File_editing {
        private static List<string> file_words;
        private static Regex regNum = new Regex(@"\d{1,2}");
		private static MatchCollection number;
		static NumberTranslate nt = 0;
        public static void File_Reader(string path)
        {
            var streamreader = new StreamReader(path);
			foreach (var item in streamreader.ReadToEnd())
			{
				string strFile= String.Empty;
				number = regNum.Matches(strFile);
				if (item != ' ' || item != '\n')
				{
					strFile += item.ToString();
				}
				else { 
					regNum.Replace(strFile, delegate (Match m) {
						int num = int.Parse(m.Value.ToString());
						if (num <= 20)
						{
                            nt = (NumberTranslate)num;
                            return nt;
						}
						else
						{
							int num1 = num % 10;
							return num.ToString() + num1.ToString();
						}
                    });
                    file_words.Add(strFile);
                    strFile = String.Empty;
                }
			}
            streamreader.Close();
        }
        public static void File_writer(string path)
        {
			string time = DateTime.Now.ToString("HH.mm.ss");
            var streamwriter = new StreamWriter(path+time+".txt");
            streamwriter.Close();
        }
        public static void File_edit()
        {
			
			foreach (var item in number)
			{
				 
			}
        }
	}
    internal class Program
    {
		

        static void Main(string[] args)
        {
			try
			{
				
			}
			catch (Exception)
			{
				
			}
        }
    }
}
