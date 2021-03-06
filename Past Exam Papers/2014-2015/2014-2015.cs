﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;// must include this reference when implementing file handling


/*

Marek Kieja
S00173510
14/04/2017
Program for a games company maintains high score records for its game players.  

    */
class Game
{
    static void Main()
    {
        int filleLength;
        string[,] arrey;
        int[] countArr;

        CreateFile();

        filleLength = LineCount();
        arrey = WriteArray(filleLength);
        countArr = Analysis(arrey, filleLength);// call appropriate method(s)
        Print(countArr);

        Console.ReadKey();

    }// end main
    static void CreateFile()
    {
        // create a connection to the file
        StreamWriter sw = new StreamWriter(@"C:\Users\s00173510\Desktop\PROJECT_MK\scores2.txt"); // placed the file in the debug folder, so no path needed

        //write to file
        sw.WriteLine("001,T1,4");
        sw.WriteLine("002,T2,6");
        sw.WriteLine("003,T3,7");
        sw.WriteLine("004,T3,5");
        sw.WriteLine("005,T1,6");
        sw.WriteLine("006,T2,7");
        sw.WriteLine("007,T4,2");

        // close the connection to the file
        sw.Close();
    }
    static int LineCount()// count numbers of lines in the scores.txt
    {
        StreamReader sr = new StreamReader(@"C:\Users\s00173510\Desktop\PROJECT_MK\scores2.txt");
        int count = 0;

        string line;
        while ((line = sr.ReadLine()) != null)
        {
            count++;
        }

        return count;
    }
    static string[,] WriteArray(int size)
    {
        int y = 0;

        StreamReader sr = new StreamReader(@"C:\Users\s00173510\Desktop\PROJECT_MK\scores2.txt");
        string[] fields = new string[2];// array to store chopped up line
        string[,] arreyAll = new string[size, 3];

        string lineIn;// will hold data that we read in

        lineIn = sr.ReadLine();// read in first line from file

        while (lineIn != null)// null signals end of the file
        {

            fields = lineIn.Split(','); // split lineIn where there is a ','

            for (int i = 0; i < 3; i++)
            {
                arreyAll[y, i] = fields[i];

            }
            y++;
            lineIn = sr.ReadLine();// read in the next line
        }
        return arreyAll;
    }

    static int[] Analysis(string[,] arrey, int count)//Score Analysis Report method
    {
        int z = 0;
        int numer = 0;
        int price = 0;

        string[] age = { "T1", "T2", "T3", "T4" };
        int[] value = { 40, 45, 55, 60 };
        int[] countArr = new int[7];// 2D array to store data

        while (count > 0)
        {

            price = int.Parse(arrey[z, 2]);//Convert string to int      

            numer += price;

            //Assign value to 2d array location

            for (int y = 0; y < age.Length; y++)
            {


                if (arrey[z, 1] == age[y])
                {
                    countArr[y] += price * value[y];
                }

            }

            z++;
            count--;

        }//while end
        return countArr;
    }

    static void Print(int[] countArr)
    {
        // print to screen
        string[] score = { "T1", "T2", "T3", "T4", "Total", };
        Console.WriteLine("Ticket Type {0,14}", "Total Retail value");
        Console.WriteLine();

        for (int i = 0; i < 5; i++)
        {
            Console.Write("{0,-9}", score[i]);

            Console.WriteLine("{0,13:f2}", countArr[i]);
            countArr[4] += countArr[i];
        }
        Console.WriteLine();

    }



}
