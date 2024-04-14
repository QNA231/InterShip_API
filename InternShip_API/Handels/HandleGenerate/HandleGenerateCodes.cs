namespace InternShip_API.Handels.HandleGenerate
{
    public class HandleGenerateCodes
    {
        public static string GenerateCode()
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmSS");
            Random random = new Random();
            string result = random.Next(100000, 999999).ToString();
            string code = time + result;
            return code;
        }
    }
}
