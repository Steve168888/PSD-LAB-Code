using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Factory
{
    public class AlbumFactory
    {
        public Album CreateAlbum(int id, string name, string desc, int price, int stock, int artistId, string imagePath)
        {
            return new Album
            {
                albumId = id, 
                albumName = name, 
                albumDesc = desc, 
                albumPrice = price, 
                albumStock = stock, 
                artistId = artistId, 
                albumImage = imagePath
            };
        }
    }
}