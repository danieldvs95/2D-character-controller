using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform horizontalFirePoint;

    public Transform verticalFirePoint;

    public GameObject bulletPrefab;

    public PlayerMovement player;
	
	void Update () {
        if (!player.IsJumping() && Input.GetButtonDown("Shoot"))
        {
            if (player.IsAimingUp())
            {
                Shoot(verticalFirePoint);
            } else if (player.IsAiming())
            {
                Shoot(horizontalFirePoint);
            }
        }
	}

    void Shoot (Transform firePoint)
    {
        GameObject instance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        instance.GetComponent<Bullet>().SetDirection(firePoint == horizontalFirePoint);

    }
}
