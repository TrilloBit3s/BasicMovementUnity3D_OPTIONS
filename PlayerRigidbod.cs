//Mover player com Rigidbody
using UnityEngine;

public class PlayerRigidbod : MonoBehaviour
{
	public float speed = 5;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		Vector3 direction = new Vector3(horizontal, 0, vertical);
		
        //Função que move o player com Rigidbody
        //No Rigidbody você pode escolher qualquer uma das Tres
    
		//Move Position
        //rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        //Alterando direção a velocidade
        //rb.velocity = direction * speed;//assim ainda tem bug de gravidade
        //rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);//essa linha "resolve a gravidade"

        //Adicionando força
        //rb.AddForce(direction * speed);
	}
}