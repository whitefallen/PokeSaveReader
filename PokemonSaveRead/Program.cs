using System;
using System.IO;
using Newtonsoft.Json;
using PKHeX.Core;

namespace PokemonSaveRead
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (args.Length != 0)
            {
                var path = args[0];
                var sav = SaveUtil.GetVariantSAV(path);
                if (sav != null)
                {
                    var party = sav.PartyData;
                    var pokemonSaveData = new PokemonSaveData();
                    pokemonSaveData.TrainerName = sav.OT;
                    pokemonSaveData.PlayedTime = sav.PlayTimeString;
                    Console.WriteLine();
                    //pokemonSaveData.CurrentBadges = ;
                    foreach (var pokemon in party)
                    {
                        var tempPoke = new Pokemon
                        {
                            SpeciesId = pokemon.Species,
                            Nickname = pokemon.Nickname,
                            Level = pokemon.CurrentLevel
                        };
                        pokemonSaveData.Party.Add(tempPoke);
                    }
                    var fileName = $"Party-{now}.json";
                    var jsonString = JsonConvert.SerializeObject(pokemonSaveData, Formatting.Indented);
                    Console.WriteLine(JsonConvert.SerializeObject(pokemonSaveData));
                    File.WriteAllText(fileName, jsonString);
                }
                else
                {
                    Console.WriteLine("No Save Found");
                }
            }
            else
            {
                Console.WriteLine("No Save specified");
            }
        }
    }
}