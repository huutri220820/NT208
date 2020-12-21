//Vo Huu Tri - 18521531 UIT
using System.IO;

namespace DataLayer.Enums
{
    public static class Lorem
    {
        public static string AvatarDefault = @"https://www.pavilionweb.com/wp-content/uploads/2017/03/man-300x300.png";
        public static string BookImage = @"https://www.vinabook.com/images/thumbnails/product/240x/361208_p92078mnxbtremattroilucnuadembia1.jpg";
        public static string BookDescription = File.ReadAllText(@".\Data\BookDescripton.txt");
    }
}