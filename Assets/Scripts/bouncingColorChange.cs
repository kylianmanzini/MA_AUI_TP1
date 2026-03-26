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
            Material mat = visualsRenderer.material;

            Color newColor = Random.ColorHSV();

            Debug.Log("New color: " + newColor);

            if (mat.HasProperty("_BaseColor"))
            {
                mat.SetColor("_BaseColor", newColor);
            }
            else
            {
                mat.color = newColor;
            }
        }
    }
}
