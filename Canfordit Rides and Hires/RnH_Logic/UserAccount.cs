using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Canfordit_Rides_and_Hires.Models;

namespace Canfordit_Rides_and_Hires.RnH_Logic
{
    public class UserAccount
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<UserProfile> GetUsers()
        {
            return db.UserProfiles.ToList();
        }

        public bool NewUser(UserProfile model)
        {
            try
            {
                db.UserProfiles.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}