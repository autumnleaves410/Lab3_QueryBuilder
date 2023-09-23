using System;
namespace Lab3QueryBuilder
{
	public class BannedGame : IClassModel
	{

		public int Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }
        public string Country { get; set; }
        public string Details { get; set; }


        public BannedGame() //default constructor
		{

		}

		public BannedGame(int id, string title, string series, string country, string details)
		{
			Id = id;
			Title = title;
			Series = series;
			Country = country;
			Details = details;
		}


	}
}

