namespace Trans2Quik.Core
{
    public class Security
    {
        public string ClassCode { get; private set; }
        public string SecCode { get; private set; }
		public int SecPoints { get; private set; }

		public Security(string classCode, string secCode, int secPoints)
        {
            this.ClassCode = classCode;
            this.SecCode = secCode;
			this.SecPoints = secPoints;
        }
    }
}
