﻿using FunBooksAndVideos.BusinessLogic.Classes;
using FunBooksAndVideos.BusinessLogic.Interfaces;
using FunBooksAndVideos.Model.Entities;
using FunBooksAndVideos.Model.Interfaces;
using FunBooksAndVideos.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.UnitTest
{
    [TestClass]
    public class VideoMemberShipActivatorTest
    {
        Mock<IMembershipActivateRepository> _membershipActivateRepository;
        Mock<IMembershipActivator> _membershipActivator;

        [TestInitialize]
        public void SetUp()
        {
            _membershipActivateRepository = new Mock<IMembershipActivateRepository>();
            _membershipActivateRepository.Setup(a => a.Activate(It.IsAny<Order>())).Returns(It.IsAny<bool>());
        }


        [TestMethod]
        public void GivenVideoMembershipActivatorWhenIPassVideoMembershipThenActivateIt()
        {
            //Arrange
            _membershipActivator = new Mock<IMembershipActivator>();
            Order order = BuildVideoMemberShipTestData();

            //TODO:Update injecion with MOQ

            IMembershipActivator memberShipActivator = new VideoMembershipActivator(_membershipActivator.Object, _membershipActivateRepository.Object);

            //Act
            memberShipActivator.Activate(order);

            //Assert
            _membershipActivateRepository.Verify(a => a.Activate(It.IsAny<Order>()), Times.Exactly(1));
        }

        [TestMethod]
        public void GivenVideoMembershipActivatorIWhenPassBookMembershipThenDontActivateIt()
        {
            //Arrange
            _membershipActivator = new Mock<IMembershipActivator>();
            Order order = BuildBookMemberShipTestData();

            //TODO:Update injecion with MOQ

            IMembershipActivator memberShipActivator = new VideoMembershipActivator(_membershipActivator.Object, _membershipActivateRepository.Object);

            //Act
            memberShipActivator.Activate(order);

            //Assert
            _membershipActivateRepository.Verify(a => a.Activate(It.IsAny<Order>()), Times.Exactly(0));
            _membershipActivator.Verify(a => a.Activate(It.IsAny<Order>()), Times.Exactly(1));
        }

        private Order BuildBookMemberShipTestData()
        {
            return new Order
            {
                ItemLines = new List<IProduct>
                {
                new BookMembership{ProductId = 1, ProductName = "BookMembership"},
                new Book{ProductId = 2, ProductName = "Girl on the train"}
                }
            };
        }
        private Order BuildVideoMemberShipTestData()
        {
            return new Order
            {
                ItemLines = new List<IProduct>
                {
                new VideoMembership{ProductId = 1, ProductName = "VideoMembership"},
                new Book{ProductId = 2, ProductName = "Girl on the train"}
                }
            };
        }
    }
}
