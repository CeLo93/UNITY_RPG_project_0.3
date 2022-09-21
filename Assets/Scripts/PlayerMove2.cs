using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class PlayerMove2 : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------

    Vector3 target; // 1.
    Rigidbody rb; // 1.
    //private Ray ray; //1
    //private NavMeshAgent nav; // 1.
    //private RaycastHit hit; // 1.
    //private Vector3 pos; // 3 será a posição do mouse

    //====CAMERAROTATE-v*
    public Transform cameraP;
    //====CAMERAROTATE-^*

    //====CINEMACHINE--v (3)
    CinemachineTransposer ct; // 3. Variável para acessar os componentes do Cinemachine na Unity.
    public CinemachineVirtualCamera playerCam; // 3. Acesso público a câmera, para que possamos arrastar objetos para ela.
   
    private Vector3 currPos; // 3. Achar a posição atual
    //====CINEMACHINE--^

    //====MENU--v
    public static bool canMove = true; // 8.2 [Script: CursorOver.cs]
    private Animator animator;
    [SerializeField] float velocidade = 5f;
    private Vector3 inputs;
    //====MENU--^

    private NavMeshAgent character;

    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    void Start()
    {
        //nav = GetComponent<NavMeshAgent>(); // 1. Atribuindo o Objeto, que possui o componente NavMeshAgent, à variável "nav"
        rb = GetComponent<Rigidbody>(); // 1
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>(); // 3. Obtemos o componente de giro "CinemachineTransposer", que é o que quermos para girar a câmera, e temos que citaro playerCam., pois ele será referênciado com nosso objeto a ser acessado o Cinemachine.
        currPos = ct.m_FollowOffset; // 3. Passará os valores da câmera, referente a posição do mouse atual, para a variável.

        character = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // 2. Atribui o Animator do Objeto à variável

    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(Time.deltaTime * velocidade * inputs.normalized);
        character.Move(Vector3.down.normalized * Time.deltaTime);

        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward.normalized, inputs, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("andando", false);
        }

        
    }//-----------------------------------------------------------------------------------------------------------------^ UPDATE ^--------------------------------------------------------------------------------------------------------



    #region comentados----v
    /*private void MovePlayer() // 2°
    {
        if (canMove == true)
        {
            //====Movimentação com o WASD e Giro da câmera do mouse--v
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(h, 0, v).normalized;

            transform.Translate(dir * velocityC * Time.deltaTime);

            if (Input.GetMouseButton(1))
            {

                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                transform.Rotate(new Vector3(0, mouseX * rotationC * Time.deltaTime, 0));
                //transform.Rotate(new Vector3(mouseY * rotationC * Time.deltaTime, 0, 0));
                //transform.eulerAngles = new Vector3(mouseY, mouseX, 0);


            }

            //====Movimentação com o WASD e Giro da cãmera do mouse--^
            #region ======== ANIMAÇÕES DE MOVIEMENTO---v
            velH = h;
            velV = v;
            velHV = h + v;
            velHV2 = h - v;
            velHV3 = -h + v;
            velHV4 = -h - v;


            // ==== MOVIMENTACAO CIMA BAIXO
            if (velV > 0 && velH == 0) // 2.2 
            {
                anim.SetBool("sprinting", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
            }

            if (velV < 0 || velV == 0) // 2.2
            {
                anim.SetBool("sprinting", false);
            }
            if (velV < 0 && velH == 0) // 2.2 
            {
                anim.SetBool("sprintingback", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
            }

            if (velV > 0 || velV == 0) // 2.2
            {
                anim.SetBool("sprintingback", false);
            }

            // ==== MOVIMENTACAO ESQUERDA DIREITA


            if (velH > 0 && velV > 0) // 2.2 
            {
                anim.SetBool("sprintingright", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
                anim.SetBool("runbasicright", true);
                anim.SetBool("runfrontright", true);
            }
            if (velH == 0 || velV == 0)
            {
                anim.SetBool("sprintingright", false);
                anim.SetBool("runbasicright", false);
                anim.SetBool("runfrontright", false);
            }


            if (velH < 0 && velV > 0) // 2.2 
            {
                anim.SetBool("sprintingleft", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
                anim.SetBool("runbasicleft", true);
                anim.SetBool("runfrontleft", true);
            }

            if (velH == 0 || velV == 0)
            {
                anim.SetBool("sprintingleft", false);
                anim.SetBool("runbasicleft", false);
                anim.SetBool("runfrontleft", false);
            }


            if (velH < 0 && velV == 0) // 2.2 
            {
                anim.SetBool("basicleft", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
            }
            if (velH == 0 || velH > 0)
            {
                anim.SetBool("basicleft", false);
            }


            if (velH > 0 && velV == 0) // 2.2 
            {
                anim.SetBool("basicright", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
            }
            if (velH == 0 || velH < 0)
            {
                anim.SetBool("basicright", false);
            }

            if (velH > 0 && velV < 0) // 2.2 
            {
                anim.SetBool("runbackright", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
                anim.SetBool("strafebackright", true);
                anim.SetBool("backbackright", true);
            }
            if (velH == 0 || velV == 0)
            {
                anim.SetBool("runbackright", false);
                anim.SetBool("strafebackright", false);
                anim.SetBool("backbackright", false);
            }

            if (velH < 0 && velV < 0) // 2.2 
            {
                anim.SetBool("runbackleft", true); // 2.2 Caso a condição realize, este comando irá ativar a nossa animação, condicionada no Animator com o a condição de nome sprinting
                anim.SetBool("strafebackleft", true);
                anim.SetBool("backbackleft", true);
            }
            if (velH == 0 || velV == 0)
            {
                anim.SetBool("runbackleft", false);
                anim.SetBool("strafebackleft", false);
                anim.SetBool("backbackleft", false);
            }

            #endregion ======== ANIMAÇÕES DE MOVIEMENTO---^*/


    /*//=====Cálculo-v
    x = nav.velocity.x;
    z = nav.velocity.z;
    velocitySpeed = x + z;
    //Explicação---^: O cálculo irá atribuir o valor ao x, z e velocitySpeed da seguinte maneira, os valores do componente NavMeshAgent de velocidade serão atribuidos a variável "x" no eixo X e na variável "z" no Z,
    //o velocitySpeed é a soma dos dois, pois independente do valor, precisamos que ela seja diferente de 0 para acionr a animação. Como o personagem se movimenta em direções variadas entre os eixos X e Z, a soma irá
    // sempre ser um valor diferente de zero.


    if (Input.GetMouseButtonDown(0))
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            nav.destination = hit.point;
        }
    }*/

    #endregion comentados----^
}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------
