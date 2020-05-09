using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LidiaDishnicaWeb.Models
{
    public class CommodityRootsModel
    {
        public CommodityRootsModel()
        {
        }
        public int id { get; set; }
        [DisplayName("Code")]
        public string Code { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Active")]
        public bool Active { get; set; }

        [DisplayName("CommodityChapterId")]
        public int CommodityChapterId { get; set; }

        public void Fill(LidiaDishnica.CommodityRoots itemToFill)
        {
            itemToFill.Name = this.Name;
        }
    }
}