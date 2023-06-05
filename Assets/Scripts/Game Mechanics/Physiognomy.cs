using System.Collections.Generic;
using System;

public class Physiognomy
{
    protected Dictionary<string, BodyPart> _bodyParts;

    public void AddPart(string displayName)
    {
        var bp = new BodyPart();
        bp.DisplayName = displayName;
        
    }

    public BodyPart GetPart(string displayName)
    {
        BodyPart R;

        _bodyParts.TryGetValue(displayName, out R);

        return R;
    }
}
