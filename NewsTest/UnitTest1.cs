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
        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<News>>();
            mock.Setup(r => r.GetAll()).Returns(new List<News> {
                                                    new News { Id = 1 },
                                                    new News { Id = 2 },
                                                    new News { Id = 3 },
                                                    new News { Id = 4 },
                                                    new News { Id = 5 },
                                                    new News { Id = 6 },
                                                    new News { Id = 7 }
                                                    });
            // Создание объекта контроллера
            var controller = new HomeController(mock.Object);

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            // Вызов метода Index
            var view = controller.Index(2) as ViewResult;


            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<News> model = view.Model as PageListViewModel<News>;
            
            //длинна списка обьектов = 2
            Assert.AreEqual(2, model.Count);
            //Id объектов списка соответствуют двум последним элементам списка
            Assert.AreEqual(6, model[0].Id);
            Assert.AreEqual(7, model[1].Id);
        }


        /// <summary>
        /// Проверка на выборку 3 случайных новостей
        /// </summary>
        [TestMethod]
        public void RandThreeTest()
        {
            // Arrange
            var mock = new Mock<IRepository<News>>();
            mock.Setup(r => r.GetAll()).Returns(new List<News> { new News { Id = 1 } });

            var controller = new HomeController(mock.Object);

            // Act
            // Вызов метода RandThree
            var list = controller.RandThree() as List<News>;

            // Assert
            Assert.IsNotNull(list, "Список не получен");
            //количество возвращаемых элементов списка  = 3
            Assert.AreEqual(3, list.Count);
        }

        /// <summary>
        /// Тест метода Create на вызов представления Create в случае ошибки модели
        /// </summary>
        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            // Arrange
            string expected = "Create";
            var mock = new Mock<IRepository<News>>();
            News news = new News();
            var controller = new AdminController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");

            // Act
            var result = controller.Create(news) as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Список не получен");
            //сравниваем имена вьюшек
            Assert.AreEqual(expected, result.ViewName);
        }

        /// <summary>
        /// Тест метода Create на переадресацию в представление Index
        /// </summary>
        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            // Arrange
            string expected = "Index";
            var mock = new Mock<IRepository<News>>();
            News news = new News();
            var controller = new AdminController(mock.Object);

            // Act
            var result = controller.Create(news) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "Список не получен");
            //сравниваем имена методов действия
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        /// <summary>
        /// Сохранение модели
        /// </summary>
        [TestMethod]
        public void CreatePostAction_SaveModel()
        {
            // Arrange
            var mock = new Mock<IRepository<News>>();
            News news = new News();
            var controller = new AdminController(mock.Object);

            // Act
            var result = controller.Create(news) as RedirectToRouteResult;

            // Assert
            mock.Verify(v => v.Create(news));
        }
    }
}
