using UnityEngine;

public class bouncingColorChange : MonoBehaviour
{
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

        
        if (meshRenderer == null || materialPool == null || materialPool.Length == 0)
            return;

        currentMaterialIndex = (currentMaterialIndex + 1) % materialPool.Length;
        meshRenderer.material = materialPool[currentMaterialIndex];

        Debug.Log("Collision with: " + collision.gameObject.name);
        Debug.Log("Switched to material index: " + currentMaterialIndex);
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

    private MeshRenderer meshRenderer;

    // Shared pool for all cubes using this script
    private static Material[] materialPool;
    private static bool poolInitialized = false;

    private static string colorPropertyName;
    private int currentMaterialIndex = 0;

    void Start()
    {
        Transform visuals = transform.Find("Visuals");

        if (visuals == null)
        {
            Debug.LogError("Visuals child not found on " + gameObject.name);
            return;
        }

        meshRenderer = visuals.GetComponentInChildren<MeshRenderer>();

        if (meshRenderer == null)
        {
            Debug.LogError("No MeshRenderer found inside Visuals on " + gameObject.name);
            return;
        }

        InitializeMaterialPool();

        if (materialPool == null || materialPool.Length == 0)
        {
            Debug.LogError("Material pool was not initialized.");
            return;
        }

        meshRenderer.material = materialPool[currentMaterialIndex];

        Debug.Log("Initial material assigned to: " + meshRenderer.gameObject.name);
        Debug.Log("Shader used: " + meshRenderer.material.shader.name);
    }

    private static void InitializeMaterialPool()
    {
        if (poolInitialized) return;

        Shader shader = Shader.Find("Universal Render Pipeline/Lit");

        if (shader != null)
        {
            colorPropertyName = "_BaseColor";
            Debug.Log("Using URP shader.");
        }
        else
        {
            shader = Shader.Find("Standard");
            colorPropertyName = "_Color";
            Debug.Log("Using Standard shader.");
        }

        if (shader == null)
        {
            Debug.LogError("No compatible shader found.");
            return;
        }

        materialPool = new Material[]
        {
            CreateMaterial(shader, Color.red),
            CreateMaterial(shader, Color.green),
            CreateMaterial(shader, Color.blue),
            CreateMaterial(shader, Color.yellow),
            CreateMaterial(shader, Color.magenta),
            CreateMaterial(shader, Color.cyan),
            CreateMaterial(shader, new Color(1f, 0.5f, 0f)) // orange
        };

        poolInitialized = true;
    }

    private static Material CreateMaterial(Shader shader, Color color)
    {
        Material mat = new Material(shader);
        mat.SetColor(colorPropertyName, color);
        return mat;
    }
}