using System;

namespace UntitledBattleGame
{
    public static class Rando
    {
        private static Random _randomGenerator;

        public static Random generator
        {
            get => _randomGenerator;
            set => _randomGenerator = value;
        }

        static Rando()
        {
            _randomGenerator = new Random(Guid.NewGuid().GetHashCode());
        }

        public static void SetSeed(int seed) => new Random(seed);

        public static long Long(long min = -9223372036854775808, long max = 9223372036854775807)
        {
            byte[] buffer = new byte[8];
            _randomGenerator.NextBytes(buffer);
            return Math.Abs(BitConverter.ToInt64(buffer, 0) % (max - min)) + min;
        }

        public static double Double() => _randomGenerator.NextDouble();

        public static float Float(float max) => (float)_randomGenerator.NextDouble() * max;

        public static float Float(float min, float max) => min + (float)_randomGenerator.NextDouble() * (max - min);

        /*public static Vec2 Vec2(float minX, float maxX, float minY, float maxY) => new Vec2(Float(minX, maxX), Float(minY, maxY));

        public static Vec2 Vec2(Vec2 spanX, Vec2 spanY) => new Vec2(Float(spanX.x, spanX.y), Float(spanY.x, spanY.y));*/

        public static int Int(int _max) => _randomGenerator.Next(0, _max + 1);

        public static int Int(int min, int max) => _randomGenerator.Next(min, max + 1);

        public static T Choose<T>(params T[] _values) => _values[Int(_values.Length - 1)];

        public static uint UInt()
        {
            byte[] buffer = new byte[4];
            _randomGenerator.NextBytes(buffer);
            uint num = BitConverter.ToUInt32(buffer, 0);
            if (num == 0U)
                num = 1U;
            return num;
        }
    }
}
