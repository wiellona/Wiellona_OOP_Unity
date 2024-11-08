// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class LevelManager : MonoBehaviour
// {
//     [SerializeField] private Animator Animation; // Animator untuk transisi
//     private static readonly int StartTrigger = Animator.StringToHash("Start"); // Trigger untuk mulai transisi

//     void Awake()
//     {
//         // Pastikan Animator dinonaktifkan di awal
//         if (Animation != null)
//         {
//             Animation.enabled = false;
//         }
//     }

//     // Coroutine untuk memuat scene baru secara asynchronous
//     IEnumerator LoadSceneAsync(string sceneName)
//     {
//         // Aktifkan Animator dan jalankan transisi
//         if (Animation != null)
//         {
//             Animation.enabled = true;
//             Animation.SetTrigger(StartTrigger); // Mulai transisi animasi
//         }

//         // Tunggu selama durasi animasi transisi (misalnya 1 detik)
//         yield return new WaitForSeconds(1);

//         // Load scene baru secara asynchronous
//         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

//         // Tunggu hingga scene baru selesai dimuat
//         while (!asyncLoad.isDone)
//         {
//             yield return null;
//         }

//         // Setelah scene selesai dimuat, posisikan ulang Player
//         if (Player.Instance != null)
//         {
//             Player.Instance.transform.position = new Vector3(0, -4.5f, 0);
//         }
//         else
//         {
//             Debug.LogWarning("Player instance not found!");
//         }

//         // Nonaktifkan Animator setelah transisi selesai
//         if (Animation != null)
//         {
//             Animation.enabled = false;
//         }
//     }

//     // Method untuk memulai proses loading scene
//     public void LoadScene(string sceneName)
//     {
//         StartCoroutine(LoadSceneAsync(sceneName));
//     }
// }
