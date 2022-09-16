using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public int number; // 10. número do captador, que irá definir qual ícone irá aparecer no menu do inventário, ao pegar o item no mapa

    public bool redMushroom = false; // 10.1
    public bool purpleMushroom = false; // 10.1
    public bool brownMushroom = false; // 10.1
    public bool redFlower = false; //10.1
    public bool blueFlower = false; //10.1

    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------

  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetMouseButtonDown(0)) //10.2 Ao clicar, ele coleta o item
            {
                MostraItems();

            }
        }
    }

    void DisplayIcons() //10.1
    {
        //10== Fará o código de adicionar o ícone do ítem, ao menu de inventário, executar antes de destruí-lo--v
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
        //10== Fará o código de adicionar o ícone do ítem, ao menu de inventário, executar antes de destruí-lo--^
    }
    private void MostraItems()
    {
        if (redMushroom == true) //10.1 Este trecho irá reconhecer quando o número do item for igual a 1 (pois 0 seria 1 cogumelo aqui), irá mostrar no inventário. Sempre que coletar mais que um, adiciona ele e o destrói, a fim de não aparecer no menu a imagem repetida
        {
            if (InventoryItems.redMushrooms == 0)
            {
                DisplayIcons();
            }
            InventoryItems.redMushrooms++;
            Destroy(gameObject);
        }
        else if (brownMushroom == true) //10.1 Este trecho irá reconhecer quando o número do item for igual a 1 (pois 0 seria 1 cogumelo aqui), irá mostrar no inventário. Sempre que coletar mais que um, adiciona ele e o destrói, a fim de não aparecer no menu a imagem repetida
        {

            if (InventoryItems.brownMushrooms == 0)
            {
                DisplayIcons();
            }
            InventoryItems.brownMushrooms++;
            Destroy(gameObject);
        }
        else if (blueFlower == true) //10.1 Este trecho irá reconhecer quando o número do item for igual a 1 (pois 0 seria 1 cogumelo aqui), irá mostrar no inventário. Sempre que coletar mais que um, adiciona ele e o destrói, a fim de não aparecer no menu a imagem repetida
        {

            if (InventoryItems.blueFlowers == 0)
            {
                DisplayIcons();
            }
            InventoryItems.blueFlowers++;
            Destroy(gameObject);
        }
        else if (redFlower == true) //10.1 Este trecho irá reconhecer quando o número do item for igual a 1 (pois 0 seria 1 cogumelo aqui), irá mostrar no inventário. Sempre que coletar mais que um, adiciona ele e o destrói, a fim de não aparecer no menu a imagem repetida
        {

            if (InventoryItems.redFlowers == 0)
            {
                DisplayIcons();
            }
            InventoryItems.redFlowers++;
            Destroy(gameObject);
        }

        else //10.1 se não, apenas mostre o item e o destrua
        {
            DisplayIcons();
            Destroy(gameObject);
        }
    }

   
}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------

