using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

//Cria��o da Classe GameManager
public class GameManager : MonoBehaviour

{
    //Declare vari�veis do tipo int chamadas pontos e teclaAtual.
    int pontos, teclaAtual;
    //Declare uma vari�vel do tipo float chamada relogio.
    float relogio;
    //Declare uma vari�vel do tipo array de KeyCode chamada teclas.
    KeyCode[] teclas;

    //M�todo Start:
    private void Start()
    {
        //No m�todo Start, chame o m�todo GerarSetas.
        GerarSetas();
    }

    //M�todo Update:
    void Update ()
    {
        //No m�todo Update, fa�a uma verifica��o para cada seta direcional, se foram pressionadas (DownArrow, UpArrow, RightArrow, LeftArrow).
        //Se for, em cada checagem, chame o m�todo ChecarTecla passando a tecla correspondente como par�metro.
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

        //Depois chame o m�todo ContagemRegressiva.
        ContagemRegressiva();

      
    }

    //M�todo ContagemRegressiva:
    void ContagemRegressiva()
    {
        //Decremente relogio com Time.deltaTime.
        relogio -= Time.deltaTime;

        //Atualize os textos no UIManager chamando AtualizarTextos passando pontos e relogio.
        UIManager.instance.AtualizarTextos(pontos, relogio);

        //Se relogio for menor ou igual a 0, subtraia pontos por teclas.Length menos teclaAtual  e chame GerarSetas.
        if (relogio <= 0)
        {
            pontos -= teclaAtual - teclaAtual; 
            GerarSetas();
        }


    }

    //M�todo GerarSetas:
    void GerarSetas()
    {
        //Inicialize teclaAtual como 0.
        teclaAtual = 0;

        //Crie um novo array de KeyCode com um tamanho aleat�rio entre 5 e 15 e atribua a teclas.
        teclas = new KeyCode[Random.Range(5, 15)];

        //Por meio de um for, preencha o array com valores aleat�rios entre 273 e 276(c�digos para setas direcionais).
        for (int i = 0; i < teclas.Length ; i++)  
        {               // Esse KeyCode ao lado de Random, serve para converter o valor de Random.Range em KeyCode
            teclas[i] = (KeyCode)Random.Range(273, 276); 
        }

        //Defina relogio como a metade do comprimento do array de teclas.
        relogio = teclas.Length / 2;

        //Atualize as setas no UIManager chamando AtualizarSetas passando teclas como par�metro.
        UIManager.instance.AtualizarSetas(teclas); 
    }

    //M�todo ChecarTecla:
    //Crie um par�metro KeyCode chamado teclaPressionada
    void ChecarTecla(KeyCode teclaPressionada)
    {
        ////Verifique se a teclaPressionada corresponde � teclaAtual do array teclas.
        if (teclaPressionada == teclas[teclaAtual]) 
        {
            //Se sim, incremente pontos e chame AtualizarSeta passando teclaAtual e true como par�metro.
            pontos++;
            UIManager.instance.AtualizarSeta(teclaAtual, true);
        }
        else
        {
            //Se n�o, decremente pontos e relogio, e chame AtualizarSeta passando teclaAtual e false como par�metro.
            pontos--;
            relogio--;
            UIManager.instance.AtualizarSeta(teclaAtual, false);
        }

        //Atualize os textos no UIManager chamando AtualizarTextos passando pontos e relogio como par�metro.
        UIManager.instance.AtualizarTextos(pontos, relogio);

        //Incremente teclaAtual.
        teclaAtual++;

        //Se teclaAtual for igual ao comprimento do array teclas, chame GerarSetas.
        if (teclaAtual == teclas.Length)
        {
            GerarSetas();
        }

    }

}
