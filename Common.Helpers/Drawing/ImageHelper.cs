namespace Common.Helpers.Drawing
{
    using System.Drawing;
    using System.IO;
    using System.Drawing.Imaging;
    using System;
    using System.Linq;

    public class ImageHelper
    {
        public static string[] ValidExtensions = { ".bmp", ".emf", ".exif", ".gif", ".ico", ".jpg", ".jpeg", ".dmp", ".png", ".tiff", ".wmf" };
        public string FileName { get; private set; }
        public bool ImageExists { get; private set; }
        public Image Image { get; private set; }
        public string DirectoryName { get; private set; }
        public string FileNameWithoutExtension { get; private set; }
        public string Extension { get; private set; }
        public ImageFormat ImageFormat
        {
            get
            {
                ImageFormat returnValue = null;

                switch (this.Extension)
                {
                    case ".bmp":
                        returnValue = ImageFormat.Bmp;
                        break;

                    case ".emf":
                        returnValue = ImageFormat.Emf;
                        break;

                    case ".exif":
                        returnValue = ImageFormat.Exif;
                        break;

                    case ".gif":
                        returnValue = ImageFormat.Gif;
                        break;

                    case ".ico":
                        returnValue = ImageFormat.Icon;
                        break;

                    case ".jpeg":
                    case ".jpg":
                        returnValue = ImageFormat.Jpeg;
                        break;

                    case ".dmp":
                        returnValue = ImageFormat.MemoryBmp;
                        break;

                    case ".png":
                        returnValue = ImageFormat.Png;
                        break;

                    case ".tiff":
                        returnValue = ImageFormat.Tiff;
                        break;

                    case ".wmf":
                        returnValue = ImageFormat.Wmf;
                        break;
                }

                return returnValue;
            }
        }

        public string ToExension(ImageFormat imageFormat)
        {
            var returnValue = string.Empty;

            if (imageFormat == ImageFormat.Bmp)
            {
                returnValue = ".bmp";
            }
            else if (imageFormat == ImageFormat.Emf)
            {
                returnValue = ".emf";
            }
            else if (imageFormat == ImageFormat.Exif)
            {
                returnValue = ".exif";
            }
            else if (imageFormat == ImageFormat.Gif)
            {
                returnValue = ".gif";
            }
            else if (imageFormat == ImageFormat.Icon)
            {
                returnValue = ".ico";
            }
            else if (imageFormat == ImageFormat.Jpeg)
            {
                returnValue = ".jpg";
            }
            else if (imageFormat == ImageFormat.MemoryBmp)
            {
                returnValue = ".dmp";
            }
            else if (imageFormat == ImageFormat.Png)
            {
                returnValue = ".png";
            }
            else if (imageFormat == ImageFormat.Tiff)
            {
                returnValue = ".tiff";
            }
            else if (imageFormat == ImageFormat.Wmf)
            {
                returnValue = ".wmf";
            }

            return returnValue;
        }

        public ImageHelper(string fileName)
        {
            this.FileName = fileName;

            if (File.Exists(this.FileName))
            {
                this.Initialize();
                
                SaveRotateFlip();

                this.ImageExists = true;
            }
            else
            {
                this.ImageExists = false;
            }
        }

        private void Initialize()
        {
            this.Image = Image.FromFile(this.FileName);
            this.DirectoryName = Path.GetDirectoryName(this.FileName);
            this.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.FileName);
            this.Extension = Path.GetExtension(this.FileName).ToLower();
        }
                
        public void ScaleImage(string destination, string fileName, Quadrilateral quadrilateral, ImageFormat imageFormatOverride = null, CroppedDetails croppedDetails = null)
        {
            var newQuadrilateral = quadrilateral.Scale(this.Image.Width, this.Image.Height);

            this.ResizeImage(destination, fileName, newQuadrilateral, imageFormatOverride, croppedDetails);
        }

        public void ResizeImage(string destination, string fileName, Quadrilateral quadrilateral, ImageFormat imageFormatOverride = null, CroppedDetails croppedDetails = null)
        {
            var imageFromFile = this.Image;

            if (croppedDetails != null)
            {
                var croppedTile = new Bitmap(croppedDetails.Width, croppedDetails.Height);

                croppedTile.SetResolution(this.Image.HorizontalResolution, this.Image.VerticalResolution);

                var croppedGraphic = Graphics.FromImage(croppedTile);

                var croppedArea = new Rectangle(croppedDetails.X1, croppedDetails.Y1, croppedDetails.Width, croppedDetails.Height);

                croppedGraphic.DrawImage(this.Image, 0, 0, croppedArea, GraphicsUnit.Pixel);

                imageFromFile = croppedTile;
            }

            var newImage = new Bitmap(quadrilateral.Width, quadrilateral.Height);

            newImage.SetResolution(imageFromFile.HorizontalResolution, imageFromFile.VerticalResolution);

            Graphics.FromImage(newImage)
                    .DrawImage(imageFromFile, 0, 0, quadrilateral.Width, quadrilateral.Height);

            if (imageFormatOverride == null)
            {
                var fileNameNew = string.Concat(destination, "//", fileName, this.Extension);
                newImage.Save(fileNameNew, this.ImageFormat);
            }
            else
            {
                var extension = this.ToExension(imageFormatOverride);
                var fileNameNew = string.Concat(destination, "//", fileName, extension);
                newImage.Save(fileNameNew, imageFormatOverride);
            }
        }

        private void SaveRotateFlip()
        {
            var orientationValue = GetOrientationValue();

            if (orientationValue != -1)
            {
                var rotateFlipType = GetRotateFlipType(orientationValue);

                SaveRotateFlip(rotateFlipType);
            }
        }

        private void SaveRotateFlip(RotateFlipType rotateFlipType)
        {
            this.Image.RotateFlip(rotateFlipType);
            this.Image.Save(this.FileName);
        }

        private int GetOrientationValue()
        {
            var returnValue = -1;

            var property = this.Image.PropertyItems.FirstOrDefault(pi => pi.Id == 0x0112);

            if (property != null)
            {
                returnValue = this.Image.GetPropertyItem(property.Id).Value[0];
            }

            return returnValue;
        }

        private RotateFlipType GetRotateFlipType(int orientationValue)
        {
            var returnValue = RotateFlipType.RotateNoneFlipNone;

            switch (orientationValue)
            {
                case 1:
                    returnValue = RotateFlipType.RotateNoneFlipNone;
                    break;
                case 2:
                    returnValue = RotateFlipType.RotateNoneFlipX;
                    break;
                case 3:
                    returnValue = RotateFlipType.Rotate180FlipNone;
                    break;
                case 4:
                    returnValue = RotateFlipType.Rotate180FlipX;
                    break;
                case 5:
                    returnValue = RotateFlipType.Rotate90FlipX;
                    break;
                case 6:
                    returnValue = RotateFlipType.Rotate90FlipNone;
                    break;
                case 7:
                    returnValue = RotateFlipType.Rotate270FlipX;
                    break;
                case 8:
                    returnValue = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    returnValue = RotateFlipType.RotateNoneFlipNone;
                    break;
            }

            return returnValue;
        }
    }

    public struct Quadrilateral
    {
        public int Width;
        public int Height;

        public Quadrilateral(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Quadrilateral Scale(int imageWidth, int imageHeight)
        {
            var scaleWidth = 0;
            var scaleHeight = 0;

            if (imageWidth == this.Width && imageHeight == this.Height)
            {
                scaleWidth = imageWidth;
                scaleHeight = imageHeight;
            }
            else 
            {
                var largerSide = Math.Max(imageWidth, imageHeight);

                if (largerSide == imageWidth)
                {
                    scaleWidth = this.Width;

                    var widthDifference = this.CalculateDifference(imageWidth, this.Width);

                    var widthRation = (decimal)widthDifference / (decimal)imageWidth;

                    scaleHeight = this.CalculateScale(imageHeight, widthRation);
                }
                else
                {
                    scaleHeight = this.Height;

                    var heightDifference = this.CalculateDifference(imageHeight, this.Height);

                    var heightRation = (decimal)heightDifference / (decimal)imageHeight;

                    scaleWidth = this.CalculateScale(imageWidth, heightRation);
                }
            }


            return new Quadrilateral(scaleWidth, scaleHeight);
        }

        private int CalculateDifference(int imageValue, int thresholdValue)
        {
            var returnValue = 0;

            if (imageValue > thresholdValue)
            {
                // scale image down
                returnValue = imageValue - thresholdValue;
            }
            else if (imageValue < thresholdValue)
            {
                // scale image up
                returnValue = thresholdValue - imageValue;
            }

            return returnValue;
        }

        private int CalculateScale(int imageValue, decimal ratio)
        {
            var returnValue = 0;

            var adjustment = imageValue * ratio;

            if (ratio < 1)
            {
                // scale image down
                returnValue = (int)Math.Round(imageValue - adjustment);
            }
            else
            {
                // scale image up
                returnValue = (int)Math.Round(imageValue + adjustment);
            }

            return returnValue;
        }
    }

    public class CroppedDetails
    {
        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public CroppedDetails(int x1, int y1, int x2, int y2, int width, int height)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.Width = width;
            this.Height = height;
        }
    }
}
