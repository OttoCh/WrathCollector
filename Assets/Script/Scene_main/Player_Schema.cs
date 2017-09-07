using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Schema: MonoBehaviour {

    public int health_point;
    public int mana_point;
    public int wrath_point;
    public Animator animator;
    public SpriteRenderer sp;

    public Player_Schema()
    {
        this.health_point = 100;
        this.mana_point = 100;
        this.wrath_point = 100;
    }

    public Player_Schema(int health_point, int mana_point, int wrath_point)
    {
        this.health_point = health_point;
        this.mana_point = mana_point;
        this.wrath_point = wrath_point;
    }

    public Player_Schema(int health_point, int mana_point, int wrath_point, Animator animator, SpriteRenderer sp)
    {
        this.health_point = health_point;
        this.mana_point = mana_point;
        this.wrath_point = wrath_point;
        this.animator = animator;
        this.sp = sp;
    }

}
