﻿using System.Collections.ObjectModel;

namespace RGBMAUI
{
    public interface IColorsRepository
    {
        abstract void AddColor(NamedColor color);

        abstract void DeleteColor(NamedColor color);

        abstract Task<IList<NamedColor>> GetColors();
    }
}