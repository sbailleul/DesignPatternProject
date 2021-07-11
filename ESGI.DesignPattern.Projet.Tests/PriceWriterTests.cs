using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class PriceWriterTests
    {
        [Fact]
        public void Price_writer_works()
        {
            
            var price = new Price(21, "USD");

            var sut = new PriceWriter(price);
            var expectedResult = "<price currency='USD'>" +
                                 "21.00" +
                                 "</price>";
            
            Assert.Equal(expectedResult, sut.GetContent());
            
        }
        
        [Fact]
        public void Price_writer_should_handle_negative_price()
        {
            
            var price = new Price(-21, "USD");

            var sut = new PriceWriter(price);
            var expectedResult = "<price currency='USD'>" +
                                 "-21.00" +
                                 "</price>";
            
            Assert.Equal(expectedResult, sut.GetContent());
            
        }
        
        [Fact]
        public void Price_writer_should_round_up_lower_than_cents()
        {
            
            var price = new Price(0.499,"USD");

            var sut = new PriceWriter(price);
            var expectedResult = "<price currency='USD'>" +
                                 "0.50" +
                                 "</price>";
            
            Assert.Equal(expectedResult, sut.GetContent());
        }
    }
}