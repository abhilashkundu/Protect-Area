using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class turrentShooter : MonoBehaviour
{
    //Image image;

    private bool canShoot = true;
    private bool tankOn = false;
    //public int maxDef = 5;
    public GameObject bulletPrefab;

    [SerializeField] WavesController tankcont;
    private Transform currentTarget;

    static int clicked = 0;
    public int clickedTemp;
    public float shootingDelay = 5f;

    public Buttoncontroller butCont;
    void Start()
    {
        tankcont = GameObject.FindGameObjectWithTag("manager").GetComponent<WavesController>();
    }
    public void OnMouseDown()
    {
        clickedTemp = clicked;
        //if clicked it will increment 'TotalActiveTankNo' in the wavesController
        if (clicked <= tankcont.TotalActiveTankNo && butCont.enableTank && !tankOn)
        {
            clicked += 1; // to cheak for clicked tank
            
            //transparent switcher
            Color imgColor = GetComponent<SpriteRenderer>().color;
            imgColor.a = 255 / 255f;
            GetComponent<SpriteRenderer>().color = imgColor;

            print("tank active");

            tankOn = true;
        }

        if(butCont.disarmTank && tankOn)
        {
            clicked -= 1;

            Color imgColor = GetComponent<SpriteRenderer>().color;
            imgColor.a = 40 / 255f;
            GetComponent<SpriteRenderer>().color = imgColor;

            print("tank disarm");

            tankOn = false;
            butCont.disarmTank = false;
        }
    }

    private void Update()
    {
        if (tankOn && currentTarget != null)
        {
            // Rotate the turret towards the current target
            Vector3 directionToTarget = currentTarget.position - transform.position;
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy" && tankOn && canShoot)
        {
            print("Enemy Spotted");
            // Check if there's no current target or if the current target is destroyed
            if (currentTarget == null)
            {
                currentTarget = other.transform;
            }

            // Instantiate the bullet prefab at the turret's position
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Get the bullet's script component (assuming it has a script called "Bullet")
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            // Pass the enemy's position to the bullet's script
            bulletScript.SetTarget(other.transform.position);

            canShoot = false;

            Invoke("ResetShoot", shootingDelay);
        }
    }

    private void ResetShoot()
    {
        canShoot = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == currentTarget)
        {
            // If the current target exits the trigger area, set currentTarget to null
            currentTarget = null;
        }
    }
}