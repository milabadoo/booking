﻿using booking.order.Abstract;
using booking.order.Controllers;
using booking.order.Model;
using booking.order.Repository;
using booking.common.ViewModel;
using booking.order.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.TestOrders
{
    public class CreateOrder
    {
        
        [Fact]
        public async Task TestCreateOrder()
        {
            // Arrange
            string testId = "100";
            Order order = GetTestOrders().FirstOrDefault(p => p.Id == testId);
            //var mockLogger = new Mock<ILogger<ClientController>>();
            
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(c => c.Add(order));
            //mockRepo.Setup(c => c.SaveChanges())
            //    .Returns(Task.CompletedTask);
            var controller = new OrderController(mockRepo.Object);

            // Act
            var result =  controller.Post(order);

            // Assert
            var actionResult = Assert.IsType<OkResult>(result);
           
            var model = Assert.IsType<OkResult>(actionResult);
            
        }
        /*
        [Fact]
        public async Task TestCreateClient()
        {
            // Arrange
            string testId = "100";
            Client client = GetTestClients().FirstOrDefault(p => p.Id == testId);
            //var mockLogger = new Mock<ILogger<ClientController>>();

            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(c => c.Add(client));
            //mockRepo.Setup(c => c.SaveChanges())
            //    .Returns(Task.CompletedTask);
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = controller.Post(client);

            // Assert
            var actionResult = Assert.IsType<OkResult>(result);

            var model = Assert.IsType<OkResult>(actionResult);
            /*
            Assert.Equal(client.Id, model.Id);
            Assert.Equal(client.Firstname, model.Firstname);
            Assert.Equal(client.Middlename, model.Middlename);
            Assert.Equal(client.Lastname, model.Lastname);
            Assert.Equal(client.Age, model.Age);
            */




        private List<Order> GetTestOrders()
        {
            var orders = new List<Order>
            {

                new Order()
                {
                    Id = "1",
                    FlightId = "110",
                    ClientId = "210",
                    Summ = 1000,
                    Status = 0
                },
                new Order()
                {
                    Id = "2",
                    FlightId = "120",
                    ClientId = "220",
                    Summ = 2000,
                    Status = 0
                },
                new Order()
                {
                    Id = "3",
                    FlightId = "130",
                    ClientId = "230",
                    Summ = 3000,
                    Status = 0
                }
            };
            return orders;
        }

    }
}
