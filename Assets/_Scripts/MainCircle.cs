using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    [SerializeField] private float targetDiameterInPixels; 
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetCircleSize(targetDiameterInPixels);
    }

    private void SetCircleSize(float sizeInPx)
    {
        float spriteDiameterInPixels = _spriteRenderer.sprite.rect.width;
        float scale = sizeInPx / spriteDiameterInPixels;
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
