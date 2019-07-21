﻿using System;

namespace CalculatedField
{
    class ScriptError
    {
        public readonly int Column;
        public readonly int Line;
        public readonly string Description;

        public ScriptError(int column, int line, string description) 
        {
            Column = column;
            Line = line;
            Description = description;
        }

        public string Message => String.Format("({0}, {1}): {2}", Line, Column, Description);

    }
}