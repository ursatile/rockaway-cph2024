namespace Rockaway.WebApp.Data {
	public class Customer(string firstName, string lastName) {
		public string FirstName { get; } = firstName;
		public string LastName { get; } = lastName;

		public string FullName => firstName + " " + lastName;

		public bool SendMail() {
			var to = firstName + lastName + @"example.com";
		}
	}
}
