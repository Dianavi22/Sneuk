using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public bool isInRange;
    public Dialogue dialogue;
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) TriggerDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) isInRange = false;
        DialogueManager.instance.EndDialogue();
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
