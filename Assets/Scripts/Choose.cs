using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 6.1 usar a interface da Unity, assim teremos acesso aos elementos do Canvas
using UnityEngine.SceneManagement; // 6.2 Poderei administrar a transição de cenas


public class Choose : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject[] characters; // 5
    private int p = 0; // 5
    public Text playerName; // 6.1 Variável que aramazenará o nome do player e jogará para a classe saveScript, para ser salvo


    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------


    public void Next() // 5° Ativa o próximo personagem e deixa desativado o anterior
    {
        if (p < characters.Length - 1)
        {
            characters[p].SetActive(false);
            p++;
            characters[p].SetActive(true);
        }




    }//-----------------------------------------------------------------------------------------------------------------^ Next() ^--------------------------------------------------------------------------------------------------------
    public void Back() // 5° Ativa o  personagem anterior e deixa desativado o próximo
    {
        if (p > 0) // ou posso usar if (p <= characters.Length - 1 && p >= characters.Length - 5 )
        {
            characters[p].SetActive(false);
            p--;
            characters[p].SetActive(true);
        }
       




    }//-----------------------------------------------------------------------------------------------------------------^ Next() ^--------------------------------------------------------------------------------------------------------

    public void Accept() // 6.1 irá salvar o nome e o personagem, assim que pressionar o botão accept.
    {
        SaveScript.pchar = p; // 6.1 Irá passar o valor de "p", que é, na prática, o meu personagem, para a variável pchar, que irá salvar esse valor.
        SaveScript.pname = playerName.text; // 6.1 Irá salvar o nosso elemento de texto (nosso nome de personagem) para a variável pname, da classe SaveScript.
        SceneManager.LoadScene(1); // 6.2 Irá carregar a próxima cena, assim que eu clicar em Accept na tela

    }





}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------

