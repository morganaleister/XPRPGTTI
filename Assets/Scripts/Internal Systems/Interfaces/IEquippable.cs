public interface IEquippable
{
    public string[] ValidParts { get; set; }

    public bool IsEquipped { get; }
    public void Equip(ICanEquip to);

}

public interface ICanEquip
{
    public void Equip(IEquippable item);
}




