using IocDemo;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocDemoTests
{
    [TestClass]
    public class ChatServiceTests
    {
        [TestMethod]
        public void SendMessageTo_CallsSendMessage()
        {
            // Arrange
            var mockService = new Mock<IMessageHandler>();
            IMessageHandler messageHandler = mockService.Object;
            ChatService chatService = new ChatService(messageHandler);

            // Act
            chatService.SendMessageTo("test-user", "test-message");

            // Assert
            mockService.Verify(mh => mh.SendMessage(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void SendMessageTo_CallsSendMessageWithCorrectString()
        {
            // Arrange
            var mockService = new Mock<IMessageHandler>();
            IMessageHandler messageHandler = mockService.Object;
            ChatService chatService = new ChatService(messageHandler);

            // Act
            chatService.SendMessageTo("test-user", "test-message");

            // Assert
            mockService.Verify(mh => mh.SendMessage("To test-user: test-message"), Times.Once);
        }

        [TestMethod]
        public void RecieveMessageFrom_CallsGetMessage()
        {
            // Arrange
            var mockService = new Mock<IMessageHandler>();
            IMessageHandler messageHandler = mockService.Object;
            ChatService chatService = new ChatService(messageHandler);
            mockService.Setup(mh => mh.GetMessage()).Returns("test-message");

            // Act
            chatService.RecieveMessageFrom("test-user");

            // Assert
            mockService.Verify(mh => mh.GetMessage(), Times.Once);
        }

        [TestMethod]
        public void RecieveMessageFrom_ReturnsCorrectMessage()
        {
            // Arrange
            var mockService = new Mock<IMessageHandler>();
            IMessageHandler messageHandler = mockService.Object;
            ChatService chatService = new ChatService(messageHandler);
            mockService.Setup(mh => mh.GetMessage()).Returns("test-message");

            // Act
            string result = chatService.RecieveMessageFrom("test-user");

            // Assert
            Assert.AreEqual("test-user says test-message", result);
        }

        [TestMethod]
        public void SendMessageTo_CallsSendMessage2()
        {
            // Arrange
            IMessageHandler messageHandler = new EmailHandler();
            ChatService chatService = new ChatService(messageHandler);

            // Act
            chatService.SendMessageTo("test-user", "test-message");

            // Assert

        }
    }
}
