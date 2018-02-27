
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace DataBaseLoad
{
    class Program
    {

       


        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("["+i+"] Sentence :");
                insertGreeting();
            }
        }
    }
}
