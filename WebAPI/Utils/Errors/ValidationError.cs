﻿namespace WebAPI.Utils.Errors
{
    public class ValidationError
    {
        public ValidationError(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }
    }
}