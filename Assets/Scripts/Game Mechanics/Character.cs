[System.Serializable]
public class Character : Selectable, IKillable
{
    public Physiognomy Body { get; set; }

    public Gauge HitPoints { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsAlive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    
}
