using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.DTOs
{
    public class TokenSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifeSpan { get; set; }
    }
}
