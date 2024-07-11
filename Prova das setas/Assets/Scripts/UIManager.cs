using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

//Crie uma classe chamada UIManager que herda de MonoBehaviour.
public class UIManager : MonoBehaviour

{
   //Declare uma variável estática pública do tipo UIManager chamada instance.
   public static UIManager instance;

    //Declare um array serializado do tipo Sprite chamado sprites.
    [SerializeField] Sprite[] sprites;

    //Declare um array serializado do tipo Image chamado imagens.
    [SerializeField] Image[] imagens;

    //Declare duas variáveis serializadas do tipo TextMeshProUGUI chamadas textoDePontuacao e textoDoRelogio.
    [SerializeField] TextMeshProUGUI textoDePontuacao; //Para qualquer TextMeshProUgui, é necessário ter um TMPro la encima, é gerado automaticamente.

    [SerializeField] TextMeshProUGUI textoDoRelogio;

    //No método Awake, inicialize instance como a instância atual(this).
    #region Singleton

    private void Awake()

    {

        instance = this;

    }

    #endregion

    //Método AtualizarSetas: //Este método tem como parâmetro um array de KeyCode chamado setas.
    public void AtualizarSetas(KeyCode[] setas) //Dentro do array/vetor KeyCode, tem o direcionamento de várias setas.

    {
        //Para cada Image em imagens, atualize a sprite correspondente com base no valor da tecla em setas.
        for (int i = 0; i < imagens.Length; i++) //Serve para percorrer cada imagem de cada seta.
        {
            //Se o índice for maior ou igual ao comprimento do array setas, defina a sprite como a primeira no array sprites.
            if (i >= setas.Length)
            {
                imagens[i].sprite = sprites[0]; //Aqui se altera a imagens[i] de sprite, para sprites[0]. //o [i] para saber qual repetição esta.
            }
            //Caso contrário, defina a sprite com base na tecla (DownArrow, UpArrow, LeftArrow, RightArrow).
            else if (setas[i] == KeyCode.DownArrow) //Tecla para baixo
            {
                imagens[i].sprite = sprites[1];
            }
            else if (setas[i] == KeyCode.UpArrow) //Tecla para cima
            {
                imagens[i].sprite = sprites[2];
            }
            else if (setas[i] == KeyCode.LeftArrow) //Tecla para a Esquerda
            {
                imagens[i].sprite = sprites[3];
            }
            else if (setas[i] == KeyCode.RightArrow) //Tecla para a Direita
            {
                imagens[i].sprite = sprites[4];
            }

            //Defina a cor da imagem como branca.
            imagens[i].color = Color.white;
        }
    }

    //Método AtualizarSeta:
    //Este método tem como parâmetro um inteiro setaSelecionada e um booleano acertou.
    public void AtualizarSeta( int setaSelecionada, bool acertou)
    {
        //Se acertou for verdadeiro, defina a cor da imagem correspondente como verde.
        if (acertou)
        {
            imagens[setaSelecionada].color = Color.green;
        }
        //Caso contrário, defina a cor da imagem como vermelha.
        else
        {
            imagens[setaSelecionada].color = Color.red;
        }
    }

    //Método AtualizarTextos:
    //Este método tem como parâmetro um inteiro pontuacao e um float relogio.
    public void AtualizarTextos(int pontuacao, float relogio)
    {
        //Atualize o text de textoDePontuacao com o valor de pontuacao convertido para string.
        textoDePontuacao.text = pontuacao.ToString(); //ToString é uma forma de converter valores numéricos para string.
        //- Atualize o `text` de `textoDoRelogio` com o valor de `relogio` convertido para `string`.
        textoDoRelogio.text = relogio.ToString();
    }



}

