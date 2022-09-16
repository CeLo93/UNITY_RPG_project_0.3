using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 9. inventario

public class InventoryItems : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject inventoryMenu; //8
    public GameObject openBook; //8
    public GameObject closedBook; //8

    //===ÍCONES NO INVENTÁRIO--v
    public Image[] emptySlots; //10 Acessando os espaços dos ícones no inventário
    public Sprite[] icons; //10 Acessando as sprites dos ícones
    public Sprite emptyIcon; //10 comparando o ícone vazio para ver se possui sprite ou não para, assim, poder armazenar o ítem no slot vazio

    public static int newIcon = 0; //10
    public static bool iconUpdate = false; //10
    private int max; //10

    public static int redMushrooms = 0; //10.1 Ele lembrará, sempre, esse valor de 0 para a variável
    public static int purpleMushrooms = 0; //12.1 Ele lembrará, sempre, esse valor de 0 para a variável
    public static int brownMushrooms = 0; //12.1 Ele lembrará, sempre, esse valor de 0 para a variável
    public static int blueFlowers = 0; //10.1
    public static int redFlowers = 0;
    public static int roots = 0; //10.1
    public static int leafDew = 0; 
    public static int dragonEgg = 0; 
    public static int redPotion = 0; 
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;

    //===ÍCONES NO INVENTÁRIO e suas variáveis estáticas--^

    /* EXPLICAÇÃO DA LÓGICA DA MENSAGEM DO INVENTÁRIO:-------v 
     
        Irei adicionar os meus itens nas variáveis estáticas aqui. Após isso, irei determiná-los como 0 no start, para sempre iniciarem como 0, pois preciso coletá-los
        para contar. Cada item adicionado a um slot da array icons, deve seguir este procedimento. Devo ficar atentto, pois o script HintMessage irá definir a mensagem
        de acordo com o número do slot da array atribuído ao ítem lá na engine. Assim, eu adiciono o ícone ao slot da array, coloco a variável aqui, seto a mensagem
        no HintMessage com o número exato do ítem na array e a mensagem que quero passar.

        PEGANDO O ITEM:
        
        Devo adicionar o ítem, atribuído a variável aqui, como explicado acima, no Script Pickup. Apenas preciso manter o padrão do código do script Pickup e ir copiando
        para outros ítens que adicione. Eu posso fazer um método para apenas mudar a variável, sem ter que usar todo aquele código repetido (vou mudar isso depois). Preciso
        adicionar a variável booleana em Pickups, correspondente ao meu item, junto com o número do captador dele da variável correspondente ao array do InventoryItems. Depois
        atacho o script pickup ao objeto, a ser coletado na cena e correspondente ao meu ícone do menu, e marco a opção booleana dele na engine.

        RESUMO -> Faço a variável do item no InventoryItems, depois irei adicionar o ícone ma array na engine, faço a variável no pickups e atacho o script no objeto correspondente
                  e depois só preciso repetir os códigos de mensagem em HintMessage e Pickups. Basicamente, qualquer item que eu vá adicionar, só preciso repetir este processo feito
                  aqui, pois a base do código já está pronta.
    */
    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    void Start()
    {
        //8 Inicia o game com o menu fechado---v //9
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        //8 Inicia o game com o menu fechado---^

        max = emptySlots.Length; //10 Vai começar o game a corresponder ao total de ícones vazios

        //=== Iniciando os itens do zero, sempre que eu os pegar vão iniciar com 0---v
        redMushrooms = 0; //10.1
        purpleMushrooms = 0;
        brownMushrooms = 0;
        blueFlowers = 0; //10.1 sempre que iniciamos o game, o valor dos itens será 0
        redFlowers = 0;
        roots = 0; //10.1
        leafDew = 0;
        dragonEgg = 0;
        redPotion = 0;
        bluePotion = 0;
        greenPotion = 0;
        purplePotion = 0;
        bread = 0;
        cheese = 0;
        meat = 0;
        //=== Iniciando os itens do zero, sempre que eu os pegar vão iniciar com 0---^

    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    void Update()
    {
        if(iconUpdate == true) // 10 código para mudar o icone do inventario ao pegar no mapa
        {
            for(int i = 0; i < max; i++)
            {
                if(emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon; //12 Vou passar a mensagem, do script dde mensagem, para o slot definito em i aqui
                }
            }

            StartCoroutine(Reset()); // 10

        }
        

    }//-----------------------------------------------------------------------------------------------------------------^ UPDATE ^--------------------------------------------------------------------------------------------------------
    
    public void OpenMenu() // 8 Abre o menu e mostra o ícone do livro aberto
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        Time.timeScale = 0; // 8.1 Este comando congela (pausa o tempo) o tempo do jogo. Se fosse 1, seria normal (como na outra função); Se fosse 2, seria 2x mais rápido
    }
    public void CloseMenu() // 8 fecha o menu e mostra o ícone do livro fechado
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        Time.timeScale = 1; // 8.1 Este comando normaliza o game que foi pausado na função anterior. 

    }

    private IEnumerator Reset() //10 Courotine esperando 1 segundo para executar
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;

    }


}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------
