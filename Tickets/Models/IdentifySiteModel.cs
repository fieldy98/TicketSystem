using System.Net;


namespace Tickets.Models
{
    public class IdentifySiteModel
    {
        public string Site { get; set; }

        public string IdentifySite(string ClientIP)
        {

            var bytes = IPAddress.Parse(ClientIP).GetAddressBytes();    // Parse IP
            var _octet = bytes[bytes.Length - 3];                  // Gather Second Octet


            if (_octet == 11)
            {
                Site = "Panama";
            }
            else if (_octet == 12)
            {
                Site = "Stine";
            }
            else if (_octet == 13)
            {
                Site = "Seibert";
            }
            else if (_octet == 14)
            {
                Site = "Van Horn";
            }
            else if (_octet == 15)
            {
                Site = "Castle";
            }
            else if (_octet == 16)
            {
                Site = "Stockdale";
            }
            else if (_octet == 17)
            {
                Site = "Sandrini";
            }
            else if (_octet == 18)
            {
                Site = "Sing Lum";
            }
            else if (_octet == 19)
            {
                Site = "Laurelglen";
            }
            else if (_octet == 20)
            {
                Site = "Hart";
            }
            else if (_octet == 21)
            {
                Site = "Loudon";
            }
            else if (_octet == 22)
            {
                Site = "Buena Vista";
            }
            else if (_octet == 23)
            {
                Site = "McAuliffe";
            }
            else if (_octet == 24)
            {
                Site = "Williams";
            }
            else if (_octet == 25)
            {
                Site = "Reagan";
            }
            else if (_octet == 26)
            {
                Site = "Berkshire";
            }
            else if (_octet == 27)
            {
                Site = "Old River";
            }
            else if (_octet == 28)
            {
                Site = "Doug Miller";
            }
            else if (_octet == 31)
            {
                Site = "Thompson";
            }
            else if (_octet == 32)
            {
                Site = "Actis";
            }
            else if (_octet == 33)
            {
                Site = "Tevis";
            }
            else if (_octet == 34)
            {
                Site = "Warren";
            }
            else if (_octet == 35)
            {
                Site = "Stonecreek";
            }
            else
            {
                Site = "District Office";
            }

            return Site;
        }
    }
}