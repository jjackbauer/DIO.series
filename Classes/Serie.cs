using System;
namespace DIO.series
{
    public class Serie : BaseEntity
    {
        private Genres Genre {get; set;}
        private String Title{get; set;}

        private String Description{get; set;}
        private int Year{get; set;}

        public Serie(int Id,Genres Genre, String Title, String Description, int Year)
        {
            this.Id = Id;
            this.Genre = Genre;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;
        }

        public override string ToString()
        {
            String output = "";
            output+="Genre: "+this.Genre+Environment.NewLine;
            output+="Title: "+this.Title+Environment.NewLine;
            output+="Description: "+this.Description+Environment.NewLine;
            output+="Since: "+this.Year+Environment.NewLine;
            return output;
        }
    }
}