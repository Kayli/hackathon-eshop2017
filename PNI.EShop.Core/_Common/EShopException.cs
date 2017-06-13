using System;
using System.Collections.Generic;
using System.Text;

namespace PNI.EShop.Core._Common
{
    public class EShopException : Exception
    {
        public EShopException(string message) : base(message)
        {
        }
    }
}
