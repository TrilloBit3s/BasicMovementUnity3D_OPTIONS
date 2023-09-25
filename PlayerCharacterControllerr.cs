//Mover player com CharacterController
using UnityEngine;

public class PlayerCharacterControllerr : MonoBehaviour
{
    public float speed = 5;
    public float yVelocity = -9.81f;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
      //Vector3 direction = new Vector3(horizontal, 0, vertical);//não aplica gravidade
		Vector3 direction = new Vector3(horizontal, yVelocity, vertical);//aplica gravidade
		
        //Função que move o player com CharacterController
		cc.Move(direction * speed * Time.deltaTime);
	}

    //verificar a colisao em trigger
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        
    }
}
