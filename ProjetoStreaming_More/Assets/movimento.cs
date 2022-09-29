using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimento : MonoBehaviour
{
    float _velocidadeFrente;
    float _velocidadeTras;
    float _velocidadeGirar;
    PlayerInput playerInput;
    Vector3 movimentoV;

    // Start is called before the first frame update
    /*
    void Start()
    {
        
        _velocidadeFrente = 10;
        _velocidadeTras = 5;
        _velocidadeGirar = 60;
        
}
*/
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void OnEnable()
    {
        playerInput.actions["Move"].started += Mover;
        playerInput.actions["Move"].canceled += Parar;
    }
        void OnDisable()
        {
            playerInput.actions["Move"].started -= Mover;
            playerInput.actions["Move"].canceled -= Parar;
        }

    public void Mover(InputAction.CallbackContext contexto)
    {
        movimentoV = new Vector3(contexto.ReadValue <Vector2>().x, 0f, contexto.ReadValue < Vector2>().y);
    }
    public void Parar(InputAction.CallbackContext contexto)
    {
        movimentoV = new Vector3(0f,0f,0f);
    }
        // Update is called once per frame
        
       void Update()
       {

        transform.position += movimentoV * 0.01f;
        /*
           if (Input.GetKey("w"))
           {
               transform.Translate(0, 0, (_velocidadeFrente * Time.deltaTime));
           }

           if (Input.GetKey("s"))
           {
               transform.Translate(0, 0, (-_velocidadeTras * Time.deltaTime));
           }

           if (Input.GetKey("a"))
           {
               transform.Rotate(0, (-_velocidadeGirar * Time.deltaTime), 0);
           }

           if (Input.GetKey("d"))
           {
               transform.Rotate(0, (_velocidadeGirar * Time.deltaTime), 0);
           }
*/
    }

}
