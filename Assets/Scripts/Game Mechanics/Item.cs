using UnityEngine;

[System.Serializable]
public class Item : Container<Item>, IStackable, IEquippable, IBreakable
{
    protected string id, displayName;
    protected CompositionMaterial compMat;

    public string ID { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string DisplayName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Vector3 Area { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public uint MaxStacks { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Gauge HitPoints { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsBroken => throw new System.NotImplementedException();

    public string[] ValidParts { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    

    protected ICanEquip equippedOn;
    public ICanEquip EquippedOn => equippedOn;

    protected bool isEquipped;
    public bool IsEquipped { get => isEquipped; }

    public void Equip(ICanEquip to)
    {
        to.Equip(this);
        equippedOn = to;

    }

}

public class CompositionMaterial
{
    public string materialName;


}

public class Composition
{
    private CompositionMaterial[] materials;
    private float[] percentages;

    public void Add(CompositionMaterial material, float percentage)
    {
        var prevMats = materials;
        var prevPercents = percentages;

        var newMatsLen = prevMats.GetLength(0) + 1;
        var newMaterials = new CompositionMaterial[newMatsLen];
        prevMats.CopyTo(newMaterials, 0);
        newMaterials[newMatsLen] = material;

        var newPercentsLen = prevPercents.GetLength(0) + 1;
        var newPercents = new float[newMatsLen];
        prevPercents.CopyTo(newPercents, 0);
        newPercents[newPercentsLen] = percentage;

        materials = newMaterials;
        percentages = newPercents;

    }
}



