using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firewatch.Data.Repositories;
using Firewatch.Models;

namespace Firewatch.Services
{
    public class InstanceService : IInstanceService
    {
        private readonly IInstanceRepository _instanceRepository;

        public InstanceService(IInstanceRepository instanceRepository)
        {
            _instanceRepository = instanceRepository ?? throw new ArgumentNullException(nameof(instanceRepository));
        }

        public async Task<IEnumerable<Instance>> GetInstances()
        {
            return await _instanceRepository.GetInstances();
        }
    }
}
