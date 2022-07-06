using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Utilities.ImageSecurity
{
    public static class ImageSecurity
    {
        public static bool IsImage(this IFormFile file)
        {
            try
            {
                var ime = System.Drawing.Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    //TODO : Find The Library for Video too
}
