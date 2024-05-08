using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models
{
    public interface ISaleRepository
    {
        SaleModel GetSaleById(int saleId);
        void SaveSale(SaleModel sale);
        void DeleteSale(int saleId);
    }

    public partial class SaleModel : ISaleRepository
    {
        public SaleModel()
        {
        }

        [Key]
        public int SalesID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProductID { get; set; }

        public decimal Price { get; set; }

        public virtual string Name { get; set; }

        public decimal SalesPercentage { get; set; }

        public virtual ProductModel Product { get; set; }

        public SaleModel GetSaleById(int saleId)
        {
            // TODO: Implement logic to fetch sale by ID
            throw new NotImplementedException();
        }

        public void SaveSale(SaleModel sale)
        {
            // TODO: Implement logic to save/update sale
            throw new NotImplementedException();
        }

        public void DeleteSale(int saleId)
        {
            // TODO: Implement logic to delete sale by ID
            throw new NotImplementedException();
        }
    }
}
