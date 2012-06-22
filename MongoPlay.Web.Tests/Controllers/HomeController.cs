using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace MongoPlay.Web.Tests.Controllers
{
    public class HomeController
    {
        [Fact]
        public void CanRunIndexAction()
        {
            var controller = new Web.Controllers.HomeController();
            var result = controller.Index();
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
