using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonList : MonoBehaviour
{
    List<Pokemon> pokemons = new List<Pokemon>();
    Text nameText = null;
    Text typesText = null;
    Text descText = null;
    Text numText = null;
    int activePokemon = 0;
    GameObject MessagePrefab;
    List<GameObject> MessageObjects = new List<GameObject>();

    public PokemonList(GameObject MessagePrefab)
    {
        nameText = GameObject.Find("Desc").transform.GetChild(0).GetChild(0).GetComponent<Text>();
        typesText = GameObject.Find("Desc").transform.GetChild(0).GetChild(1).GetComponent<Text>();
        descText = GameObject.Find("Desc").transform.GetChild(0).GetChild(2).GetComponent<Text>();
        numText = GameObject.Find("Desc").transform.GetChild(0).GetChild(3).GetComponent<Text>();
        this.MessagePrefab = MessagePrefab;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
        AddMessage(pokemon.getOb());
        
        if (pokemons.Count == 1)
        {
            setActive(activePokemon);
        } else
        {
            pokemon.TurnOffOn(false);
        }
    }

    public void AddMessage(GameObject pokemon)
    {
        GameObject gameObject = Instantiate(MessagePrefab);
        gameObject.transform.SetParent(GameObject.Find("ChatPanel").transform, false);
        gameObject.GetComponentInChildren<Text>().text = pokemon.name;
        MessageObjects.Add(gameObject);
    }

    public void setNextActive()
    {
        int pokemon = activePokemon;
        if (activePokemon + 1 < pokemons.Count)
        {
            pokemon += 1;
        }
        else
        {
            pokemon = 0;
        }
        setActive(pokemon);
    }

    public void setPreviousActive()
    {
        int pokemon = activePokemon;
        if (activePokemon - 1 >= 0)
        {
            pokemon -= 1;
        }
        else
        {
            pokemon = pokemons.Count-1;
        }
        setActive(pokemon);
    }

    public void setActive(int pokemon)
    {
        pokemons[activePokemon].TurnOffOn(false);
        MessageObjects[activePokemon].transform.GetComponentInChildren<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        this.activePokemon = pokemon;

        MessageObjects[activePokemon].transform.GetComponentInChildren<Image>().color = new Color(0.7f, 0.1f, 0.1f, 1f);
        nameText.text = pokemons[activePokemon].getName();
        typesText.text = "Type: " + pokemons[activePokemon].getTypes();
        numText.text = "#" + pokemons[activePokemon].getNumber();
        descText.text = pokemons[activePokemon].getDesc();
        pokemons[activePokemon].TurnOffOn(true);
    }
}
