using ShortURL.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShortURL.Test.Business
{
    public class ClickBusinessTest : IClassFixture<DependencyFixture>
    {
        private ClickBusiness ClickBusiness;

        public ClickBusinessTest(DependencyFixture fixture)
        {
            ClickBusiness = fixture.Resolve<ClickBusiness>();
        }

        [Fact]
        public void Test_WrongCode()
        {
            long count = ClickBusiness.CountClicksByCode("");
            Assert.Equal(0, count);
        }
    }
}
