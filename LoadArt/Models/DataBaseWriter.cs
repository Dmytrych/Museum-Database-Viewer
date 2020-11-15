using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadArt.Models;

namespace LoadArt.Models
{
    public static class DataBaseWriter
    {
        public static void Write(Picture picture)
        {
            using (MuseumContext db = new MuseumContext())
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
            }
        }
        public static async Task WriteAsync(Picture picture)
        {
            using(MuseumContext db = new MuseumContext())
            {
                db.Pictures.Add(picture);
                await db.SaveChangesAsync();
            }
        }
    }
}
