using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => this.Portfolio.Count;
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && stock.PricePerShare <= this.MoneyToInvest)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            var targetStock = this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (targetStock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < targetStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.Portfolio.Remove(targetStock);
                this.MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }

        }
        public Stock FindStock(string companyName)
        {
            var targetStock = this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (targetStock == null)
            {
                return null;
            }
            return targetStock;
        }
        public Stock FindBiggestCompany()
        {

            if (this.Portfolio.Count > 0)
            {
                this.Portfolio.OrderByDescending(x => x.MarketCapitalization);
                return this.Portfolio[0];
            }
            return null;
        }
        public string InvestorInformation()
        {

            //return
            //    $"The investor {this.FullName} with a broker {this.BrokerName} has stocks: " + Environment.NewLine +
            //    string.Join(Environment.NewLine, Portfolio);


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine($"{stock}");
            }


            return sb.ToString().TrimEnd();
        }

    }
}
