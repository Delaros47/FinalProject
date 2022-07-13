using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product has successfully added.";
        public static string ProductNameInvalid = "Invalid Product name.";
        public static string MaintanceTime ="Maintance time";
        public static string ProductDeleted= "Product has successfully deleted.";
        public static string ProductUpdated = "Product has successfully updated.";
        public static string ProductCountOfCategoryLimitExeceeded = "A Category shouldn't contain more than 10 Products";
        public static string TheSameProductNameExists = "The same Product name exists in our database please try to add another one";
        public static string CategoryLimitExeceeded = "A new Product cannot be due to Category number execeeds 15";
    }
}
