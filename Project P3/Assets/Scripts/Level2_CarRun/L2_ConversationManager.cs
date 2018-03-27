using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ConversationManager : MonoBehaviour
{
    private List<string> dialogue;

    void Start()
    {
        dialogue = new List<string>();
    }

    public void StartConversation(L2_Conversation conversation)
    {
        Debug.Log("StartConverstation");
    }
}
