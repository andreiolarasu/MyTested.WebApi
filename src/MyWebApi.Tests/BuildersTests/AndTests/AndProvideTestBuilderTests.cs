﻿namespace MyWebApi.Tests.BuildersTests.AndTests
{
    using System;
    using System.Web.Http.Results;
    using NUnit.Framework;
    using Setups.Controllers;

    [TestFixture]
    public class AndProvideTestBuilderTests
    {
        [Test]
        public void AndProvideShouldReturnProperController()
        {
            var controller = MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.BadRequestWithErrorAction())
                .ShouldReturn()
                .BadRequest()
                .WithErrorMessage()
                .AndProvideTheController();

            Assert.IsNotNull(controller);
            Assert.IsAssignableFrom<WebApiController>(controller);
        }

        [Test]
        public void AndProvideShouldReturnProperActionName()
        {
            var actionName = MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.BadRequestWithErrorAction())
                .ShouldReturn()
                .BadRequest()
                .WithErrorMessage()
                .AndProvideTheActionName();

            Assert.AreEqual("BadRequestWithErrorAction", actionName);
        }

        [Test]
        public void AndProvideShouldReturnProperActionResult()
        {
            var actionResult = MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.StatusCodeAction())
                .ShouldReturn()
                .StatusCode()
                .AndProvideTheActionResult();

            Assert.IsNotNull(actionResult);
            Assert.IsAssignableFrom<StatusCodeResult>(actionResult);
        }

        [Test]
        public void AndProvideShouldReturnProperCaughtException()
        {
            var caughtException = MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.ActionWithException())
                .ShouldThrow()
                .Exception()
                .AndProvideTheCaughtException();

            Assert.IsNotNull(caughtException);
            Assert.IsAssignableFrom<NullReferenceException>(caughtException);
        }
    }
}
