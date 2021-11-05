using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Leetcode.Get_Top_Rated_Food_Outlets
{
	public static class GetTopRatedFoodOutlets
	{
		public static void Go()
		{
			foreach (var outlet in Get("Denver"))
			{
				Console.WriteLine(outlet);
			}

			Console.ReadKey();
		}

		private static List<string> Get(string city)
		{
			double maxRating = 0;
			var result = new List<string>();

			using var client = new HttpClient();
			client.BaseAddress = new Uri("https://jsonmock.hackerrank.com/api/");
			var page = 1;

			var (totalPages, data) = GetTotalPagesAndOutletsOnPage(client, city, page);

			if (totalPages == 0 || data is null || !data.Any()) return result;

			var currentMaxRating = data.Where(x => x is { UserRating: { } }).Max(x => x.UserRating.AverageRating);

			if (currentMaxRating > maxRating)
			{
				maxRating = currentMaxRating;
				result = new List<string>();
			}

			result.AddRange(data.Where(x => x.UserRating.AverageRating == maxRating).Select(x => x.Name));

			while (page < totalPages)
			{
				page++;
				(_, data) = GetTotalPagesAndOutletsOnPage(client, city, page);

				if (data is null) return result;

				currentMaxRating = data.Where(x => x is { UserRating: { } }).Max(x => x.UserRating.AverageRating);

				if (currentMaxRating > maxRating)
				{
					maxRating = currentMaxRating;
					result = new List<string>();
				}

				if (currentMaxRating == maxRating)
				{
					result.AddRange(data.Where(x => x.UserRating.AverageRating == maxRating)
						.Select(x => x.Name));
				}

			}

			return result;
		}

		private static (int, List<Outlet>) GetTotalPagesAndOutletsOnPage(HttpClient client, string city, int page)
		{
			var response = client.GetAsync($"food_outlets?city={city}&page={page}").Result;

			if (response.IsSuccessStatusCode)
			{
				var content = response.Content.ReadAsStringAsync().Result;
				var responseObj = JsonSerializer.Deserialize<ApiResponse>(content);
				if (responseObj?.Data != null) return (responseObj.TotalPages, responseObj.Data);
			}

			return (0, null);
		}
	}

	public class ApiResponse
	{
		[JsonPropertyName("total_pages")]
		public int TotalPages { get; set; }

		[JsonPropertyName("data")]
		public List<Outlet> Data { get; set; }
	}

	public class Outlet
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("user_rating")]
		public Rating UserRating { get; set; }
	}

	public class Rating
	{
		[JsonPropertyName("average_rating")]
		public double AverageRating { get; set; }
	}
}