public static class EzDebug 
{
    /// <summary>
    /// Use this in Update to show a line of text with the selected index order if there are more lines being shown.
    /// </summary>
    /// <param name="text"></param>
    public static void Live(string text, int index)
    {
        EzDebugMgr.singleton.Live(text, index);
        
    }

}
