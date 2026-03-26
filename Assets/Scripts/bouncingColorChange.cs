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
            Debug.Log("Changing color of " + visualsRenderer);

            Material mat = visualsRenderer.material;

            if (mat.HasProperty("_BaseColor"))
            {
                mat.SetColor("_BaseColor", Random.ColorHSV());
            }
            else
            {
                mat.color = Random.ColorHSV();
            }
        }
    }
}
