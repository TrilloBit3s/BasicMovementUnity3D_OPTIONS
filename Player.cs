//mover personagem com teclado ou gamepad
//script simples
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform cam;
    private CharacterController controle;  
    private Animator anim;

    public float velocidade_Movimento;

    private Vector3 direcao; //(horizontal, vertical)
    private Vector3 direcao_Movimento; //indica a direção do player

    //Variaveis para suavização de rotação do Peronagem
    private float tempo_De_Giro_Suave = 0.1f; 
    private float velocidade_De_Giro_Suave; 

    void Start() 
    {
        cam = Camera.main.transform;
        controle = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update() 
    {
        GetInput();
        moverPersonagem();
    }

    void GetInput()
    {
        direcao = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void moverPersonagem()
    {
        if(direcao.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocidade_De_Giro_Suave, tempo_De_Giro_Suave);
            transform.rotation = Quaternion.Euler(0f, angle, 0f); //aplicando a rotação

            //resolvendo a direção fixa do player, sem ela o player fica sempre pra frente
            direcao_Movimento = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        //normaliza andar do player
        controle.Move(direcao_Movimento.normalized * velocidade_Movimento * direcao.magnitude * Time.deltaTime);
    }
}