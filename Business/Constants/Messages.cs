using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product has successfully added";
        public static string ProductInvalidName = "Product Name cannot be less than two characters";

        public static string MaintenanceTime = "Maintenance Time is now!";
        public static string ProductOfCategoryNumber ="Category has more than 10 products";
        public static string TheSameProductNameExists="The same product name already exists";
        public static string CategoryLimitExceded = "The category number cannot be greater than 15";
    }
}
