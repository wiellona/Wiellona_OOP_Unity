using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // Weapon yang akan diberikan ke player
    private Weapon weapon; // Weapon yang menjadi bagian dari pickup

    void Awake()
    {
        // Buat instance baru dari weaponHolder untuk digunakan sebagai weapon pickup
        weapon = Instantiate(weaponHolder);
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false); // Sembunyikan visual weapon pada awalnya
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Objek Player Memasuki trigger");

            // Cari apakah ada weapon yang sudah terpasang pada player
            Weapon currentWeapon = collision.gameObject.GetComponentInChildren<Weapon>();

            // Jika ada, nonaktifkan tampilan weapon lama (tanpa menghancurkannya)
            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            // Lampirkan weapon baru pada player
            weapon.transform.SetParent(collision.transform);
            weapon.transform.localPosition = Vector3.zero;

            // Aktifkan tampilan weapon baru
            TurnVisual(true);
        }
        else
        {
            Debug.Log("Bukan Objek Player yang memasuki Trigger");
        }
    }

    // Metode untuk menyalakan atau mematikan visual
    public void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }
}