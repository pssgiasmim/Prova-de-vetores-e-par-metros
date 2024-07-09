using System.Collections;
using System.Collections.Generic;
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

}
