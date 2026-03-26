using UnityEngine;

public class bouncingColorChange : MonoBehaviour
{

    // Kylian
//    [SerializeField] private Renderer visualsRenderer;
//    void OnTriggerEnter(Collider collision)
//    {
//        Debug.Log("GameObject collided with " + collision.name);
//
//        Renderer renderer = GetComponent<Renderer>();
//
//        renderer.material.color = Random.ColorHSV();
//    }
    
    // VINC
    [SerializeField] private Renderer visualsRenderer;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("GameObject collided with " + collision.gameObject.name);

         if (visualsRenderer != null)
        {
            Color newColor = Random.ColorHSV();

            Debug.Log("New color: " + newColor);

            visualsRenderer.material.SetColor("_BaseColor", newColor);
            visualsRenderer.material.SetColor("_Color", newColor);

            visualsRenderer.sharedMaterial.color = newColor;
        }
    }
}
