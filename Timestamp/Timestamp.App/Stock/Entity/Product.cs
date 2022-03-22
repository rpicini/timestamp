using Timestamp.Core;
using Timestamp.Core.Validation;

namespace Timestamp.App.Stock.Entity
{
    public class Product
    {
        public Product(string Name, TypeEnum Type, string Brand, int Amount, string Currency, decimal UnitPrice)
        {
            UpdateInfo(Name, Type, Brand, Amount, Currency, UnitPrice);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
        public string Brand { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public decimal UnitPrice { get; set; }

        public void UpdateInfo(string name, TypeEnum type, string brand, int amount, string currency, decimal unitPrice)
        {
            new Guard()
                    .NotNullOrEmpty(nameof(Name), name)
                    .EnumValidate(type)
                    .NotNullOrEmpty(nameof(Brand), brand)
                    .NotNullOrEmpty(nameof(Currency), currency)
                    .GreaterThan(nameof(UnitPrice), unitPrice, 0)
                    .GreaterThan(nameof(Amount), amount, 0)
                    .Validate();

            Name = name;
            Type = type;
            Brand = brand;
            Amount = amount;
            Currency = currency;
            UnitPrice = unitPrice;
        }

    }
}
