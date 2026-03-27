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
    public GameObject respawnPrefab;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("GameObject collided with " + collision.gameObject.name);

        GameObject[] user = GameObject.FindGameObjectsWithTag("MainCamera");
    

       GameObject MainCamera = user[0];

        Debug.Log("MainCamera position: " + MainCamera.transform.position);
       
        if (visualsRenderer != null)
        {
            float distance = Vector3.Distance(MainCamera.transform.position, visualsRenderer.transform.position);

            Debug.Log("Distance to user: " + distance);

            float scaleMultiplier = getScaleMultiplier(distance);
            Debug.Log("Scale multiplier: " + scaleMultiplier);
            
            increaseScale(scaleMultiplier);
        }
    }

     void increaseScale(float scaleMultiplier)
    {
        if (visualsRenderer != null)
        {
            visualsRenderer.transform.localScale *= scaleMultiplier;
        }
    }
 
    float getScaleMultiplier(float distance)
    {
        float minDistance = 1f;
        float maxDistance = 10f;

        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Normalize distance (0 = close, 1 = far)
        float t = (distance - minDistance) / (maxDistance - minDistance);

        float minScale = 1.05f; // small increase when close
        float maxScale = 1.5f;  // big increase when far

        return Mathf.Lerp(minScale, maxScale, t);
    }
}
