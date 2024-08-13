// <copyright file="State.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAgesLib.FSM;

/// <summary>
/// Represents a state within the state machine.
/// </summary>
/// <typeparam name="T">The type of the context data the state operates on.</typeparam>
public abstract class State<T> {
    /// <summary>
    /// Does a tick of the state.
    /// <para>To indicate that the state machine should finish, return the <see cref="FinishState{T}.Instance"/>.</para>
    /// </summary>
    /// <param name="input">The input to operate on.</param>
    /// <returns>The state that should be operated on next. It can be returned itself to keep operating on the same state.</returns>
    public abstract Result<State<T>> Tick(T input);

    /// <summary>
    /// Call this to indicate that the state machine should finish execution.
    /// </summary>
    /// <returns>An instance of the <see cref="FinishState{T}"/> state.</returns>
    protected FinishState<T> Finish() => FinishState<T>.Instance;
}
