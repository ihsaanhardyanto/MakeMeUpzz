using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class MakeupFactory
    {
        public static Makeup CreateMakeup(int id, string name, int price, int weight, int typeID, int brandID)
        {
            return new Makeup
            {
                MakeupID = id,
                MakeupName = name,
                MakeupPrice = price,
                MakeupWeight = weight,
                MakeupTypeID = typeID,
                MakeupBrandID = brandID
            };
        }
    }
}