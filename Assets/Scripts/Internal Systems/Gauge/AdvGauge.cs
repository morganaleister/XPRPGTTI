using System;
using UnityEngine;

[Serializable]
public class AdvGauge : Gauge
{

    [SerializeField]
    private float _underflow, _overflow;

    /// <summary>
    /// The current value of the gauge.
    /// </summary>
    public new float Current
    {
        get => this.Current;
        protected set
        {
            // Check if the value is overflowing or underflowing.
            if (value > this.Max)
            {
                // How much is it overflowing?
                _overflow = value - this.Max;

                // Adjust the current value.
                value = this.Max;
            }
            else if (value < 0)
            {
                // How much is it underflowing?
                _underflow = -value;

                // Adjust the current value.
                value = 0;
            }

            // Set the current value.
            this.Current = value;
        }
    }

    /// <summary>
    /// The current value of the gauge normalized to 0-1.
    /// </summary>
    public float Normalized
    {
        get => Current / this.Max;
    }

    /// <summary>
    /// The current value of the gauge as a Vector2.
    /// </summary>
    public UnityEngine.Vector2 Fraction => new UnityEngine.Vector2(Current, this.Max);

    /// <summary>
    /// Whether the gauge is overflowing.
    /// </summary>
    public bool Overflowing
    {
        get
        {
            return _overflow > 0;
        }
    }

    /// <summary>
    /// The amount of overflow.
    /// </summary>
    public float Overflow
    {
        get => _overflow;
    }

    /// <summary>
    /// Whether the gauge is underflowing.
    /// </summary>
    public bool Underflowing
    {
        get
        {
            return _underflow < 0;
        }
    }
  

    /// <summary>
    /// Creates a new AdvGauge with the specified maximum value.
    /// </summary>
    /// <param name="max">The maximum value of the gauge.</param>
    public AdvGauge(float max)
    {
        Max = max;
    }

    /// <summary>
    /// Sets the current value of the gauge.
    /// </summary>
    /// <param name="value">The new value of the gauge.</param>
    public void SetValue(float value)
    {
        Current = value;
    }
}