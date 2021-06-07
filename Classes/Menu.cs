using System.Collections.Generic;
using System;
namespace DIO.series
{
    public abstract class Menu
    {
        public List<String> Headers = new List<String>();
        public List<Option> Options = new List<Option>();
        public char Terminator = 'X';

    
        public void Run()
        {   
            String userOption = "";
            
            do
            {
                bool InvalidOption=true;
                ListOptions();
                userOption = Console.ReadLine().ToUpper();

                foreach(Option o in Options)
                {
                    if(o.Command == userOption[0])
                    {
                        InvalidOption=false;
                        o.Handler();
                        break;
                    }

                    if(InvalidOption)
                        throw new ArgumentOutOfRangeException();
                }
            }while(userOption[0] != Terminator);
        }
        public Option setOption(String OptionName, char Command, bool Enabled, del Handler)
        {
            var aux = new Option();

            aux.OptionName=OptionName;
            aux.Command=Command;
            aux.Enabled=Enabled;
            aux.Handler=Handler;

            return aux;
        }
        
        public void ListOptions()
        {   
            Console.Clear();

            foreach(String s in Headers)
                Console.WriteLine(s);
            

            foreach(Option o in Options)
            {
                Console.WriteLine("["+o.Command+"] - "+ o.OptionName);
            }

            Console.WriteLine("["+this.Terminator+"] - Exit Menu");

            Console.Write("Choose Wisely >");
        }

 
    }

    public struct Option
    {
        public del Handler;
        public String OptionName;
        public char Command;
        public bool Enabled;
    }

    public delegate void del();
}