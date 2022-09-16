using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject[] Characters; // 7
    public Transform spawnPoint; // 7

    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    void Start()
    {

        Instantiate(Characters[SaveScript.pchar], spawnPoint.position, spawnPoint.rotation); // 7 Irei instanciar o player, de acordo com a escolha da variável pchar (script SaveScript), que é definida pelo valor da variável p (script Choose), sendo spawnado na posição e rotação exatas do objeto, que possui este script anexo, as quais foram configuradas de acordo com o player modelo que estava na cena


    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    






}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------

