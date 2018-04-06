using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ConversationManager : MonoBehaviour
{
    public L2_Conversation conversation;
    private List<string> dialogueHolder = new List<string>();

    public bool nextCenteces = false;

    void Update()
    {
        EndConversation();
        NextSentence();
        
    }

    public void StartConversation(L2_Conversation conversation)
    {
        Debug.Log("StartConverstation");
        Debug.Log(conversation.dialogue[0]);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab werkt");
            nextCenteces = true;
        }
    }
    
    public void NextSentence()
    {
        if (nextCenteces == true)
        {
            Debug.Log(conversation.dialogue[1]);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log(conversation.dialogue[2]);
                nextCenteces = false;
            }
        }
        
        //Left
        if (Input.GetKey ("1"))
        {
            Debug.Log(conversation.dialogue[3]);
            
        }
        //Right
        if(Input.GetKey ("2"))
        {
            Debug.Log(conversation.dialogue[4]);
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
