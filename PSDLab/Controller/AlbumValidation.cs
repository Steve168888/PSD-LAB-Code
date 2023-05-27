using PSDLab.Model;
using PSDLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Controller
{
    public class AlbumValidation
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        public bool validateInput(string name, string desc, int price, int stock)
        {
            Album albumFound = (from x in db.Albums where x.albumName == name select x).FirstOrDefault();
            if (albumFound != null)
            {
                return false;
            }
            else if(name.Length <= 0 || name.Length >= 50)
            {
                return false;
            }
            else if(desc.Length <= 0 || desc.Length >= 255)
            {
                return false;
            }
            else if(stock <= 0)
            {
                return false;
            }
            else if(price < 100000 || price > 1000000)
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