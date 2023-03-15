using UnityEngine;
using UnityEngine.Tilemaps;

public class HouseFade : MonoBehaviour
{
    [SerializeField] private float targetOpacity = 0.5f;
    [SerializeField] private float fadeSpeed = 0.5f;
    private TilemapRenderer houseRenderer;
    private Color originalColor;

    private void Start()
    {
        houseRenderer = GetComponent<TilemapRenderer>();
        originalColor = houseRenderer.material.color;
    }

    private void Update()
    {
        Color color = houseRenderer.material.color;
        color.a = Mathf.Lerp(color.a, targetOpacity, fadeSpeed * Time.deltaTime);
        houseRenderer.material.color = color;
    }

    public void PlayerEntered()
    {
        targetOpacity = 0.75f;
    }

    public void PlayerExited()
    {
        targetOpacity = 1f;
    }
}
