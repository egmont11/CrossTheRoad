﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrossTheRoadGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;

    private Player _player;
    private List<Lane> Lanes;
    
    private double _timeElapsed;
    private Random _random;
    
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        Lanes = new List<Lane>();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _texture = new Texture2D(GraphicsDevice, 1, 1);
        _texture.SetData(new Color[] { Color.DarkSlateGray });

        _random = new Random();
        
        _timeElapsed = 0;
        
        Lanes.Add(new Lane(430));
        Lanes[0].Type = 0;
        Lanes[0].Color = Color.Green;
        
        int y = -50;
        for (int i = 50; i > 0; i--)
        {
            y -= 50;
            Lanes.Add(new Lane(480 + y));
        }
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        // TODO: Add your update logic here

        _timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

        if (_timeElapsed > _random.NextDouble())
        {
            for (int i = Lanes.Count - 1; i > 0; i--)
            {
                Lanes[i].SpawnVehicle();
            }
        }
        
        Console.WriteLine(Lanes.Count);

        if (Lanes.Count > 0)
        {
            for (int i = Lanes.Count - 1; i >= 0; i--)
            {
                for (int i2 = Lanes[i].OnLaneVehicles.Count - 1; i > 0; i--)
                {
                    Lanes[i].OnLaneVehicles[i2].Rectangle.X += 1;
                }

            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        for (int i = Lanes.Count-1; i >= 0; i--)
        {
            //Console.WriteLine(i);
            _spriteBatch.Draw(_texture, Lanes[i].Rectangle, Lanes[i].Color);
        }
        
        _spriteBatch.End();
        
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}