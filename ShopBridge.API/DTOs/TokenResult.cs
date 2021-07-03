using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.DTOs
{
    public class TokenResult
    {
        public bool Success { get; set; }
        public string Errors { get; set; }
        public string Token { get; set; }

    }
}
