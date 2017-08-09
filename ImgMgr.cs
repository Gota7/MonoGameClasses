/*
ImageMgr is an easy to use image manager to load xnb images into Monogame.

Getting Started:
1. Declare a new ImageMgr before the first function.
2. Set up the new ImageMgr in LoadContent AFTER spriteBatch is declared with parameters: (spriteBatch, Content)
3. Use imageMgr.loadImages() right after decalring the new ImageMgr.
4. Define a path to the images in a file called ImgList.txt in the Content folder.
5. Draw Images!
6. You can also get the Texture2D or Rectangle of an image.
7. Rectangle properties are automatically set with drawImage();

*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseVengeance
{
    /// <summary>
    /// An all purpose class for drawing images defined by ImgList.txt. It's great.
    /// </summary>
    class ImageMgr
    {
        //Needed values for images.
        SpriteBatch spriteBatch;
        ContentManager contentManager;

        //Images
        Texture2D[] images = new Texture2D[System.IO.File.ReadLines(@"Content\ImgList.txt").Count()];
        Rectangle[] imagesR = new Rectangle[System.IO.File.ReadLines(@"Content\ImgList.txt").Count()];


        /// <summary>
        /// Get needed things to draw images. Use in Setup section of Game.
        /// </summary>
        /// <param name="spriteBatch2"></param> spriteBatch
        /// <param name="contentManager2"></param> Content
        public ImageMgr(SpriteBatch spriteBatch2, ContentManager contentManager2) {

            //Define needed things.
            spriteBatch = spriteBatch2;
            contentManager = contentManager2;

        }



        /// <summary>
        /// Loads images from list. Use after setting up new ImageMgr, still in setup secton of game.
        /// </summary>
        public void loadImages()
        {

            string[] ImgListLines = System.IO.File.ReadAllLines(@"Content\ImgList.txt");

            //Polish the lines array to eliminate IDs.
            for (int i = 1; i < ImgListLines.Length; i++)
            {

                //Debug.WriteLine(i);

                ImgListLines[i] = ImgListLines[i].Split('=').Last();

                //Append images array
                images[i] = contentManager.Load<Texture2D>(ImgListLines[i]);

                //Set Rectangles
                imagesR[i] = new Rectangle(0 - images[i].Width, 0 - images[i].Height, images[i].Width, images[i].Height);

            }


        }




        /// <summary>
        /// Draw an image.
        /// </summary>
        /// <param name="ID">ID of image to draw.</param>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        public void drawImage(int ID, int x, int y)
        {

            //Define new rectangle properties.
            imagesR[ID] = new Rectangle(x, y, images[ID].Width, images[ID].Height);

            //Draw image.
            spriteBatch.Begin();
            spriteBatch.Draw(images[ID], imagesR[ID], Color.White);
            spriteBatch.End();

        }


        /// <summary>
        /// Draw an image.
        /// </summary>
        /// <param name="newTexture">Texture of image to draw.</param>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="w">Width of image.</param>
        /// <param name="h">Height of image.</param>
        public void drawImage(Texture2D newTexture, int x, int y, int w = -1, int h = -1)
        {

            //Use default dimensions.
            if (w == -1) w = newTexture.Width;
            if (h == -1) h = newTexture.Height;

            //Define new rectangle properties.
            Rectangle newTextureR = new Rectangle(x, y, w, h);

            //Draw image.
            spriteBatch.Begin();
            spriteBatch.Draw(newTexture, newTextureR, Color.White);
            spriteBatch.End();

        }


        /// <summary>
        /// Draw an image.
        /// </summary>
        /// <param name="ID">ID of image to draw.</param>
        /// <param name="rect">Rectangle of image to draw.</param>
        public void drawImage(int ID, Rectangle rect)
        {

            //Draw image.
            spriteBatch.Begin();
            spriteBatch.Draw(images[ID], rect, Color.White);
            spriteBatch.End();

        }


        /// <summary>
        /// Draw an image.
        /// </summary>
        /// <param name="newTexture">Texture of image to draw.</param>
        /// <param name="rect">Rectangle of image to draw.</param>
        public void drawImage(Texture2D tex, Rectangle rect)
        {

            //Draw image.
            spriteBatch.Begin();
            spriteBatch.Draw(tex, rect, Color.White);
            spriteBatch.End();

        }


        /// <summary>
        /// Draw an image.
        /// </summary>
        /// <param name="ID">ID of image to draw.</param>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="w">Width.</param>
        /// <param name="h">Height.</param>
        public void drawImage(int ID, int x, int y, int w, int h)
        {

            //Define new rectangle properties
            imagesR[ID] = new Rectangle(x, y, w, h);

            //Draw image.
            spriteBatch.Begin();
            spriteBatch.Draw(images[ID], imagesR[ID], Color.White);
            spriteBatch.End();

        }



        /// <summary>
        /// Get the Rectangle for an image ID.
        /// </summary>
        /// <param name="ID"></param> ID of image.
        public Rectangle getRect(int ID) {
            return imagesR[ID];
        }



        /// <summary>
        /// Get the Texture2D for an image ID.
        /// </summary>
        /// <param name="ID"></param> ID of image.
        public Texture2D getTexture2D(int ID)
        {
            return images[ID];
        }

    }
}
