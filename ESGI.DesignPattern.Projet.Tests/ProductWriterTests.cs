using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class ProductWriterTests
    {
        [Fact]
        public void Produce_writer_works()
        {
            
            var tshirtProduct = new Product(4321, "T-Shirt", ProductSize.Medium, new Price(21, "USD"), "red");

            var sut = new ProductWriter(tshirtProduct);
            var expectedResult = "<product id='4321' color='red' size='medium'>" +
                                 "<price currency='USD'>" +
                                 "21.00" +
                                 "</price>" +
                                 "T-Shirt" +
                                 "</product>";
            
            Assert.Equal(expectedResult, sut.GetContent());
            
        }

        [Fact]
        public void Produce_writer_shouldnt_display_non_existing_size()
        {
            
            var tshirtProduct = new Product(4321, "T-Shirt", null, new Price(21, "USD"), "red");

            var sut = new ProductWriter(tshirtProduct);
            var expectedResult = "<product id='4321' color='red'>" +
                                 "<price currency='USD'>" +
                                 "21.00" +
                                 "</price>" +
                                 "T-Shirt" +
                                 "</product>";
            
            Assert.Equal(expectedResult, sut.GetContent());
            
        }
        
        [Fact]
        public void Produce_writer_should_display_NOT_APPLICABLE_for_unhandled_size()
        {
            
            var tshirtProduct = new Product(4321, "T-Shirt", ProductSize.ExtraLarge, new Price(21, "USD"), "red");

            var sut = new ProductWriter(tshirtProduct);
            var expectedResult = "<product id='4321' color='red' size='NOT APPLICABLE'>" +
                                 "<price currency='USD'>" +
                                 "21.00" +
                                 "</price>" +
                                 "T-Shirt" +
                                 "</product>";
            
            Assert.Equal(expectedResult, sut.GetContent());
            
        }
    }
}