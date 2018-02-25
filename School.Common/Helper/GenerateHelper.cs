namespace School.Common.Helper
{
    public class GenerateHelper
    {
        public static string GeneratePassword(int lenght)
        {
            const string chars = "123456789ABCDEFGHJKLMNPRSTUVYZ";
            var code = "";
            var random = new System.Random();

            for (var i = 0; i < lenght; i++)
            {
                var row = random.Next(0, chars.Length - 1);
                code += chars[row];
            }
            return code;
        }
        public static string GenerateNumber(int lenght)
        {
            const string chars = "123456789";
            var code = "";
            var random = new System.Random();

            for (var i = 0; i < lenght; i++)
            {
                var row = random.Next(0, chars.Length - 1);
                code += chars[row];
            }
            return code;
        }
    }
}
