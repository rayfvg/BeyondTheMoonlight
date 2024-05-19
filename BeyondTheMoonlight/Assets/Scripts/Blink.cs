using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void StartBlick()
    {
        StartCoroutine("BlinkEffect");
        Invoke("StartColor", 1f);
    }
    public void StartColor()
    {
        _spriteRenderer.color = new Color(255f, 255f, 255f, 255f);
    }
    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            _spriteRenderer.color = new Color(255, Mathf.Sin(t * 30) * 0.5f + 0.5f,
                Mathf.Sin(t * 30) * 0.5f + 0.5f, 255);
            yield return null;
        }
    }
}
