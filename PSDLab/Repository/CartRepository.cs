using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Repository
{
    public class CartRepository
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        public List<Album> getAllCartContent(int customerId)
        {
            List<Album> albumList = new List<Album>();

            albumList = (from c in db.Carts
                            join a in db.Albums on c.albumId equals a.albumId
                            where c.customerId == customerId
                            select new
                            {
                                albumId = a.albumId,
                                albumName = a.albumName,
                                albumDesc = a.albumDesc,
                                albumPrice = a.albumPrice,
                                albumStock = a.albumStock,
                                albumImage = a.albumImage
                            })
                        .AsEnumerable()
                        .Select(a => new Album
                        {
                            albumId = a.albumId,
                            albumName = a.albumName,
                            albumDesc = a.albumDesc,
                            albumPrice = a.albumPrice,
                            albumStock = a.albumStock,
                            albumImage = a.albumImage
                        })
                            .ToList();

            return albumList;
        }

        public List<Cart> getAlbumQty(int customerId)
        {
            List<Cart> listQty = (from x in db.Carts where x.customerId == customerId select x).ToList();
            return listQty;
        }
    }
}