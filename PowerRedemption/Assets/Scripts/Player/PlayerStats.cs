using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Entity
{

    [Header("Dependencies")]
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(this.maxLife);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(this.life);
    }
}
