// <copyright file="StateMachine.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.FSM;

/// <summary>
/// A state machine that can be used to act based on input.
/// </summary>
/// <typeparam name="T">The type of the context data the state machine operates on.</typeparam>
public class StateMachine<T> {
    private State<T> currentState;

    /// <summary>
    /// Initializes a new instance of the <see cref="StateMachine{T}"/> class.
    /// </summary>
    /// <param name="initialState">The starting state of the state machine.</param>
    public StateMachine(State<T> initialState) {
        currentState = initialState;
    }

    /// <summary>
    /// Does a tick of the state machine.
    /// <para>To indicate that the state machine should finish, return the <see cref="FinishState{T}.Instance"/>.</para>
    /// </summary>
    /// <param name="input">The input to operate on.</param>
    /// <returns><see langword="true"/> if the operation was succesful, <see langword="false"/> if not.</returns>
    public virtual Result<StateMachineResult> Tick(T input) {
        if (currentState == FinishState<T>.Instance) {
            return StateMachineResult.Finished;
        }

        var result = currentState.Tick(input);

        if (!result) {
            return (StateMachineResult.Failed, result.Errors);
        }

        currentState = result;

        return StateMachineResult.InProgress;
    }

    /// <summary>
    /// Runs the state machine to completion.
    /// </summary>
    /// <param name="input">The input to the state machine.</param>
    /// <returns><see langword="true"/> if the state machine ran to completion succesfully, otherwise <see langword="false"/>.</returns>
    public Result<T> RunToCompletion(T input) {
        Result<StateMachineResult> result;

        do {
            result = Tick(input);
        } while (result && result == StateMachineResult.InProgress);

        if (result) {
            return input;
        } else {
            return (default, result.Errors);
        }
    }
}

/// <summary>
/// Values that the state machine returns to indicate the current state of running the state machine.
/// </summary>
public enum StateMachineResult {
    /// <summary>
    /// Default state.
    /// </summary>
    None = 0,

    /// <summary>
    /// The state machine is currently in progress.
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// The state machine has failed somewhere along the way.
    /// </summary>
    Failed = 2,

    /// <summary>
    /// The state machine has finished.
    /// </summary>
    Finished = 3,
}