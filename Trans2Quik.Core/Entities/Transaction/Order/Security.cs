namespace Trans2Quik.Core
{
    public class Security
    {
        public string ClassCode { get; private set; }
        public string SecCode { get; private set; }

        public Security(string classCode, string secCode)
        {
            this.ClassCode = classCode;
            this.SecCode = secCode;
        }
    }
}
