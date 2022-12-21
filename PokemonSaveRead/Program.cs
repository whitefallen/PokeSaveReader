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
                    var pokemonParty = new PokemonParty();
                    foreach (var pokemon in party)
                    {
                        var tempPoke = new Pokemon
                        {
                            SpeciesId = pokemon.Species,
                            Nickname = pokemon.Nickname,
                            Level = pokemon.CurrentLevel
                        };
                        pokemonParty.Party.Add(tempPoke);
                    }
                    var fileName = $"Party-{now}.json";
                    var jsonString = JsonConvert.SerializeObject(pokemonParty, Formatting.Indented);
                    Console.WriteLine(JsonConvert.SerializeObject(pokemonParty));
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