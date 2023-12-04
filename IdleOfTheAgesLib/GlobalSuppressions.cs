// <copyright file="GlobalSuppressions.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

/* This file is used by Code Analysis to maintain SuppressMessage
 * attributes that are applied to this project.
 * Project-level suppressions either have no target or are given
 * a specific target and scoped to a namespace, type, member, etc.
 */

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Is part of base classes to prevent duplication.", Scope = "type", Target = "~T:IdleOfTheAgesLib.Models.ModJsonData.ThumbnailDataElement")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Is part of base classes to prevent duplication.", Scope = "type", Target = "~T:IdleOfTheAgesLib.Models.ModJsonData.VisisbleDataElement")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Is a generic base class for use.", Scope = "type", Target = "~T:IdleOfTheAgesLib.Result`1")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Is a generic base class that is meant to be inherited from.", Scope = "type", Target = "~T:IdleOfTheAgesLib.UI.Element`2")]
