using System;
namespace mummy.Models.ViewModels
{
	public class MummyViewModel
	{
        public IQueryable<Mummy> Mummy { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}