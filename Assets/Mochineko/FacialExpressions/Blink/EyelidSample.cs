#nullable enable
using System;
using System.Runtime.InteropServices;

namespace Mochineko.FacialExpressions.Blink
{
    /// <summary>
    /// A sample of eyelid morphing.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct EyelidSample : IEquatable<EyelidSample>
    {
        /// <summary>
        /// Target eyelid.
        /// </summary>
        public readonly Eyelid eyelid;
        /// <summary>
        /// Weight of morphing.
        /// </summary>
        public readonly float weight;

        public EyelidSample(Eyelid eyelid, float weight)
        {
            if (weight is < 0f or > 1f)
            {
                throw new ArgumentOutOfRangeException(nameof(weight));
            }

            this.eyelid = eyelid;
            this.weight = weight;
        }

        public bool Equals(EyelidSample other)
        {
            return eyelid == other.eyelid
                   && weight.Equals(other.weight);
        }

        public override bool Equals(object? obj)
        {
            return obj is EyelidSample other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)eyelid, weight);
        }
    }
}
