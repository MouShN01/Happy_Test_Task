using UnityEngine;

public class MainCircle : MonoBehaviour // main class with speed and size change methods
{
    [SerializeField] private float targetDiameterInPixels; // field to set diameter of circle
    [SerializeField] private float speed; // field to set speed of circle
    private SpriteRenderer _spriteRenderer;

    public float Speed => speed;

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

    private void Update()
    {
        CommandInvoker.ExecuteCommand();
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}
