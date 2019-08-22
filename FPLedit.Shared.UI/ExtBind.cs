﻿using Eto.Forms;
using FPLedit.Shared.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FPLedit.Shared.UI
{
    public static class ExtBind
    {
        public static IIndirectBinding<string> ColorBinding(ColorCollection cc)
            => Binding.Property<string, string>(c => cc.ToName(ColorFormatter.FromHexString(c)));

        public static void AddIntConvBinding<TValue, T1>(this BindableBinding<T1, string> binding, Expression<Func<TValue, int>> property)
            where T1 : IBindable
        {
            var shadowBinding = Binding.Property(property);

            binding.BindDataContext<TValue>(s => shadowBinding.GetValue(s).ToString(), (s, str) =>
            {
                if (int.TryParse(str, out int i))
                    shadowBinding.SetValue(s, i);
            });
        }

        public static void AddFloatConvBinding<TValue, T1>(this BindableBinding<T1, string> binding, Expression<Func<TValue, float>> property)
            where T1 : IBindable
        {
            var shadowBinding = Binding.Property(property);

            binding.BindDataContext<TValue>(s => shadowBinding.GetValue(s).ToString(), (s, str) =>
            {
                if (float.TryParse(str, out float i))
                    shadowBinding.SetValue(s, i);
            });
        }

        public static void AddTimeSpanConvBinding<TValue, T1>(this BindableBinding<T1, string> binding, Expression<Func<TValue, TimeSpan>> property)
            where T1 : IBindable
        {
            string convFromTs(TimeSpan ts) => ts.ToShortTimeString();
            TimeSpan convToTs(string s)
            {
                TimeSpan.TryParse(s.Replace("24:", "1.00:"), out var ts);
                return ts;
            };

            binding.Convert(convToTs, convFromTs).BindDataContext(property);
        }
    }
}