using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ConversationManager : MonoBehaviour
{
    [TextArea(2,5)]
    public List<string> sentences = new List<string>();
    [TextArea(2,5)]
    public List<string> answers = new List<string>();

    void Update()
    {
        EndConversation();
    }

    public void StarConversation()
    {
        
    }

    public void EndConversation()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = true;
        }
        
    }
}
