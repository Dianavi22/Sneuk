using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public void AddSpeed(int speedGiven, float speedDuration) 
    { 
        PlayerMovement.instance.moveSpeed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }

    private IEnumerator RemoveSpeed(int speedGivenn, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.moveSpeed -= speedGivenn;

    }

}
