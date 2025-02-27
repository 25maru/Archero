using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpriteChanger
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    public void ApplySprite()
    {
        spriteRenderer.sprite = sprite;
    }
}

public class Gate : MonoBehaviour
{
    [SerializeField] private List<SpriteChanger> sprites;
    [SerializeField] private List<AudioClip> audioClips;

    public void Open()
    {
        foreach (SpriteChanger sprite in sprites)
        {
            sprite.ApplySprite();
        }

        if (audioClips.Count != 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, audioClips.Count);
            AudioClip clip = audioClips[randomIndex];
            AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
        }

        if (TryGetComponent(out Collider2D collider))
            collider.enabled = false;
    }
}
