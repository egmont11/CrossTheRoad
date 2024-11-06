using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossTheRoadGame;

public class Vehicle
{
    public Rectangle Rectangle;
    public int Type;
    public Texture2D Texture;
    
    public Vehicle(int y, int type)
    {
        int width = 70;
        Type = type;

        switch (Type)
        {
            case 0:
                width = 75;
                //Texture = new Texture2D();
                break;
            case 1:
                //Texture = new Texture2D();
                break;
        }
        Rectangle = new Rectangle(0, y, width, 35);
    }
}