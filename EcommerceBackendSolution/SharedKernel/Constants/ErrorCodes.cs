using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Constants
{
    public static class ErrorCodes
    {
        public const string USER_NOT_FOUND = "ERR_001";
        public const string PRODUCT_NOT_FOUND = "ERR_002";
        public const string PRODUCT_OUT_OF_STOCK = "ERR_003";
        public const string PAYMENT_FAILED = "ERR_004";
        public const string UNAUTHORIZED_ACCESS = "ERR_005";
        public const string INVALID_REQUEST = "ERR_006";
    }
}
