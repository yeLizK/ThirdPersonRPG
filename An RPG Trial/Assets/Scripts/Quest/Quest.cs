[System.Serializable]
public class Quest
{
    public string Name;
    public string Description;
    public bool Completed;
    public bool isQuestActive;
    public void SetQuestActive()
    {
        isQuestActive = true;
    }

    public virtual bool EvaluateQuest()
    {
        //Write the condition when overriding
        if(Completed)
        { return true; }
        return false;
    }
    public void Complete()
    {
        Completed = true;
    }
}
