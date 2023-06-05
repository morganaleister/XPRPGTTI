using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "CompositionMaterial", menuName = "CompositionMaterials/Solid")]
public class SO_SolidMaterial : SO_RawMaterial
{
    public bool _breakable;
    public int _maxStacks;     

}
