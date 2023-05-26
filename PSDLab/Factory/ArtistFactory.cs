using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Factory
{
    public class ArtistFactory
    {
        public Artist CreateArtist(int id, string name, string image)
        {
            return new Artist
            {
                artistId = id,
                artistName = name,
                artistImage = image
            };
        }
    }
}