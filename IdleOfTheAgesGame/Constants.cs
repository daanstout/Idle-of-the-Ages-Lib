namespace IdleOfTheAgesGame {
    public static class Constants {
        #region Classes
        public class Item {
            public string ID { get; }

            public string Name { get; }

            public string TranslationKey { get; }

            public string NamespacedID => $"{NAMESPACE}:{ID}";

            public Item(string id, string name, string translationKey) {
                ID = id;
                Name = name;
                TranslationKey = translationKey;
            }
        }

        public class Skill : Item {
            public Skill(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }

        public class SkillCategory : Item {
            public SkillCategory(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }

        public class Age : Item {
            public Age(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }

        public class Thumbnail : Item {
            public Thumbnail(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion

        public static string NAMESPACE { get; } = "IdleOfTheAgesGame";

        #region Skills
        public static Skill WOODCUTTING { get; } = new Skill("woodcutting", "Woodcutting", "Woodcutting");
        public static Skill MINING { get; } = new Skill("Mining", "Mining", "Minig");
        #endregion

        #region Skill Categories
        public static SkillCategory NON_COMBAT { get; } = new SkillCategory("non_combat", "Non Combat", "Non_Combat");
        #endregion

        #region Ages
        public static Age STONE_AGE { get; } = new Age("stone_age", "Stone Age", "Stone_Age");
        #endregion

        #region Thumbnails
        public static Thumbnail TREE { get; } = new Thumbnail("Tree", "Tree", "Tree");
        #endregion
    }
}
