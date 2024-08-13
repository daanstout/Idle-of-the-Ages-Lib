// <copyright file="FinishState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAgesLib.FSM;

/// <summary>
/// A state that indicates that the state machine is finished.
/// </summary>
/// <typeparam name="T">The type of the context data the state operates on.</typeparam>
public class FinishState<T> : State<T> {
    /// <summary>
    /// Gets a static instance to use.
    /// </summary>
    public static FinishState<T> Instance { get; } = new();

    private FinishState() { }

    /// <inheritdoc/>
    public override Result<State<T>> Tick(T input) => this;
}
