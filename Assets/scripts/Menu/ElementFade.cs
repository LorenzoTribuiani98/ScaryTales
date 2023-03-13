using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementFade : MonoBehaviour
{
    private CanvasRenderer[] children_renderer;
    // Start is called before the first frame update
    void Start()
    {
        children_renderer = GetComponentsInChildren<CanvasRenderer>();
        foreach(CanvasRenderer render in children_renderer)
        {
            render.SetAlpha(0);
        }
        gameObject.SetActive(false);
    }

    public IEnumerator Fade(float duration, bool reverse = false)
    {
        if (!gameObject.activeSelf) gameObject.SetActive(true);
        yield return Animations.Fading(children_renderer, duration, 1, reverse);
        if (reverse) gameObject.SetActive(false);
    }

}
