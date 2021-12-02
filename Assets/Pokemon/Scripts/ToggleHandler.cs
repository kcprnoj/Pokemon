using Newtonsoft.Json.Linq;
using System;
using System.IO;
using UnityEngine;

public class ToggleHandler : MonoBehaviour
{
    PokemonList pokemonList;
    GameObject pokemon;
    public GameObject MessagePrefab;

    void Start()
    {
        pokemonList = new PokemonList(MessagePrefab);
        pokemon = GameObject.Find("Pokemon");
        var jsonPokedex = Resources.Load<TextAsset>("pokedex_raw_array");
        JArray pokedexData = JArray.Parse(jsonPokedex.text);

        for (int i = 0; i < pokemon.transform.childCount; i++)
        {
            GameObject go = pokemon.transform.GetChild(i).gameObject;
            JObject data = findPokemon(pokedexData, go.name);
            if (data != null)
            {
                int health = Int32.Parse(data["stats"][0]["base_stat"].ToString());
                int attack = Int32.Parse(data["stats"][1]["base_stat"].ToString());
                int defense = Int32.Parse(data["stats"][2]["base_stat"].ToString());
                int specialAttack = Int32.Parse(data["stats"][3]["base_stat"].ToString());
                int specialDefense = Int32.Parse(data["stats"][4]["base_stat"].ToString());
                int speed = Int32.Parse(data["stats"][5]["base_stat"].ToString());
                string desc = data["description"].ToString();
                int number = Int32.Parse(data["id"].ToString());
                int weight = Int32.Parse(data["weight"].ToString());
                string types = "";
                JArray typesArray = JArray.Parse(data["types"].ToString());
                
                for (int j = 0; j < typesArray.Count; j++)
                {
                    types += typesArray[j]["name"];
                    if (j + 1 < typesArray.Count)
                        types += ", ";
                }

                pokemonList.AddPokemon(new Pokemon(go, number, weight, attack, defense, health,
                    specialAttack, specialDefense, speed, types, desc));
            }
            else
            {
                go.SetActive(false);
            }
        }

        pokemonList.setPreviousActive();
        pokemonList.setNextActive();
        pokemonList.setNextActive();
        pokemonList.setNextActive();
        pokemonList.setNextActive();
    }

    public void NextPokemonHandler()
    {
        pokemonList.setNextActive();
    }

    public void PreviousPokemonHandler()
    {
        pokemonList.setPreviousActive();
    }

    public void MakeBiggerHandler()
    {
        pokemon.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
    }

    private JObject findPokemon(JArray pokedex, string name)
    {
        for (int i = 0; i < pokedex.Count; i++)
        {
            JObject pokemon = JObject.Parse(pokedex[i].ToString());
            if (pokemon["name"].ToString().Equals(name.ToLower()))
            {
                return pokemon;
            }
        }
        return null;
    }

    public void MakeLesserHandler()
    {
        if (pokemon.transform.localScale.x - 0.01 > 0 &&
            pokemon.transform.localScale.y - 0.01 > 0 &&
            pokemon.transform.localScale.z - 0.01 > 0)
            pokemon.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
    }
}
