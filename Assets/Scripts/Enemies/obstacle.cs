using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {
    
    void PlayerSideCollision()
    {
        FindObjectOfType<Player>().giveDamage(1);
    }
}
