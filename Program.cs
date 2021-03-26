using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Субтитры2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream filoviyPotok = new FileStream("C:\\Users\\buka2\\Desktop\\c#\\Titles.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader str = new StreamReader(filoviyPotok);
            string data = str.ReadToEnd();
            string[] dataArray = data.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataArray.Length; i++)
            {
                if (dataArray[i] == "Top")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    PrintTop(dataArray[i + 2]);
                    Console.ResetColor();
                    continue;
                }
                else if (dataArray[i] == "Bottom")
                {
                    PrintBottom(dataArray[i + 2]);
                    continue;
                }
                else if (dataArray[i] == "Left")
                {
                    PrintLeft(dataArray[i + 2]);
                    continue;
                }
                else if (dataArray[i] == "Right")
                {
                    PrintRight(dataArray[i + 2]);
                    continue;
                }
                //Console.WriteLine(dataArray[i]);
                //System.Threading.Thread.Sleep(2000);
            }
            str.Close();
        }
        static void PrintTop(string TextTop)
        {
            int width = Console.WindowWidth;
            if (TextTop.Length < width)
            {
                TextTop = TextTop.PadLeft((width - TextTop.Length) / 2 + TextTop.Length, ' ');
            }
            Console.WriteLine(TextTop);
        }
        static void PrintRight(string TextRight)
        {
            int topRightText = Console.WindowWidth - TextRight.Length;
            Console.SetCursorPosition(topRightText, 14);
            Console.Write(TextRight);
        }
        static void PrintLeft(string TextLeft)
        {
            int bottomY = Console.WindowHeight - 16;
            Console.SetCursorPosition(0, bottomY);
            Console.Write(TextLeft);
        }
        static void PrintBottom(string BotTextX)
        {
            int centerX = (Console.WindowWidth / 2) - (BotTextX.Length / 2);
            int centerY = Console.WindowHeight - 1;
            Console.SetCursorPosition(centerX, centerY);
            Console.Write(BotTextX);
        }
    }
}