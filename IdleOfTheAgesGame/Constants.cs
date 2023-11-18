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
        
        #region Skills
        public class Skill : Item {
            public static Skill WOODCUTTING { get; } = new Skill("woodcutting", "Woodcutting", "Woodcutting");
            public static Skill MINING { get; } = new Skill("mining", "Mining", "Mining");

            private Skill(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion

        #region Skill Categories
        public class SkillCategory : Item {
            public static SkillCategory Generating { get; } = new SkillCategory("generating", "Generating", "Generating");

            public SkillCategory(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion

        #region Ages
        public class Age : Item {
            public static Age STONE_AGE { get; } = new Age("stone_age", "Stone Age", "Stone_Age");

            public Age(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion

        #region Thumbnails
        public class Thumbnail : Item {
            public static Thumbnail TREE { get; } = new Thumbnail("tree", "Tree", "Tree");

            public Thumbnail(string id, string name, string translationKey) : base(id, name, translationKey) { }
        }
        #endregion
        #endregion

        public static string NAMESPACE { get; } = "IdleOfTheAgesGame";
    }
}
