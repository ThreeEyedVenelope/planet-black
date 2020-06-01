using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFadeIn : MonoBehaviour
{
    [SerializeField]
    private float titleFadeSpeed = 0.03f;
    [SerializeField]
    private float menuFadeSpeed = 0.03f;

    [SerializeField]
    private GameObject menuPanel;


    private CanvasGroup titleCanvasGroup = null;
    private CanvasGroup menuCanvasGroup = null; 

    private float titleAlpha;
    private float menuAlpha;

    void Awake()
    {
        titleCanvasGroup = GetComponent<CanvasGroup>();
        menuCanvasGroup = menuPanel.GetComponent<CanvasGroup>();

        if (titleCanvasGroup == null)
            Debug.LogError("Error: Title image needs a canvas group.");
        else if (titleCanvasGroup != null) titleCanvasGroup.alpha = titleAlpha;

        if (menuCanvasGroup == null)
            Debug.LogError("Error: Menu panel needs a canvas group.");
        else if (menuCanvasGroup != null) menuCanvasGroup.alpha = menuAlpha;
    }

    void Update()
    {
        if (titleAlpha <= 1.0f)
        {
            titleAlpha += Time.deltaTime * titleFadeSpeed;
            titleCanvasGroup.alpha = titleAlpha;
            Debug.Log("Title Alpha: " + titleAlpha);
            if (titleAlpha >= 0.5f)
            {
                if (menuAlpha <= 1.0f)
                {
                    menuAlpha += Time.deltaTime * titleFadeSpeed;
                    menuCanvasGroup.alpha = menuAlpha;
                    Debug.Log("Menu Alpha : " + menuAlpha);
                }
            }
        }
    }
}

