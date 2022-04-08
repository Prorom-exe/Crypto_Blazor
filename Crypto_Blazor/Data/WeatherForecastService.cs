namespace Crypto_Blazor.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
        #region Lab1
        public Task<string> Lab1_Crypto(string message, int size)
        {
            string result = "";
            var letters = message.Replace(" ", "").ToCharArray();
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < letters.Length; j = j + size)
                {
                    try
                    {
                        result += letters[j];
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return Task.FromResult(result);
        }
        public Task<string> Lab1_DeCrypto(string message, int size)
        {
            string result = "";
            var letters = message.Replace(" ", "").ToCharArray();
            int height = 1;
            while ((height * size) < letters.Length)
            {
                height++;
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = i; j < letters.Length; j = j + height)
                {
                    try
                    {
                        result += letters[j];
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return Task.FromResult(result);
        }
        #endregion
        #region Lab2
        public async Task<string> Lab2_Crypto(string message, string code)
        {
            try
            {
                var codeLenght = code.Length;
                int charPosition = 1;
                string encryptMessage = "";
                foreach (var mChar in message.ToArray())
                {
                    if (charPosition > codeLenght)
                    {
                        charPosition = 1;
                    }
                    int x = GetNumberInChar(mChar);
                    var sd = code[charPosition-1];
                    var y = GetNumberInChar(sd);
                    var listAlb = GetSkippedAlfavit(y);
                    encryptMessage += listAlb[x];
                    charPosition++;
                }
                return encryptMessage;
            }
            catch
            {

            }
            return "";
        }

        private char GetCharInNumber(int number)
        {
            char[] endtext2 = new char[]
        { 'à', 'á', 'â', 'ã', 'ä', 'å', '¸', 'æ', 'ç', 'è', 'é', 'ê', 'ë',
      'ì', 'í', 'î', 'ï', 'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø',
      'ù', 'ú', 'û', 'ü', 'ý', 'þ', 'ÿ' };
            return endtext2.ToList()[number - 1];
        }
        private int GetNumberInChar(char value)
        {
            char[] endtext2 = new char[]
        { 'à', 'á', 'â', 'ã', 'ä', 'å', '¸', 'æ', 'ç', 'è', 'é', 'ê', 'ë',
      'ì', 'í', 'î', 'ï', 'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø',
      'ù', 'ú', 'û', 'ü', 'ý', 'þ', 'ÿ' };
            return endtext2.ToList().IndexOf(value);
        }
        private List<char> GetSkippedAlfavit(int value)
        {
            char[] endtext2 = new char[]
        { 'à', 'á', 'â', 'ã', 'ä', 'å', '¸', 'æ', 'ç', 'è', 'é', 'ê', 'ë',
      'ì', 'í', 'î', 'ï', 'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø',
      'ù', 'ú', 'û', 'ü', 'ý', 'þ', 'ÿ' };
            var list = new List<char>();
            list.AddRange(endtext2.Skip(value).Take(33 - value).ToList());
            list.AddRange(endtext2.Take(value).ToList());
            return list;
        }

        public async Task<string> Lab2_DeCrypto(string message, string code)
        {
            try
            {
                var codeLenght = code.Length;
                int charPosition = 1;
                string encryptMessage = "";
                foreach (var mChar in message.ToArray())
                {
                    if (charPosition > codeLenght)
                    {
                        charPosition = 1;
                    }
                    var listAlb = GetSkippedAlfavit(GetNumberInChar(code[charPosition-1]));
                    var ch = listAlb.ToList().IndexOf(mChar);
                    encryptMessage += GetCharInNumber(ch+1);
                    charPosition++;
                }
                return encryptMessage;
            }
            catch
            {

            }
            return "";
        }
        #endregion
        #region lab3
        public async Task<int[]> Lab3_Crypto(int[] message, int[] code)
        {
            int[] result =  new int[message.Length];
            for(int i = 0; i<message.Length; i++)
            {
                result[i]= message[i] ^ code[i];
            }
                      return result;
        }
        #endregion
    }
}