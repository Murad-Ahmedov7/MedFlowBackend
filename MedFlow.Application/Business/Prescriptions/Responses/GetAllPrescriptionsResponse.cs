using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Prescriptions.Responses
{
    public class GetAllPrescriptionsResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public List<GetPrescriptionItemsResponse> PrescriptionItems { get; set; } = new();

    }
}
