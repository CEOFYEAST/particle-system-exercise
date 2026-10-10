using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParticleSystemExercise;

public class ParticleSystemExampleGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private MouseState priorMouse;
    private ExplosionParticleSystem _explosions;

    public ParticleSystemExampleGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        RainParticleSystem rain = new(this, new Rectangle(100, -20, 500, 10));
        Components.Add(rain);

        _explosions = new ExplosionParticleSystem(this, 20);
        Components.Add(_explosions);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        MouseState currentMouse = Mouse.GetState();
        Vector2 mousePosition = new Vector2(currentMouse.X, currentMouse.Y);

        if (currentMouse.LeftButton == ButtonState.Pressed && currentMouse.LeftButton == ButtonState.Released)
        {
            _explosions.PlaceExplosion(mousePosition);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
