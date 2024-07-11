using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

//Criação da Classe GameManager
public class GameManager : MonoBehaviour

{
    //Declare variáveis do tipo int chamadas pontos e teclaAtual.
    int pontos, teclaAtual;
    //Declare uma variável do tipo float chamada relogio.
    float relogio;
    //Declare uma variável do tipo array de KeyCode chamada teclas.
    KeyCode[] teclas;

    //Método Start:
    private void Start()
    {
        //No método Start, chame o método GerarSetas.
        GerarSetas();
    }

    //Método Update:
    void Update ()
    {
        //No método Update, faça uma verificação para cada seta direcional, se foram pressionadas (DownArrow, UpArrow, RightArrow, LeftArrow).
        //Se for, em cada checagem, chame o método ChecarTecla passando a tecla correspondente como parâmetro.
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

        //Depois chame o método ContagemRegressiva.
        ContagemRegressiva();

      
    }

    //Método ContagemRegressiva:
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

    //Método GerarSetas:
    void GerarSetas()
    {
        //Inicialize teclaAtual como 0.
        teclaAtual = 0;

        //Crie um novo array de KeyCode com um tamanho aleatório entre 5 e 15 e atribua a teclas.
        teclas = new KeyCode[Random.Range(5, 15)];

        //Por meio de um for, preencha o array com valores aleatórios entre 273 e 276(códigos para setas direcionais).
        for (int i = 0; i < teclas.Length ; i++)  
        {               // Esse KeyCode ao lado de Random, serve para converter o valor de Random.Range em KeyCode
            teclas[i] = (KeyCode)Random.Range(273, 276); 
        }

        //Defina relogio como a metade do comprimento do array de teclas.
        relogio = teclas.Length / 2;

        //Atualize as setas no UIManager chamando AtualizarSetas passando teclas como parâmetro.
        UIManager.instance.AtualizarSetas(teclas); 
    }

    //Método ChecarTecla:
    //Crie um parâmetro KeyCode chamado teclaPressionada
    void ChecarTecla(KeyCode teclaPressionada)
    {
        ////Verifique se a teclaPressionada corresponde à teclaAtual do array teclas.
        if (teclaPressionada == teclas[teclaAtual]) 
        {
            //Se sim, incremente pontos e chame AtualizarSeta passando teclaAtual e true como parâmetro.
            pontos++;
            UIManager.instance.AtualizarSeta(teclaAtual, true);
        }
        else
        {
            //Se não, decremente pontos e relogio, e chame AtualizarSeta passando teclaAtual e false como parâmetro.
            pontos--;
            relogio--;
            UIManager.instance.AtualizarSeta(teclaAtual, false);
        }

        //Atualize os textos no UIManager chamando AtualizarTextos passando pontos e relogio como parâmetro.
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
