namespace MDS
{
    public class LoginResponse
    {
        public bool IsValidationCorrect { get; set; }

        public bool Error { get; set; }

        public string Text { get; set; }

        public string ApiToken { get; set; }
    }
}
