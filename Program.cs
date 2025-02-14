using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Greed.Game.Casting;
using Greed.Game.Directing;
using Greed.Game.Services;


namespace Greed
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";

        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT = 20;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the robot
            Actor robot = new Actor();
            robot.SetText("#");
            robot.SetFontSize(FONT_SIZE);
            robot.SetColor(WHITE);
            robot.SetPosition(new Point(MAX_X / 2, MAX_Y / 2));
            cast.AddActor("robot", robot);


            // create the artifacts
            Random random = new Random();
            for (int i = 0; i < DEFAULT; i++)
            {
                string text = ((char)(42)).ToString();

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = 1;
                int g = 255;
                int b = 1;
                Color color = new Color(r, g, b);

                Falling_objects falling_objects = new Falling_objects();
                falling_objects.SetText(text);
                falling_objects.SetFontSize(FONT_SIZE);
                falling_objects.SetColor(color);
                falling_objects.SetPosition(position);
                falling_objects.SetScore(1);
                cast.AddActor("falling_objects", falling_objects);
            }

            for (int i = 0; i < DEFAULT; i++)
            {
                string text = ((char)(111)).ToString();

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = 255;
                int g = 1;
                int b = 1;
                Color color = new Color(r, g, b);

                Falling_objects falling_objects = new Falling_objects();
                falling_objects.SetText(text);
                falling_objects.SetFontSize(FONT_SIZE);
                falling_objects.SetColor(color);
                falling_objects.SetPosition(position);
                falling_objects.SetScore(-1);
                cast.AddActor("falling_objects", falling_objects);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);
        }
    }
}