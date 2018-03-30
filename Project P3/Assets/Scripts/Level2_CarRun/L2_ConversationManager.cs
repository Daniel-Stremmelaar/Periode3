using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ConversationManager : MonoBehaviour
{
    public L2_Conversation conversation;
    private List<string> dialogueHolder;

    void Start()
    {
        dialogueHolder = new List<string>();
    }

    public void StartConversation(L2_Conversation conversation)
    {
        Debug.Log("StartConverstation");
    }
    public void NextSentence()
    {
        if (Input.GetButton("1"))
        {
            
        } 
    }
}
