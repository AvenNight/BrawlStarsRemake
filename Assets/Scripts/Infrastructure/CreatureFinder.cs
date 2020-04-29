using System;
using UnityEngine;

public class CreatureFinder : ObjectsFinder
{
    public CreatureFinder(GameObject from, string tag) : base(from, tag)
    {
        foreach (var e in objects)
        {
            if (e.TryGetComponent(out Creature creature))
                creature.DeathNotify += () => objects.Remove(e);
            else
                throw new ArgumentException($"GameObject with tag {tag} is not a 'Creature'");
        }
    }
}