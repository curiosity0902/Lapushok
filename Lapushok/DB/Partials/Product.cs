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

        public string ColorCard
        {
            get
            {
                bool hasBeenSoldInLastMonth = CheckSalesInLastMonth(); 

                if (!hasBeenSoldInLastMonth)
                {
                    return "#ffcccc"; 
                }
                else
                {
                    return "#ffffff"; 
                }
            }
        }

        private bool CheckSalesInLastMonth()
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

            var salesCount = HistoryRealesProduct.Where(s => s.Date >= oneMonthAgo).Count();

            return salesCount > 0;
        }

        public string RealCost
        {
            get 
            {
                return $"{ProductMaterial.Sum(x => x.CountMaterial * x.Material.Cost)} руб.";
            }
        }

    }
}
