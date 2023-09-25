//Mover o player com Transform
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
	public float speed = 5;
	
	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		Vector3 direction = new Vector3(horizontal, 0, vertical);
		
		//Função que move o player com CharacterController
		transform.Translate(direction * speed * Time.deltaTime);
	}
}