using System;

namespace ClashofClans.Utilities.Utils
{
    public class GameUtils
    {
        public static string GenerateToken
        {
            get
            {
                var random = new Random();
                var token = string.Empty;

                for (var i = 0; i < 40; i++)
                    token += "abcdefghijklmnopqrstuvwxyz0123456789"[random.Next(36)];

                return token;
            }
        }

        public static bool IsHigherRoleThan(int role, int roleToCompare)
        {
            var table = new[] {1, 1, 4, 2, 3};
            return role >= 5 || roleToCompare >= 5 || table[roleToCompare] < table[role];
        }

        public static long GetIDFromHashTag(string Tag)
        {
            long id = 0;
            try
            {
                char[] _TagArray = Tag.Replace("#", "").ToUpper().ToCharArray();
                long _ID = 0;
                for (int _Index = 0; _Index < _TagArray.Length; _Index++)
                {
                    int _I = "0289PYLQGRJCUV".IndexOf(_TagArray[_Index]);
                    _ID *= 14;
                    _ID += _I;
                }
                int High = (int)_ID % 256;
                int Low = (int)(_ID - High) >> 8;
                id = ((long)High << 32) | (Low & 0xFFFFFFFFL);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return id;
        }
    }
}