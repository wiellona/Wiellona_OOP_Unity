using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }

    // public static Player Instance { get; private set; }

    // void Awake()
    // {
    //     // Cek jika sudah ada instance Player yang lain, maka hancurkan yang baru
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else if (Instance != this)
    //     {
    //         Destroy(gameObject);
    //     }

    //     // Pastikan Player tidak dihancurkan saat berpindah scene
    //     DontDestroyOnLoad(gameObject);
    // }
}
