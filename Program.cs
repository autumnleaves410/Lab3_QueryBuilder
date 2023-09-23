using System;
namespace Lab3QueryBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

internal class Program 
{
    static void Main(string[] args)
    {

        var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        var dbPath = root + $"{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}data.db";
        var filePath = root + Path.DirectorySeparatorChar + "AllPokemon.csv";
        var filePathBanned = root + Path.DirectorySeparatorChar + "BannedGames.csv";

        using (var q = new QueryBuilder(dbPath))
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            List<BannedGame> bannedGames = new List<BannedGame>();
            int pokeCounter = 0;
            int banCounter = 0;

            try
            {
                using(var streamReader = new StreamReader(filePath))
                {
                    streamReader.ReadLine();

                    while (!streamReader.EndOfStream)
                    {
                        string? line = streamReader.ReadLine();
                        string[] fields = line.Split(",");


                        Pokemon aPokemon = new Pokemon()
                        {
                            Id = pokeCounter,
                            DexNumber = Int32.Parse(fields[0].Trim()),
                            Name = fields[1].Trim(),
                            Form = fields[2].Trim(),
                            Type1 = fields[3].Trim(),
                            Type2 = fields[4].Trim(),
                            Total = Int32.Parse(fields[5].Trim()),
                            HP = Int32.Parse(fields[6].Trim()),
                            Attack = Int32.Parse(fields[7].Trim()),
                            Defense = Int32.Parse(fields[8].Trim()),
                            SpecialAttack = Int32.Parse(fields[9].Trim()),
                            SpecialDefense = Int32.Parse(fields[10].Trim()),
                            Speed = Int32.Parse(fields[11].Trim()),
                            Generation = Int32.Parse(fields[12].Trim())

                        };

                        pokemons.Add(aPokemon);
                        pokeCounter++;

                    }

                    
                }


                using (var streamReader = new StreamReader(filePathBanned))
                {

                    streamReader.ReadLine();

                    while (!streamReader.EndOfStream)
                    {
                        string? line = streamReader.ReadLine();
                        string[] fields = line.Split(",");

                        BannedGame aGame = new BannedGame()
                        {
                            Id = banCounter,
                            Title = fields[0].Trim(),
                            Series = fields[1].Trim(),
                            Country = fields[2].Trim(),
                            Details = fields[3].Trim()

                        };

                        bannedGames.Add(aGame);
                        banCounter++;
                    }

                }


            }

            catch (Exception e)
            {
                Console.WriteLine("There was an error.");
            }

            
            using (var builder = new QueryBuilder(dbPath))
            {

                try
                {
                    builder.DeleteAll<Pokemon>();
                    Console.WriteLine("All Pokemon successfully deleted!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured while deleting Pokemon: {ex.Message}");
                }


                try
                {
                    builder.DeleteAll<BannedGame>();
                    Console.WriteLine("All games successfully deleted!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured while deleting games: {ex.Message}");
                }


                foreach (Pokemon mon in pokemons)
                {
                    builder.Create(mon);
                    Console.WriteLine($"Pokemon {mon.Name} successfully added!");
                }

                foreach (BannedGame game in bannedGames)
                {
                    builder.Create(game);
                    Console.WriteLine($"Game {game.Title} successfully added!");
                }

                try
                {
                    Pokemon testPokemon = new Pokemon(0, 1, "Name", "Form", "Type1", "Type2", 0, 0, 0, 0, 0, 0, 0, 1);
                    builder.Create(testPokemon);
                    Console.WriteLine($"Pokemon successfully added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"There was an error adding your Pokemon to the list: {ex.Message}");
                }

                try
                {
                    BannedGame testBannedGame = new BannedGame(137, "Title", "Series", "Country", "Details");
                    builder.Create(testBannedGame);
                    Console.WriteLine($"Game successfully added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"There was an error adding your game to the list: {ex.Message}");
                }



            }


        }












        









        //Write a single object to the database


    }
}

