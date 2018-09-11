using Xunit;
using Moq;
using WBS.API.Controllers;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WBS.DAL.Data.Classes;
using Microsoft.AspNetCore.Mvc;
using WBS.DAL.Data.Models.ViewModels;
using WBS.Tests.Helpers;
using WBS.DAL.Data.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using WBS.DAL;
using WBS.DAL.Cache;
using WBS.DAL.Layers.Classes;

namespace WBS.Tests.Tests
{
    public class BudgetPlanControllerTests
    {
        private readonly BudgetPlanController budgetPlanController;
        private readonly Mock<BudgetPlanDAL> budgetPlansDalMock;
        private readonly Mock<WBSContext> contextMock;
        private readonly Mock<CrudCache<BudgetPlan>> cacheMock;

        private const int countBudgetPlans = 20;
        private const string status = "test";

        public BudgetPlanControllerTests()
        {
            var budgetPlansList = GetBudgetPlansList();
            var budgetPlans = MockHelper.MockDbSet(budgetPlansList);

            cacheMock = new Mock<CrudCache<BudgetPlan>>();
            contextMock = new Mock<WBSContext>();
            contextMock.Setup(db => db.BudgetPlans).Returns(budgetPlans.Object);
            contextMock.Setup(db => db.Set<BudgetPlan>()).Returns(budgetPlans.Object);

            budgetPlansDalMock = GetBudgetPlansDalMock(budgetPlansList);

            var loggerMock = new Mock<ILogger<BudgetPlanController>>();
            budgetPlanController = new BudgetPlanController(budgetPlansDalMock.Object, loggerMock.Object);
            budgetPlanController.ControllerContext = new ControllerContext();
            budgetPlanController.ControllerContext.HttpContext = new DefaultHttpContext();
            budgetPlanController.ControllerContext.HttpContext.Request.Host = new HostString("localhost:50122");
            budgetPlanController.ControllerContext.HttpContext.Request.Path = new PathString("/api/budgetPlan");
        }

        #region Utils

        public Mock<BudgetPlanDAL> GetBudgetPlansDalMock(List<BudgetPlan> budgetPlansList)
        {
            var budgetPlansDalMock = new Mock<BudgetPlanDAL>(contextMock.Object, cacheMock.Object);
            budgetPlansDalMock
                .Setup(m => m.Get())
                .Returns(budgetPlansList);
            budgetPlansDalMock
                .Setup(m => m.Create(It.IsAny<BudgetPlan>()))
                .Returns<BudgetPlan>(x => x);
            budgetPlansDalMock
                .Setup(m => m.Update(It.IsAny<BudgetPlan>()))
                .Returns<BudgetPlan>(x => budgetPlansList.Find(b => b.Id == x.Id));
            budgetPlansDalMock
                .Setup(m => m.Delete(It.IsAny<int>()))
                .Returns<int>(id => budgetPlansList.Find(b => b.Id == id));
            budgetPlansDalMock
                .Setup(m => m.GetStatusOfPlan(It.IsAny<int>()))
                .Returns(new Status { Title = status });
            budgetPlansDalMock
                .Setup(m => m.IsAlreadyHaveInDb(It.IsAny<int>()))
                .Returns<int>(y => budgetPlansList.Find(b => b.Year == y) != null);

            return budgetPlansDalMock;
        }

        public List<BudgetPlan> GetBudgetPlansList()
        {
            var budgetPlansList = new List<BudgetPlan>();
            for (int i = 1; i <= countBudgetPlans; i++)
            {
                budgetPlansList.Add(new BudgetPlan
                {
                    Id = i,
                    Year = 2017 - i,
                    Events = new List<Event>() { new Event { Id = i } },
                    Items = new List<ItemOfBudgetPlan> { new ItemOfBudgetPlan { Id = i } }
                });
            }
            return budgetPlansList;
        }

        #endregion Utils


        #region Tests

        [Fact]
        public void GetAll_ReturnsDataWithPaginationViewModel()
        {
            int defaultCurrentPage = 0;
            int defaultElementsPerPage = 5;

            var result = ((OkObjectResult)budgetPlanController.Get()).Value;
            var allData = budgetPlansDalMock.Object.Get()
                .Take(defaultElementsPerPage)
                .Select(bp => new BudgetPlanViewModel(bp.Id, bp.Year, status));

            AssertHelper.JsonEquals(new DataWithPaginationViewModel<BudgetPlanViewModel>
            {
                Data = allData.Select(bp => new BudgetPlanViewModel(bp.Id, bp.Year, status)),
                Pagination = new Pagination
                {
                    CurrentPage = defaultCurrentPage,
                    ElementsPerPage = defaultElementsPerPage,
                    ElementsCount = countBudgetPlans
                }
            }, result);

        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(-1, 15)]
        [InlineData(30, 10)]
        public void GetPage_ReturnsDataWithPaginationViewModel(int currentPage, int pageSize)
        {
            DataWithPaginationViewModel<BudgetPlanViewModel> result =
                (DataWithPaginationViewModel<BudgetPlanViewModel>)((OkObjectResult)budgetPlanController.Get(currentPage, pageSize)).Value;
            var allData = budgetPlansDalMock.Object.Get().Skip((currentPage) * pageSize)
                            .Take(pageSize);

            AssertHelper.JsonEquals(new DataWithPaginationViewModel<BudgetPlanViewModel>
            {
                Data = allData.Select(bp => new BudgetPlanViewModel(bp.Id, bp.Year, status)),
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = countBudgetPlans }
            },
                result);
        }

        [Fact]
        public void Post_WithNullValue_ReturnsBadRequest()
        {
            var response = budgetPlanController.Post(null);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Post_WithExistingYear_ReturnsBadRequest()
        {
            BudgetPlanViewModel viewModel = new BudgetPlanViewModel()
            {
                Status = status,
                Year = 2016
            };
            var response = budgetPlanController.Post(viewModel);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Post_WithCorrectValue_ReturnsCreated()
        {
            BudgetPlanViewModel viewModel = new BudgetPlanViewModel()
            {
                Year = 2017 - countBudgetPlans - 1
            };
            var response = budgetPlanController.Post(viewModel);

            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public void Put_NullValue_ReturnsBadRequest()
        {
            var response = budgetPlanController.Put(null);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Put_ValueWithNonexistentId_ReturnsBadRequest()
        {
            Action action = () => budgetPlanController.Put(new BudgetPlanViewModel() { Id = 0 });

            //TODO: создать больше классов исключений, проверять по конкретному типу
            Assert.Throws<Exception>(action);
        }

        //Добавить тесты для случаев:
        // ? если статуса нет в бд
        // ? если год уже существует
        [Fact]
        public void Put_WithCorrectValue_ReturnsOk()
        {
            var response = budgetPlanController.Put(new BudgetPlanViewModel()
            {
                Id = 1,
                Status = "new status",
                Year = 1900
            });

            Assert.IsType<OkObjectResult>(response);
            //Проверить, что в БД изменилось значение?
        }

        [Fact]
        public void Delete_ValueWithNonexistentId_ReturnsBadRequest()
        {
            var response = budgetPlanController.Delete(0);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Delete_WithCorrectValue_ReturnsOk()
        {
            var response = budgetPlanController.Delete(1);

            Assert.IsType<OkObjectResult>(response);
            //Проверить, что в БД значение удалено?
        }

        #endregion Tests
    }

}
