using System;
using UnityEngine;

public class CreatureFinder : ObjectsFinder
{
    public CreatureFinder(GameObject from, params string[] tags) : base(from, tags)
    {
        foreach (var e in objects)
        {
            if (e.TryGetComponent(out Creature creature))
                creature.DeathNotify += () => objects.Remove(e);
            else
                throw new ArgumentException($"GameObject with tag {tags} is not a 'Creature'");
        }
    }
}