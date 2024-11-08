// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     // Singleton instance untuk GameManager
//     public static GameManager Instance { get; private set; }

//     // Referensi ke LevelManager
//     public LevelManager LevelManager { get; private set; }

//     // Referensi ke Player
//     private GameObject player;

//     void Awake()
//     {
//         // Cek jika sudah ada instance GameManager yang lain, hapus yang baru
//         if (Instance != null && Instance != this)
//         {
//             Destroy(this.gameObject);
//             return;
//         }

//         // Set instance ke GameManager ini
//         Instance = this;

//         // Cari komponen LevelManager di dalam anak-anak GameManager
//         LevelManager = GetComponentInChildren<LevelManager>();

//         // Jangan hancurkan GameObject ini dan Camera saat berpindah scene
//         DontDestroyOnLoad(gameObject);
//         DontDestroyOnLoad(GameObject.Find("Camera"));

//         // Temukan Player dan pastikan tidak dihancurkan
//         player = GameObject.FindWithTag("Player");
//         if (player != null)
//         {
//             DontDestroyOnLoad(player);
//         }
//     }

//     void Start()
//     {
//         // Hapus semua objek kecuali Camera dan Player
//         DestroyAllExcept(new string[] { "MainCamera", "Player" });
//     }

//     private void DestroyAllExcept(string[] tagsToKeep)
//     {
//         // Temukan semua game object di scene
//         GameObject[] allObjects = FindObjectsOfType<GameObject>();

//         // Loop untuk setiap objek
//         foreach (GameObject obj in allObjects)
//         {
//             // Jika objek tidak ada di daftar yang ingin dipertahankan, hapus objek tersebut
//             bool shouldDestroy = true;
//             foreach (string tag in tagsToKeep)
//             {
//                 if (obj.CompareTag(tag))
//                 {
//                     shouldDestroy = false;
//                     break;
//                 }
//             }

//             if (shouldDestroy)
//             {
//                 Destroy(obj);
//             }
//         }
//     }
// }
