using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialoguePanel;
    public Text dialogueText;

    [Header("Dialogue")]
    [TextArea(2, 4)]
    public string[] lines = new string[3]
    {
        "你好，冒险者。",
        "前方很危险，注意陷阱。",
        "祝你好运！"
    };

    [Header("Interaction")]
    public string playerTag = "Player";
    public KeyCode interactKey = KeyCode.E;

    private bool playerInRange;
    private bool isTalking;
    private int currentLineIndex;

    void Start()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && !isTalking && Input.GetKeyDown(interactKey))
        {
            StartDialogue();
        }

        if (isTalking && Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        if (lines == null || lines.Length == 0) return;

        isTalking = true;
        currentLineIndex = 0;

        if (dialoguePanel != null) dialoguePanel.SetActive(true);
        ShowCurrentLine();
    }

    void NextLine()
    {
        currentLineIndex++;

        if (currentLineIndex >= lines.Length)
        {
            EndDialogue();
            return;
        }

        ShowCurrentLine();
    }

    void ShowCurrentLine()
    {
        if (dialogueText != null)
        {
            dialogueText.text = lines[currentLineIndex];
        }
    }

    void EndDialogue()
    {
        isTalking = false;

        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        if (dialogueText != null) dialogueText.text = "";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerInRange = false;

            if (isTalking)
            {
                EndDialogue();
            }
        }
    }
}
