using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossTheRoadGame;

public class Lane
{
    public Rectangle Rectangle;
    public Texture2D Texture;

    public int Type;    // 0 = safe spot, 1 = road
    public List<Vehicle> OnLaneVehicles;
    public Color Color;
    
    private Random _random = new Random();
    
    public Lane(int y)
    {
        Rectangle = new Rectangle(0, y, 800, 50);
        Type = _random.Next(2);
        OnLaneVehicles = new List<Vehicle>();

        switch(Type)
        {
            case 0:
                Color = Color.Green;
                //Texture = someTexture;
                break;
            case 1:
                Color = Color.Gray;
                //Texture = someOtherTexture;
                break;
            default:
                Color = Color.White;
                break;
        }
    }

    public void SpawnVehicle()
    {
        
        OnLaneVehicles.Add(new Vehicle(this.Rectangle.Y-10, _random.Next(0, 1)));
    }
}