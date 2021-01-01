using System.Text;

namespace Assets.Scripts.Extensions
{
    public static class StringExtensions
    {
        public static string Repeat(this string str, int count)
        {
            var strBuilder = new StringBuilder();
            
            for (var i = 0; i < count; i++)
            {
                strBuilder.Append(str);
            }

            return strBuilder.ToString();
        }
    }
}