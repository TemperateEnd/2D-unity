using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    public Slider ammoSlider;
    public Text ammoText;
    public GameObject playerGun;
    Image playerGunSprite;

    public static int currAmmo;
    public static int maxAmmo;
    public static int ammoMags;

    public GameObject bullet;

    public Weapon equippedWeapon;

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
        playerGunSprite = playerGun.GetComponent<Sprite>();
        playerGunSprite = equippedWeapon.weaponSprite;

        ammoSlider.maxValue = maxAmmo;
        ammoSlider.value = currAmmo;

        ammoText.text = currAmmo + " / " + ammoMags;



        if (Input.GetMouseButtonDown(0))
        {
            currAmmo--;

            //Instantiate(bullet, new Vector3(0, 0, (bullet.transform.Translate.forward * Time.deltaTime)), 0);
        }
        

        if(currAmmo == 0)
        {
            Reload();
        }

        if(Input.GetKeyDown(KeyCode.R) && ammoMags > 0 && currAmmo < maxAmmo|| currAmmo == 0 && ammoMags > 0)
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
