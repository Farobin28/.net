namespace Oskar230173.TaskPlanner.Domain.Logic.Tests
{
    public class SimpleTaskPlannerTests
    {
        [Fact]
        public void CreatePlan_SortsTasksCorrectly()
        {
            // Arrange
            var mockRepository = new Mock<IWorkItemsRepository>();
            // ����������� ���-��'��� ��� ���������� ����������� ������ �������
            mockRepository.Setup(repo => repo.GetAll()).Returns(new List<WorkItem>
        {
            new WorkItem { Id = 1, Priority = Priority.High },
            new WorkItem { Id = 2, Priority = Priority.Low },
            new WorkItem { Id = 3, Priority = Priority.Medium },
        });

            var taskPlanner = new SimpleTaskPlanner(mockRepository.Object);

            // Act
            var plan = taskPlanner.CreatePlan();

            // Assert
            var expectedOrder = new List<int> { 1, 3, 2 }; // ���������� ������� ��������������
            var actualOrder = plan.Select(item => item.Id).ToList();
            Assert.Equal(expectedOrder, actualOrder);
        }
    }
}