using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;  // Kecepatan peluru saat bergerak
    public int damage = 10;  // Jumlah kerusakan yang dihasilkan oleh peluru
    private Rigidbody2D rb;  // Referensi ke komponen Rigidbody2D
    private Vector2 minScreenBounds;  // Batas layar bagian bawah/kiri
    private Vector2 maxScreenBounds;  // Batas layar bagian atas/kanan
    public IObjectPool<Bullet> objectPool;  // Objek peluru untuk pengelolaan ulang


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        maxScreenBounds = mainCamera.transform.position + new Vector3(cameraWidth / 2, cameraHeight / 2);
        minScreenBounds = mainCamera.transform.position - new Vector3(cameraWidth / 2, cameraHeight / 2);
    }

    void MoveBullet()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, bulletSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika bertabrakan dengan objek bertanda "Enemy", kembalikan peluru ke kolam objek
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReturnToPool();
        }
        // Kembalikan peluru ke kolam objek dalam kasus tabrakan lain
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        if (objectPool != null)
        {
            objectPool.Release(this);
        }
    }

    void Update()
    {
        MoveBullet();
        if (transform.position.x < minScreenBounds.x || transform.position.x > maxScreenBounds.x ||
            transform.position.y < minScreenBounds.y || transform.position.y > maxScreenBounds.y)
        {
            ReturnToPool();
        }
    }

}