using System;

namespace PNI.EShop.Core
{
    public class EShopException : Exception
    {
        public EShopException(string message) : base(message)
        {
        }
    }
}
