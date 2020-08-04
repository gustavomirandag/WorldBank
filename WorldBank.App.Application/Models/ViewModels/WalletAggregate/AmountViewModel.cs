using System;

namespace WorldBank.App.Application.Models.ViewModels.WalletAggregate
{
    //Value Object
    public struct AmountViewModel
    {
        public CurrencyViewModel Currency { get; set; }
        public decimal Value { get; set; }

        public static readonly AmountViewModel MinValue = new AmountViewModel() { Value = decimal.MinValue };           // absolute zero
        public static readonly AmountViewModel MaxValue = new AmountViewModel() { Value = decimal.MaxValue };

        public AmountViewModel(CurrencyViewModel currency, decimal value)
        {
            if (value < AmountViewModel.MinValue.Value)
            {
                throw new ArgumentOutOfRangeException("value", "Value cannot be less then Amount.MinValue (absolute zero)");
            }

            if (value > AmountViewModel.MaxValue.Value)
            {
                throw new ArgumentOutOfRangeException("value", "Value cannot be more then Amount.MaxValue");
            }

            Currency = currency;
            Value = value;
        }

        public AmountViewModel(string currency, decimal value)
        {
            if (value < AmountViewModel.MinValue.Value)
            {
                throw new ArgumentOutOfRangeException("value", "Value cannot be less then Amount.MinValue (absolute zero)");
            }

            if (value > AmountViewModel.MaxValue.Value)
            {
                throw new ArgumentOutOfRangeException("value", "Value cannot be more then Amount.MaxValue");
            }

            Currency = new CurrencyViewModel(currency);
            Value = value;
        }

        public static AmountViewModel NewAmount(CurrencyViewModel currency, decimal value)
        {
            return new AmountViewModel(currency, value);
        }

        public static AmountViewModel Parse(string amountStr)
        {
            var splittedAmount = amountStr.Split(' ');
            CurrencyViewModel currency = splittedAmount[0];
            decimal value = decimal.Parse(splittedAmount[1]);
            return new AmountViewModel(currency, value);
        }

        public static AmountViewModel operator +(AmountViewModel amount1, AmountViewModel amount2)
        {
            if (amount1.Currency != amount2.Currency)
            {
                throw new InvalidCastException("Invalid cast in sum operation.", new Exception("Amounts Currency needs to be of the same type."));
            }

            return new AmountViewModel(amount1.Currency, amount1.Value + amount2.Value);
        }

        public static AmountViewModel operator -(AmountViewModel amount1, AmountViewModel amount2)
        {
            if (amount1.Currency != amount2.Currency)
            {
                throw new InvalidCastException("Invalid cast in subtraction operation.", new Exception("Amounts Currency needs to be of the same type."));
            }

            return new AmountViewModel(amount1.Currency, amount1.Value - amount2.Value);
        }

        public static AmountViewModel operator ++(AmountViewModel amount)
        {
            amount.Value++;
            return amount;
        }

        public static AmountViewModel operator --(AmountViewModel amount)
        {
            amount.Value--;
            return amount;
        }

        public static bool operator ==(AmountViewModel amount1, AmountViewModel amount2)
        {
            if (amount1.Currency != amount2.Currency)
            {
                return false;
            }
            //throw new InvalidCastException("Invalid cast in sum operation.", new Exception("Amounts Currency needs to be of the same type."));
            return amount1.Value == amount2.Value;
        }

        public static bool operator !=(AmountViewModel amount1, AmountViewModel amount2)
        {
            if (amount1.Currency != amount2.Currency)
            {
                return true;
            }
            //throw new InvalidCastException("Invalid cast in sum operation.", new Exception("Amounts Currency needs to be of the same type."));
            return amount1.Value != amount2.Value;
        }

        public static AmountViewModel operator +(AmountViewModel amount, int value)
        {
            return new AmountViewModel(amount.Currency, amount.Value + value);
        }

        public static AmountViewModel operator -(AmountViewModel amount, int value)
        {
            return new AmountViewModel(amount.Currency, amount.Value - value);
        }

        public static implicit operator decimal(AmountViewModel amount)
        {
            return amount.Value;
        }

        public override bool Equals(object obj)
        {
            return this == ((AmountViewModel)obj);
        }

        public override int GetHashCode()
        {
            return this.Currency.GetHashCode() + this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Currency.ToString()} {Value.ToString()}";
        }
    }
}