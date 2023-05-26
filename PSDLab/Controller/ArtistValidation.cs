using PSDLab.Model;
using PSDLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Controller
{
    public class ArtistValidation
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        public bool validateName(string name)
        {
            Artist artistFound = (from x in db.Artists where x.artistName == name select x).FirstOrDefault();
            if(artistFound != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}