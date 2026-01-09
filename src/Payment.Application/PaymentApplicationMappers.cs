using Payment.Dtos;
using Payment.Entities;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace Payment;

[Mapper]
public partial class PaymentApplicationMappers
{
    /* You can configure your Mapperly mapping configuration here.
     * Alternatively, you can split your mapping configurations
     * into multiple mapper classes for a better organization. */
    public partial Overviews Map(CreateOverviewDto source);
    public partial OverviewResponse Map(Overviews overviews);

}
