using System;
using System.Collections.Generic;
using System.Net;

namespace HW5.Deserializers
{
	public static class IPAddressValidator
	{
        public static bool AreIpAddressesValid(IList<string> ipAddresses)
        {
            foreach (string ipAddress in ipAddresses)
            {
                if (!IPAddress.TryParse(ipAddress, out _))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

