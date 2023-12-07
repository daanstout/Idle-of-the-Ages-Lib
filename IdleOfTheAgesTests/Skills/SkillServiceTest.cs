using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using IdleOfTheAgesRuntime.Skills;

using NSubstitute;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAgesTests.Skills;

[TestFixture]
public class SkillServiceTest
{
    private class DummySkill : SkillImplementation
    {
        public DummySkill(SkillData skillData) : base(skillData) { }

        public override string Namespace { get; } = "Test";

        public override Type SkillUI { get; } = typeof(DummyUI);
    }

    private class DummyUI { }


    private IModLibrary modLibrary;

    private SkillService instance;

    [SetUp]
    public void SetUp()
    {
        modLibrary = Substitute.For<IModLibrary>();

        instance = new SkillService(modLibrary);
    }

    [Test]
    public void RegisterSkillImplementation_WhenAddingSkillWithUnknownSkillData_ReturnsFalse()
    {
        // Arrange

        // Act
        var result = instance.RegisterSkillImplementation<DummySkill>("dummy");

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.False);
            Assert.That(result.ErrorReason, Is.Not.Null);
            Assert.That(result.Exception, Is.Not.Null);
        });
    }
}
