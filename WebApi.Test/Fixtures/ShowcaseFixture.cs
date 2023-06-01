using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models.Entities;

namespace WebApi.Test.Fixtures
{
    public class ShowcaseFixture
    {
        public static List<ShowcaseEntity> Entities = new List<ShowcaseEntity>()
        {
            new ShowcaseEntity { Id = 1, Title="Title 1", Offer="Great offer 1", ImgUrl="Pic1"},
            new ShowcaseEntity { Id = 2, Title="Title 2", Offer="Great offer 2", ImgUrl="Pic2"},
            new ShowcaseEntity { Id = 3, Title="Title 3", Offer="Great offer 3", ImgUrl="Pic3"}
        };
    }
}
