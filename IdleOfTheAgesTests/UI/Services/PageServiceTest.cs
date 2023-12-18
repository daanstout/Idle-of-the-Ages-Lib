using IdleOfTheAgesLib.Models.ModJsonData;

using IdleOfTheAgesRuntime.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAgesTests.UI.Services;
[TestFixture]
public class PageServiceTest {
    private PageService service;

    [SetUp]
    public void SetUp() {
        service = new PageService();
    }

    [Test]
    public void ChangeActivePage_WhenCalledWithNull_ReturnsFalseWithArgumentNullException() {
        // Arrange

        // Act
        var result = service.ChangeActivePage(null!);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That((bool)result, Is.False);
            Assert.That(result.Exception, Is.Not.Null);
            Assert.That(result.Exception, Is.InstanceOf<ArgumentNullException>());
        });
    }

    [Test]
    public void ChangeActivePage_WhenCalledWithEmptyString_ReturnsFalseWithArgumentNullException() {
        // Arrange

        // Act
        var result = service.ChangeActivePage(string.Empty);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That((bool)result, Is.False);
            Assert.That(result.Exception, Is.Not.Null);
            Assert.That(result.Exception, Is.InstanceOf<ArgumentNullException>());
        });
    }

    [Test]
    public void ChangeActivePage_WhenCalledWithUnknownPageID_ReturnsFalseWithArgumentException() {
        // Arrange

        // Act
        var result = service.ChangeActivePage("page");

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That((bool)result, Is.False);
            Assert.That(result.Exception, Is.Not.Null);
            Assert.That(result.Exception, Is.InstanceOf<ArgumentException>());
        });
    }

    [Test]
    public void ChangeActivePage_WhenCalledWithKnownPageThatIsNotActive_ReturnsTrueSetsPageActiveAndFiresEvent() {
        // Arrange
        service.RegisterPageGroup(new PageGroupData("test", "test", "test", "test", new SortingOrderData("test", 0)));
        const string PAGE_ID = "test:test";

        string? eventPassedID = null;

        service.OnPageChangedEvent += id => eventPassedID = id;

        // Act
        var result = service.ChangeActivePage(PAGE_ID);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That((bool)result, Is.True);
            Assert.That(eventPassedID, Is.Not.Null);
            Assert.That(eventPassedID, Is.EqualTo(PAGE_ID));
            Assert.That(service.ActivePage, Is.EqualTo(PAGE_ID));
        });
    }

    [Test]
    public void ChangeActivePage_WhenCalledWithKnownPageThatIsAlreadyActive_ReturnsTrueAndDoesNotFireEvent() {
        // Arrange
        service.RegisterPageGroup(new PageGroupData("test", "test", "test", "test", new SortingOrderData("test", 0)));
        const string PAGE_ID = "test:test";

        service.ChangeActivePage(PAGE_ID);

        string? eventPassedID = null;

        service.OnPageChangedEvent += id => eventPassedID = id;

        // Act
        var result = service.ChangeActivePage(PAGE_ID);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That((bool)result, Is.True);
            Assert.That(eventPassedID, Is.Null);
            Assert.That(eventPassedID, Is.Not.EqualTo(PAGE_ID));
            Assert.That(service.ActivePage, Is.EqualTo(PAGE_ID));
        });
    }
}
