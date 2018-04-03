using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ConversationManager : MonoBehaviour
{
    public L2_Conversation conversation;
    private List<string> dialogueHolder = new List<string>();

    void Update()
    {
        EndConversation();
        NextSentence();
    }

    public void StartConversation(L2_Conversation conversation)
    {
        Debug.Log("StartConverstation");
        
    }
    public void NextSentence()
    {
        //Left
        if (Input.GetKey ("1"))
        {
            Debug.Log(conversation.dialogue[4]);
            
        }
        //Right
        if(Input.GetKey ("2"))
        {
            Debug.Log(conversation.dialogue[5]);
        }
    }
    public void EndConversation()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = true;
        }
    }
}
