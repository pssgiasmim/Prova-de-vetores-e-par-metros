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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Checartecla(UpArrow);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Checartecla(DownArrow);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Checartecla(RightArrow);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Checartecla(LeftArrow);
        }

        ContagemRegressiva();

      
    }

    void ContagemRegressiva()
    {
        relogio -= Time.deltaTime;
        AtualizarTexto(pontos, relogio);
        if(relogio <= 0)
        {
             teclas.Length.pontos -= teclaAtual;
            GerarSetas();
        }


    }

    void GerarSetas()
    {
        teclaAtual= 0;
        teclas = new KeyCode[Random.Range(5, 15)];
        for (int i = 0; KeyCode[Random.Range(273, 276)];i++) ;
        {
            relogio = teclas.Length / 2;

            UIManager.AtualiazarSeta(teclas);
        }

         
    }

    void ChecarTecla(KeyCode teclaPressionada)
    {
        if (teclaPressionada == teclas[teclaAtual])
        {
            pontos++;
            AtualizarSeta(teclaAtual, true);
        }
        else
        {
            pontos--;
            relogio--;
            AtualizarSeta(teclaAtual, false);
        }

        UIManager.AtualizarTextos(pontos, relogio);
        teclaAtual++;
        if(teclaAtual == teclas.Length)
        {
            GerarSetas();
        }

    }

}
