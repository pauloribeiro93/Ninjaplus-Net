using NUnit.Framework;
using NinjaPlus.Common;

namespace NinjasPlus.Tests 
{
    public class OnAirTest : BaseTest 
    {

        [Test]
        [Category("Smoke")] 
        public void ShouldBeHaveTitle() 
        {
          
            Browser.Visit("/login"); 
            Assert.AreEqual("Ninja+", Browser.Title); 

        
        }
      
    }
}
