﻿using System;

namespace FPLedit.Shared.Rendering
{
    public sealed class MColor
    {
        public byte R { get; }

        public byte G { get; }

        public byte B { get; }

        public MColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        
        public string Hex => ColorFormatter.ToString(this);

        public static bool operator ==(MColor? c1, MColor? c2) =>
            (ReferenceEquals(c1, null) && (ReferenceEquals(c2, null)) || (!ReferenceEquals(c1, null) && c1.Equals(c2)) || (!ReferenceEquals(c2, null) && c2.Equals(c1)));

        public static bool operator !=(MColor? c1, MColor? c2) => !(c1 == c2);

        public override bool Equals(object? obj)
            => obj is MColor c2 && this.R == c2.R && this.G == c2.G && this.B == c2.B;

        public override int GetHashCode() => R + (G << 8) + (B << 16);

        public static explicit operator MColor(Eto.Drawing.Color sc)
            => new MColor((byte)sc.Rb, (byte)sc.Gb, (byte)sc.Bb);

        public static explicit operator Eto.Drawing.Color(MColor m)
            => Eto.Drawing.Color.FromArgb(m.R, m.G, m.B);

        public static explicit operator System.Drawing.Color(MColor m)
        {
            if (ShouldSwitchColors)
                return System.Drawing.Color.FromArgb(255, m.B, m.G, m.R);
            return System.Drawing.Color.FromArgb(255, m.R, m.G, m.B);
        }

        public static MColor White => new MColor(255, 255, 255);

        public static bool ShouldSwitchColors => Eto.Platform.Instance.IsGtk;
    }
}
