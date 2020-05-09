using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LidiaDishnicaWeb.Models
{
    public class CommodityChapterModel
    {
        public int id { get; set; }
        [DisplayName("Code")]
        public string Code { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Active")]
        public bool Active { get; set; }

        [DisplayName("CommoditySectionId")]
        public int CommoditySectionId { get; set; }

        public List<LidiaDishnica.CommodityRoots> CommodityRootsItems { get; set; }


        //insert values to save
        public void Fill(LidiaDishnica.CommodityChapters itemToFill)
        {

            itemToFill.Active = this.Active;
            itemToFill.Code = this.Code;
            itemToFill.CommoditySectionId = this.CommoditySectionId;
            itemToFill.Description = this.Description;
            itemToFill.Id = this.id;
            itemToFill.Name = this.Name;

        }

        //fill form values edit case
        public void Preselect(LidiaDishnica.CommodityChapters item)
        {
            if (item != null)
            {
                this.id = item.Id;
                this.Active = item.Active;
                this.Code = item.Code;
                this.CommoditySectionId = item.CommoditySectionId;
                this.Description = item.Description;
                this.Name = item.Name;
            }
        }



    }
}