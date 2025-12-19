using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aras.SampleCrowdFunding.UtilityService.RpcResponseStates
{
    public interface IRequestRpc
    {
        bool IsCancellationRequested { get; set; }

        bool IsValid(out List<string> errorList);
    }
}
