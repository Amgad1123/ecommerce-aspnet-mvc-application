using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models
{
    public interface ITransactionRepository
    {
        TransactionModel GetTransactionById(int transactionId);
        void SaveTransaction(TransactionModel transaction);
        void DeleteTransaction(int transactionId);
    }

    public partial class TransactionModel : ITransactionRepository
    {
        [Key]
        public int TransactionId { get; set; }

        public int OrderId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public virtual OrderModel Order { get; set; }

        public TransactionModel GetTransactionById(int transactionId)
        {
            // TODO: Implement logic to fetch transaction by ID
            throw new NotImplementedException();
        }

        public void SaveTransaction(TransactionModel transaction)
        {
            // TODO: Implement logic to save/update transaction
            throw new NotImplementedException();
        }

        public void DeleteTransaction(int transactionId)
        {
            // TODO: Implement logic to delete transaction by ID
            throw new NotImplementedException();
        }
    }
}
