using UnityEngine;

public class bouncingColorChange : MonoBehaviour
{
    [SerializeField] private Renderer visualsRenderer;
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("GameObject collided with " + collision.name);

        Renderer renderer = GetComponent<Renderer>();

        renderer.material.color = Random.ColorHSV();
    }
}
