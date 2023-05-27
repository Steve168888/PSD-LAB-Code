using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Repository
{
    public class ArtistRepository
    {
        private static DatabaseEntities db = SingletonDatabase.GetInstance();

        public void registerArtist(Artist artistDetail)
        {
            db.Artists.Add(artistDetail);
            db.SaveChanges();
        }

        public Artist getArtistByName(string name)
        {
            Artist artistFound = (from x in db.Artists where name == x.artistName select x).FirstOrDefault();
            return artistFound;
        }

        public Artist getArtistByID(int id)
        {
            Artist artistFound = (from x in db.Artists where id == x.artistId select x).FirstOrDefault();
            return artistFound;
        }
    }
}