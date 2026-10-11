namespace ParticleSystemExercise;

using Microsoft.Xna.Framework;

public interface IParticleEmitter
{
    public Vector2 Position { get; }

    public Vector2 Velocity { get; }
}