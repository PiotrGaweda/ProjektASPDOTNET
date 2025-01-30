using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplicationTestProject
{
    public class StudentControllerTests
    {
        List<StudentViewModel> students;
        Mock<IStudentService> studentServiceMock;

        [SetUp]
        public void Setup()
        {
            // fill students model mock
            students = new List<StudentViewModel>();
            students.Add(new StudentViewModel() { Id = 1, Name = "Asterix", IndexNumber = "000001" });
            students.Add(new StudentViewModel() { Id = 2, Name = "Obelix", IndexNumber = "000002" });

            // create service mock
            studentServiceMock = new Mock<IStudentService>();
        }

        [Test]
        public void TestIndexAction()
        {
            // Arrange
            this.studentServiceMock.Setup(m => m.FindAll()).Returns(students);
            var studentController = new StudentController(studentServiceMock.Object);

            // Act
            var result = studentController.Index();

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result is ViewResult);
            var viewResult = result as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Index");
            Assert.IsNotNull(viewResult.Model);
            Assert.IsTrue(viewResult.Model is List<StudentViewModel>);
            var studentsModel = viewResult.Model as List<StudentViewModel>;
            Assert.That(studentsModel, Has.Count.EqualTo(2));
        }
    }
}