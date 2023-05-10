using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class MPSpeedBuff : PowerupEffects2
{
    public float amount = 1000;
    public int id = 0;
    public override void Apply(GameObject target)
    {
        if(target.CompareTag("Player"))
        {
            target.GetComponent<NetworkMultiplayer>().hasPowerup.Value = true;
            target.GetComponent<NetworkMultiplayer>().playerSpeed += amount;
        }       
    }

    public override void remove(GameObject target)
    {
       if(target.CompareTag("Player"))
       {
            target.GetComponent<NetworkMultiplayer>().hasPowerup.Value = false;
            target.GetComponent<NetworkMultiplayer>().playerSpeed -= amount;
       }
    }

    public override int GetId()
    {
        return id;
    }
}
