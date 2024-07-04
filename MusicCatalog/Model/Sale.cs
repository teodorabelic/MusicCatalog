using MusicCatalog.ModelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class Sale
    {
        private int id;
        private SaleTypeEnum.SaleType saleType;
        private string link;

        public Sale(int id, SaleTypeEnum.SaleType saleType, string link)
        {
            this.id = id;
            this.saleType = saleType;
            this.link = link;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public SaleTypeEnum.SaleType SaleType
        {
            get { return saleType; }
            set { saleType = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string StringToCsv()
        {
            return saleType + "|" + link;
        }


    }
}
