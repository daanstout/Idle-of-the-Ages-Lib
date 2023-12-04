// <copyright file="Constants.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesGame {
    /// <summary>
    /// A class to hold data for the code to reference to prevent mismatched data.
    /// </summary>
    public static class Constants {
        #region Classes

        /// <summary>
        /// Base class for constant classes.
        /// </summary>
        public abstract class ItemBase {
            /// <summary>
            /// Gets the ID of the item.
            /// </summary>
            public string ID { get; }

            /// <summary>
            /// Gets the name of the item.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Gets the translation Key of the item.
            /// </summary>
            public string TranslationKey { get; }

            /// <summary>
            /// Gets the namespaced ID of the item.
            /// </summary>
            public string NamespacedID => $"{NAMESPACE}:{ID}";

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemBase"/> class.
            /// </summary>
            /// <param name="id">The ID of the item.</param>
            /// <param name="name">The name of the item.</param>
            /// <param name="translationKey">The translation key of the item.</param>
            protected ItemBase(string id, string name, string translationKey) {
                ID = id;
                Name = name;
                TranslationKey = translationKey;
            }
        }

        #region Skills

        /// <summary>
        /// Represents a skill in the game.
        /// </summary>
        public class Skill : ItemBase {
            /// <summary>
            /// Gets the data for the Woodcutting Skill.
            /// </summary>
            public static Skill WOODCUTTING { get; } = new Skill("woodcutting", "Woodcutting", "Woodcutting");

            /// <summary>
            /// Gets the data for the Mining Skill.
            /// </summary>
            public static Skill MINING { get; } = new Skill("mining", "Mining", "Mining");

            private Skill(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion

        #region Skill Categories

        /// <summary>
        /// Represents a Skill Category in the game.
        /// </summary>
        public class SkillCategory : ItemBase {
            /// <summary>
            /// Gets the data for the Generating Skill Category.
            /// </summary>
            public static SkillCategory Generating { get; } = new SkillCategory("generating", "Generating", "Generating");

            private SkillCategory(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion

        #region Ages

        /// <summary>
        /// Represents an Age in the game.
        /// </summary>
        public class Age : ItemBase {
            /// <summary>
            /// Gets the data for the Stone Age.
            /// </summary>
            public static Age STONE_AGE { get; } = new Age("stone_age", "Stone Age", "Stone_Age");

            private Age(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion

        #region Thumbnails

        /// <summary>
        /// Represents a Thumbnail in the game.
        /// </summary>
        public class Thumbnail : ItemBase {
            /// <summary>
            /// Gets the data for the Tree Thumbnail.
            /// </summary>
            public static Thumbnail TREE { get; } = new Thumbnail("tree", "Tree", "Tree");

            private Thumbnail(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion
        #endregion

        /// <summary>
        /// Gets the namespace of the game.
        /// </summary>
        public static string NAMESPACE { get; } = "IdleOfTheAgesGame";
    }
}
