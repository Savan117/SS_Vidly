
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[Display (Name="Date Added")]
		public DateTime DateAdded { get; set; }
		[Required]
		[Range(1,20)]
		[Display (Name="Number In stock")]
		public int NumInStock { get; set; }
		[Required]
		[Display (Name="Released Date")]
		public DateTime ReleaseDate { get; set; }
		public Genre Genre { get; set; }
		[Display(Name = "Genre")]
		[Required]
		public int GenreId { get; set; }

	}
}