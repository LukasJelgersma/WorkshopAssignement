using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] public Camera camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Define your isometric offset (e.g., above and behind the player)
        Vector3 offset = new Vector3(0, 10, -10);

        // Update camera position to follow the player
        camera.transform.position = transform.position + offset;

        // Keep camera rotation fixed for isometric view
        camera.transform.rotation = Quaternion.Euler(45, 0, 0); // Adjust angles as needed
    }
    
    void OnFire() 
    {
        RaycastHit hit;
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            _agent.SetDestination(hit.point);
            // instantiate sphere at hit.point
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = hit.point;
            Destroy(sphere, 1f); // destroy sphere after 1 second
        } 
    }
}
