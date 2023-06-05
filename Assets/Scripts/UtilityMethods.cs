using System;
using System.Globalization;

public static class UtilityMethods
{
    /// <summary>
    /// Extension method that constrains any <see cref="IComparable{T}"/> type <paramref name="value" /> to the lower bound <paramref name="min" /> and the upper bound <paramref name="max" />.
    /// If <paramref name="value" /> is less than <paramref name="min" />, <paramref name="min" /> is returned.
    /// If <paramref name="value" /> is greater than <paramref name="max" />, <paramref name="max" /> is returned.
    /// Otherwise, <paramref name="value"/> is returned.
    ///
    /// This method is optimized by using the Math.Min and Math.Max methods instead of the CompareTo method.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The value to constrain.</param>
    /// <param name="min">The lower bound to constrain <paramref name="value" /> to.</param>
    /// <param name="max">The upper bound to constrain <paramref name="value" /> to.</param>
    /// <returns><paramref name="value" /> constraint to the specified bounds.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> is greater than <paramref name="max"/>.</exception>
    ///
    /// **Comment:** This method constrains a value to a specified range.
    public static T ConstrainToRange<T>(this T value, T min, T max)
        where T : notnull, IComparable<T>
    {
        /// <summary>
        /// Checks if the minimum value is greater than the maximum value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> is greater than <paramref name="max"/>.</exception>
        ///
        /// **Comment:** This method checks if the minimum value is greater than the maximum value.
        if (min.CompareTo(max) > 0)
        {
            throw new ArgumentOutOfRangeException(nameof(min), $"The argument {nameof(min)} must not be greater than the argument {nameof(max)}.");
        }

        /// <summary>
        /// Constrains the value to the specified range.
        /// </summary>
        ///
        /// **Comment:** This method constrains the value to the specified range.
        return value.CompareTo(min) < 0 ? min : value.CompareTo(max) > 0 ? max : value;
    }

    /// <summary>
    /// Reduces the specified object's HitPoints by the specified amount.
    /// </summary>
    /// <param name="damageable">The <see cref="IDamageable"/> to damage.</param>
    /// <param name="damage">The float amount of damage to do.</param>
    public static void DoDamage(IDamageable damageable, float damage)
    {
        /// <summary>
        /// Subtracts the specified amount of damage from the object's HitPoints property.
        /// </summary>
        damageable.HitPoints.Current -= Math.Abs(damage);
    }

}