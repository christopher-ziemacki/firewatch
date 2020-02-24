using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Firewatch.App.Models;
using Firewatch.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Firewatch.App.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private ISystemUserService SystemUserService { get; set; }

        [Inject] private IMapper Mapper { get; set; }

        [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected IEnumerable<Instance> Instances { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationStateTask;
            var userName = authenticationState.User.Identity.Name;

            var instances = await InstanceService.GetInstances();

            var tasks = new List<Task>();
            var results = new List<Instance>();
            foreach (var instance in instances)
            {
                var result = Mapper.Map<Instance>(instance);
                results.Add(result);

                var task = SystemUserService.DoesUserHaveAccess(instance.UrlName, userName).ContinueWith(t =>
                {
                    result.DoesCurrentUserHaveAccess = t.Result;
                });

                tasks.Add(task);

                task = SystemUserService.DoesTeamAdministratorHaveAccess(instance.UrlName)
                    .ContinueWith(t => { result.DoesTeamAdministratorHaveAccess = t.Result; });

                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            Instances = results;
        }
    }
}