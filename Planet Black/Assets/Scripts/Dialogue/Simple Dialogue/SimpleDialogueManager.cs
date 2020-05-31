using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// NOTE:
///     This script handles one person dialogue and handles 
/// the name & dialogue text within the SAME text.
/// 
/// Implementation instructions:
///     1. Create an empty game object in the scene and name it DialogueManager
///     2. Manually assign via drag and drop the:
///         a. Dialogue GameObject
///         b. The "DialogueText" text object that's a child of the dialogue gameObject
/// </summary>
public class SimpleDialogueManager : MonoBehaviour
{
    [SerializeField, Tooltip("The GameObject that makes up the dialogue bar.")]
    private GameObject m_dialogueBar;

    [SerializeField, Tooltip("This is the text object child of the dialogue bar that's meant to display the actual dialogue in the dialogue box.")]
    private Text m_dialogueText;

    private Queue<string> m_sentences;

    void Awake()
    {
        m_sentences = new Queue<string>();

        // Turn off dialogue bar on upon starting the level
        m_dialogueBar.SetActive(false);
    }

    public void StartSimpleDialogue(SimpleDialogue dialogue)
    {
        // Turn on dialogue bar
        m_dialogueBar.SetActive(true);

        // Clear anything that may still be in the dialogue box from before
        m_sentences.Clear();

        // Queue up the sentences in sequence
        foreach (string sentence in dialogue.Sentences)
        {
            m_sentences.Enqueue(sentence);
        }

        DisplayNextSequence();
    }

    /// <summary>
    /// Sets, updates, and displays the next sentence in the queue
    /// </summary>
    public void DisplayNextSequence()
    {
        // If there are no more sentences, then end the dialogue
        if (m_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Move to the next sentence in the sequence
        string sentence = m_sentences.Dequeue();

        // Set the text to display the next sentence
        m_dialogueText.text = sentence;
    }

    /// <summary>
    /// Ends dialogue when there is nothing else left in the sentence queue
    /// </summary>
    private void EndDialogue()
    {
        // Turn off the dialogue bar
        m_dialogueBar.SetActive(false);
    }
}
