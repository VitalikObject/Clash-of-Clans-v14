using System;
using System.Diagnostics;
using ClashofClans.Database.Cache;
using ClashofClans.Logic;
using ClashofClans.Logic.Clan;
using ClashofClans.Logic.Home;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging.Abstractions;

namespace ClashofClans.Database
{
    public class ObjectCache
    {
        private readonly TimeSpan _expirationTimeSpan;
        private readonly MemoryCache _objectCache;
        private readonly MemoryCache _playerCache;
        private readonly MemoryCache _allianceCache;

        public ObjectCache()
        {
            var options = new MemoryCacheOptions
            {
                ExpirationScanFrequency = TimeSpan.FromMinutes(5)
            };

            _expirationTimeSpan = TimeSpan.FromHours(2);

            _objectCache = new MemoryCache(options, new NullLoggerFactory());
            _playerCache = new MemoryCache(options, new NullLoggerFactory());
            _allianceCache = new MemoryCache(options, new NullLoggerFactory());

            Logger.Log("Successfully loaded caches", null);
        }

        /// <summary>
        ///     Cache a player to access it from memory
        /// </summary>
        /// <param name="player"></param>
        public void CachePlayer(Player player)
        {
            try
            {
                var home = player.Home;
                var json = home.GameObjectManager.Save();

                var playerEntry = _playerCache.CreateEntry(home.Id);
                playerEntry.Value = home;
                _playerCache.Set(home.Id, playerEntry, _expirationTimeSpan);

                var objectEntry = _objectCache.CreateEntry(home.Id);
                objectEntry.Value = json;
                _objectCache.Set(home.Id, objectEntry, _expirationTimeSpan);
            }
            catch (Exception)
            {
                Logger.Log("Failed to cache player.", GetType(), Logger.ErrorLevel.Error);
            }
        }

        /// <summary>
        ///     Cache a clan to access it from memory
        /// </summary>
        /// <param name="alliance"></param>
        public void CacheAlliance(Alliance alliance)
        {
            try
            {
                var allianceEntry = _allianceCache.CreateEntry(alliance.Id);
                allianceEntry.Value = alliance;
                _allianceCache.Set(alliance.Id, allianceEntry, _expirationTimeSpan);
            }
            catch (Exception)
            {
                Logger.Log("Failed to cache alliance.", GetType(), Logger.ErrorLevel.Error);
            }
        }

        public Player GetCachedPlayer(long id)
        {
            try
            {
                var st = new Stopwatch();
                st.Start();

                if (_playerCache.Get(id) is ICacheEntry playerEntry)
                    if (_objectCache.Get(id) is ICacheEntry objectEntry)
                        if (playerEntry.Value is Home home)
                            if (objectEntry.Value is string json)
                            {
                                home.Time.SubTick = 0;
                                home.GameObjectManager.LoadJson(json);

                                st.Stop();
                                Logger.Log($"Successfully got player {id} from cache in {st.ElapsedMilliseconds}ms",
                                    null,
                                    Logger.ErrorLevel.Debug);

                                return new Player
                                {
                                    Home = home
                                };
                            }
            }
            catch (Exception)
            {
                Logger.Log("Failed to fetch player from cache.", GetType(), Logger.ErrorLevel.Error);
            }

            return null;
        }

        public Alliance GetCachedAlliance(long id)
        {
            try
            {
                var st = new Stopwatch();
                st.Start();

                if (_allianceCache.Get(id) is ICacheEntry allianceEntry)
                {
                    if (allianceEntry.Value is Alliance alliance)
                    {
                        st.Stop();
                        Logger.Log($"Successfully got alliance {id} from cache in {st.ElapsedMilliseconds}ms", null,
                            Logger.ErrorLevel.Debug);

                        return alliance;
                    }
                }
            }
            catch (Exception)
            {
                Logger.Log("Failed to fetch alliance from cache.", GetType(), Logger.ErrorLevel.Error);
            }

            return null;
        }
        public void UncacheAlliance(long id)
        {
            _allianceCache.Remove(id);
        }
        public long CachedPlayers()
        {
            return _playerCache.Count;
        }
        public long CachedAlliances()
        {
            return _allianceCache.Count;
        }
    }
}