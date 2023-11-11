using System;

namespace IdleOfTheAgesLib.DependencyInjection {
    /// <summary>
    /// An attribute that can be applied to a parameter to indicate that the dependency should be sourced from the parent libraries if possible.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ParentSourceAttribute : Attribute {
    }
}
