using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Factory
{
    public class CartFactory
    {
        public static Cart Createcart(int id, int album_id )
        {
            return new Cart
            {
                customerId = id,
                albumId = album_id,
                Qty = 1
            };
        }
    }
}