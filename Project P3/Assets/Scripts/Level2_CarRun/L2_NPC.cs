using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_NPC : MonoBehaviour
{
    public L2_Conversation conversation;
    public void TriggerConversation()
    {
        FindObjectOfType<L2_ConversationManager>().StartConversation(conversation);
    }
	
}
