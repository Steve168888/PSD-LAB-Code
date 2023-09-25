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

        public Album getAlbumByID(int id)
        {
            Album albumFound = (from x in db.Albums where id == x.albumId select x).FirstOrDefault();
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
        public void RemoveAlbum(int albumId)
        {
            // Retrieve the album from the database
            Album albumToRemove = db.Albums.FirstOrDefault(x => x.albumId == albumId);

            if (albumToRemove != null)
            {
                // Remove the album from the database context
                db.Albums.Remove(albumToRemove);
                db.SaveChanges();
            }
        }
        public static class CartFactory
        {
            public static Cart Createcart(int customer_Id, int album_Id)
            {
                // Create a new Cart instance with the provided customerId and albumId
                // Example:
                return new Cart
                {
                    customerId = customer_Id,
                    albumId = album_Id
                };
            }
        }
        public static void addNewCart(int customerId, int albumId)
        {
            Cart newCart = CartFactory.Createcart(customerId, albumId);
            db.Carts.Add(newCart);
            db.SaveChanges();
        }

    }
}