// using System.Collections;
// using UnityEngine;

// public class Portal : MonoBehaviour
// {
//     // Fields untuk mengontrol pergerakan dan rotasi asteroid
//     [SerializeField] private float speed = 5f;
//     [SerializeField] private float rotateSpeed = 50f;

//     // Posisi baru yang akan dituju asteroid
//     private Vector2 newPosition;

//     // Referensi ke Player untuk mengecek apakah memiliki weapon
//     private GameObject player;

//     // Collider dari asteroid
//     private Collider2D asteroidCollider;

//     // Start is called before the first frame update
//     void Start()
//     {
//         // Inisialisasi posisi baru dan referensi ke Player serta Collider
//         ChangePosition();
//         player = GameObject.FindWithTag("Player");
//         asteroidCollider = GetComponent<Collider2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Cek apakah jarak asteroid dengan posisi baru kurang dari 0.5
//         if (Vector2.Distance(transform.position, newPosition) < 0.5f)
//         {
//             // Jika sudah dekat, buat posisi baru
//             ChangePosition();
//         }

//         // Gerakkan asteroid menuju posisi baru
//         transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

//         // Beri rotasi pada asteroid
//         transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

//         // Cek apakah Player memiliki weapon dan aktifkan/ nonaktifkan asteroid sesuai kondisi
//         if (player != null && player.GetComponent<PlayerScript>().HasWeapon)
//         {
//             // Tampilkan asteroid dan aktifkan collidernya
//             GetComponent<SpriteRenderer>().enabled = true;
//             asteroidCollider.enabled = true;
//         }
//         else
//         {
//             // Sembunyikan asteroid dan matikan collidernya jika player tidak memiliki weapon
//             GetComponent<SpriteRenderer>().enabled = false;
//             asteroidCollider.enabled = false;
//         }
//     }

//     // Method untuk mengubah posisi baru asteroid secara random
//     void ChangePosition()
//     {
//         float randomX = Random.Range(-10f, 10f);
//         float randomY = Random.Range(-5f, 5f);
//         newPosition = new Vector2(randomX, randomY);
//     }

//     // Method untuk mendeteksi tabrakan asteroid dengan Player
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             // Jika asteroid menyentuh Player, load scene "Main" menggunakan LevelManager
//             LevelManager.Instance.LoadScene("Main");
//         }
//     }
// }
