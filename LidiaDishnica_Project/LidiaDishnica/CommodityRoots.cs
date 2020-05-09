using Guest19.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LidiaDishnica
{
    //[Serializable]
    public class CommodityRoots
    {

        #region Constructors

        CommodityRoots(Guest19.Database.CommodityRoots commodityRoots)
        {

            Id = commodityRoots.Id;
            CommodityChapterId = commodityRoots.CommodityChapterId;
            Code = commodityRoots.Code;
            Name = commodityRoots.Name;
            Description = commodityRoots.Description;
            Active = commodityRoots.Active;

        }
        public CommodityRoots()
        {
        }
        #endregion

        #region Attributes

        public int Id { get; set; }
        public int CommodityChapterId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        #endregion

        #region Methods

        public bool Save()
        {
            bool saved;
            try
            {
                using (var context = new Guest19DataContext())
                {

                    var dbItem = context.CommodityRoots.SingleOrDefault(i => i.Id == this.Id);

                    //update
                    if (dbItem != null)
                    {

                        dbItem.Active = this.Active;
                        dbItem.Code = this.Code;
                        dbItem.CommodityChapterId = this.CommodityChapterId;
                        dbItem.Description = this.Description;
                        dbItem.Name = this.Name;

                        context.SubmitChanges();//update il db
                        saved = true;
                    }
                    //new
                    else
                    {
                        var newDbItem = new Guest19.Database.CommodityRoots();
                        newDbItem.Active = this.Active;
                        newDbItem.Code = this.Code;
                        newDbItem.CommodityChapterId = this.CommodityChapterId;
                        newDbItem.Description = this.Description;
                        newDbItem.Name = this.Name;

                        context.CommodityRoots.InsertOnSubmit(newDbItem);//insert new records in db
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

        public List<CommodityRoots> GetByIdParent(int? rootId = null)
        {
            using (var context = new Guest19DataContext())
            {
                var query =
                    from root in context.CommodityRoots
                         .Where(i =>
                            (rootId.HasValue ? i.CommodityChapterId == rootId : true)
                            &&
                            (i.Active))


                    select new CommodityRoots(root);

                return query.ToList();
            }
        }
        public CommodityRoots GetById(int? id = null)
        {
            using (var context = new Guest19DataContext())
            {
                var query =
                    from root in context.CommodityRoots
                         .Where(i =>
                            (id.HasValue ? i.Id == id : true)
                            &&
                            (i.Active))
                    select new CommodityRoots(root);

                return query.FirstOrDefault();
            }
        }

        #endregion


    }
}
