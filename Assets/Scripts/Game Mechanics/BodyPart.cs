
/// <summary>
/// This class only supports 1 <see cref="Item"/> equipped at a time and will always overwrite the previous reference when adding a new one.
/// </summary>

public class BodyPart : IDamageable, ICanEquip
{
    /// <summary>
    /// The name of the body part.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// The hit points of the body part.
    /// </summary>
    public Gauge HitPoints { get; set; }

    /// <summary>
    /// The item currently equipped to the body part.
    /// </summary>
    public IEquippable EquippedItem { get; set; }

    /// <summary>
    /// Equips the specified item to the body part.
    /// </summary>
    /// <param name="item">The item to equip.</param>
    /// <remarks>
    /// The item must be valid for the body part.
    /// </remarks>
    public void Equip(IEquippable item)
    {
        // Check if the item is valid for the body part.
        foreach (string validPart in item.ValidParts)
        {
            if (validPart == DisplayName)
            {
                // Equip the item.
                EquippedItem = item;
                break;
            }
        }
    }

    /// <summary>
    /// Gets a string representation of the body part.
    /// </summary>
    /// <returns>A string representation of the body part.</returns>
    public override string ToString()
    {
        return $"BodyPart '{DisplayName}' with {HitPoints} hit points";
    }
}

