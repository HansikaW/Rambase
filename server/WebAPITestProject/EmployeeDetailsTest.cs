using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using WebAPI.Enitities;
using WebAPI.Handler;
using WebAPI.Mapper;
using WebAPI.Repositories;
using WebAPI.Models;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITestProject
{
    public class EmployeeDetailsTest
    {
        private readonly EmployeeDetailHandler _handler;

        private readonly IMapper _mapper;


        public EmployeeDetailsTest()
        {
            var mockRepo = new Mock<IEmployeeDetailRepository>();

            IList<EmployeeDetail> employeeDetail = new List<EmployeeDetail>()
            {
                new EmployeeDetail
                {
                    EId = 1,
                    EmployeeName = "Hansika",
                    PhoneNo = "0712656744",
                    BDay ="01/12",
                    Nic= "12345V"
                },
                new EmployeeDetail
                {
                    EId = 2,
                    EmployeeName = "Jayani",
                    PhoneNo = "071211111",
                    BDay ="01/01",
                    Nic= "12345Y"
                }
            };

            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employeeDetail.ToList());

            mockRepo.Setup(repo => repo.GetEmployeeDetailById(
                It.IsAny<int>())).ReturnsAsync((int i) => employeeDetail.SingleOrDefault(x => x.EId == i));

            mockRepo.Setup(repo => repo.Insert(It.IsAny<EmployeeDetail>()))
                 .Callback((EmployeeDetail employeeDetails) =>
                 {
                     employeeDetails.EId = employeeDetail.Count() + 1;
                     employeeDetail.Add(employeeDetails);
                 }).Verifiable();

            mockRepo.Setup(repo => repo.Delete(It.IsAny<EmployeeDetail>()))
                 .Callback((EmployeeDetail employeeDetails) =>
                 {
                     employeeDetails.EId = employeeDetail.Count() - 1;
                     employeeDetail.Remove(employeeDetails);
                 }).Verifiable();

            mockRepo.SetupAllProperties();

            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m => m.Map<EmployeeDetailEntity, EmployeeDetail>(It.IsAny<EmployeeDetailEntity>())).Returns((i) =>{new EmployeeDetail());

            _mapper = WebAPI.Mapper.Mapper.GetMapper();
            _handler = new EmployeeDetailHandler(mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetEmployeeDetailById_returnsEmployeeDetail()
        {
            // Arrange
            const int expected = 1;
            const int id = 1;

            // Act
            var employeeDetail = await _handler.GetEmployeeDetail(id);

            // Assert
            Assert.Equal(expected, employeeDetail.EId);
        }

        [Fact]
        public async Task GetAllEmployees_returnsEmployeeDetails()
        {
            // Arrange
            const int expected = 2;

            // Act
            var employeeDetails = await _handler.GetEmployeeDetails();

            // Assert
            Assert.Equal(expected, employeeDetails.Count());
        }

        [Fact]
        public async Task AddNewEmployee()
        {
            // Arrange
            var EmployeeDetail = new EmployeeDetail()
            {
                EId = 1,
                EmployeeName = "Hansika",
                PhoneNo = "0712656744",
                BDay = "01/12",
                Nic = "12345V"
            };

            // Act
            var employeeDetail = await _handler.PostEmployeeDetail(EmployeeDetail);

            // Assert
            Assert.Equal(EmployeeDetail.EId, employeeDetail);
        }

        [Fact]
        public async Task Update_EditedEmployee()
        {
            // Arrange
            var EmployeeDetail = new EmployeeDetail()
            {
                EId = 1,
                EmployeeName = "Hansika",
                PhoneNo = "0712656744",
                BDay = "01/12",
                Nic = "12345V"
            };

            // Act
            var employeeDetail = await _handler.PutEmployeeDetailAsync(EmployeeDetail.EId, EmployeeDetail);

            // Assert
            Assert.Equal(EmployeeDetail.EId, employeeDetail.EId);
        }

        [Fact]
        public async Task DeleteEmployee()
        {
            // Arrange
            var EmployeeDetail = new EmployeeDetail
            {
                EId = 1,
                EmployeeName = "Hansika",
                PhoneNo = "0712656744",
                BDay = "01/12",
                Nic = "12345V"
            };

            // Act
            var employeeDetail = await _handler.DeleteEmployeeDetail(EmployeeDetail.EId);

            // Assert
            Assert.Equal(EmployeeDetail.EId, employeeDetail);
        }
    }
}

