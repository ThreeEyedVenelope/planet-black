using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for more complex dialogue and will have the names of the speakers
/// as separate text objects
/// </summary>
[System.Serializable]
public class Dialogue
{
    [SerializeField, Tooltip("The name of the person speaking.")]
    private string m_name;

    public string Name { get { return m_name; }}

    [SerializeField, TextArea(2, 5)]
    private string[] m_sentences;

    public string[] Sentences { get { return m_sentences; }}
}
