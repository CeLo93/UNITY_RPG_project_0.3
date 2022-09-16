using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //11
using UnityEngine.UI; //11

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject hintBox; // 11 Acesso à caixa de texto
    public Text message; //11 Acesso ao texto
    private bool displaying = true; // 11.1
    private bool overIcon = false; //11.1
    private Vector3 screenPoint; //11 converter mouse para a caixa de texto
    public int objectType = 0; // 12

    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if (displaying == true)
        {

            hintBox.SetActive(true); //11 Ao passar o mouse do objeto, ativará a caixa de texto
            screenPoint.x = Input.mousePosition.x + 430; //11 converte o mous em 2D e ajusta a escala no valor determinado
            screenPoint.y = Input.mousePosition.y; //11 Iguala a posição do mouse na tela a posição do mouse.
            screenPoint.z = 1f; //11 vai ser a distância da câmera
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint); // Converterá a posição da caixa de texto a uma posição 3D dentro do jogo
            MessageDisplay(); //11 irá executar o texto que configurarmos aqui
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overIcon = false; //11.1

        hintBox.SetActive(false); //11 Desativa a caixa ao sair do evento
    }
   

    void Start()
    {
        hintBox.SetActive(false); //11 Inicia o jogo com a janela de texto desativada, sempre

    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    void Update()
    {
        if (overIcon == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            displaying = true;
            
        }

    }//-----------------------------------------------------------------------------------------------------------------^ UPDATE ^--------------------------------------------------------------------------------------------------------

    void MessageDisplay()
    {
        if (objectType == 0)
        {
            message.text = "empty";
        }
        if (objectType == 1)
        {
            message.text = InventoryItems.redMushrooms.ToString() + " red mushroons to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem, caso seja o redMushroom que está setado na engine como slot 1
        }
        if (objectType == 2)
        {
            message.text = InventoryItems.purpleMushrooms.ToString() + " purple mushroons to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem, caso seja o redMushroom que está setado na engine como slot 1

        }
        if (objectType == 3)
        {
            message.text = InventoryItems.brownMushrooms.ToString() + " brown mushroons to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem, caso seja o redMushroom que está setado na engine como slot 1

        }
        if (objectType == 4)
        {
            message.text = InventoryItems.blueFlowers.ToString() + " blue flowers to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem
        }
        if (objectType == 5)
        {
            message.text = InventoryItems.redFlowers.ToString() + " red flowers to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem
        }
        if (objectType == 6)
        {
            message.text = InventoryItems.roots.ToString() + " roots to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem, caso seja o redMushroom que está setado na engine como slot 1
        }
        if (objectType == 7)
        {
            message.text = InventoryItems.leafDew.ToString() + " leaf dew to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem, caso seja o redMushroom que está setado na engine como slot 1
        }
        if (objectType == 8)
        {
            message.text = "key to open chests";
        }
        if (objectType == 9)
        {
            message.text = InventoryItems.dragonEgg.ToString() + " dragon eggs to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem, caso seja o redMushroom que está setado na engine como slot 1

        }
        if (objectType == 10)
        {
            message.text = InventoryItems.bluePotion.ToString() + " blue potion to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem
        }
        if (objectType == 11)
        {
            message.text = InventoryItems.purplePotion.ToString() + " purple potion to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem
        }
        if (objectType == 12)
        {
            message.text = InventoryItems.greenPotion.ToString() + " green potion to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem
        }
        if (objectType == 13)
        {
            message.text = InventoryItems.redPotion.ToString() + " red potion to be used in potions"; // 12 Exibe a quantidade dos itens do objeto especificado no script InvewntoryItems, mais uma mensagem
        }



    }



}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------

