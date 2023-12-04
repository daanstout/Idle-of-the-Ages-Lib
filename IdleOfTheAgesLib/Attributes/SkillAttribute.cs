// <copyright file="SkillAttribute.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.Skills {
    /// <summary>
    /// Indicates that a class is a <see cref="SkillImplementation"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SkillAttribute : Attribute {
        /// <summary>
        /// Gets the ID of the skill this class is implementing.
        /// </summary>
        public string SkillID { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillAttribute"/> class.
        /// </summary>
        /// <param name="skillID">The ID of the skill.</param>
        public SkillAttribute(string skillID) {
            SkillID = skillID;
        }
    }
}
