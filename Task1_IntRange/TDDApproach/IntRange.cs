﻿using System;

namespace Task1_IntRange.TDDApproach
{
    /// <summary>
    /// Base class for IntRanges
    /// </summary>
    public abstract class IntRange
    {
        public float Min { get; protected set; }
        public float Max { get; protected set; }

        protected int[] values;
        protected int intMin, intMax;
        protected BoundType boundType;

        public IntRange()
        {
            values = new int[0];
        }

        public IntRange(int left, int right)
        {
            boundType = BoundType.Int;
            InitBounds(left, right);
            intMin = (int)Min;
            intMax = (int)Max;
            InitRange();
        }

        public IntRange(float left, float right)
        {
            boundType = BoundType.Float;
            InitBounds(left, right);
            intMin = (int)Math.Ceiling(Min);
            intMax = (int)Math.Floor(Max);
            InitRange();
        }

        private void InitBounds(float left, float right)
        {
            if (left < right)
            {
                Min = left;
                Max = right;
            }
            else
            {
                Min = right;
                Max = left;
            }
        }
        protected abstract void InitRange();

        public bool IsEmpty()
        {
            return values.Length == 0;
        }

        public int Length()
        {
            return values.Length;
        }

        public bool Contains(int v) {
            return ContainsFloat(v);
        }

        protected bool ContainsInt(int v)
        {
            int index = v - intMin;
            return (index < 0 || index >= values.Length) ? false : true;
        }

        public abstract bool ContainsFloat(float v);
        

        public bool Intersects(IntRange ir2)
        {
            return (ContainsFloat(ir2.Min) || ContainsFloat(ir2.Max)) && (ir2.ContainsFloat(Min) || ir2.ContainsFloat(Max));
        }

        protected enum BoundType { Int, Float };
    }

}
