// <copyright file="ModDataConverter.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Models.JsonConverters;

/// <summary>
/// A converter to deserialize <see cref="ModData"/> objects.
/// </summary>
public class ModDataConverter : JsonConverter<ModData> {
    private static readonly string PROPERTY_ID = "id";
    private static readonly string PROPERTY_NAME = "name";
    private static readonly string PROPERTY_TRANSLATION_KEY = "translation_key";
    private static readonly string PROPERTY_THUMBNAIL = "thumbnail";
    private static readonly string PROPERTY_SORTING_ORDER = "sorting_order";

    /// <inheritdoc/>
    public override void WriteJson(JsonWriter writer, ModData? value, JsonSerializer serializer) => throw new NotImplementedException();

    /// <inheritdoc/>
    public override ModData? ReadJson(JsonReader reader, Type objectType, ModData? existingValue, bool hasExistingValue, JsonSerializer serializer) {
        JObject obj = JObject.Load(reader);

        var @namespace = obj["namespace"]?.Value<string>() ?? throw new JsonSerializationException("Namespace property is missing in Json Structure!");

        var skills = ParseSkills(obj["skills"], @namespace);
        var skillCategories = ParseSkillCategories(obj["skill_categories"], @namespace);
        var pageGroups = ParsePageGroups(obj["page_groups"], @namespace);
        var pages = ParsePages(obj["pages"], @namespace);
        var items = ParseItems(obj["items"], @namespace);
        var actions = ParseActions(obj["actions"], @namespace);
        var lootTables = ParseLootTables(obj["loot_tables"]);

        return new ModData(@namespace, skillCategories, skills, pageGroups, pages, items, actions, lootTables);
    }

    private static List<SkillData> ParseSkills(JToken? skills, string @namespace) {
        List<SkillData> result = [];

        if (skills == null)
            return result;

        foreach (var obj in skills) {
            var id = GetRequiredProperty(obj, PROPERTY_ID, obj.Value<string>)!;
            var name = GetRequiredProperty(obj, PROPERTY_NAME, obj.Value<string>)!;
            var translationKey = GetRequiredProperty(obj, PROPERTY_TRANSLATION_KEY, obj.Value<string>)!;
            var thumbnail = GetRequiredProperty(obj, PROPERTY_THUMBNAIL, obj.Value<string>)!;
            var sortingOrder = GetRequiredProperty(obj, PROPERTY_SORTING_ORDER, ParseSortingOrder);
            var skillCategory = GetRequiredProperty(obj, "skill_category", obj.Value<string>)!;

            var skill = new SkillData(@namespace, id, name, translationKey, sortingOrder, thumbnail, skillCategory);

            result.Add(skill);
        }

        return result;
    }

    private static List<SkillCategoryData> ParseSkillCategories(JToken? skillCategories, string @namespace) {
        List<SkillCategoryData> result = [];

        if (skillCategories == null)
            return result;

        foreach (var obj in skillCategories) {
            var id = GetRequiredProperty(obj, PROPERTY_ID, obj.Value<string>)!;
            var name = GetRequiredProperty(obj, PROPERTY_NAME, obj.Value<string>)!;

            var skillCategory = new SkillCategoryData(@namespace, id, name);

            result.Add(skillCategory);
        }

        return result;
    }

    private static List<PageGroupData> ParsePageGroups(JToken? pageGroups, string @namespace) {
        List<PageGroupData> result = [];

        if (pageGroups == null)
            return result;

        foreach (var obj in pageGroups) {
            var id = GetRequiredProperty(obj, PROPERTY_ID, obj.Value<string>)!;
            var name = GetRequiredProperty(obj, PROPERTY_NAME, obj.Value<string>)!;
            var translationKey = GetRequiredProperty(obj, PROPERTY_TRANSLATION_KEY, obj.Value<string>)!;
            var sortingOrder = GetRequiredProperty(obj, PROPERTY_SORTING_ORDER, ParseSortingOrder);

            var pageGroup = new PageGroupData(@namespace, id, name, translationKey, sortingOrder);

            result.Add(pageGroup);
        }

        return result;
    }

    private static List<PageData> ParsePages(JToken? pages, string @namespace) {
        List<PageData> result = [];

        if (pages == null)
            return result;

        foreach (var obj in pages) {
            var id = GetRequiredProperty(obj, PROPERTY_ID, obj.Value<string>)!;
            var name = GetRequiredProperty(obj, PROPERTY_NAME, obj.Value<string>)!;
            var translationKey = GetRequiredProperty(obj, PROPERTY_TRANSLATION_KEY, obj.Value<string>)!;
            var sortingOrder = GetRequiredProperty(obj, PROPERTY_SORTING_ORDER, ParseSortingOrder);
            var thumbnail = GetRequiredProperty(obj, PROPERTY_SORTING_ORDER, obj.Value<string>)!;
            var pageType = GetRequiredProperty(obj, "page_type", obj.Value<PageData.PageTypeValues>);
            var targetID = GetRequiredProperty(obj, "target_id", obj.Value<string>)!;
            var pageGroup = GetRequiredProperty(obj, "page_group", obj.Value<string>)!;

            var page = new PageData(@namespace, id, name, translationKey, sortingOrder, thumbnail, pageType, targetID, pageGroup);

            result.Add(page);
        }

        return result;
    }

    private static List<ItemData> ParseItems(JToken? items, string @namespace) {
        List<ItemData> result = [];

        if (items == null)
            return result;

        foreach (var obj in items) {
            var id = GetRequiredProperty(obj, PROPERTY_ID, obj.Value<string>)!;
            var name = GetRequiredProperty(obj, PROPERTY_NAME, obj.Value<string>)!;
            var translationKey = GetRequiredProperty(obj, PROPERTY_TRANSLATION_KEY, obj.Value<string>)!;
            var sortingOrder = GetRequiredProperty(obj, PROPERTY_SORTING_ORDER, ParseSortingOrder);
            var thumbnail = GetRequiredProperty(obj, PROPERTY_SORTING_ORDER, obj.Value<string>)!;
            var sellPrice = GetRequiredProperty(obj, "sell_price", obj.Value<int>);
            var metadata = GetProperty(obj, "metadata", obj.Value<Dictionary<string, string>>, [])!;
            var category = GetProperty(obj, "category", obj.Value<string>, string.Empty)!;
            var description = GetProperty(obj, "description", obj.Value<string>, string.Empty)!;
            var type = GetProperty(obj, "type", obj.Value<string>, string.Empty)!;
            var requiredForCompletion = GetProperty(obj, "required_for_completion", obj.Value<bool>);
            var tag = GetProperty(obj, "tag", obj.Value<string>, string.Empty)!;

            var item = new ItemData(@namespace, id, name, translationKey, sortingOrder, thumbnail, description, sellPrice, metadata, category, type, requiredForCompletion, tag);

            result.Add(item);
        }

        return result;
    }

    private static List<ActionData> ParseActions(JToken? actions, string @namespace) {
        List<ActionData> result = [];

        if (actions == null)
            return result;

        foreach (var obj in actions) {
            var skillID = GetRequiredProperty(obj, "skill_id", obj.Value<string>)!;
            var actionElements = GetRequiredProperty(obj, "actions", token => ParseActionElements(token, @namespace));

            var action = new ActionData(skillID, actionElements);

            result.Add(action);
        }

        return result;
    }

    private static List<ActionElement> ParseActionElements(JToken? actions, string @namespace) {
        List<ActionElement> result = [];

        if (actions == null)
            return result;

        foreach (var obj in actions) {
            var id = GetRequiredProperty(obj, PROPERTY_ID, obj.Value<string>)!;
            var name = GetRequiredProperty(obj, PROPERTY_NAME, obj.Value<string>)!;
            var translationKey = GetRequiredProperty(obj, PROPERTY_TRANSLATION_KEY, obj.Value<string>)!;
            var thumbnail = GetRequiredProperty(obj, PROPERTY_THUMBNAIL, obj.Value<string>)!;
            var baseDuration = GetRequiredProperty(obj, "base_duration", obj.Value<float>);
            var baseXP = GetRequiredProperty(obj, "base_xp", obj.Value<float>);
            var baseExpertise = GetRequiredProperty(obj, "base_expertise", obj.Value<float>);
            var baseExpertisePool = GetRequiredProperty(obj, "base_expertise_pool", obj.Value<float>);
            var requiredLevel = GetRequiredProperty(obj, "required_level", obj.Value<int>);

            var action = new ActionElement(@namespace, id, name, translationKey, new SortingOrderData(string.Empty, -1), thumbnail, baseDuration, baseXP, baseExpertise, baseExpertisePool, requiredLevel);

            result.Add(action);
        }

        return result;
    }

    private static List<LootTable> ParseLootTables(JToken? tables) {
        List<LootTable> result = [];

        if (tables == null)
            return result;

        foreach (var obj in tables) {
            var targetType = GetRequiredProperty(obj, "target_type", obj.Value<TargetType>);
            var targetID = GetRequiredProperty(obj, "target_id", obj.Value<string>)!;
            var entries = GetRequiredProperty(obj, "loot_entries", ParseLootEntries);

            var table = new LootTable(targetType, targetID, entries);

            result.Add(table);
        }

        return result;
    }

    private static List<LootEntry> ParseLootEntries(JToken? entries) {
        List<LootEntry> result = [];

        if (entries == null)
            return result;

        foreach (var obj in entries) {
            var itemID = GetRequiredProperty(obj, "item_id", obj.Value<string>)!;
            var guaranteed = GetProperty(obj, "guaranteed", obj.Value<bool>, false);
            var baseAmount = GetRequiredProperty(obj, "base_amount", obj.Value<int>);
            var weight = GetProperty(obj, "weight", obj.Value<float?>);
            var percentage = GetProperty(obj, "percentage", obj.Value<float?>);
            var action = GetProperty(obj, "action", obj.Value<string>, "add")!;

            var entry = new LootEntry(itemID, guaranteed, baseAmount, weight, percentage, action);

            result.Add(entry);
        }

        return result;
    }

    private static SortingOrderData ParseSortingOrder(JToken sortingOrder) {
        return new SortingOrderData(GetProperty(sortingOrder, "after", sortingOrder.Value<string>, string.Empty)!, GetProperty(sortingOrder, "order", sortingOrder.Value<int>, -1));
    }

    private static T GetRequiredProperty<T>(JToken token, string name, Func<JToken, T> parseFunc) {
        var prop = token[name] ?? throw new JsonSerializationException($"Property [{name}] was not found!", token.Path, (token as IJsonLineInfo).LineNumber, (token as IJsonLineInfo).LinePosition, null);

        return parseFunc(prop);
    }

    private static T GetProperty<T>(JToken token, string name, Func<JToken, T> parseFunc, T defaultValue = default!) {
        var prop = token[name];

        if (prop == null) {
            return defaultValue;
        }

        return parseFunc(prop);
    }
}
