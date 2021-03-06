﻿using FPLedit.Shared;
using FPLedit.Shared.Rendering;

namespace FPLedit.TimetableChecks
{
    internal sealed class UpdateColorsAction : ITimetableInitAction
    {
        public string Init(Timetable tt, IReducedPluginInterface pluginInterface)
        {
            // Farbangaben zwischen jTG- und FPLedit-Versionen vereinheitlichen
            ColorTimetableConverter.ConvertAll(tt);
            return null;
        }
    }
}
