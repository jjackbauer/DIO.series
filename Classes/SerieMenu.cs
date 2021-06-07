using System.Collections.Generic;
using System;
namespace DIO.series
{
    public class SerieMenu : Menu
    {
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
            Options.Add(setOption("Clear Screen",'C',true,Console.Clear));

        }
        public void FunctionListSeries()
        {
            
        }
        public void FunctionAddSeries()
        {
            
        }

        public void FunctionUpdateSeries()
        {
            
        }
        public void FunctionDeleteSeries()
        {
            
        }
        public void FunctionViewSeries()
        {

        }
        
    }

    
}