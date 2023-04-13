using System;
namespace mummy.Models.ViewModels
{
	public class PageInfo
	{
        public int TotalNumMummies { get; set;}

		public int MummiesPerPage { get; set; }

		public int CurrentPage { get; set; }

		//figuring out how many pages we need
		//cast the type from decimal to int and get the highest number of pages needed w/ ceiling
		public int TotalPages => (int) Math.Ceiling((double) TotalNumMummies / MummiesPerPage);
	}
}

