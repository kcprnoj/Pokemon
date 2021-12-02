using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon
{
    GameObject ob;
    int weight;
    int attack;
    int defense;
    int hp;
    int specialAttack;
    int specialDefense;
    int speed;
    string types;
    string desc;
    int number;

    public Pokemon(GameObject ob, int number, int weight, int attack, int defense, int hp,
        int specialAttack, int specialDefense, int speed, string types, string desc)
    {
        this.ob = ob;
        this.weight = weight;
        this.attack = attack;
        this.defense = defense;
        this.hp = hp;
        this.specialAttack = specialAttack;
        this.specialDefense = specialDefense;
        this.speed = speed;
        this.types = types;
        this.desc = desc;
        this.number = number;
    }

    public void TurnOffOn(bool on)
    {
        ob.SetActive(on);
        if (on)
        {
            updateProgress();
        }
    }

    public GameObject getOb()
    {
        return ob;
    }

    public void updateProgress()
    {
        Slider health = GameObject.Find("Health").GetComponentInChildren<Slider>();
        Slider defense = GameObject.Find("Defense").GetComponentInChildren<Slider>();
        Slider attack = GameObject.Find("Attack").GetComponentInChildren<Slider>();
        Slider spAttack = GameObject.Find("SpecialAttack").GetComponentInChildren<Slider>();
        Slider spDefense = GameObject.Find("SpecialDefense").GetComponentInChildren<Slider>();
        Slider speed = GameObject.Find("Speed").GetComponentInChildren<Slider>();

        attack.GetComponentInChildren<Text>().text = "" + this.attack;
        health.GetComponentInChildren<Text>().text = "" + this.hp;
        defense.GetComponentInChildren<Text>().text = "" + this.defense;
        speed.GetComponentInChildren<Text>().text = "" + this.speed;
        spAttack.GetComponentInChildren<Text>().text = "" + this.specialAttack;
        spDefense.GetComponentInChildren<Text>().text = "" + this.specialDefense;

        health.value = this.hp;
        defense.value = this.defense;
        attack.value = this.attack;
        speed.value = this.speed;
        spDefense.value = this.specialDefense;
        spAttack.value = this.specialAttack;
    }

    public string getName()
    {
        string text = ob.name;
        return text;
    }

    public string getTypes()
    {
        return types;
    }

    public string getDesc()
    {
        return desc;
    }

    public int getNumber()
    {
        return number;
    }
}
