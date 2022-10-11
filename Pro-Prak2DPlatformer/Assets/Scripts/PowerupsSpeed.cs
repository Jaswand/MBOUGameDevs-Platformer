using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Speedbuff")]

public class PowerupsSpeed : PowerupEffects
{
    public float amount;
    public override void Apply (GameObject target)
    {
        target.GetComponent<PlayerMovement>().moveSpeed += amount;
    }
}
