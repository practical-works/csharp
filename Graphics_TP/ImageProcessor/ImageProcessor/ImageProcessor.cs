using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageProcessor
{
    public static class ImageProcessor
    {
        public enum ImageComparisonType
        {
            Area, Content
        }

        /// <summary>
        /// Compare deux objets et retourne une valeur indiquant si l'un d'entre eux
        /// est inférieur, égal ou supérieur à l'autre.
        /// </summary>
        /// <param name="x">Premier objet à comparer.</param>
        /// <param name="y">Second objet à comparer.</param>
        /// <returns>
        ///     Entier signé qui indique les valeurs relatives de x et y, comme indiqué dans
        ///     le tableau suivant.
        ///     Valeur             |  Signification 
        ///     ------------------------------------------
        ///     Inférieur à zéro   | x est inférieur à y.
        ///     Zéro               | x est égal à y.
        ///     Supérieur à zéro   | x est supérieur à y.
        /// </returns>
        public static int CompareImagesByArea(Image image1, Image image2)
        {
            return (image1.Width * image1.Height) - (image2.Width * image2.Height);
        }
        /// <summary>
        /// Checks if an image is cropped from another and returns the matching ratio (inferior or equal to 1).
        /// </summary>
        /// <param name="potentialPieceOfImage"></param>
        /// <param name="originalImage"></param>
        /// <returns></returns>
        public static  int ImageIsPieceOfAnotherImage(Image potentialPieceOfImage, Image originalImage)
        {
            string[] potentialArray = ImageToStringArray(potentialPieceOfImage);
            string[] originalArray = ImageToStringArray(originalImage);
            int matches = 0;
            foreach (string potentialLine in potentialArray)
            {
                foreach (string originalLine in originalArray)
                {
                    if (originalLine.Contains(potentialLine))
                    {
                        matches++;
                    }
                }
            }
            return matches / potentialArray.Length;
        }

        public static string[] ImageToStringArray(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            string[] stringArray = new string[bitmap.Height];
            for (int y = 0; y < bitmap.Height; y++)
            {
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < bitmap.Width; x++)
                {
                    line.Append(bitmap.GetPixel(x, y));
                }
                stringArray[y] = line.ToString();
            }
            return stringArray;
        }

        public static Image ImageToGray(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    int grayValue = (pixel.R + pixel.G + pixel.B) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }
            return bitmap;
        }

        public static Image ImageToNegative(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            return bitmap;
        }
    }
}
