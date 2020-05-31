using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for simplified dialogue and will include the name of the speaker 
/// in the same text box as the dialogue, but separated by new lines to allow
/// the name to appear in the top left corner of the text box.
/// 
/// Example:
/// 
/// [Name Here]
/// 
/// [Dialogue Text]
/// </summary>
[System.Serializable]
public class SimpleDialogue
{
    [SerializeField, TextArea(2, 5)]
    private string[] m_sentences;

    public string[] Sentences { get { return m_sentences; } }
}
