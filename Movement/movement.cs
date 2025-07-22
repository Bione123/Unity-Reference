using System;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput; // creo una variabile di tipo playerinput che gestisce tutte le azioni nelle action maps
    private float movementX; // Variabile che definisce il movimento sull'asse x
    public float speed = 5f; // Variabile che definisce la velocità di movimento

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // assegno alla variabile playerinput il componente playerinput (rendo il gameobject pronto a ricevere istruzioni, devo solo dirgli quali sono)
        playerInput.actions["Move"].performed += ctx => movementX = ctx.ReadValue<Vector2>().x; // Se viene eseguita un'azione di tipo "move" prendila e inseriscila nella variabile movementX (sarà di tipo Vector2)
        playerInput.actions["Move"].canceled += ctx => movementX = 0f; // Quando l'azione smette di essere eseguita, metti il movimento = 0
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer() // funzione che gestisce il movimento del giocatore
    {
        Vector3 moveDirection = new Vector3(movementX, 0, 0) * speed * Time.deltaTime;
        transform.position += moveDirection;
    }
}
