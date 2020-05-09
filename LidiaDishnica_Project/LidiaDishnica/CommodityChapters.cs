using Guest19.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LidiaDishnica
{
    public class CommodityChapters 
        //: ITreeNode<CommodityChapters>
    {
        #region Constructors

         CommodityChapters(Guest19.Database.CommodityChapters commodityChapters)
        {
            Id = commodityChapters.Id;
            CommoditySectionId = commodityChapters.CommoditySectionId;
            Code = commodityChapters.Code;
            Name = commodityChapters.Name;
            Description = commodityChapters.Description;
            Active = commodityChapters.Active;
        }

        public CommodityChapters()
        {
           //Children= new List<CommodityRoots>();
        }
        #endregion

        #region Attributes

        public int Id { get;  set; }
        public int CommoditySectionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        //public List<CommodityRoots> Children { get; set; }


        #endregion

        #region Methods

        public bool Save()
        {
            bool saved;
            try
            {
                using (var context = new Guest19DataContext())
                {

                    var dbItem = context.CommodityChapters.SingleOrDefault(i => i.Id == this.Id);

                    //update
                    if (dbItem != null)
                    {

                        dbItem.Active = this.Active;
                        dbItem.Code = this.Code;
                        dbItem.CommoditySectionId = this.CommoditySectionId;
                        dbItem.Description = this.Description;
                        dbItem.Name = this.Name;

                        context.SubmitChanges();//update il db
                        saved = true;
                    }
                    //new
                    else
                    {
                        var newDbItem = new Guest19.Database.CommodityChapters();
                        newDbItem.Active = this.Active;
                        newDbItem.Code = this.Code;
                        newDbItem.CommoditySectionId = this.CommoditySectionId;
                        newDbItem.Description = this.Description;
                        newDbItem.Name = this.Name;

                        context.CommodityChapters.InsertOnSubmit(newDbItem);//insert new records in db
                        context.SubmitChanges();
                        saved = true;
                    }
                }
            }
            catch (Exception ex)
            {

                saved = false;
            }
            return saved;
        }

        public void Delete()
        {
            this.Active = false;
            Save();
        }

        public  List<CommodityChapters> Search(int? rootId = null, string code = null,
           string name = null)
        {
            using (var context = new Guest19DataContext())
            {
                var query =
                    from chapter in context.CommodityChapters
                       .Where(i =>i.Active)
                       
                    select new CommodityChapters(chapter);

                return query.ToList();
            }
        }
        

        #endregion
    }
}
