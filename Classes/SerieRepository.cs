using System;
using System.Collections.Generic;
using DIO.series.interfaces;

namespace DIO.series
{
    public class SerieRepository : iRepository<Serie>
    {
        List<Serie> Listing = new List<Serie>();
        public Serie Get(int IdItem)
        {
            if(IsInBounds(IdItem))
                return Listing[IdItem];

            return null;
        }

        public List<Serie> GetList()
        {
            return Listing;
        }

        public int GetNextId()
        {
            return Listing.Count;
        }

        public void Insert(Serie Entity)
        {
            Listing.Add(Entity);
        }

        public void Remove(int IdItem)
        {
            if(IsInBounds(IdItem))
                Listing[IdItem].Delete();
        }

        public void Update(int IdItem, Serie Entity)
        {
            if(IsInBounds(IdItem))
                Listing[IdItem] = Entity;
        }
        private bool IsInBounds(int IdItem)
        {
            return (Listing.Count > IdItem && IdItem >= 0);
        }
    }
}