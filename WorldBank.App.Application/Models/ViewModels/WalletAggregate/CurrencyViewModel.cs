using System;

namespace WorldBank.App.Application.Models.ViewModels.WalletAggregate
{
    //Value Object
    public struct CurrencyViewModel : IComparable<CurrencyViewModel>
    {
        //Exemplos de Code: USD, BRL, BTC etc.
        public string Code { get; set; }

        public CurrencyViewModel(string code)
        {
            if (code.Length != 3)
            {
                throw new ArgumentOutOfRangeException("Currency needs to have three characters length.");
            }

            Code = code;
        }

        public static implicit operator string(CurrencyViewModel currency)
        {
            return currency.Code;
        }


        public static implicit operator CurrencyViewModel(string currency)
        {
            return new CurrencyViewModel(currency);
        }

        public static bool operator ==(CurrencyViewModel currency1, CurrencyViewModel currency2)
        {
            if (currency1.Code == currency2.Code)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(CurrencyViewModel currency1, CurrencyViewModel currency2)
        {
            if (currency1.Code != currency2.Code)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }

        public override string ToString()
        {
            return Code;
        }

        public int CompareTo(CurrencyViewModel other)
        {
            return this.Code.CompareTo(other.Code);
        }
    }
}
