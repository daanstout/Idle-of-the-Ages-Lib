using IdleOfTheAgesLib.Data;

using System;

namespace IdleOfTheAgesLib.Attributes {
    /// <summary>
    /// Indicates that a class is a <see cref="Skill"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SkillAttribute : Attribute { }
}
