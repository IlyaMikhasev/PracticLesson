using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PracticLesson
{
	public class File_editing {
        public static List<string> file_words = new List<string>();
        private static Regex reg_word = new Regex(@"[^ ]*");
        private static Dictionary<int, string> NumberTrans = new Dictionary<int, string>(){
        { 0, "ноль"},
        { 1,"один"},
        { 2,"два"},
        { 3,"три"},
        { 4,"четыре"},
        { 5,"пять"},
        { 6,"шесть"},
        { 7,"семь"},
        { 8,"воссемь"},
        { 9,"девять"},
        { 10,"десять"},
        { 11,"одинадцать"},
        { 12,"двенадцать"},
        { 13,"тринадцать"},
        { 14,"четырнадцать"},
        { 15,"пятьнадцать"},
        { 16,"шестнадцать"},
        { 17,"семнадцать"},
        { 18,"восемнадцать"},
        { 19,"девятнадцать"},
        { 20,"двадцать"},
        {30,"тридцать"},
        {40,"сорок"},
        { 50,"пятьдесят"},
        {60,"шестьдесят"},
        { 70,"семьдесят"},
        { 80,"восемьдесят"},
        { 90,"девяносто"}
        };
        public static void File_Reader(string path)
        {
            var streamreader = new StreamReader(path);
			string strFile= String.Empty;
            for (int i = 0; !streamreader.EndOfStream; i++)
            {
                 strFile += streamreader.ReadLine();                
            }
            MatchCollection words = reg_word.Matches(strFile);
            foreach (Match match in words) {
                if (match.Value == "")
                    continue;
                file_words.Add(File_edit(match.Value));
            }
            streamreader.Close();
            Console.WriteLine("Файл считан");
        }
        public static void File_writer(string path)
        {
			string time = DateTime.Now.ToString("HH.mm.ss");
            var streamwriter = new StreamWriter(path+time+".txt");
            for (int i = 0; i < file_words.Count; i++) {
                streamwriter.Write($"{file_words[i]} ");
            }
            streamwriter.Close();
            Console.WriteLine("Файл записан");
        }
        private static string File_edit(string _word)
        {
            
            string res = "";
            try
            {
                int numberWord = int.Parse(_word);
                if (numberWord <= 19 && numberWord >=0)
                    res = NumberTrans[numberWord];
                else {
                    int intTen=numberWord/10+10;
                    int intOne = numberWord % 10;
                    res = NumberTrans[intTen] + NumberTrans[intOne];
                }
            }
            catch 
            {
                res = _word;
            }
            return res;		
        }
	}
    internal class Program
    {
       

        static void Main(string[] args)
        {
            bool openfile = true;
            string path = "";
            try {
                path = args[0];
                File_editing.File_Reader(path);
                Console.WriteLine("Введите название файла для сохранения");
                path = Console.ReadLine();
                File_editing.File_writer(path);
            }
            catch
            {                
                while (openfile)
                {
                    try
                    {
                        Console.WriteLine("Необоходимо ввести корректный адресс файла");
                        path = Console.ReadLine();
                        File_editing.File_Reader(path);
                        openfile = false;
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка открытия файла");                        
                    }
                }
                Console.WriteLine("Введите название создаваемого файла");
                path = Console.ReadLine();
                File_editing.File_writer(path);
            }
            Console.WriteLine("Работа завершена");
        }
    }
}
