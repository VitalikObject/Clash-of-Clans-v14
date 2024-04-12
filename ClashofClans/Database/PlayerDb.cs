using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClashofClans.Core;
using ClashofClans.Logic;
using ClashofClans.Logic.Home;
using ClashofClans.Logic.Sessions;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ClashofClans.Files.CsvUtils;

namespace ClashofClans.Database
{
    public class PlayerDb
    {
        private const string Name = "players";
        private static string _connectionString;
        private static long _playerSeed;

        public PlayerDb()
        {
            _connectionString = new MySqlConnectionStringBuilder
            {
                Server = Resources.Configuration.MySqlServer,
                Database = Resources.Configuration.MySqlDatabase,
                UserID = Resources.Configuration.MySqlUserId,
                Password = Resources.Configuration.MySqlPassword,
                SslMode = MySqlSslMode.None,
                MinimumPoolSize = 4,
                MaximumPoolSize = 20,
                CharacterSet = "utf8mb4"
            }.ToString();

            _playerSeed = MaxPlayerId();

            if (_playerSeed > -1) return;

            Logger.Log($"MysqlConnection for players failed [{Resources.Configuration.MySqlServer}]!", GetType());
            Program.Exit();
        }

        public static async Task ExecuteAsync(MySqlCommand cmd)
        {
            #region Execute

            try
            {
                cmd.Connection = new MySqlConnection(_connectionString);
                await cmd.Connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
            catch (MySqlException exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);
            }
            finally
            {
                cmd.Connection?.Close();
            }

            #endregion
        }

        public static long MaxPlayerId()
        {
            #region MaxId

            try
            {
                long seed;

                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var cmd = new MySqlCommand($"SELECT coalesce(MAX(Id), 0) FROM {Name}", connection))
                    {
                        seed = Convert.ToInt64(cmd.ExecuteScalar());
                    }

                    connection.Close();
                }

                return seed;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return -1;
            }

            #endregion
        }

        public static async Task<long> CountAsync()
        {
            #region Count

            try
            {
                long seed;

                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM {Name}", connection))
                    {
                        seed = Convert.ToInt64(await cmd.ExecuteScalarAsync());
                    }

                    await connection.CloseAsync();
                }

                return seed;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return 0;
            }

            #endregion
        }

        public static async Task<Player> CreateAsync()
        {
            #region Create

            try
            {
                var id = _playerSeed++;
                if (id <= -1)
                    return null;

                var player = new Player(id + 1);
                var home = player.Home;

                using (var cmd =
                    new MySqlCommand(
                        $"INSERT INTO {Name} (`Id`, `IsOnline`, `Trophies`, `PreviousSeasonMonth`, `PreviousSeasonTrophies`, `Language`, `FacebookId`, `Home`, `Objects`, `Sessions`) VALUES ({id + 1}, {home.Status}, {home.Trophies}, {home.PreviousSeasonMonth}, {home.PreviousSeasonTrophies}, @language, @fb, @home, @objects, @sessions)")
                )
                {
#pragma warning disable 618
                    cmd.Parameters?.AddWithValue("@language", home.PreferredDeviceLanguage);
                    cmd.Parameters?.AddWithValue("@fb", home.FacebookId);
                    cmd.Parameters?.AddWithValue("@home",
                        JsonConvert.SerializeObject(home, Configuration.JsonSettings));
                    cmd.Parameters?.AddWithValue("@objects", home.GameObjectManager.Save());
                    cmd.Parameters?.AddWithValue("@sessions",
                        JsonConvert.SerializeObject(home.Sessions, Configuration.JsonSettings));
#pragma warning restore 618

                    await ExecuteAsync(cmd);
                }

                return player;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return null;
            }

            #endregion
        }

        public static async Task<Player> GetAsync(long id)
        {
            #region Get

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    Player player = null;

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} WHERE Id = '{id}'", connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            player = new Player
                            {
                                Home = JsonConvert.DeserializeObject<Home>((string) reader["Home"],
                                    Configuration.JsonSettings)
                            };

                            player.Home.Sessions = JsonConvert.DeserializeObject<List<Session>>(
                                                       (string) reader["Sessions"],
                                                       Configuration.JsonSettings) ?? new List<Session>(50);

                            player.Home.GameObjectManager.LoadJson((string) reader["Objects"]);
                            break;
                        }
                    }

                    await connection.CloseAsync();

                    return player;
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return null;
            }

            #endregion
        }

        public static async Task SaveAsync(Player player)
        {
            #region Save

            try
            {
                var home = player.Home;

                using (var cmd =
                    new MySqlCommand(
                        $"UPDATE {Name} SET `IsOnline`='{home.Status}', `Trophies`='{home.Trophies}', `PreviousSeasonMonth`='{home.PreviousSeasonMonth}', `PreviousSeasonTrophies`='{home.PreviousSeasonTrophies}', `Language`=@language, `FacebookId`=@fb, `Home`=@home, `Objects`=@objects, `Sessions`=@sessions WHERE Id = '{home.Id}'")
                )
                {
#pragma warning disable 618
                    cmd.Parameters?.AddWithValue("@language", home.PreferredDeviceLanguage);
                    cmd.Parameters?.AddWithValue("@fb", home.FacebookId);
                    cmd.Parameters?.AddWithValue("@home",
                        JsonConvert.SerializeObject(home, Configuration.JsonSettings));
                    cmd.Parameters?.AddWithValue("@objects", home.GameObjectManager.Save());
                    cmd.Parameters?.AddWithValue("@sessions",
                        JsonConvert.SerializeObject(home.Sessions, Configuration.JsonSettings));
#pragma warning restore 618

                    await ExecuteAsync(cmd);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);
            }

            #endregion
        }

        public static async Task DeleteAsync(long id)
        {
            #region Delete

            try
            {
                using (var cmd = new MySqlCommand(
                    $"DELETE FROM {Name} WHERE Id = '{id}'")
                )
                {
                    await ExecuteAsync(cmd);

                    /*if (Redis.IsConnected)
                        await Redis.UncachePlayerAsync(id);*/
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);
            }

            #endregion
        }

        public static async Task<List<Player>> GetGlobalPlayerRankingAsync()
        {
            #region GetGlobal

            var list = new List<Player>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} ORDER BY `Trophies` DESC LIMIT 200",
                        connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();
                        Player player = null;
                        while (await reader.ReadAsync())
                            list.Add(player = new Player
                            {
                                Home = JsonConvert.DeserializeObject<Home>((string)reader["Home"],
                                    Configuration.JsonSettings)
                            });
                    }

                    await connection.CloseAsync();
                }

                return list;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return list;
            }

            #endregion
        }

        public static async Task<List<Player>> GetLeagueMemberListAsync(int league)
        {
            #region LeagueMember

            var list = new List<Player>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} WHERE `Trophies` BETWEEN {LeagueUtils.GetPlacementLimitLow(league)} AND {LeagueUtils.GetPlacementLimitHigh(league)} ORDER BY `Trophies` DESC LIMIT 200",
                        connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();
                        Player player = null;
                        while (await reader.ReadAsync())
                            list.Add(player = new Player
                            {
                                Home = JsonConvert.DeserializeObject<Home>((string)reader["Home"],
                                    Configuration.JsonSettings)
                            });
                    }

                    await connection.CloseAsync();
                }

                return list;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return list;
            }

            #endregion
        }

        public static async Task<List<Player>> GetPreviousSeasonGlobalPlayerRankingAsync()
        {
            #region GetPreviousGlobal

            var list = new List<Player>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} WHERE `PreviousSeasonMonth` <=> {DateTime.Now.Month - 1} ORDER BY `PreviousSeasonTrophies` DESC LIMIT 200",
                        connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();
                        Player player = null;
                        while (await reader.ReadAsync())
                            list.Add(player = new Player
                            {
                                Home = JsonConvert.DeserializeObject<Home>((string)reader["Home"],
                                    Configuration.JsonSettings)
                            });
                    }

                    await connection.CloseAsync();
                }

                return list;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return list;
            }

            #endregion
        }

        public static async Task<List<Player>> GetLocalPlayerRankingAsync(string language)
        {
            #region GetLocal

            var list = new List<Player>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd =
                        new MySqlCommand(
                            $"SELECT * FROM {Name} WHERE Language = '{language}' ORDER BY `Trophies` DESC LIMIT 200",
                            connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();

                        Player player = null;
                        while (await reader.ReadAsync())
                            list.Add(player = new Player
                            {
                                Home = JsonConvert.DeserializeObject<Home>((string)reader["Home"],
                                    Configuration.JsonSettings)
                            });
                    }

                    await connection.CloseAsync();
                }

                return list;
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return list;
            }

            #endregion
        }

        public static async Task<Player> GetRandomCachedPlayer(Player player)
        {
            #region GetRandom

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    Player enemy = null;

                    int minTrophies;
                    int maxTrophies;

                    if (player.Home.Trophies >= 5000)
                    {
                        minTrophies = LeagueUtils.GetPlacementLimitLow(player.Home.League);
                        maxTrophies = LeagueUtils.GetPlacementLimitHigh(player.Home.League);
                    }
                    else
                    {
                        minTrophies = player.Home.Trophies > 600 ? player.Home.Trophies - 600 : 0;
                        maxTrophies = player.Home.Trophies + 600;
                    }

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} WHERE Id != '{player.Home.Id}' AND IsOnline = '0' AND Trophies BETWEEN '{minTrophies}' AND '{maxTrophies}' ORDER BY RAND() LIMIT 1", connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            enemy = new Player
                            {
                                Home = JsonConvert.DeserializeObject<Home>((string)reader["Home"],
                                    Configuration.JsonSettings)
                            };

                            enemy.Home.Sessions = JsonConvert.DeserializeObject<List<Session>>(
                                                       (string)reader["Sessions"],
                                                       Configuration.JsonSettings) ?? new List<Session>(50);

                            enemy.Home.GameObjectManager.LoadJson((string)reader["Objects"]);
                            break;
                        }
                    }

                    await connection.CloseAsync();

                    return enemy;
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception, null, Logger.ErrorLevel.Error);

                return null;
            }

            #endregion
        }
    }
}