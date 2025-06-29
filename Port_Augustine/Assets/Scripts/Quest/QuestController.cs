using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance {  get; private set; }
    public List<QuestProgress> activateQuests = new();
    private QuestUI questUI;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        questUI = FindObjectOfType<QuestUI>();
    }

    public void AcceptQuest(Quest quest)
    {
        if (IsQuestActive(quest.questID)) return;
        
            activateQuests.Add(new QuestProgress(quest));

            questUI.UpdateQuestUI();
        
    }

    public bool IsQuestActive(string questID) =>activateQuests.Exists(q => q.QuestID == questID);  
}
