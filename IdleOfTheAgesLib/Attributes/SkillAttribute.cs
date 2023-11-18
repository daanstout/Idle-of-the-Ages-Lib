using System;

namespace IdleOfTheAgesLib.Skills {
    /// <summary>
    /// Indicates that a class is a <see cref="SkillImplementation"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SkillAttribute : Attribute {
        /// <summary>
        /// The ID of the skill this class is implementing.
        /// </summary>
        public string SkillID { get; }

        /// <summary>
        /// Instantiates a new Skill Attribute.
        /// </summary>
        /// <param name="skillID">The ID of the skill.</param>
        public SkillAttribute(string skillID) {
            SkillID = skillID;
        }
    }
}
