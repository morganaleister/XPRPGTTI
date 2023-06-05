using System;
using UnityEngine;

/// <summary>
/// A Serializable class that will only take a value between 0 and 'max' on the 'current' field, and will only take positive values on the 'max' field.
/// </summary>
[Serializable]
public class Gauge
{
    /// <summary>
    /// The current value of the gauge.
    /// </summary>
    public float Current
    {
        get
        {
            /// <summary>
            /// Gets the current value of the gauge.
            /// </summary>
            /// <returns>The current value of the gauge.</returns>
            return Current;
        }
        set
        {
            /// <summary>
            /// Sets the current value of the gauge.
            /// </summary>
            /// <param name="value">The new value of the gauge.</param>
            /// <remarks>
            /// The value must be between 0 and Max.
            /// </remarks>
            Current = UtilityMethods.ConstrainToRange(value, 0, Max);
        }
    }

    /// <summary>
    /// The maximum value of the gauge.
    /// </summary>
    public float Max { get => Max; set => Max = Math.Abs(value); }


    /// <summary>
    /// Creates a new instance of Gauge with the indicated paramenters.
    /// </summary>
    /// <param name="current">current value</param>
    /// <param name="max">maximum value</param>
    public Gauge(float current, float max)
    {
        this.Max = max;
        this.Current = current;
    }


    /// <summary>
    /// Create a new <see cref="Gauge"/> instance with <see cref="Current"/> value at <paramref name="value"/> value.
    /// </summary>
    /// <param name="value">New instance's <see cref="Current"/> and <see cref="Max"/> values.</param>
    public Gauge(float value) => new Gauge(value, value);

    /// <summary>
    /// Creates a new instance of Gauge with a value of 1 for both <see cref="Current"/> and <see cref="Max"/>.
    /// </summary>
    public Gauge() => new Gauge(1);

    /// <summary>
    /// Resets the gauge to its initial state.
    /// </summary>
    public void Reset()
    {
        Current = 0;
        Max = 1;
    }

    /// <summary>
    /// Decreases the value of the gauge by 1.
    /// </summary>
    public void Decrease()
    {
        Current--;
    }

    /// <summary>
    /// Increases the value of the gauge by 1.
    /// </summary>
    public void Increase()
    {
        Current++;
    }

    /// <summary>
    /// Returns a string representation of the gauge.
    /// </summary>
    /// <returns>A string representation of the gauge.</returns>
    public override string ToString()
    {
        return $"Gauge '{Current}' with {Max} max";
    }
}