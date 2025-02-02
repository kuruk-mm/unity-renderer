using ExploreV2Analytics;
using NSubstitute;
using NUnit.Framework;

public class PlacesAndEventsSectionComponentControllerTests
{
    private PlacesAndEventsSectionComponentController placesAndEventsSectionComponentController;
    private IPlacesAndEventsSectionComponentView placesAndEventsSectionComponentView;
    private IExploreV2Analytics exploreV2Analytics;

    [SetUp]
    public void SetUp()
    {
        placesAndEventsSectionComponentView = Substitute.For<IPlacesAndEventsSectionComponentView>();
        exploreV2Analytics = Substitute.For<IExploreV2Analytics>();
        placesAndEventsSectionComponentController = new PlacesAndEventsSectionComponentController(placesAndEventsSectionComponentView, exploreV2Analytics);
    }

    [TearDown]
    public void TearDown() { placesAndEventsSectionComponentController.Dispose(); }

    [Test]
    public void InitializeCorrectly()
    {
        // Assert
        Assert.AreEqual(placesAndEventsSectionComponentView, placesAndEventsSectionComponentController.view);
        Assert.IsNotNull(placesAndEventsSectionComponentController.placesSubSectionComponentController);
        Assert.IsNotNull(placesAndEventsSectionComponentController.eventsSubSectionComponentController);
    }

    [Test]
    public void RequestExploreV2ClosingCorrectly()
    {
        // Arrange
        bool exploreClosed = false;
        placesAndEventsSectionComponentController.OnCloseExploreV2 += () => exploreClosed = true;

        // Act
        placesAndEventsSectionComponentController.RequestExploreV2Closing();

        // Assert
        Assert.IsTrue(exploreClosed);
    }

    [Test]
    public void RaiseOnAnyActionExecutedInAnySubSectionCorrectly()
    {
        // Arrange
        bool anyActionExecuted = false;
        placesAndEventsSectionComponentController.OnAnyActionExecuted += () => anyActionExecuted = true;

        // Act
        placesAndEventsSectionComponentController.OnAnyActionExecutedInAnySubSection();

        // Assert
        Assert.IsTrue(anyActionExecuted);
    }
}