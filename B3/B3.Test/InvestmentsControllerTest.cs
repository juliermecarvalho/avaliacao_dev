using B3.Controllers;
using B3.Models;

namespace B3.Test
{
    [TestClass]
    public class InvestmentsControllerTest
    {
       

        [TestMethod]
        public void Calculate_final_value_6()
        {
            // Arrange
            var investment = new Investment(10, 6);
            var expcted = 7.82533000M;

            // Act
            var actual = investment.CalculateFinalValue();

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
            var actual = investment.CalculateFinalValue();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);

        }

        [TestMethod]
        public void Calculate_final_value_24()
        {
            // Arrange
            var investment = new Investment(10, 24);
            var expcted = 8.33019000M;

            // Act
            var actual = investment.CalculateFinalValue();

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
            var actual = investment.CalculateFinalValue();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error the month must be greater than 0")]
        public void Generates_error_the_month_less_than_one()
        {
            // Arrange
            new Investment(10, 0);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error initial value must be greater than 0")]
        public void Generates_error_when_initial_value_less_than_zero()
        {
            // Arrange
             new Investment(0, 1);



        }

        [TestMethod]
        public void Checks_if_the_method_calculatefinalvalue_is_called()
        {
            // Arrange
            var controller = new InvestmentsController();
            var expcted = 8.5826200M;

            // Act
            var actual = controller.CalculateFinalValue(10, 25);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expcted, actual);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error, the CDI must be greater than 0")]
        public void GeneratesErrorWhenCdiValueLessThanZero()
        {
            // Arrange
            new Investment(0, 1);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error, the CDI must be greater than 0")]
        public void GeneratesErrorWhenTbValueLessThanZero()
        {
            // Arrange
            new Investment(0, 1);
          
        }
      

    }
}
