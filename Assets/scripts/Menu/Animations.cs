using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations
{
    public static IEnumerator Fading(CanvasRenderer[] renderers, float duration, float target_alpha, bool reverse = false)
    {
        float t = 0f;
        float step = 0.01f;

        float per_step_increment = (step * target_alpha) / duration;
        float alpha;
        if (reverse)
        {
            alpha = target_alpha;
            per_step_increment = -per_step_increment;
        }
        else
        {
            alpha = 0f;
        }


        while (t < duration)
        {
            foreach(CanvasRenderer renderer in renderers)
            {
                renderer.SetAlpha(alpha);
            }            
            alpha += per_step_increment;
            t += step;
            yield return new WaitForSeconds(step);
        }
    }
}
