namespace ServerEmployeeWatch
{
	internal class Client
	{
		public string Username;
		public string ComputerName;
		public string Mac;
		public string IP;
		public string LastSeen;
		public byte[] ScreenshotBytes;

		public void Update(Client other)
		{
			Username = other.Username;
			ComputerName = other.ComputerName;
			LastSeen = other.LastSeen;
		}
	}
}
