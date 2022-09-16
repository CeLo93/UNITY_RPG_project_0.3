using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInactivetrigger : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject triggerDoorexit; // 13 Variável dos telhados
    public GameObject roof; // 13 Variável dos telhados
    public GameObject props; // 13 Variável dos itens das construções


    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------


    void Start()
    {
        roof.SetActive(true); //13 Inicia o game com os telhados ativados
        props.SetActive(false); //13 Inicia o game com os itens das contruções desativados


    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------

    private void OnTriggerStay(Collider other) // 13 Irá ativar o gatilho ao tocar o colisor, desativando o telhado e ativando os props
    {
        if (other.CompareTag("Player"))
        {
            triggerDoorexit.SetActive(true);
            roof.SetActive(true); //13 Inicia o game com os telhados ativados
            props.SetActive(false); //13 Inicia o game com os itens das contruções desativados

        }
    }
    private void OnTriggerExit(Collider other) // 13 Aqui irá restaurá a configuração padrão ao sair do colisor
    {
        if (other.CompareTag("Player"))
        {
            triggerDoorexit.SetActive(false);
            
        }
    }



}