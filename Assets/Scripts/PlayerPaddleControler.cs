using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public float speed = 5f;

    public string movmentAxisName = "Vertical";
    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if(isPlayer)
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        else
            spriteRenderer.color = SaveController.Instance.colorEnemy;

    }


    void Update()
    {
        // Captura da entrada vertical (seta para cima, seta para baixo, teclas W e S)
        float moveInput = Input.GetAxis(movmentAxisName);

        // Calcula a nova posição da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        // Limita a posição vertical da raquete para que ela não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        // Atualiza a posição da raquete
        transform.position = newPosition;
    }

}
