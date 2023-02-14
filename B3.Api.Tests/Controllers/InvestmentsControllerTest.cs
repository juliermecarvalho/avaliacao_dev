using B3.Api.Controllers;
using B3.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace B3.Api.Tests.Controllers
{
    [TestClass]
    public class InvestmentsControllerTest
    {
        const decimal cdi = 0.009m;
        const decimal tb = 1.08m;

        [TestMethod]
        public void Calculate_final_value_6()
        {
            // Arrange
            var investment = new Investment(10, 6);
            var expcted = 7.82533000M;

            // Act
            var actual = investment.CalculateFinalValue(cdi, tb);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);

        }

        [TestMethod]
        public void Calculate_final_value_12()
        {
            // Arrange
            var investment = new Investment(10, 12);
            var expcted = 8.077760M;

            // Act
            var actual = investment.CalculateFinalValue(cdi, tb);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);

        }

        [TestMethod]
        public void Calculate_final_value_24()
        {
            // Arrange
            var investment = new Investment(10,24);
            var expcted = 8.33019000M;

            // Act
            var actual = investment.CalculateFinalValue(cdi, tb);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);

        }

        [TestMethod]
        public void Calculate_final_value_maior_que_24()
        {
            // Arrange
            var investment = new Investment(10, 25);
            var expcted = 8.5826200M;

            // Act
            var actual = investment.CalculateFinalValue(cdi, tb);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error the month must be greater than 0")]
        public void Generates_error_the_month_less_than_one()
        {
            // Arrange
            
            var investment = new Investment(10,0);
           

            // Act
            investment.GetTaxPercentage();
                      
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error initial value must be greater than 0")]
        public void Generates_error_when_initial_value_less_than_zero()
        {
            // Arrange
            var investment = new Investment(0, 1);

            // Act
            investment.CalculateFinalValue(cdi, tb);


        }

        [TestMethod]
        public void Checks_if_the_method_calculatefinalvalue_is_called()
        {
            // Arrange
            var controller = new InvestmentsController();
            var investment = new Investment(10, 25);
            var expcted = 8.5826200M;

            // Act
            var actual = controller.CalculateFinalValue(investment);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error, the CDI must be greater than 0")]
        public void Generates_error_when_cdi_value_less_than_zero()
        {
            // Arrange
            var investment = new Investment(0, 1);

            // Act
            investment.CalculateFinalValue(cdi, tb);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error, the CDI must be greater than 0")]
        public void Generates_error_when_tb_value_less_than_zero()
        {
            // Arrange
            var investment = new Investment(0, 1);

            // Act
            investment.CalculateFinalValue(cdi, tb);


        }


    }
}
