using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup2 : MonoBehaviour
{
    public float duration = 3f;
    public PowerupEffects2 powerupeffect;
    public static int numOfPowerups;
    public GameObject powerupIcon;
    [SerializeField] GameObject pickupeffect;

    private void Awake()
    {
        int powerId = powerupeffect.GetId();
        Debug.Log(powerId);
        switch (powerId)
        {
            case 0:
                powerupIcon = Game
            case 1:
                powerupIcon = GameObject.Find("SuperKickIcon");
        }
        
     }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        
        if (other.CompareTag("Player") && !other.GetComponent<PlayerMove>().hasPowerup)
        {
            numOfPowerups--;

            if (powerupeffect.GetId() == 0)
            {
                
                StartCoroutine(PickupSpeed(other.gameObject));
            }
            else if (powerupeffect.GetId() == 1)
            {
                StartCoroutine(PickupKick(other.gameObject));
            }
            else if (powerupeffect.GetId() == 2)
            {
                StartCoroutine(PickupSlow(other.gameObject));
            }
            else if (powerupeffect.GetId() == 3)
            {
                StartCoroutine(PickupStick(other.gameObject));
            }
            else if (powerupeffect.GetId() == 4)
            {
                StartCoroutine(PickupFreeze(other.gameObject));
            }
        }
        else if (other.CompareTag("AI-character") && !other.GetComponent<AIScript>().hasPowerup)
        {
            numOfPowerups--;

            if (powerupeffect.GetId() == 0)
            {
                StartCoroutine(PickupSpeed(other.gameObject));
            }
            else if (powerupeffect.GetId() == 1)
            {
                StartCoroutine(PickupKick(other.gameObject));
            }
            else if (powerupeffect.GetId() == 2)
            {
                StartCoroutine(PickupSlow(other.gameObject));
            }
            else if (powerupeffect.GetId() == 3)
            {
                StartCoroutine(PickupStick(other.gameObject));
            }
            else if (powerupeffect.GetId() == 4)
            {
                StartCoroutine(PickupFreeze(other.gameObject));
            }
        }
    }

    IEnumerator PickupSpeed(GameObject other)
    {
        DeactivatePowerup();
        
        powerupeffect.Apply(other);
        yield return new WaitForSeconds(duration);
        powerupeffect.remove(other);
     
        Destroy(gameObject);
    }

    IEnumerator PickupKick(GameObject other)
    {
        DeactivatePowerup();
        EnableIcon();
        powerupeffect.Apply(other);
        yield return new WaitUntil(MIsPressed);
        DisableIcon();
        powerupeffect.remove(other);
        Destroy(gameObject);

    }

    IEnumerator PickupSlow(GameObject other)
    {
        DeactivatePowerup();
        powerupeffect.Apply(other);
        yield return new WaitForSeconds(duration);
        powerupeffect.remove(other);
        Destroy(gameObject);

    }

    IEnumerator PickupStick(GameObject other)
    {
        DeactivatePowerup();
        powerupeffect.Apply(other);
        yield return new WaitUntil(other.GetComponent<stickScript2>().touchingBall);
        yield return new WaitForSeconds(duration);
        powerupeffect.remove(other);
        Destroy(gameObject);

    }

    IEnumerator PickupFreeze(GameObject other)
    {
        DeactivatePowerup();
        powerupeffect.Apply(other);
        yield return new WaitForSeconds(duration);
        Debug.Log("WeAreTesting");
        powerupeffect.remove(other);
        Destroy(gameObject);

    }

    public bool MIsPressed()
    {
        return Input.GetKeyDown(KeyCode.M);
    }
    public void DeactivatePowerup()
    {
        Instantiate(pickupeffect, transform.position, transform.rotation);
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void EnableIcon()
    {
        powerupIcon.GetComponent<Image>().enabled = true;
    }
    public void DisableIcon()
    {
        powerupIcon.GetComponent<Image>().enabled = false;
    }

}
