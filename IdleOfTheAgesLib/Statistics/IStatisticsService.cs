// <copyright file="IStatisticsService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAgesLib.Statistics;

/// <summary>
/// A service to record statistics to.
/// </summary>
public interface IStatisticsService
{
    /// <summary>
    /// Increments the numeric value behind the statistic.
    /// </summary>
    /// <param name="statistic">The statistic to increment.</param>
    /// <param name="createIfMissing">If <see langword="true"/>, creates an entry for the statistic if it hasn't been added yet.</param>
    /// <returns><see langword="true"/> if the statistic was succesfully incremented.</returns>
    Result Increment(string statistic, bool createIfMissing = true);

    /// <summary>
    /// Decrements the numeric value behind the statistic.
    /// </summary>
    /// <param name="statistic">The statistic to decrement.</param>
    /// <param name="createIfMissing">If <see langword="true"/>, creates an entry for the statistic if it hasn't been added yet.</param>
    /// <returns><see langword="true"/> if the statistic was succesfully decremented.</returns>
    Result Decrement(string statistic, bool createIfMissing = true);

    /// <summary>
    /// Adds a numeric value of a statistic. If a negative value is given, it is decremented.
    /// </summary>
    /// <param name="statistic">The statistic to add the value to.</param>
    /// <param name="value">The value to add.</param>
    /// <param name="createIfMissing">If <see langword="true"/>, creates an entry for the statistic if it hasn't been added yet.</param>
    /// <returns><see langword="true"/> if the statistic was succesfully adjusted.</returns>
    Result Add(string statistic, int value, bool createIfMissing = true);
}
