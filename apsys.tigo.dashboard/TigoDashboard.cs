using System;

namespace apsys.tigo.dashboard
{
    public class TigoDashboard
    {

        public decimal NetSales { get; set; }
        public decimal DirectCost { get; set; }
        public decimal Workforce { get; set; }


        public decimal CalculateThroughput()
        {
            if (NetSales < 0)
                throw new ArgumentException("Net sales can't be lesser to zero");

            if (DirectCost < 0)
                throw new ArgumentException("Direct cost can't be lesser to zero");

            return NetSales - DirectCost;
        }
                

        public static decimal CalculateOperationCost(decimal workforce, decimal manfacturingCost, decimal salesCost, decimal administrationCost, decimal financialCost)
        {
            if (workforce < 0)
                throw new ArgumentException("Worforce can't be lesser to zero");
            if (manfacturingCost < 0)
                throw new ArgumentException("Manfacturing Cost can't be lesser to zero");
            if (salesCost < 0)
                throw new ArgumentException("Sales Cost can't be lesser to zero");
            if (administrationCost < 0)
                throw new ArgumentException("Administration cost can't be lesser to zero");
            if (financialCost < 0)
                throw new ArgumentException("Financial cost cost can't be lesser to zero");

            return workforce + manfacturingCost + salesCost + administrationCost + financialCost;
        }

        public static decimal CalculateInvestment(decimal accountsReceivable, decimal inventoriesAmount, decimal currentAssets, decimal fixedAssets)
        {
            if (accountsReceivable < 0)
                throw new ArgumentException("Accounts receivable can't be lesser to zero");

            if (inventoriesAmount < 0)
                throw new ArgumentException("Inventories amount can't be lesser to zero");

            if (currentAssets < 0)
                throw new ArgumentException("Current assets can't be lesser to zero");

            if (fixedAssets < 0)
                throw new ArgumentException("Fixed assets can't be lesser to zero");

            return accountsReceivable + inventoriesAmount + currentAssets + fixedAssets;
        }
    }
}
