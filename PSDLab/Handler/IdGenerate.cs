using PSDLab.Model;
using PSDLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Handler
{
    public class IdGenerate
    {
        public static DatabaseEntities db = SingletonDatabase.GetInstance();
        public static int GenerateAlbumID()
        {
            bool isTableEmpty = !db.Albums.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.Albums.Max(c => c.albumId)) + 1;
                return nextId;
            }
        }

        public static int GenerateArtistID()
        {
            bool isTableEmpty = !db.Artists.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.Artists.Max(c => c.artistId)) + 1;
                return nextId;
            }
        }

        public static int GenerateUserID()
        {
            bool isTableEmpty = !db.Customers.Any();
            if (isTableEmpty)
            {
                return 0;
            }
            else
            {
                int nextId = (db.Customers.Max(c => c.customerId)) + 1;
                return nextId;
            }
        }
    }
}