// <copyright file="AgeService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.Skills {
    /// <summary>
    /// A service that holds all the registered ages.
    /// </summary>
    [Service(typeof(IAgeService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class AgeService : IAgeService {
        private readonly List<AgeData> ages = new List<AgeData>();

        /// <inheritdoc/>
        public Result RegisterAge(AgeData age) {
            ages.Add(age);

            return true;
        }
    }
}
