using System;
using Reflection;

[AttributeUsage(AttributeTargets.Class |
    AttributeTargets.Method,
    AllowMultiple = true)]
public class CustomAttribute : Attribute
{
    public string Name { get; set; }
    public CustomAttribute(string name)
    {
        this.Name = name;
    }
}