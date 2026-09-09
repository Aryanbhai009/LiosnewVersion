using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public float damage = 35f;
    public float fireRate = 0.1f;
    public float range = 100f;
    public int maxAmmo = 30;
    public int currentAmmo;

    public Transform cameraTransform;
    public float recoilX = -2f;
    public float recoilY = 1f;

    public Camera fpsCam;
    private bool readyToShoot = true;

    void Start() => currentAmmo = maxAmmo;

    void Update()
    {
        if (Input.GetButton("Fire1") && readyToShoot && currentAmmo > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;
        currentAmmo--;
        ApplyRecoil();

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            PlayerStats enemy = hit.transform.GetComponent<PlayerStats>();
            if (enemy != null) enemy.TakeDamage(damage);
        }

        Invoke(nameof(ResetShot), fireRate);
    }

    void ResetShot() => readyToShoot = true;

    void ApplyRecoil()
    {
        if (cameraTransform != null)
            cameraTransform.localRotation *= Quaternion.Euler(recoilX, Random.Range(-recoilY, recoilY), 0);
    }
}
