[System.Serializable]
public class TutorialQuest
{
    public string Name;
    public string Description;
    public bool Completed;
    public bool isQuestActive;
    public string key;
    public void SetQuestActive()
    {
        isQuestActive = true;
    }

    public void Complete()
    {
        Completed = true;
        isQuestActive = false;
    }
}
