using NUnit.Framework;
using System;

namespace apsys.tigo.dashboard.tests
{
    public class TigoDashboardTests
    {
        public TigoDashboard ClassUnderTest { get; set; }

        [TestCase(100000, 55000)]
        [TestCase(85600, 42300)]
        [TestCase(150000.00, 85000.00)]
        [TestCase(0.00, 85000.00)]
        [TestCase(85000.00, 0.00)]
        [TestCase(0.00, 0.00)]
        public void CalculateThroughput_ValidParams_ReturnExpectedThroughput(decimal netSales, decimal directCost)
        {
            // Arrange
            SetMockData(netSales, directCost);
            // Act
            decimal throughput = ClassUnderTest.CalculateThroughput();
            // Assert
            Assert.That(throughput, Is.EqualTo(netSales - directCost));
        }

        [Test]
        public void CalculateThroughput_InvalidNetSales_ThrowsArgumentInvalidException()
        {
            // Arrange
            SetMockData(-1000, 68888);
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(()=> ClassUnderTest.CalculateThroughput());
            Assert.That(exception.Message, Is.EqualTo("Net sales can't be lesser to zero"));
        }

        [Test]
        public void CalculateThroughput_InvalidDirectCost_ThrowsArgumentInvalidException()
        {
            // Arrange
            SetMockData(68888, -1000);
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ClassUnderTest.CalculateThroughput());
            Assert.That(exception.Message, Is.EqualTo("Direct cost can't be lesser to zero"));
        }

        [TestCase(8000.00, 1200.00, 3000.00, 1200.00, 250.00, 13650.00)]
        [TestCase(8000.00, 1200.00, 2430.00, 825.00, 30.00, 12485.00)]
        [TestCase(10500.00, 1800.00, 2500.00, 1200.00, 300.00, 16300.00)]
        [TestCase(0.00, 0.00, 0.00, 0.00, 0.00, 0.00)]
        public void CalculateOperationCost_ValidParams_ReturnExpectedDirectCost(decimal workforce, decimal manfacturingCost, decimal salesCost, decimal administrationCost, decimal financialCost, decimal expectedDirectCost)
        {
            //Act
            decimal operationCost = TigoDashboard.CalculateOperationCost(workforce, manfacturingCost, salesCost, administrationCost, financialCost);
            ///Assert
            Assert.That(operationCost, Is.EqualTo(expectedDirectCost));
        }

        [Test]
        public void CalculateOperationCost_InvalidWorkforce_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateOperationCost(-1000, 10, 10, 10,25));
            Assert.That(exception.Message, Is.EqualTo("Worforce can't be lesser to zero"));
        }
        [Test]
        public void CalculateOperationCost_InvalidManfacturingCost_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateOperationCost(1000, -10, 10, 10, 25));
            Assert.That(exception.Message, Is.EqualTo("Manfacturing Cost can't be lesser to zero"));
        }

        [Test]
        public void CalculateOperationCost_InvalidSalesCost_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateOperationCost(1000, 10, -10, 10, 25));
            Assert.That(exception.Message, Is.EqualTo("Sales Cost can't be lesser to zero"));
        }

        [Test]
        public void CalculateOperationCost_InvalidAdministrationCost_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateOperationCost(1000, 10, 10, -10, 25));
            Assert.That(exception.Message, Is.EqualTo("Administration cost can't be lesser to zero"));
        }

        [Test]
        public void CalculateOperationCost_InvalidFinancialCost_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateOperationCost(1000, 10, 10, 10, -25));
            Assert.That(exception.Message, Is.EqualTo("Financial cost cost can't be lesser to zero"));
        }

        [TestCase(25000, 2500, 0, 50000, 77500)]
        [TestCase(25000, 1500, 0, 52000, 78500)]
        public void CalculateInvestment_ValidParams_ReturnExpectedInvestment(decimal accountsReceivable, decimal inventoriesAmount, decimal currentAssets, decimal fixedAssets, decimal expectedInvestment)
        {
            // Act
            decimal investment = TigoDashboard.CalculateInvestment(accountsReceivable, inventoriesAmount, currentAssets, fixedAssets);
            // Assert
            Assert.That(investment, Is.EqualTo(expectedInvestment));
        }

        [Test]
        public void CalculateInvestment_InvalidAccountsReceivable_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateInvestment(-10, 10, 10, 10));
            Assert.That(exception.Message, Is.EqualTo("Accounts receivable can't be lesser to zero"));
        }

        [Test]
        public void CalculateInvestment_InvalidInventoriesAmount_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateInvestment(10, -10, 10, 10));
            Assert.That(exception.Message, Is.EqualTo("Inventories amount can't be lesser to zero"));
        }

        [Test]
        public void CalculateInvestment_InvalidAccountsCurrentAssets_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateInvestment(10, 10, -10, 10));
            Assert.That(exception.Message, Is.EqualTo("Current assets can't be lesser to zero"));
        }

        [Test]
        public void CalculateInvestment_InvalidFixedAssets_ThrowsArgumentInvalidException()
        {
            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => TigoDashboard.CalculateInvestment(10, 10, 10, -10));
            Assert.That(exception.Message, Is.EqualTo("Fixed assets can't be lesser to zero"));
        }

        [Test]
        public void CalculateUtility_ValidParams_return()
        {

        }

        [SetUp]
        public void SetUp()
        {
            ClassUnderTest = new TigoDashboard();
        }

        public void SetMockData(decimal netSales, decimal directCost)
        {
            ClassUnderTest.NetSales = netSales;
            ClassUnderTest.DirectCost = directCost;
        }

    }
}
