using System.Reflection.Metadata;

namespace fb_backend_gyakorlas_01.Dtos
{
   public record JegyHozzaadasDto(int JegySzammal, string JegySzoveggel, string TanarVez, string TanarKer, string Tantargy);
   public record TanarPost(string VezetekNev, string KeresztNev, string Email, string Nem);
}
