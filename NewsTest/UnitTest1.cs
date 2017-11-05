using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinskNews.Controllers;
using MinskNews.Models;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using MinskNews;

namespace NewsTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Проверка разбиения на страницы
        /// </summary>
        //[TestMethod]
        //public void PagingTest()
        //{
        //    // Arrange
        //    // Макет репозитория
        //    var mock = new Mock<IRepository<News>>();
        //    mock.Setup(r => r.GetAll()).Returns(new List<News> {
        //                                            new News { Id = 1 },
        //                                            new News { Id = 2 },
        //                                            new News { Id = 3 },
        //                                            new News { Id = 4 },
        //                                            new News { Id = 5 },
        //                                            new News { Id = 6 },
        //                                            new News { Id = 7 }
        //                                            });
        //    // Создание объекта контроллера
        //    var controller = new HomeController(mock.Object);

        //    // Макеты для получения HttpContext HttpRequest
        //    var request = new Mock<HttpRequestBase>();
        //    var httpContext = new Mock<HttpContextBase>();
        //    httpContext.Setup(h => h.Request).Returns(request.Object);
        //    // Создание контекста контроллера
        //    controller.ControllerContext = new ControllerContext();
        //    controller.ControllerContext.HttpContext = httpContext.Object;

        //    // Act
        //    // Вызов метода Index
        //    var view = controller.Index(2) as ViewResult;
           
            
        //    // Assert
        //    Assert.IsNotNull(view, "Представление не получено");
        //    Assert.IsNotNull(view.Model, "Модель не получена");
        //    PageListViewModel<News> model = view.Model as PageListViewModel<News>;
        //    Assert.AreEqual(2, model.Count);
        //    Assert.AreEqual(6, model[0].Id);
        //    Assert.AreEqual(7, model[1].Id);
        //}


        /// <summary>
        /// Проверка на выборку 3 случайных новостей
        /// </summary>
        [TestMethod]
        public void RandThreeTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<News>>();
            mock.Setup(r => r.GetAll()).Returns(new List<News> { new News { Id = 1 } });
            
            // Создание объекта контроллера
            var controller = new HomeController(mock.Object);

            // Act
            // Вызов метода Index
            var list = controller.RandThree() as List<News>;

            // Assert
            Assert.IsNotNull(list, "Список не получен");
            Assert.AreEqual(3, list.Count);
        }
    }
}
