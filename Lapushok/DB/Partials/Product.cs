using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lapushok.DB
{
    public partial class Product
    {
        public string MaterialsList
        {
            get
            {
                return $"Материалы: {string.Join(" ,", ProductMaterial.Select(x => x.Material.Name))}";
            }
        }

        public string Photo
        {
            get
            {
                string result = Image;
                string imagePng = "/Images/picture.png";

                if (result == null)
                {
                    return imagePng;
                }
                else
                {
                    return result;
                }

            }
        }
        
        //public string ColorCard
        //{
        //    get 
        //    {
        //        string result = "#ff4c5b";
        //        if (DateTime.mon)
        //        {
        //            return
        //        }
        //        else
        //        {
        //            return 
        //        }
        //    }
        //}
    }
}
