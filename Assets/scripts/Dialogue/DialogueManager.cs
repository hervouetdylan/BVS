using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    private Mouvements mouv;
    public Button button;

    void Start()
    {
        sentences = new Queue<string>();
        mouv = FindObjectOfType<Mouvements>();
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        mouv.inAction = !mouv.inAction;
        EventSystem.current.SetSelectedGameObject(button.gameObject);

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
            yield return null;
        }
        
    }
    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        mouv.inAction = !mouv.inAction;

    }
}
