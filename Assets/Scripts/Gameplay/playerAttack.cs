using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    public Slider ammoSlider;
    public Text ammoText;

    public static int currAmmo;
    public static int maxAmmo;
    public static int ammoMags;

    public GameObject bullet;

    private Vector3 mousePosition;
    private Vector3 diff;
    private float rotZ;

    public Weapon equippedWeapon;

    public GameObject playerWeapon;

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = equippedWeapon.ammoPerMag;
        currAmmo = maxAmmo;
        ammoMags = 10;
    }

    // Update is called once per frame
    void Update()
    {
        ammoSlider.maxValue = maxAmmo;
        ammoSlider.value = currAmmo;

        ammoText.text = currAmmo + " / " + ammoMags;

        playerWeapon.GetComponent<SpriteRenderer>();
        playerWeapon.GetComponent<SpriteRenderer>().sprite = equippedWeapon.weaponSprite;

        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diff.Normalize();

        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);



        if (Input.GetMouseButtonDown(0))
        {
            currAmmo--;

            GameObject instantiatedBullet = Instantiate(bullet, playerWeapon.transform.position, transform.rotation);

            instantiatedBullet.GetComponent<Rigidbody>();
            instantiatedBullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector2(0, 10));

            Destroy(instantiatedBullet, 1.5f);
        }

        if (currAmmo == 0 && ammoMags > 0)
        {
            Reload();
        }

        else if(Input.GetKeyDown(KeyCode.R) && ammoMags > 0 && currAmmo < maxAmmo)
        {
            Reload();
        }

        void Reload()
        {
            currAmmo = maxAmmo;
            ammoMags--;
        }
    }
}
