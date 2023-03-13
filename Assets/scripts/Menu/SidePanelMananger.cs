using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidePanelMananger : MonoBehaviour
{
    public List<CustomButton> buttons;
    public Button closeButton;
    public float fadeDuration;

    private CanvasRenderer[] render = new CanvasRenderer[1];
    private Dictionary<CustomButton, bool> active = new Dictionary<CustomButton, bool>();

    private void Start()
    {
        foreach(CustomButton button in buttons)
        {
            button.onClick.AddListener(() =>
            {
                StartCoroutine(SwitchPanel(button));
            });
            active[button] = false;
        }
        render[0] = GetComponent<CanvasRenderer>();
        render[0].SetAlpha(0);

        closeButton.onClick.AddListener(()=> {
            StartCoroutine(ClosePanel());        
        });
    }


    private IEnumerator ClosePanel()
    {
        foreach (CustomButton key in buttons)
        {
            if (active[key])
            {
                yield return StartCoroutine(Fade(key, true));
                active[key] = false;
            }
        }
        StartCoroutine(MainPanelFade(true));
    }


    private IEnumerator SwitchPanel(CustomButton button)
    {
        if (render[0].GetAlpha() < 0.1)
        {
            gameObject.SetActive(true);
            yield return StartCoroutine(MainPanelFade());
            StartCoroutine(Fade(button));
            active[button] = true;
        }
        else
        {
            foreach(CustomButton key in buttons)
            {
                if (active[key])
                {
                    yield return StartCoroutine(Fade(key, true));
                    active[key] = false;
                }
            }
            StartCoroutine(Fade(button));
            active[button] = true;
        }
    }

    private IEnumerator MainPanelFade(bool reverse = false)
    {
        yield return StartCoroutine(
            Animations.Fading(render, 0.3f, 1f, reverse));
    }


    private IEnumerator Fade(CustomButton button, bool reverse = false)
    {
        float duration_per_element = fadeDuration / button.elements.Count;
        if (!reverse)
        {
            foreach (ElementFade element in button.elements)
            {
                yield return StartCoroutine(element.Fade(duration_per_element, reverse));
            }
        }
        else
        {
            for(int i = button.elements.Count-1; i>=0; i--)
            {
                yield return StartCoroutine(button.elements[i].Fade(duration_per_element, reverse));
            }
        }
        
    }
}

