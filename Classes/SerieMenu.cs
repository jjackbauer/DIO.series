using System.Collections.Generic;
using System;
namespace DIO.series
{
    public class SerieMenu : Menu
    {
        static SerieRepository  Repository = new SerieRepository();

        public SerieMenu()
        {
            Headers.Add("Dio.Series Demo");
            Headers.Add("Developed by Ricardo Medeiros");
            Headers.Add("https://github.com/jjackbauer/DIO.series");

            Options.Add(setOption("List Series",'1',true,FunctionListSeries));
            Options.Add(setOption("Add Series",'2',true,FunctionAddSeries));
            Options.Add(setOption("Update Series",'3',true,FunctionUpdateSeries));
            Options.Add(setOption("Delete Series",'4',true,FunctionDeleteSeries));
            Options.Add(setOption("View Series",'5',true,FunctionViewSeries));
            Options.Add(setOption("Clear Screen",'C',true,Clear));

        }
        static void FunctionListSeries()
        {   
            Clear();
            if((Repository.GetList()).Count == 0 )
            {
                Console.WriteLine("There is no register stored");
                WaitForKey();
                return;
            }
                

            Console.Write(Repository);
            WaitForKey();
        }
        static void FunctionAddSeries()
        {
            Repository.Insert(GetSerieFromInput());
        }

        static void FunctionUpdateSeries()
        {
           int toUpdate =  GetValidSeriesIndex();
            Repository.Update(toUpdate,GetSerieFromInput());
        }
        static void FunctionDeleteSeries()
        {
            int toDelete = GetValidSeriesIndex();
            Repository.Remove(toDelete);
        }
        static void FunctionViewSeries()
        {
            int toView = GetValidSeriesIndex();
        }

        static Serie GetSerieFromInput()
        {
            foreach(int i in Enum.GetValues(typeof(Genres)))
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genres), i));
            
            Console.Write("Select the genre from the options above > ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Type the title of the serie > ");
            string inputTitle = Console.ReadLine();

            Console.Write("Type the year of the serie > ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Type the description of the serie > ");
            string inputDescription = Console.ReadLine();

            var output = new Serie(Repository.GetNextId(),(Genres)inputGenre,inputTitle,inputDescription,inputYear);
            
            WaitForKey();
            
            return output;

        }
        static  int GetValidSeriesIndex()
        {
            bool done = false;
            int inputId;

            do
            {
                Clear();
                Console.Write("Type the serie id > ");
                inputId = int.Parse(Console.ReadLine());
                
                if(Repository.GetNextId() > inputId)
                {
                    Console.WriteLine(Repository.Get(inputId));
                    Console.Write("Is this the wanted serie <Y/N> > ");
                    string inputOption = Console.ReadLine();
                    done = inputOption.ToUpper() == "Y" ? true :false;
                }
                else
                {
                    Console.WriteLine("Invalid id {0}. Repository has only {1} series.",inputId,Repository.GetNextId()-1);
                    WaitForKey();
                }
            }while(!done);

            Clear();
            WaitForKey();

            return inputId;
        }
        
    }

    
}