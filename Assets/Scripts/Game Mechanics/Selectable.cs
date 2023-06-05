public abstract class Selectable : EZLogMB
{
    protected bool _isSelected;

    public bool IsSelected => _isSelected;

    public void Select()
    {
        _isSelected = true;        
    }

    public void Deselect()
    {
        _isSelected = false;
    }
}
