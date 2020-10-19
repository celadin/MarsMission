using System;

namespace MarsMission.Core
{
    public class Plateau
    {
        private int _weight;
        private int _height;

        public int Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Weight");

                _weight = value;
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Height");

                _height = value;
            }
        }
    }
}