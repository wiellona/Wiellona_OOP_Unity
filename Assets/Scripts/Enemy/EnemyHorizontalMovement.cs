using UnityEngine;

public class EnemyHorizontalMovement : Enemy
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 dir;

    private void Awake()
    {
        PickRandomPositions();
    }

    private void Update()
    {
        if (dir != Vector2.zero)  // Pastikan dir sudah di-set
        {
            transform.Translate(moveSpeed * Time.deltaTime * dir);
        }

        // Mengubah posisi enemy dari koordinat dunia ke koordinat viewport
        Vector3 ePos = Camera.main.WorldToViewportPoint(transform.position);

        // Deteksi apakah musuh keluar dari layar dan ubah posisinya
        if (ePos.x < -0.05f && dir == Vector2.right)
        {
            PickRandomPositions();  // Kembali ke sisi kanan
        }
        if (ePos.x > 1.05f && dir == Vector2.left)
        {
            PickRandomPositions();  // Kembali ke sisi kiri
        }
    }


    private void PickRandomPositions()
    {
        Vector2 randPos;
        // Mengatur arah bergerak secara acak (kanan atau kiri)
        if (Random.Range(0f, 1f) >= 0.5f)
        {
            dir = Vector2.right;  // Arahkan ke kanan
        }
        else
        {
            dir = Vector2.left;   // Arahkan ke kiri
        }

        // Menentukan posisi spawn berdasarkan arah
        if (dir == Vector2.right)
        {
            randPos = new Vector2(1.1f, Random.Range(0.1f, 0.95f));  // Spawn di sisi kiri layar
        }
        else
        {
            randPos = new Vector2(-0.01f, Random.Range(0.1f, 0.95f));  // Spawn di sisi kanan layar
        }

        // Mengubah posisi musuh ke koordinat dunia berdasarkan posisi layar
        transform.position = Camera.main.ViewportToWorldPoint(randPos) + new Vector3(0, 0, 10);
    }

}
