using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

 
public class UIManager : MonoBehaviour

{

    UIManager instance;

    [SerializeField] Sprite[] sprites;

    [SerializeField] Image[] imagens;

    [SerializeField] TextMeshProUGUI textoDePontuacao; //Para qualquer TextMeshProUgui, é necessário ter um TMPro la encima, é gerado automaticamente.

    [SerializeField] TextMeshProUGUI textoDoRelogio;

    //Qualquer AWAKE precisa de um SINGLETON.
    #region Singleton

    private void Awake()

    {

        instance = this;

    }

    #endregion

    public void AtualizarSetas(KeyCode[] setas) //Dentro do array/vetor KeyCode, tem o direcionamento de várias setas.

    {

        for (int i = 0; i < imagens.Length; i++) //Serve para percorrer cada imagem de cada seta.
        {  //Deve se comparar se as imagens das setas, são iguais as setas selecionadas. Se a imagem é seta para cima, a seta deve ser para cima.

            if (i >= setas.Length)
            {
                imagens[i].sprite = sprites[0]; //Aqui se altera a imagens[i] de sprite, para sprites[0]. //o [i] para saber qual repetição esta.
            }
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

            //Alteração de cor da imagem
            imagens[i].color = Color.white;
        }
    }

    void AtualizarSeta( int setaSelecionada, bool acertou)
    {
        if (acertou)
        {
            imagens[setaSelecionada].color = Color.green;
        }
        else
        {
            imagens[setaSelecionada].color = Color.red;
        }
    }



}

