using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] Text interactUI;

    public bool isInRange;
    public Dialogue dialogue;

    private void Awake()
    {
        Global.GlobalVariables.Text = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) TriggerDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
            interactUI.text = "VOUS POUVEZ PARLER A CE PNJ";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            interactUI.text = "";
        }
            DialogueManager.instance.EndDialogue();
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
