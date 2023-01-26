public class Quest
{
    public string name { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public bool isQuestActive { get; set; }
    public void SetQuestActive()
    {
        isQuestActive = true;
    }

    public void EvaluateQuest()
    {
        //Write the condition when overriding
    }
    public void Complete()
    {
        Completed = true;
    }
}
