using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TwoPersonDialogue : MonoBehaviour
{
    [SerializeField, Tooltip("The name of the first person speaking. (NOTE: This should be the one who speaks first)")]
    private string m_personOneName;

    [SerializeField, Tooltip("The name of the second person speaking. (NOTE: This should be the one who speaks second)")]
    private string m_personTwoName;

    public string PersonOneName { get { return m_personOneName; } }
    public string PersonTwoName { get { return m_personTwoName; } }

    [SerializeField, TextArea(2, 5), Tooltip("This is stores the dialogue for the first person speaking.")]
    private string[] m_personOneSentences;

    [SerializeField, TextArea(2, 5), Tooltip("This is stores the dialogue for the second person speaking.")]
    private string[] m_personTwoSentences;

    public string[] PersonOneSentences { get { return m_personOneSentences; } }

    public string[] PersonTwoSentences { get { return m_personOneSentences; } }
}
