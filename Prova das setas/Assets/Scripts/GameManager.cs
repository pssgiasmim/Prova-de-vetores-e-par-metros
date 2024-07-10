using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    int pontos, teclaAtual;
    float relogio;
    KeyCode[] teclas;

    private void Start()
    {
        GerarSetas();
    }
    void Update ()
    {
        //Verificação para cada tecla direcional se foram pressionadas
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChecarTecla(KeyCode.UpArrow); 
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChecarTecla(KeyCode.DownArrow);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChecarTecla(KeyCode.RightArrow);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChecarTecla(KeyCode.LeftArrow);
        }

        ContagemRegressiva();

      
    }

    void ContagemRegressiva()
    {
        relogio -= Time.deltaTime; //Decremente relogio com Time.deltaTime.
        UIManager.instance.AtualizarTextos(pontos, relogio);
        if(relogio <= 0)
        {
            pontos -= teclaAtual - teclaAtual; //Se relogio for menor ou igual a 0, subtraia pontos por teclas.Length menos teclaAtual  e chame GerarSetas.
            GerarSetas();
        }


    }

    void GerarSetas()
    {
        teclaAtual= 0;
        teclas = new KeyCode[Random.Range(5, 15)];

        for (int i = 0; i < teclas.Length ; i++)  //Crie um novo array de KeyCode com um tamanho aleatório entre 5 e 15 e atribua a teclas.
        {               // Esse KeyCode ao lado de Random, serve para converter o valor de Random.Range em KeyCode
            teclas[i] = (KeyCode)Random.Range(273, 276); //Por meio de um for, preencha o array com valores aleatórios entre 273 e 276 (códigos para setas direcionais).
        }

        relogio = teclas.Length / 2; //Defina relogio como a metade do comprimento do array de teclas.

        UIManager.instance.AtualizarSetas(teclas); 
    }

    void ChecarTecla(KeyCode teclaPressionada)
    {
        if (teclaPressionada == teclas[teclaAtual]) //Verifique se a teclaPressionada corresponde à teclaAtual do array teclas.
        {
            pontos++;
            UIManager.instance.AtualizarSeta(teclaAtual, true);
        }
        else
        {
            pontos--;
            relogio--;
            UIManager.instance.AtualizarSeta(teclaAtual, false);
        }

        UIManager.instance.AtualizarTextos(pontos, relogio);

        teclaAtual++;

        if(teclaAtual == teclas.Length)
        {
            GerarSetas();
        }

    }

}
