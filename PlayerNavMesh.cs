//para usar NavMesh
//crie um objeto vazio para para ser a sphere
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    public Transform sphere;
    public LayerMask groundLayer;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(screenRay, out hit, Mathf.Infinity, groundLayer))
            {
                sphere.position = hit.point;
                agent.SetDestination(hit.point);
            }
        }
    }
}
