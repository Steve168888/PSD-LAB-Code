using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Repository
{
    public class AlbumRepository
    {
        private static DatabaseEntities db = SingletonDatabase.GetInstance();
        public Album getAlbumByName(string name)
        {
            Album albumFound = (from x in db.Albums where name == x.albumName select x).FirstOrDefault();
            return albumFound;
        }

        public int getArtistIDbyName(string name)
        {
            Artist artistFound = (from x in db.Artists where name == x.artistName select x).FirstOrDefault();
            return artistFound.artistId;
        }

        public void registerAlbum(Album albumDetail)
        {
            db.Albums.Add(albumDetail);
            db.SaveChanges();
        }
    }
}