using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pulo : MonoBehaviour
{
    private Rigidbody rigidbody;
    PlayerInput playerInput;
    Vector3 movimentoV;
    float jumpForce;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        playerInput.actions["JUMP"].started += Pular;
        playerInput.actions["JUMP"].canceled += Parar;
    }
    void OnDisable()
    {
        playerInput.actions["JUMP"].started -= Pular;
        playerInput.actions["JUMP"].canceled -= Parar;
    }
    // Update is called once per frame
    public void Pular(InputAction.CallbackContext contexto)
    {
        Debug.Log("pulou");
        jumpForce = 1f;
        //rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public void Parar(InputAction.CallbackContext contexto)
    {
        jumpForce = 0f;
    }
    void Update()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
