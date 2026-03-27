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
            increaseScale(1.15f);
        }
    }

    void increaseScale(float scaleMultiplier)
    {
        if (visualsRenderer != null)
        {
            visualsRenderer.transform.localScale *= scaleMultiplier;
        }
    }
}
